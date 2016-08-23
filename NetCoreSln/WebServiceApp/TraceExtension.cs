using System;
using System.Configuration;
using System.Web.Services.Protocols;
using System.IO;
using System.Text;

namespace WsSoapExtension
{
    public class TraceExtension : SoapExtension
    {
        static readonly string LogRoot = ConfigurationManager.AppSettings["logRoot"];
        Stream oldStream;
        Stream newStream;
        string filename;

        /// <summary>
        /// ������������Ӧ���浽�ڴ����У��ѱ�����
        /// </summary>
        /// <param name="stream">���� SOAP �������Ӧ���ڴ滺����</param>
        /// <returns>����ʾ�� SOAP ��չ�����޸ĵ����ڴ滺������</returns>
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        /// <summary>
        /// ��Xml Web Service��һ�����е�ʱ��һ���ԵĽ�ͨ��TraceExtensionAttribute���ݽ�����
        /// ������־��Ϣ���ļ�����ʼ��
        /// </summary>
        /// <param name="methodInfo">Ӧ�� SOAP ��չ�� XML Web services �������ض�����ԭ��</param>
        /// <param name="attribute">Ӧ���� XML Web services ������ SoapExtensionAttribute</param>
        /// <returns>SOAP ��չ��������г�ʼ�������ڻ���</returns>
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return ((TraceExtensionAttribute)attribute).Filename;
        }

        /// <summary>
        /// ���Ϊÿ���������õı���SoapMessage�ļ��������ǽ������������
        /// ��SoapMessage�����浽һ����־�ļ���,����ļ�·����Ҫ��Web Service
        /// �������ļ���web.configָ��,��
        /// <appSettings>
        ///  <add key="logRoot" value="c:\\serviceLog"/>
        /// </appSettings>
        /// </summary>
        /// <param name="WebServiceType">������������</param>
        /// <returns>���ڱ�����־��¼���ļ�·��</returns>
        public override object GetInitializer(Type WebServiceType)
        {
            //return LogRoot.TrimEnd('\\') + "\\" + WebServiceType.FullName + ".log";
            return LogRoot.TrimEnd('\\') + "\\" + WebServiceType.FullName + ".log";
        }

        //����ļ����������䱣������
        public override void Initialize(object initializer)
        {
            filename = (string)initializer;
        }

        /// <summary>
        /// �����ݻ�ΪSoap��ʽ��ʱ�򣬽�����д����־
        /// �����л�֮ǰ input
        /// ���л�֮��  output
        /// </summary>
        /// <param name="message"></param>
        public override void ProcessMessage(SoapMessage message)
        {
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;
                case SoapMessageStage.AfterSerialize:
                    WriteOutput(message);
                    break;
                case SoapMessageStage.BeforeDeserialize:
                    WriteInput(message);
                    break;
                case SoapMessageStage.AfterDeserialize:
                    break;
                default:
                    throw new Exception("invalid stage");
            }
        }
        /// <summary>
        /// ��SoapMessageд�뵽��־�ļ�
        /// </summary>
        /// <param name="message"></param>
        public void WriteOutput(SoapMessage message)
        {
            newStream.Position = 0;
            //������׷�Ӽ�¼�ļ�
            FileStream fs = new FileStream(filename, FileMode.Append,
                FileAccess.Write);
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
            string soapString = (message is SoapServerMessage) ? "Soap Response" : "Soap Request";
            w.WriteLine("-----" + soapString + Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("��")) + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"));
           
            w.Flush();
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
            Copy(newStream, oldStream);
        }

        public void WriteInput(SoapMessage message)
        {
            Copy(oldStream, newStream);
            FileStream fs = new FileStream(filename, FileMode.Append,
                FileAccess.Write);
            StreamWriter w = new StreamWriter(fs,Encoding.UTF8);

            string soapString = (message is SoapServerMessage) ?
                 "Soap Request" : "Soap Response";
            w.WriteLine("-----" + soapString +
                Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("��")) + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"));
            w.Flush();
            newStream.Position = 0;
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
        }
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from); 
            TextWriter writer = new StreamWriter(to);
            var tmp = reader.ReadToEnd();
            writer.WriteLine(tmp);
            writer.Flush();
        }
    }

    //����һ��������WebMethod��ʹ�õ�SoapExtension����
    [AttributeUsage(AttributeTargets.Method)]
    public class TraceExtensionAttribute : SoapExtensionAttribute
    {

        private string filename = "c:\\log.txt";
        private int priority;

        /// <summary>
        /// ��չ����
        /// </summary>
        public override Type ExtensionType
        {
            get { return typeof(TraceExtension); }
        }
        /// <summary>
        /// ���ȼ� 
        /// </summary>
        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        /// <summary>
        /// ���ڼ�¼��WebMethod��SoapMessage���ļ��ľ���·��
        /// Ĭ��Ϊc:\\log.txt;
        /// </summary>
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }
    }
}
