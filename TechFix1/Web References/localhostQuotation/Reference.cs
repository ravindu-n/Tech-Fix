﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TechFix1.localhostQuotation {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ManageQuotationServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ManageQuotationService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ApproveQuotationOperationCompleted;
        
        private System.Threading.SendOrPostCallback RejectQuotationOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddQuotationDetailsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetPendingQuotationsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetApprovedQuotationsOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddQuotationToInventoryOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetApprovedRequestQuotationsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ManageQuotationService() {
            this.Url = global::TechFix1.Properties.Settings.Default.TechFix1_localhostQuotation_ManageQuotationService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ApproveQuotationCompletedEventHandler ApproveQuotationCompleted;
        
        /// <remarks/>
        public event RejectQuotationCompletedEventHandler RejectQuotationCompleted;
        
        /// <remarks/>
        public event AddQuotationDetailsCompletedEventHandler AddQuotationDetailsCompleted;
        
        /// <remarks/>
        public event GetPendingQuotationsCompletedEventHandler GetPendingQuotationsCompleted;
        
        /// <remarks/>
        public event GetApprovedQuotationsCompletedEventHandler GetApprovedQuotationsCompleted;
        
        /// <remarks/>
        public event AddQuotationToInventoryCompletedEventHandler AddQuotationToInventoryCompleted;
        
        /// <remarks/>
        public event GetApprovedRequestQuotationsCompletedEventHandler GetApprovedRequestQuotationsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ApproveQuotation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ApproveQuotation(int quotationId) {
            object[] results = this.Invoke("ApproveQuotation", new object[] {
                        quotationId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ApproveQuotationAsync(int quotationId) {
            this.ApproveQuotationAsync(quotationId, null);
        }
        
        /// <remarks/>
        public void ApproveQuotationAsync(int quotationId, object userState) {
            if ((this.ApproveQuotationOperationCompleted == null)) {
                this.ApproveQuotationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnApproveQuotationOperationCompleted);
            }
            this.InvokeAsync("ApproveQuotation", new object[] {
                        quotationId}, this.ApproveQuotationOperationCompleted, userState);
        }
        
        private void OnApproveQuotationOperationCompleted(object arg) {
            if ((this.ApproveQuotationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ApproveQuotationCompleted(this, new ApproveQuotationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RejectQuotation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool RejectQuotation(int quotationId) {
            object[] results = this.Invoke("RejectQuotation", new object[] {
                        quotationId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void RejectQuotationAsync(int quotationId) {
            this.RejectQuotationAsync(quotationId, null);
        }
        
        /// <remarks/>
        public void RejectQuotationAsync(int quotationId, object userState) {
            if ((this.RejectQuotationOperationCompleted == null)) {
                this.RejectQuotationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRejectQuotationOperationCompleted);
            }
            this.InvokeAsync("RejectQuotation", new object[] {
                        quotationId}, this.RejectQuotationOperationCompleted, userState);
        }
        
        private void OnRejectQuotationOperationCompleted(object arg) {
            if ((this.RejectQuotationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RejectQuotationCompleted(this, new RejectQuotationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddQuotationDetails", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddQuotationDetails(int quotationId, decimal itemPrice, decimal discount) {
            object[] results = this.Invoke("AddQuotationDetails", new object[] {
                        quotationId,
                        itemPrice,
                        discount});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddQuotationDetailsAsync(int quotationId, decimal itemPrice, decimal discount) {
            this.AddQuotationDetailsAsync(quotationId, itemPrice, discount, null);
        }
        
        /// <remarks/>
        public void AddQuotationDetailsAsync(int quotationId, decimal itemPrice, decimal discount, object userState) {
            if ((this.AddQuotationDetailsOperationCompleted == null)) {
                this.AddQuotationDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddQuotationDetailsOperationCompleted);
            }
            this.InvokeAsync("AddQuotationDetails", new object[] {
                        quotationId,
                        itemPrice,
                        discount}, this.AddQuotationDetailsOperationCompleted, userState);
        }
        
        private void OnAddQuotationDetailsOperationCompleted(object arg) {
            if ((this.AddQuotationDetailsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddQuotationDetailsCompleted(this, new AddQuotationDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPendingQuotations", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetPendingQuotations() {
            object[] results = this.Invoke("GetPendingQuotations", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetPendingQuotationsAsync() {
            this.GetPendingQuotationsAsync(null);
        }
        
        /// <remarks/>
        public void GetPendingQuotationsAsync(object userState) {
            if ((this.GetPendingQuotationsOperationCompleted == null)) {
                this.GetPendingQuotationsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPendingQuotationsOperationCompleted);
            }
            this.InvokeAsync("GetPendingQuotations", new object[0], this.GetPendingQuotationsOperationCompleted, userState);
        }
        
        private void OnGetPendingQuotationsOperationCompleted(object arg) {
            if ((this.GetPendingQuotationsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPendingQuotationsCompleted(this, new GetPendingQuotationsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetApprovedQuotations", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetApprovedQuotations() {
            object[] results = this.Invoke("GetApprovedQuotations", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetApprovedQuotationsAsync() {
            this.GetApprovedQuotationsAsync(null);
        }
        
        /// <remarks/>
        public void GetApprovedQuotationsAsync(object userState) {
            if ((this.GetApprovedQuotationsOperationCompleted == null)) {
                this.GetApprovedQuotationsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetApprovedQuotationsOperationCompleted);
            }
            this.InvokeAsync("GetApprovedQuotations", new object[0], this.GetApprovedQuotationsOperationCompleted, userState);
        }
        
        private void OnGetApprovedQuotationsOperationCompleted(object arg) {
            if ((this.GetApprovedQuotationsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetApprovedQuotationsCompleted(this, new GetApprovedQuotationsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddQuotationToInventory", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool AddQuotationToInventory(int quotationId) {
            object[] results = this.Invoke("AddQuotationToInventory", new object[] {
                        quotationId});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void AddQuotationToInventoryAsync(int quotationId) {
            this.AddQuotationToInventoryAsync(quotationId, null);
        }
        
        /// <remarks/>
        public void AddQuotationToInventoryAsync(int quotationId, object userState) {
            if ((this.AddQuotationToInventoryOperationCompleted == null)) {
                this.AddQuotationToInventoryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddQuotationToInventoryOperationCompleted);
            }
            this.InvokeAsync("AddQuotationToInventory", new object[] {
                        quotationId}, this.AddQuotationToInventoryOperationCompleted, userState);
        }
        
        private void OnAddQuotationToInventoryOperationCompleted(object arg) {
            if ((this.AddQuotationToInventoryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddQuotationToInventoryCompleted(this, new AddQuotationToInventoryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetApprovedRequestQuotations", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetApprovedRequestQuotations() {
            object[] results = this.Invoke("GetApprovedRequestQuotations", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetApprovedRequestQuotationsAsync() {
            this.GetApprovedRequestQuotationsAsync(null);
        }
        
        /// <remarks/>
        public void GetApprovedRequestQuotationsAsync(object userState) {
            if ((this.GetApprovedRequestQuotationsOperationCompleted == null)) {
                this.GetApprovedRequestQuotationsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetApprovedRequestQuotationsOperationCompleted);
            }
            this.InvokeAsync("GetApprovedRequestQuotations", new object[0], this.GetApprovedRequestQuotationsOperationCompleted, userState);
        }
        
        private void OnGetApprovedRequestQuotationsOperationCompleted(object arg) {
            if ((this.GetApprovedRequestQuotationsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetApprovedRequestQuotationsCompleted(this, new GetApprovedRequestQuotationsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void ApproveQuotationCompletedEventHandler(object sender, ApproveQuotationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ApproveQuotationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ApproveQuotationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void RejectQuotationCompletedEventHandler(object sender, RejectQuotationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RejectQuotationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RejectQuotationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void AddQuotationDetailsCompletedEventHandler(object sender, AddQuotationDetailsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddQuotationDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddQuotationDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetPendingQuotationsCompletedEventHandler(object sender, GetPendingQuotationsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPendingQuotationsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPendingQuotationsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetApprovedQuotationsCompletedEventHandler(object sender, GetApprovedQuotationsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetApprovedQuotationsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetApprovedQuotationsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void AddQuotationToInventoryCompletedEventHandler(object sender, AddQuotationToInventoryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddQuotationToInventoryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddQuotationToInventoryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetApprovedRequestQuotationsCompletedEventHandler(object sender, GetApprovedRequestQuotationsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetApprovedRequestQuotationsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetApprovedRequestQuotationsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591