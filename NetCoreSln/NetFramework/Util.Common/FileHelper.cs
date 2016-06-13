﻿using System;
using System.IO;
using System.Text;

namespace Util.Common
{
    public static class FileHelper
    {
        public static string ReadFile(string filePath)
        {
            string fileContent = string.Empty;
            FileStream fs;

            //打开文件  
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
            }
            catch (Exception)
            {
                throw;
            }

            //尚未读取的文件内容长度  
            long left = fs.Length;
            //存储读取结果  
            byte[] bytes = new byte[100];
            //每次读取长度  
            int maxLength = bytes.Length;
            //读取位置  
            int start = 0;
            //实际返回结果长度  
            int num = 0;
            //当文件未读取长度大于0时，不断进行读取  
            while (left > 0)
            {
                fs.Position = start;
                num = 0;
                if (left < maxLength)
                    num = fs.Read(bytes, 0, Convert.ToInt32(left));
                else
                    num = fs.Read(bytes, 0, maxLength);
                if (num == 0)
                    break;
                start += num;
                left -= num;
                fileContent += Encoding.UTF8.GetString(bytes);
            }
            fs.Close();

            return fileContent;
        }
    }
}
