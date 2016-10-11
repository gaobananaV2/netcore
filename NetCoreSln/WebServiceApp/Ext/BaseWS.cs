using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServiceApp.Ext
{
    /// <summary>
    /// WebService基类，所有继承者必须实现Request方法
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[ToolboxItem(false)]
    public abstract class WSBase : WebService
    {
        ///// <summary>
        ///// IP白名单
        ///// </summary>
        internal static string IPList = "";

        /// <summary>
        /// WebService基类构造函数
        /// </summary>
        static WSBase()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["IPList"].ToString()))
                IPList = ConfigurationManager.AppSettings["IPList"];
        }

        /// <summary>
        /// 接收用户请求并返回相应结果
        /// </summary>
        /// <param name="request">请求对象</param>
        [WebMethod(EnableSession = false)]
        public Response Request(Request request)
        {
            var response = new Response();

            //try
            //{

            //    if (!Auth(request.Head))
            //    {

            //    }

            //    //判断反序列化是否成功
            //    if (request == null)
            //    {

            //    }

            //    //todo:安全校验iplist


            //    return RequestDeal(request, response);
            //}
            //catch (SoapException soaExp)
            //{
            //    //Log.Error(soaExp.Message, soaExp);

            //    response.Head.SetHeaderInfo(request.Head);
            //    // response.Head.SetResult(ResultCode.Fail, soaExp.ResultNo, soaExp.Message);
            //    return response;
            //}
            //catch (Exception exp)
            //{
            //    //Log.Error(exp.Message, exp);
            //    response.Head.SetHeaderInfo(request.Head);
            //    //response.Head.SetResult(ResultCode.Fail, 500, exp.Message);
                return response;
            //}
        }

        /// <summary>
        /// 请求处理方法
        /// </summary>
        protected abstract Response RequestDeal(Request request, Response response);



        /// <summary>
        ///  通过代理，获取客户端真实的IP地址
        /// </summary>
        /// <returns>返回客户端真实的IP地址</returns>
        private static string GetClientIPAddress()
        {
            return "";
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <returns></returns>
        private bool Auth(RequestHead head)
        {
            return true;
        }

    }
}