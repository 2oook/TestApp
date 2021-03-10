﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestApp.ChequeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Cheque", Namespace="http://schemas.datacontract.org/2004/07/TestWcf")]
    [System.SerializableAttribute()]
    public partial class Cheque : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ArticlesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal DiscountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SummField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Articles {
            get {
                return this.ArticlesField;
            }
            set {
                if ((object.ReferenceEquals(this.ArticlesField, value) != true)) {
                    this.ArticlesField = value;
                    this.RaisePropertyChanged("Articles");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Discount {
            get {
                return this.DiscountField;
            }
            set {
                if ((this.DiscountField.Equals(value) != true)) {
                    this.DiscountField = value;
                    this.RaisePropertyChanged("Discount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Summ {
            get {
                return this.SummField;
            }
            set {
                if ((this.SummField.Equals(value) != true)) {
                    this.SummField = value;
                    this.RaisePropertyChanged("Summ");
                }
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChequeService.IChequeService")]
    public interface IChequeService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChequeService/GetLastChecks", ReplyAction="http://tempuri.org/IChequeService/GetLastChecksResponse")]
        TestApp.ChequeService.Cheque[] GetLastChecks(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChequeService/GetLastChecks", ReplyAction="http://tempuri.org/IChequeService/GetLastChecksResponse")]
        System.Threading.Tasks.Task<TestApp.ChequeService.Cheque[]> GetLastChecksAsync(int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChequeService/ReceiveCheck", ReplyAction="http://tempuri.org/IChequeService/ReceiveCheckResponse")]
        void ReceiveCheck(TestApp.ChequeService.Cheque cheque);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChequeService/ReceiveCheck", ReplyAction="http://tempuri.org/IChequeService/ReceiveCheckResponse")]
        System.Threading.Tasks.Task ReceiveCheckAsync(TestApp.ChequeService.Cheque cheque);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChequeServiceChannel : TestApp.ChequeService.IChequeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChequeServiceClient : System.ServiceModel.ClientBase<TestApp.ChequeService.IChequeService>, TestApp.ChequeService.IChequeService {
        
        public ChequeServiceClient() {
        }
        
        public ChequeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChequeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChequeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChequeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestApp.ChequeService.Cheque[] GetLastChecks(int count) {
            return base.Channel.GetLastChecks(count);
        }
        
        public System.Threading.Tasks.Task<TestApp.ChequeService.Cheque[]> GetLastChecksAsync(int count) {
            return base.Channel.GetLastChecksAsync(count);
        }
        
        public void ReceiveCheck(TestApp.ChequeService.Cheque cheque) {
            base.Channel.ReceiveCheck(cheque);
        }
        
        public System.Threading.Tasks.Task ReceiveCheckAsync(TestApp.ChequeService.Cheque cheque) {
            return base.Channel.ReceiveCheckAsync(cheque);
        }
    }
}