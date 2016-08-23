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
        /// 将请求流和响应流存到内存流中，已被调用
        /// </summary>
        /// <param name="stream">包含 SOAP 请求或响应的内存缓冲区</param>
        /// <returns>它表示此 SOAP 扩展可以修改的新内存缓冲区。</returns>
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        /// <summary>
        /// 在Xml Web Service第一次运行的时候，一次性的将通过TraceExtensionAttribute传递进来的
        /// 保存日志信息的文件名初始化
        /// </summary>
        /// <param name="methodInfo">应用 SOAP 扩展的 XML Web services 方法的特定函数原型</param>
        /// <param name="attribute">应用于 XML Web services 方法的 SoapExtensionAttribute</param>
        /// <returns>SOAP 扩展将对其进行初始化以用于缓存</returns>
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return ((TraceExtensionAttribute)attribute).Filename;
        }

        /// <summary>
        /// 替代为每个方法配置的保存SoapMessage文件名，而是将整个网络服务
        /// 的SoapMessage都保存到一个日志文件中,这个文件路径需要在Web Service
        /// 的配置文件中web.config指出,如
        /// <appSettings>
        ///  <add key="logRoot" value="c:\\serviceLog"/>
        /// </appSettings>
        /// </summary>
        /// <param name="WebServiceType">网络服务的类型</param>
        /// <returns>用于保存日志记录的文件路径</returns>
        public override object GetInitializer(Type WebServiceType)
        {
            //return LogRoot.TrimEnd('\\') + "\\" + WebServiceType.FullName + ".log";
            return LogRoot.TrimEnd('\\') + "\\" + WebServiceType.FullName + ".log";
        }

        //获得文件名，并将其保存下来
        public override void Initialize(object initializer)
        {
            filename = (string)initializer;
        }

        /// <summary>
        /// 当数据还为Soap格式的时候，将数据写入日志
        /// 反序列化之前 input
        /// 序列化之后  output
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
        /// 将SoapMessage写入到日志文件
        /// </summary>
        /// <param name="message"></param>
        public void WriteOutput(SoapMessage message)
        {
            newStream.Position = 0;
            //创建或追加记录文件
            FileStream fs = new FileStream(filename, FileMode.Append,
                FileAccess.Write);
            StreamWriter w = new StreamWriter(fs, Encoding.UTF8);
            string soapString = (message is SoapServerMessage) ? "Soap Response" : "Soap Request";
            w.WriteLine("-----" + soapString + Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("在")) + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"));
           
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
                Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("在")) + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss"));
            w.Flush();
            newStream.Position = 0;
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
        }
        /// <summary>
        /// 拷贝流到流
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

    //创建一个用于在WebMethod上使用的SoapExtension属性
    [AttributeUsage(AttributeTargets.Method)]
    public class TraceExtensionAttribute : SoapExtensionAttribute
    {

        private string filename = "c:\\log.txt";
        private int priority;

        /// <summary>
        /// 扩展类型
        /// </summary>
        public override Type ExtensionType
        {
            get { return typeof(TraceExtension); }
        }
        /// <summary>
        /// 优先级 
        /// </summary>
        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        /// <summary>
        /// 用于记录该WebMethod的SoapMessage的文件的绝对路径
        /// 默认为c:\\log.txt;
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
