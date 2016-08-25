//using System;
//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Linq;
//using System.Web;
//using System.Xml.Serialization;

//namespace WebServiceApp.Ext
//{
//    /// <summary>
//    /// 响应结果
//    /// </summary>
//    [GeneratedCode("System.Xml", "4.0.30319.18408")]
//    [Serializable]
//    [DebuggerStepThrough]
//    [DesignerCategory("code")]
//    [XmlTypeAttribute(Namespace = "http://tempuri.org/")]
public class Response
{
//        private readonly ResponseHead headField = new ResponseHead();
//       // private readonly XObject xbodyField = new XObject();

//        /// <summary>
//        /// 响应的 头信息
//        /// </summary>
//        public ResponseHead Head
//        {
//            get { return headField; }
//            set { headField.CopyFrom(value); }
//        }

//        ///// <summary>
//        ///// 响应的 具体值
//        ///// </summary>
//        //[XmlIgnore, SoapIgnore, JsonIgnore]
//        //public object Body
//        //{
//        //    get { return xbodyField.Value; }
//        //    set { xbodyField.Value = value; }
//        //}

//        ///// <summary>
//        //////// </summary>
//        //public XObject XBody
//        //{
//        //    get { return xbodyField; }
//        //    set { xbodyField.CopyFrom(value); }
//        //}


//        public Response() { }
//        public Response(RequestHead requestHead)
//        {
//            this.Head.UserID = requestHead.User.UserID;
//            this.Head.RequestID = requestHead.RequestID;
//        }
//    }

//    /// <summary>
//    /// 响应 头信息
//    /// </summary>
//    [GeneratedCode("System.Xml", "4.0.30319.18408")]
//    [Serializable]
//    //    [DebuggerStepThrough]
//    [DesignerCategory("code")]
//    [XmlTypeAttribute(Namespace = "http://tempuri.org/")]
//    public class ResponseHead
//    {
//        public ResponseHead()
//        {
//           // ResultCode = ResultCode.UnKown;
//        }

//        /// <summary>
//        /// 请求版本
//        /// </summary>
//        [XmlAttribute]
//        public string Version { get; set; }
//        /// <summary>
//        /// 用户ID
//        /// </summary>
//        [XmlAttribute]
//        public string UserID { get; set; }
//        /// <summary>
//        /// 请求GUID
//        /// </summary>
//        [XmlAttribute]
//        public string RequestID { get; set; }


//        /// <summary>
//        /// 结果标志
//        /// </summary>
//        [XmlAttribute]
//       // public ResultCode ResultCode { get; set; }
//        /// <summary>
//        /// 结果标志
//        /// </summary>
//        [XmlAttribute]
//        public string ResultNo { get; set; }
//        /// <summary>
//        /// 失败信息
//        /// </summary>
//        [XmlAttribute]
//        public string ResultMsg { get; set; }
//        /// <summary>
//        /// 时间戳
//        /// </summary>
//        [XmlAttribute]
//        public string Timestamp { get; set; }


//        /// <summary>
//        /// 利用请求给结果的头部信息赋值
//        /// </summary>
//        /// <param name="header">请求头对象</param>
//        public void SetHeaderInfo(RequestHead header)
//        {
//            this.RequestID = header.RequestID;
//            this.UserID = header.User.UserID;
//        }
//        /// <summary>
//        /// 设置结果信息
//        /// </summary>
//        /// <param name="resultcode">结果类型</param>
//        /// <param name="resultno">失败代号</param>
//        /// <param name="resultmsg">失败信息</param>
//        public void SetResult(ResultCode resultcode, long resultno, string resultmsg)
//        {
//            this.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff");
//            this.ResultCode = resultcode;
//            this.ResultNo = resultno.ToString();
//            if (!string.IsNullOrEmpty(resultmsg)) this.ResultMsg = resultmsg;
//        }

//        /// <summary>
//        /// 设置结果信息
//        /// </summary>
//        /// <param name="resultcode">结果类型</param>
//        /// <param name="resultno">失败代号</param>
//        /// <param name="resultmsg">失败信息</param>
//        public void SetFailResult(ResultCode resultcode, string resultno, string resultmsg)
//        {
//            this.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffff");
//            this.ResultCode = resultcode;
//            this.ResultNo = resultno;
//            if (!string.IsNullOrEmpty(resultmsg)) this.ResultMsg = resultmsg;
//        }


//        /// <summary>
//        /// 从 另外的对象 复制属性值
//        /// </summary>
//        public void CopyFrom(ResponseHead head)
//        {
//            Version = head == null ? string.Empty : head.Version;
//            UserID = head == null ? string.Empty : head.UserID;
//            RequestID = head == null ? string.Empty : head.RequestID;
//            ResultCode = head == null ? ResultCode.Fail : head.ResultCode;
//            ResultNo = head == null ? string.Empty : head.ResultNo;
//            ResultMsg = head == null ? string.Empty : head.ResultMsg;
//            Timestamp = head == null ? string.Empty : head.Timestamp;
//        }
//    }
 }