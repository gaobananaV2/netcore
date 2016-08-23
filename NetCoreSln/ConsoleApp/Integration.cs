using DSB.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class IntegrationBase 
    {
        //private string webSrviceUrl= "https://sts.dsbsts.net:446/Integration/";
        private string webSrviceUrl = "http://sts.dsbsts.net:8002/Integration/";

        /// <summary>
        /// Get Response by webclient with post method
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private string getResponse(string relativeUrl, string postData)
        {
            var result = string.Empty;
            var url = this.webSrviceUrl + relativeUrl;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Timeout = 60000;//1 minute

            byte[] btBodys = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = btBodys.Length;
            request.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse;
            try
            {
                httpWebResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                httpWebResponse = (HttpWebResponse)ex.Response;
            }
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            result = streamReader.ReadToEnd();
            switch (httpWebResponse.StatusCode)
            {
                case HttpStatusCode.InternalServerError:
                 
                    break;
            }
            streamReader.Close();
            request.Abort();
            httpWebResponse.Close();
            return result;
        }


        private string getResponse(string relativeUrl)
        {
            string response = string.Empty;
            string url = this.webSrviceUrl + relativeUrl;
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 60000;//1 minute
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            response = sr.ReadToEnd();
            sr.Close();
            request.Abort();
            res.Close();
            return response;
        }

        public virtual string GetResult(string relativeUrl)
        {
            string result = this.getResponse(relativeUrl);
            return result;
        }
        public virtual T GetResult<T>(string relativeUrl)
        {
            try
            {
                string resultString = this.GetResult(relativeUrl);
                T result = JsonHelper.Deserialize<T>(resultString);
                return result;
            }
            catch (Exception ex)
            {
                string logContent = "ErrorMessage:" + ex.Message + ",Stack :" + ex.StackTrace;
              
                throw;
            }
        }

        public virtual string GetResult(string relativeUrl, string postData)
        {
            string result = this.getResponse(relativeUrl, postData);
            return result;
        }
        public virtual T GetResult<T>(string relativeUrl, string postData)
        {
            string resultString = this.GetResult(relativeUrl, postData);
            T result = JsonHelper.Deserialize<T>(resultString);
            return result;
        }

        public virtual string GetResult(string relativeUrl, Dictionary<string, string> parms)
        {
            StringBuilder sbParms = new StringBuilder();
            foreach (var item in parms)
            {
                if (sbParms.Length > 0)
                {
                    sbParms.Append("&");
                }
                sbParms.AppendFormat("{0}={1}", item.Key, item.Value);
            }
            relativeUrl = relativeUrl + "?" + sbParms.ToString();
            string result = this.getResponse(relativeUrl);
            return result;
        }
        public virtual T GetResult<T>(string relativeUrl, Dictionary<string, string> parms)
        {
            string resultString = this.GetResult(relativeUrl, parms);
            T result = JsonHelper.Deserialize<T>(resultString);
            return result;
        }

        public virtual string GetResult<T>(string relativeUrl, T param)
        {
            string postData = JsonHelper.Serializer<T>(param);
            string result = this.getResponse(relativeUrl, postData);

            return result;
        }
        public virtual X GetResult<T, X>(string relativeUrl, T param)
        {
            try
            {
                string postData = JsonHelper.Serializer<T>(param);
                //AddIntegrationLog("Integraion Request:" + postData + Environment.NewLine + "Url:" + relativeUrl);
                string resultString = this.GetResult<T>(relativeUrl, param);
               // AddIntegrationLog("Integraion Response:" + resultString);
                X result = JsonHelper.Deserialize<X>(resultString);
                return result;
            }
           
            catch (Exception ex)
            {
                string logContent = "ErrorMessage:" + ex.Message + ",Stack :" + ex.StackTrace;
                 
                throw;
            }
        }

        
    }
}
