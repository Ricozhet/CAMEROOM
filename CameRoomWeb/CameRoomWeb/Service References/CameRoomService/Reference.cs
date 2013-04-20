﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CameRoomWeb.CameRoomService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CameRoomService.IService")]
    public interface IService {
        
        // CODEGEN: Parameter 'GetDataResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CameRoomWeb.CameRoomService.GetDataResponse GetData(CameRoomWeb.CameRoomService.GetDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataResponse> GetDataAsync(CameRoomWeb.CameRoomService.GetDataRequest request);
        
        // CODEGEN: Parameter 'GetDataUsingDataContractResult' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse GetDataUsingDataContract(CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse> GetDataUsingDataContractAsync(CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getProvinceList", ReplyAction="http://tempuri.org/IService/getProvinceListResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        CameRoomWeb.CameRoomService.getProvinceListResponse getProvinceList(CameRoomWeb.CameRoomService.getProvinceListRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getProvinceList", ReplyAction="http://tempuri.org/IService/getProvinceListResponse")]
        System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.getProvinceListResponse> getProvinceListAsync(CameRoomWeb.CameRoomService.getProvinceListRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetData", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int value;
        
        public GetDataRequest() {
        }
        
        public GetDataRequest(int value) {
            this.value = value;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string GetDataResult;
        
        public GetDataResponse() {
        }
        
        public GetDataResponse(string GetDataResult) {
            this.GetDataResult = GetDataResult;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18034")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/")]
    public partial class CompositeType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool boolValueField;
        
        private bool boolValueFieldSpecified;
        
        private string stringValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool BoolValue {
            get {
                return this.boolValueField;
            }
            set {
                this.boolValueField = value;
                this.RaisePropertyChanged("BoolValue");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BoolValueSpecified {
            get {
                return this.boolValueFieldSpecified;
            }
            set {
                this.boolValueFieldSpecified = value;
                this.RaisePropertyChanged("BoolValueSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string StringValue {
            get {
                return this.stringValueField;
            }
            set {
                this.stringValueField = value;
                this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataUsingDataContract", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataUsingDataContractRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public CameRoomWeb.CameRoomService.CompositeType composite;
        
        public GetDataUsingDataContractRequest() {
        }
        
        public GetDataUsingDataContractRequest(CameRoomWeb.CameRoomService.CompositeType composite) {
            this.composite = composite;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataUsingDataContractResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataUsingDataContractResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public CameRoomWeb.CameRoomService.CompositeType GetDataUsingDataContractResult;
        
        public GetDataUsingDataContractResponse() {
        }
        
        public GetDataUsingDataContractResponse(CameRoomWeb.CameRoomService.CompositeType GetDataUsingDataContractResult) {
            this.GetDataUsingDataContractResult = GetDataUsingDataContractResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getProvinceList", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class getProvinceListRequest {
        
        public getProvinceListRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getProvinceListResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class getProvinceListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool getProvinceListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Data.DataSet ds;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string errMsg;
        
        public getProvinceListResponse() {
        }
        
        public getProvinceListResponse(bool getProvinceListResult, System.Data.DataSet ds, string errMsg) {
            this.getProvinceListResult = getProvinceListResult;
            this.ds = ds;
            this.errMsg = errMsg;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : CameRoomWeb.CameRoomService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<CameRoomWeb.CameRoomService.IService>, CameRoomWeb.CameRoomService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CameRoomWeb.CameRoomService.GetDataResponse CameRoomWeb.CameRoomService.IService.GetData(CameRoomWeb.CameRoomService.GetDataRequest request) {
            return base.Channel.GetData(request);
        }
        
        public string GetData(int value) {
            CameRoomWeb.CameRoomService.GetDataRequest inValue = new CameRoomWeb.CameRoomService.GetDataRequest();
            inValue.value = value;
            CameRoomWeb.CameRoomService.GetDataResponse retVal = ((CameRoomWeb.CameRoomService.IService)(this)).GetData(inValue);
            return retVal.GetDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataResponse> CameRoomWeb.CameRoomService.IService.GetDataAsync(CameRoomWeb.CameRoomService.GetDataRequest request) {
            return base.Channel.GetDataAsync(request);
        }
        
        public System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataResponse> GetDataAsync(int value) {
            CameRoomWeb.CameRoomService.GetDataRequest inValue = new CameRoomWeb.CameRoomService.GetDataRequest();
            inValue.value = value;
            return ((CameRoomWeb.CameRoomService.IService)(this)).GetDataAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse CameRoomWeb.CameRoomService.IService.GetDataUsingDataContract(CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest request) {
            return base.Channel.GetDataUsingDataContract(request);
        }
        
        public CameRoomWeb.CameRoomService.CompositeType GetDataUsingDataContract(CameRoomWeb.CameRoomService.CompositeType composite) {
            CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest inValue = new CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest();
            inValue.composite = composite;
            CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse retVal = ((CameRoomWeb.CameRoomService.IService)(this)).GetDataUsingDataContract(inValue);
            return retVal.GetDataUsingDataContractResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse> CameRoomWeb.CameRoomService.IService.GetDataUsingDataContractAsync(CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest request) {
            return base.Channel.GetDataUsingDataContractAsync(request);
        }
        
        public System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.GetDataUsingDataContractResponse> GetDataUsingDataContractAsync(CameRoomWeb.CameRoomService.CompositeType composite) {
            CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest inValue = new CameRoomWeb.CameRoomService.GetDataUsingDataContractRequest();
            inValue.composite = composite;
            return ((CameRoomWeb.CameRoomService.IService)(this)).GetDataUsingDataContractAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CameRoomWeb.CameRoomService.getProvinceListResponse CameRoomWeb.CameRoomService.IService.getProvinceList(CameRoomWeb.CameRoomService.getProvinceListRequest request) {
            return base.Channel.getProvinceList(request);
        }
        
        public bool getProvinceList(out System.Data.DataSet ds, out string errMsg) {
            CameRoomWeb.CameRoomService.getProvinceListRequest inValue = new CameRoomWeb.CameRoomService.getProvinceListRequest();
            CameRoomWeb.CameRoomService.getProvinceListResponse retVal = ((CameRoomWeb.CameRoomService.IService)(this)).getProvinceList(inValue);
            ds = retVal.ds;
            errMsg = retVal.errMsg;
            return retVal.getProvinceListResult;
        }
        
        public System.Threading.Tasks.Task<CameRoomWeb.CameRoomService.getProvinceListResponse> getProvinceListAsync(CameRoomWeb.CameRoomService.getProvinceListRequest request) {
            return base.Channel.getProvinceListAsync(request);
        }
    }
}