using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceClient
{
    public class WSClient
    {

        public static string CrsServiceURL = "CrsServiceURL";
        public static string TktServiceURL = "TktServiceURL";


        //public static Response GetOData(string url, string method, object requestBody, UserInfo user)
        //{
        //    WSProxy proxy = new WSProxy();
        //    proxy.Url = WSProxy.GetWebServiceUrl(url);

        //    Request request = new Request();
        //    request.Head.Method = method;
        //    request.Head.User = user;
        //    request.Body = requestBody;

        //    return proxy.Request(request);
        //}
        //public static object GetCrsData(string method, object requestBody, UserInfo user)
        //{
        //    var response = GetOData(OtherServiceURL, method, requestBody, user);
        //    if (response.Head.ResultCode == ResultCode.Success)
        //    {
        //        return response.Body;


        //    }
        //public static object GetTsData(string method, object requestBody, UserInfo user)
        //{

        //    var response = GetOData(TktServiceURL, method, requestBody, user);
        //    return response.Body;
        //}
    }
}
