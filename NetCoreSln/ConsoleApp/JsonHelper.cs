using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace DSB.Plugin
{
    public class JsonHelper
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

        public static T Deserialize<T>(string jsonString)
        {
            string p = @"""\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}[^""]*""";
            MatchEvaluator evaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, evaluator);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return (T)ser.ReadObject(ms);
        }

        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value.Trim('"'));
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = "\"" + string.Format("\\/Date({0}+0800)\\/", (long)ts.TotalMilliseconds) + "\"";
            return result;
        }
    }
}
