﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFClient.Calc.SR {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Calc.SR.ICalcService")]
    public interface ICalcService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcService/DoWork", ReplyAction="http://tempuri.org/ICalcService/DoWorkResponse")]
        bool DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalcService/DoWork", ReplyAction="http://tempuri.org/ICalcService/DoWorkResponse")]
        System.Threading.Tasks.Task<bool> DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICalcServiceChannel : WCFClient.Calc.SR.ICalcService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalcServiceClient : System.ServiceModel.ClientBase<WCFClient.Calc.SR.ICalcService>, WCFClient.Calc.SR.ICalcService {
        
        public CalcServiceClient() {
        }
        
        public CalcServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalcServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalcServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool DoWork() {
            return base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task<bool> DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
    }
}
