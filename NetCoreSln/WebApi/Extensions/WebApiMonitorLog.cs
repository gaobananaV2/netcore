using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;

namespace WebApi.Extensions
{
    public class WebApiMonitorLog
    {
        public string ControllerName
        {
            get;
            set;
        }
        public string ActionName
        {
            get;
            set;
        }

        public DateTime ExecuteStartTime
        {
            get;
            set;
        }
        public DateTime ExecuteEndTime
        {
            get;
            set;
        }

        public Dictionary<string, object> ActionParams
        {
            get;
            set;
        }

        public string HttpRequestHeaders
        {
            get;
            set;
        }


        public string HttpMethod
        {
            get;
            set;
        }


        public string GetLoginfo()
        {
            const string msg = @"
            Action Executing：
            ControllerName：{0}Controller
            ActionName:{1}
             StartDate：{2}
            EndDate：{3}
            Duration：{4}s
            ActionParams：{5}
            HttpRequestHeaders:{6} 
            HttpMethod:{7}
                    ";
            var loginInfo = string.Format(msg,
                ControllerName,
                ActionName,
                ExecuteStartTime,
                ExecuteEndTime,
                (ExecuteEndTime - ExecuteStartTime).TotalSeconds,
                GetCollections(ActionParams),
                HttpRequestHeaders, 
                HttpMethod);
            return loginInfo;
        }


        public string GetCollections(Dictionary<string, object> collections)
        {
            var parameters = string.Empty;
            if (collections == null || collections.Count == 0)
            {
                return parameters;
            }
            foreach (string key in collections.Keys)
            {
                parameters += string.Format("{0}={1}&", key, collections[key]);
            }
            if (!string.IsNullOrWhiteSpace(parameters) && parameters.EndsWith("&"))
            {
                parameters = parameters.Substring(0, parameters.Length - 1);
            }
            return parameters;
        }

        public string GetCollectionsJson(Dictionary<string, object> collections)
        {
            var parameters = "{";
            if (collections == null || collections.Count == 0)
            {
                return parameters;
            }
            foreach (string key in collections.Keys)
            {
                parameters += string.Format("\"{0}\":\"{1}\",", key, collections[key]);
            }
            if (!string.IsNullOrWhiteSpace(parameters) && parameters.EndsWith(","))
            {
                parameters = parameters.Substring(0, parameters.Length - 1);
            }
            return parameters + "}";
        }

        public string GetCollectionsJsonPost(Dictionary<string, object> collections)
        {
            var parameters = string.Empty;
            if (collections == null || collections.Count == 0)
            {
                return parameters;
            }
            foreach (string key in collections.Keys)
            {
                parameters+=new JavaScriptSerializer().Serialize(collections[key]);
            }
            return parameters;
        }
    }
}