﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneDirectoryProject.Math {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Math.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Plus100", ReplyAction="http://tempuri.org/IService1/Plus100Response")]
        int Plus100(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Plus100", ReplyAction="http://tempuri.org/IService1/Plus100Response")]
        System.Threading.Tasks.Task<int> Plus100Async(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Minus100", ReplyAction="http://tempuri.org/IService1/Minus100Response")]
        int Minus100(int num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Minus100", ReplyAction="http://tempuri.org/IService1/Minus100Response")]
        System.Threading.Tasks.Task<int> Minus100Async(int num);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : PhoneDirectoryProject.Math.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<PhoneDirectoryProject.Math.IService1>, PhoneDirectoryProject.Math.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Plus100(int num) {
            return base.Channel.Plus100(num);
        }
        
        public System.Threading.Tasks.Task<int> Plus100Async(int num) {
            return base.Channel.Plus100Async(num);
        }
        
        public int Minus100(int num) {
            return base.Channel.Minus100(num);
        }
        
        public System.Threading.Tasks.Task<int> Minus100Async(int num) {
            return base.Channel.Minus100Async(num);
        }
    }
}
