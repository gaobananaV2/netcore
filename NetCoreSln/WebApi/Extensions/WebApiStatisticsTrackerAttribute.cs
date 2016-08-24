using System;
using System.IO;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters; 
using System.Net.Http;

namespace WebApi.Extensions
{
    public class WebApiStatisticsTrackerAttribute : ActionFilterAttribute
    {
        private readonly string Key = "_thisWebApiOnActionMonitorLog_";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var monLog = new WebApiMonitorLog
            {
                ExecuteStartTime = DateTime.Now,
                ActionParams = actionContext.ActionArguments,
                HttpRequestHeaders = actionContext.Request.Headers.ToString(),
                HttpMethod = actionContext.Request.Method.Method
            };

            actionContext.Request.Properties[Key] = monLog;
            if (monLog.HttpMethod == "POST")
            {
                LogHelper.Info("WebServiceRequestParams" + monLog.GetCollectionsJsonPost(monLog.ActionParams));
            }
            else
            {
                LogHelper.Info("WebServiceRequestParams" + monLog.GetCollectionsJson(monLog.ActionParams));
            }
            #region
            var stream = actionContext.Request.Content.ReadAsStreamAsync().Result;
            var encoding = Encoding.UTF8;
            stream.Position = 0;
            var responseData = "";
            using (var reader = new StreamReader(stream, encoding))
            {
                responseData = reader.ReadToEnd();
            }
            if (!string.IsNullOrWhiteSpace(responseData) && !monLog.ActionParams.ContainsKey("__EntityParamsList__"))
            {
                monLog.ActionParams["__EntityParamsList__"] = responseData;
            }
            #endregion
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var monLog = actionExecutedContext.Request.Properties[Key] as WebApiMonitorLog;
            string emptyResponseMsg = string.Empty;
            if (monLog != null)
            {
                monLog.ExecuteEndTime = DateTime.Now;
                monLog.ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                monLog.ControllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                //LogHelper.Info(monLog.GetLoginfo());
                if (actionExecutedContext.Exception != null)
                {
                    var msg = string.Format(@"
                                 【{0}Controller】's【{1}】 has exceptions：
                                Action ：{2}
                               HttpRequestHeaders:{3} 
                                HttpMethod:{4}
                               ", monLog.ControllerName, monLog.ActionName, monLog.GetCollections(monLog.ActionParams), monLog.HttpRequestHeaders, monLog.HttpMethod);
                    LogHelper.Error("InternalError" + msg, actionExecutedContext.Exception);
                }
                else
                {
                    emptyResponseMsg = string.Format(@"
                                 【{0}Controller】's【{1}】 has empty response：
                                Action ：{2}
                               HttpRequestHeaders:{3} 
                                HttpMethod:{4}
                               ", monLog.ControllerName, monLog.ActionName, monLog.GetCollections(monLog.ActionParams), monLog.HttpRequestHeaders, monLog.HttpMethod);

                }
            }

            HttpContent httpContent = null;

            if (actionExecutedContext.Response != null)
            {
                httpContent = actionExecutedContext.Response.Content;
            }

            if (httpContent != null)
            {
                var value = httpContent.ReadAsStringAsync().Result;
                LogHelper.Info("WebServiceResponse" + value);

                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length < 3)
                    {
                        LogHelper.Error("WebServiceResponse" + value + emptyResponseMsg);
                    }
                }
            }

        }


    }
}