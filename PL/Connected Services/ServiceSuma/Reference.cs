﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL.ServiceSuma {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceSuma.ISuma")]
    public interface ISuma {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuma/SumarNumeros", ReplyAction="http://tempuri.org/ISuma/SumarNumerosResponse")]
        int SumarNumeros(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISuma/SumarNumeros", ReplyAction="http://tempuri.org/ISuma/SumarNumerosResponse")]
        System.Threading.Tasks.Task<int> SumarNumerosAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISumaChannel : PL.ServiceSuma.ISuma, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SumaClient : System.ServiceModel.ClientBase<PL.ServiceSuma.ISuma>, PL.ServiceSuma.ISuma {
        
        public SumaClient() {
        }
        
        public SumaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SumaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SumaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SumaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int SumarNumeros(int a, int b) {
            return base.Channel.SumarNumeros(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SumarNumerosAsync(int a, int b) {
            return base.Channel.SumarNumerosAsync(a, b);
        }
    }
}
