﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UFO.PhotoSearchServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SearchPersonByPhotoParams", Namespace="http://schemas.datacontract.org/2004/07/UfoService")]
    [System.SerializableAttribute()]
    public partial class SearchPersonByPhotoParams : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSupressedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MashineNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NatinalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PhotoArrayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhotoFileExtentionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string YearsField;
        
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
        public bool IsSupressed {
            get {
                return this.IsSupressedField;
            }
            set {
                if ((this.IsSupressedField.Equals(value) != true)) {
                    this.IsSupressedField = value;
                    this.RaisePropertyChanged("IsSupressed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MashineName {
            get {
                return this.MashineNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MashineNameField, value) != true)) {
                    this.MashineNameField = value;
                    this.RaisePropertyChanged("MashineName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Natinality {
            get {
                return this.NatinalityField;
            }
            set {
                if ((object.ReferenceEquals(this.NatinalityField, value) != true)) {
                    this.NatinalityField = value;
                    this.RaisePropertyChanged("Natinality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] PhotoArray {
            get {
                return this.PhotoArrayField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoArrayField, value) != true)) {
                    this.PhotoArrayField = value;
                    this.RaisePropertyChanged("PhotoArray");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PhotoFileExtention {
            get {
                return this.PhotoFileExtentionField;
            }
            set {
                if ((object.ReferenceEquals(this.PhotoFileExtentionField, value) != true)) {
                    this.PhotoFileExtentionField = value;
                    this.RaisePropertyChanged("PhotoFileExtention");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sex {
            get {
                return this.SexField;
            }
            set {
                if ((object.ReferenceEquals(this.SexField, value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Years {
            get {
                return this.YearsField;
            }
            set {
                if ((object.ReferenceEquals(this.YearsField, value) != true)) {
                    this.YearsField = value;
                    this.RaisePropertyChanged("Years");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetPhotoFromKaskadParams", Namespace="http://schemas.datacontract.org/2004/07/UfoService")]
    [System.SerializableAttribute()]
    public partial class GetPhotoFromKaskadParams : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BirthdayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FamilyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MashineNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OperationDateEndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime OperationDateStartField;
        
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
        public System.DateTime Birthday {
            get {
                return this.BirthdayField;
            }
            set {
                if ((this.BirthdayField.Equals(value) != true)) {
                    this.BirthdayField = value;
                    this.RaisePropertyChanged("Birthday");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Family {
            get {
                return this.FamilyField;
            }
            set {
                if ((object.ReferenceEquals(this.FamilyField, value) != true)) {
                    this.FamilyField = value;
                    this.RaisePropertyChanged("Family");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MashineName {
            get {
                return this.MashineNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MashineNameField, value) != true)) {
                    this.MashineNameField = value;
                    this.RaisePropertyChanged("MashineName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OperationDateEnd {
            get {
                return this.OperationDateEndField;
            }
            set {
                if ((this.OperationDateEndField.Equals(value) != true)) {
                    this.OperationDateEndField = value;
                    this.RaisePropertyChanged("OperationDateEnd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime OperationDateStart {
            get {
                return this.OperationDateStartField;
            }
            set {
                if ((this.OperationDateStartField.Equals(value) != true)) {
                    this.OperationDateStartField = value;
                    this.RaisePropertyChanged("OperationDateStart");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PhotoSearchServiceResult", Namespace="http://schemas.datacontract.org/2004/07/UfoService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(UFO.PhotoSearchServiceReference.SearchPersonByPhotoParams))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(UFO.PhotoSearchServiceReference.GetPhotoFromKaskadParams))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(UFO.PhotoSearchServiceReference.PhotoSearchServiceResultType))]
    public partial class PhotoSearchServiceResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object DataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UFO.PhotoSearchServiceReference.PhotoSearchServiceResultType TypeField;
        
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
        public object Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public UFO.PhotoSearchServiceReference.PhotoSearchServiceResultType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PhotoSearchServiceResultType", Namespace="http://schemas.datacontract.org/2004/07/UfoService")]
    public enum PhotoSearchServiceResultType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        OK = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cancel = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Confirmation = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PhotoSearchServiceReference.IPhotoSearchService", CallbackContract=typeof(UFO.PhotoSearchServiceReference.IPhotoSearchServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IPhotoSearchService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPhotoSearchService/SearchPersonByPhoto")]
        void SearchPersonByPhoto(UFO.PhotoSearchServiceReference.SearchPersonByPhotoParams searchPersonByPhotoParams);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPhotoSearchService/CancelSearchPersonByPhoto")]
        void CancelSearchPersonByPhoto();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPhotoSearchService/GetFhotoFromKaskad", ReplyAction="http://tempuri.org/IPhotoSearchService/GetFhotoFromKaskadResponse")]
        UFO.PhotoSearchServiceReference.PhotoSearchServiceResult GetFhotoFromKaskad(UFO.PhotoSearchServiceReference.GetPhotoFromKaskadParams getPhotoFromDbParams);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPhotoSearchServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IPhotoSearchService/PhotoSearchServiceCallback")]
        void PhotoSearchServiceCallback(UFO.PhotoSearchServiceReference.PhotoSearchServiceResult photoSearchServiceResult);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPhotoSearchServiceChannel : UFO.PhotoSearchServiceReference.IPhotoSearchService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PhotoSearchServiceClient : System.ServiceModel.DuplexClientBase<UFO.PhotoSearchServiceReference.IPhotoSearchService>, UFO.PhotoSearchServiceReference.IPhotoSearchService {
        
        public PhotoSearchServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public PhotoSearchServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public PhotoSearchServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PhotoSearchServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public PhotoSearchServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SearchPersonByPhoto(UFO.PhotoSearchServiceReference.SearchPersonByPhotoParams searchPersonByPhotoParams) {
            base.Channel.SearchPersonByPhoto(searchPersonByPhotoParams);
        }
        
        public void CancelSearchPersonByPhoto() {
            base.Channel.CancelSearchPersonByPhoto();
        }
        
        public UFO.PhotoSearchServiceReference.PhotoSearchServiceResult GetFhotoFromKaskad(UFO.PhotoSearchServiceReference.GetPhotoFromKaskadParams getPhotoFromDbParams) {
            return base.Channel.GetFhotoFromKaskad(getPhotoFromDbParams);
        }
    }
}
