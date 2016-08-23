﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp.WS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WS.TestWebServiceSoap")]
    public interface TestWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        // CODEGEN: Generating message contract since message HelloWorldWithUserNameAndPassWordRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorldWithUserNameAndPassWord", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse HelloWorldWithUserNameAndPassWord(ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorldWithUserNameAndPassWord", ReplyAction="*")]
        System.Threading.Tasks.Task<ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse> HelloWorldWithUserNameAndPassWordAsync(ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MySoapHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string userNameField;
        
        private string passWordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string UserName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
                this.RaisePropertyChanged("UserName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string PassWord {
            get {
                return this.passWordField;
            }
            set {
                this.passWordField = value;
                this.RaisePropertyChanged("PassWord");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HelloWorldWithUserNameAndPassWord", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class HelloWorldWithUserNameAndPassWordRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public ConsoleApp.WS.MySoapHeader MySoapHeader;
        
        public HelloWorldWithUserNameAndPassWordRequest() {
        }
        
        public HelloWorldWithUserNameAndPassWordRequest(ConsoleApp.WS.MySoapHeader MySoapHeader) {
            this.MySoapHeader = MySoapHeader;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="HelloWorldWithUserNameAndPassWordResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class HelloWorldWithUserNameAndPassWordResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string HelloWorldWithUserNameAndPassWordResult;
        
        public HelloWorldWithUserNameAndPassWordResponse() {
        }
        
        public HelloWorldWithUserNameAndPassWordResponse(string HelloWorldWithUserNameAndPassWordResult) {
            this.HelloWorldWithUserNameAndPassWordResult = HelloWorldWithUserNameAndPassWordResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TestWebServiceSoapChannel : ConsoleApp.WS.TestWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestWebServiceSoapClient : System.ServiceModel.ClientBase<ConsoleApp.WS.TestWebServiceSoap>, ConsoleApp.WS.TestWebServiceSoap {
        
        public TestWebServiceSoapClient() {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse ConsoleApp.WS.TestWebServiceSoap.HelloWorldWithUserNameAndPassWord(ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest request) {
            return base.Channel.HelloWorldWithUserNameAndPassWord(request);
        }
        
        public string HelloWorldWithUserNameAndPassWord(ConsoleApp.WS.MySoapHeader MySoapHeader) {
            ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest inValue = new ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest();
            inValue.MySoapHeader = MySoapHeader;
            ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse retVal = ((ConsoleApp.WS.TestWebServiceSoap)(this)).HelloWorldWithUserNameAndPassWord(inValue);
            return retVal.HelloWorldWithUserNameAndPassWordResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse> ConsoleApp.WS.TestWebServiceSoap.HelloWorldWithUserNameAndPassWordAsync(ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest request) {
            return base.Channel.HelloWorldWithUserNameAndPassWordAsync(request);
        }
        
        public System.Threading.Tasks.Task<ConsoleApp.WS.HelloWorldWithUserNameAndPassWordResponse> HelloWorldWithUserNameAndPassWordAsync(ConsoleApp.WS.MySoapHeader MySoapHeader) {
            ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest inValue = new ConsoleApp.WS.HelloWorldWithUserNameAndPassWordRequest();
            inValue.MySoapHeader = MySoapHeader;
            return ((ConsoleApp.WS.TestWebServiceSoap)(this)).HelloWorldWithUserNameAndPassWordAsync(inValue);
        }
    }
}