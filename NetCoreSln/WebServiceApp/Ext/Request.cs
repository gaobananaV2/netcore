using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebServiceApp.Ext
{
    /// <summary>
    /// 请求参数
    /// </summary>
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://tempuri.org/")]
    public class Request
    {
        //private readonly RequestHead headField = new RequestHead();
        //private readonly XObject xbodyField = new XObject();

        ///// <summary>
        ///// 请求的 头信息
        ///// </summary>
        //public RequestHead Head
        //{
        //    get { return headField; }
        //    set { headField.CopyFrom(value); }
        //}

        ///// <summary>
        ///// 请求的 具体值
        ///// </summary>
        //[XmlIgnore, SoapIgnore, JsonIgnore]
        //public object Body
        //{
        //    get { return xbodyField.Value; }
        //    set { xbodyField.Value = value; }
        //}

        ///// <summary>
        //////// </summary>
        //public XObject XBody
        //{
        //    get { return xbodyField; }
        //    set { xbodyField.CopyFrom(value); }
        //}
    }

    /// <summary>
    /// 请求 头信息
    /// </summary>
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class RequestHead
    {
        public RequestHead()
        {
            RequestID = Guid.NewGuid().ToString().ToUpper();
        }


        /// <summary>
        /// 用户ID
        /// </summary>
        //[XmlAttribute]
        //public UserInfo User { get; set; }

        /// <summary>
        /// 请求GUID
        /// </summary>
        //[XmlAttribute]
        public string RequestID { get; set; }



        /// <summary>
        /// 请求的函数
        /// </summary>
        //[XmlAttribute]
        public string Method { get; set; }
        /// <summary>
        /// 异步请求
        /// </summary>
        //[XmlAttribute]
        public bool IsAsync { get; set; }




        /// <summary>
        /// 从 另外的对象 复制属性值
        /// </summary>
        public void CopyFrom(RequestHead head)
        {
            //UserID = head == null ? string.Empty : head.UserID;
            RequestID = head == null ? string.Empty : head.RequestID;
            //ClientIP = head == null ? string.Empty : head.ClientIP;
            Method = head == null ? string.Empty : head.Method;
            IsAsync = head == null ? false : head.IsAsync;
           // User = head == null ? null : head.User;
        }

    }
}