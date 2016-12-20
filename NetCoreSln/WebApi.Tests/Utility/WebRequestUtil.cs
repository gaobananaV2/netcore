using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace WebApi.Tests.Api
{
   
    public class WebClientHelper
    {
        static class JsonHelper
        {
            /// <summary>
            /// JSON Serialization
            /// </summary>
            public static string Serializer<T>(T t)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms, t);
                string jsonString = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return jsonString;
            }

            /// <summary>
            /// JSON Deserialization
            /// </summary>
            public static T Deserialize<T>(string jsonString)
            {
                return new JavaScriptSerializer().Deserialize<T>(jsonString);
            }
        }


        string BaseAddress = "http://localhost:58986/api/";
        private string GetResponse(string relativeUrl)
        {
            string response = string.Empty;
            string url = BaseAddress + relativeUrl;
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 20000;
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            response = sr.ReadToEnd();
            res.Close();
            sr.Close();
            request.Abort();
            res.Close();
            return response;
        }


        private string GetResponse(string relativeUrl, string postData)
        {
            var result = string.Empty;
            var url = BaseAddress + relativeUrl;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Timeout = 20000;

            byte[] btBodys = Encoding.UTF8.GetBytes(postData);
            httpWebRequest.ContentLength = btBodys.Length;
            httpWebRequest.GetRequestStream().Write(btBodys, 0, btBodys.Length);

            HttpWebResponse httpWebResponse;
            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                httpWebResponse = (HttpWebResponse)ex.Response;
            }
            var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            result = streamReader.ReadToEnd();
            switch (httpWebResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    
                    break;
                case HttpStatusCode.InternalServerError:
                    //LOG;
                    break;
            }
            httpWebResponse.Close();
            streamReader.Close();
            httpWebRequest.Abort();
            httpWebResponse.Close();
            return result;
        } 

        public virtual string GetResult<T>(string relativeUrl, T param)
        {
            string postData = JsonHelper.Serializer<T>(param);
            string result = this.GetResponse(relativeUrl, postData);
            return result;
        }

        public virtual string GetResult(string relativeUrl)
        {
            string result = this.GetResponse(relativeUrl);
            return result;
        }

        public virtual TX GetResult<TX>(string relativeUrl)
        {
            string resultString = this.GetResponse(relativeUrl);
            TX result = JsonHelper.Deserialize<TX>(resultString);
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
            string result = this.GetResponse(relativeUrl);
            return result;
        }

        public virtual TX GetResult<T, TX>(string relativeUrl, T param)
        {
            string resultString = this.GetResult<T>(relativeUrl, param);
            TX result = JsonHelper.Deserialize<TX>(resultString);
            return result;
        }

    }
}