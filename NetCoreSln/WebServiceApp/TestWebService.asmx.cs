using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WsSoapExtension;

namespace WebServiceApp
{
    /// <summary>
    /// TestWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TestWebService : System.Web.Services.WebService
    {
        public MySoapHeader header = new MySoapHeader();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [SoapHeader("header")]
        public string HelloWorldWithUserNameAndPassWord()
        {
            if (header == null)
            {
                return "您没有设置SoapHeader,不能正常访问此服务!";
            }

            if (header.UserName != "peak" || header.PassWord != "111111")
            {
                return "您提供的身份验证信息有误，不能正常访问此服务!";
            }
            return "Hello World HelloWorldWithUserNameAndPassWord";
        }

        [WebMethod]
        public string HelloWorldWithLog()
        {
            return "Hello World HelloWorldWithLog";
        }

        [WebMethod]
        [TraceExtension(Filename = "d:\\data.xml", Priority = 0)]
        public string HelloWorldWithLog2()
        {
            return "Hello World HelloWorldWithLog2";
        }
    }
}
