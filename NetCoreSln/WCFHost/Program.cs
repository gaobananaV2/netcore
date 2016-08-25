using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
    class Program
    {
        private static List<ServiceHost> serviceHosts = new List<ServiceHost>();
        static StringBuilder msg = new StringBuilder();
        static void Main(string[] args)
        {
            Console.WriteLine("start ");

            InitNetTcpBinding();
            LoadAssemBly("WcfServiceLibrary");

            Console.WriteLine(msg);
            Console.Read();
        }


        private static NetTcpBinding netTcpBinding = new NetTcpBinding();
        public static NetTcpBinding InitNetTcpBinding()
        {
            netTcpBinding.Security.Mode = SecurityMode.None;
            netTcpBinding.ReceiveTimeout = TimeSpan.Parse("00:10:00");
            netTcpBinding.MaxBufferPoolSize = 2147483647; //
            netTcpBinding.MaxBufferSize = 2147483647;
            //netTcpBinding.MaxConnections = 10;
            //netTcpBinding.PortSharingEnabled = true;
            netTcpBinding.ReaderQuotas.MaxDepth = 2147483647;
            netTcpBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
            netTcpBinding.ReaderQuotas.MaxArrayLength = 2147483647;
            netTcpBinding.ReaderQuotas.MaxBytesPerRead = 2147483647;
            netTcpBinding.ReaderQuotas.MaxNameTableCharCount = 2147483647;
            netTcpBinding.MaxReceivedMessageSize = 2147483647;
            return netTcpBinding;
        }

        /// <summary>
        /// 通过反射的形式拿到wcf的契约和服务
        /// </summary>
        /// <param name="assemblyName"></param>
        public static void LoadAssemBly(string assemblyName)
        {
            Assembly assem = Assembly.Load(assemblyName);
            Dictionary<Type, Type> svTypes = new Dictionary<Type, Type>();
            List<TypeInfo> list = assem.DefinedTypes.ToList();
            foreach (TypeInfo typeInfo in list)
            {
                if (typeInfo.Attributes.ToString().IndexOf("Abstract") >= 0)
                {
                    TypeInfo tempK = typeInfo;
                    var result = (from t in list where t.Name == (tempK.Name.Substring(1)) select t).ToList();
                    TypeInfo tempV = result[0];
                    svTypes.Add(tempK, tempV);
                }

            }
            string serviceAddress = string.Format("net.tcp://{0}:{1}", "localhost", "13141");
            string endpointAddress = string.Empty;
            string tName = string.Empty;
            foreach (var item in svTypes)
            {
                tName = item.Key.Name.Substring(1);
                endpointAddress = serviceAddress + "/" + tName;

                ServiceHost serviceHost = new ServiceHost(item.Value, new Uri(endpointAddress));

                //加载元数据节点
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                serviceHost.Description.Behaviors.Add(smb);
                serviceHost.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");

                serviceHost.AddServiceEndpoint(item.Key, netTcpBinding, endpointAddress);

                serviceHost.Opened += delegate
                {
                    msg.AppendLine(string.Format("{0}开始监听 Uri 为 ：{1}/mex", tName, endpointAddress.ToString()));
                };
                serviceHost.Open();
                serviceHosts.Add(serviceHost);

            }
        }
    }
}
