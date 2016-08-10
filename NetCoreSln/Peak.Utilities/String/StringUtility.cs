using System;

namespace Peak.Utilities
{
    public static class StringUtility
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return string.IsNullOrEmpty(input);
        }

        public static bool ToBool(this string input)
        {
            bool result = false;
            bool.TryParse(input, out result);
            return result;
        }

        public static int ToInt(this string input)
        {
            int result = 0;
            if (input.IsNullOrEmpty())
            {
                return result;
            }
            else
            {
                int.TryParse(string.Format("{0:N0}", input).Replace(",", ""), out result);
                return result;
            }
        }

        public static int ToInt(this object input)
        {
            int result = 0;
            if (input == null)
            {
                return result;
            }
            else
            {
                int.TryParse(string.Format("{0:N0}", input).Replace(",", ""), out result);
                return result;
            }
        }

        public static double ToDouble(this object input)
        {
            double result = 0.00;
            if (input == null)
            {
                return result;
            }
            else
            {
                double.TryParse(input.ToString(), out result);
                return result;
            }
        }

        public static decimal ToDecimal(this object input)
        {
            decimal result = 0;
            if (input == null)
            {
                return result;
            }
            else
            {
                decimal.TryParse(input.ToString(), out result);
                return result;
            }
        }

        public static DateTime? ToDateTime(this object input)
        {

            if (input == null)
            {
                return null;
            }
            else
            {
                DateTime result;
                if (DateTime.TryParse(input.ToString(), out result))
                {
                    return result;
                }
                return null;
            }
        }

        public static string EncodeSpecialChar(string s)
        {
            return s.Replace("+", "@CMSJIA@")
                .Replace("&", "@CMSAND@")
                .Replace("=", "@CMSDENG@")
                .Replace("#", "@CMSJING@");
        }
        public static string DecodeSpecialChar(string s)
        {
            return s.Replace("@CMSJIA@", "+")
                .Replace("@CMSAND@", "&")
                .Replace("@CMSDENG@", "=")
                .Replace("@CMSJING@", "#");
        }

        /// <summary>
        /// 格式化字符串长度，超出部分显示省略号,区分汉字跟字母。汉字2个字节，字母数字一个字节
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string stringformat(this string str, int n)
        { 
            string temp = string.Empty;
            if (System.Text.Encoding.Default.GetByteCount(str) <= n)//如果长度比需要的长度n小,返回原字符串
            {
                return str;
            }
            else
            {
                int t = 0;
                char[] q = str.ToCharArray();
                for (int i = 0; i < q.Length && t < n; i++)
                {
                    if ((int)q[i] >= 0x4E00 && (int)q[i] <= 0x9FA5)//是否汉字
                    {
                        temp += q[i];
                        t += 2;
                    }
                    else
                    {
                        temp += q[i];
                        t++;
                    }
                }
                return (temp + "...");
            }
        }
 
    }
}
