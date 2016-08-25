
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApp.Ext
{
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TktService : WSBase
    {
        protected override Response RequestDeal(Request request, Response response)
        {


            //try
            //{
            //    object result = null;
            //    switch (request.Head.Method)
            //    {


            //        case "Np":
            //            new NpService().Np((HashRequest)request.Body, ref response);
            //            break;
            //        //case "GetSpByGuest":
            //        //    new HjdService().GetByGuestCard((HashRequest)request.Body, ref response);
            //        //    break;
            //        case "GetSpBy": //根据查询对象或者售票信息
            //            new BuPiaoService().GetSpBy((BuPiaoQModel)request.XBody, ref response);
            //            break;
            //    }

            //    response.Head.SetHeaderInfo(request.Head);
            //    response.Head.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff");

            //}

            //catch (Exception ex)
            //{
            //    string logMsg = string.Format("ts服务出错: 函数名:{0},错误消息：{1}", request.Head.Method, ex.Message);
            //    response.Head.SetFailResult(ResultCode.Fail, "110", logMsg);
            //    Log.Error(logMsg, ex);
            //}
            return response;
        }



    }
}