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

namespace TechFix1.localhost {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ManageUserServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ManageUserService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsValidUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserRoleOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllUsersOperationCompleted;
        
        private System.Threading.SendOrPostCallback FindUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserIDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ManageUserService() {
            this.Url = global::TechFix1.Properties.Settings.Default.TechFix1_localhost_ManageUserService;
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
        public event InsertUserCompletedEventHandler InsertUserCompleted;
        
        /// <remarks/>
        public event UpdateUserCompletedEventHandler UpdateUserCompleted;
        
        /// <remarks/>
        public event DeleteUserCompletedEventHandler DeleteUserCompleted;
        
        /// <remarks/>
        public event IsValidUserCompletedEventHandler IsValidUserCompleted;
        
        /// <remarks/>
        public event GetUserRoleCompletedEventHandler GetUserRoleCompleted;
        
        /// <remarks/>
        public event GetAllUsersCompletedEventHandler GetAllUsersCompleted;
        
        /// <remarks/>
        public event FindUserCompletedEventHandler FindUserCompleted;
        
        /// <remarks/>
        public event GetUserIDCompletedEventHandler GetUserIDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int InsertUser(string fName, string uName, string uRole, string Pasword) {
            object[] results = this.Invoke("InsertUser", new object[] {
                        fName,
                        uName,
                        uRole,
                        Pasword});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void InsertUserAsync(string fName, string uName, string uRole, string Pasword) {
            this.InsertUserAsync(fName, uName, uRole, Pasword, null);
        }
        
        /// <remarks/>
        public void InsertUserAsync(string fName, string uName, string uRole, string Pasword, object userState) {
            if ((this.InsertUserOperationCompleted == null)) {
                this.InsertUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertUserOperationCompleted);
            }
            this.InvokeAsync("InsertUser", new object[] {
                        fName,
                        uName,
                        uRole,
                        Pasword}, this.InsertUserOperationCompleted, userState);
        }
        
        private void OnInsertUserOperationCompleted(object arg) {
            if ((this.InsertUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertUserCompleted(this, new InsertUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UpdateUser(int ID, string uName, string uRole) {
            object[] results = this.Invoke("UpdateUser", new object[] {
                        ID,
                        uName,
                        uRole});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateUserAsync(int ID, string uName, string uRole) {
            this.UpdateUserAsync(ID, uName, uRole, null);
        }
        
        /// <remarks/>
        public void UpdateUserAsync(int ID, string uName, string uRole, object userState) {
            if ((this.UpdateUserOperationCompleted == null)) {
                this.UpdateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateUserOperationCompleted);
            }
            this.InvokeAsync("UpdateUser", new object[] {
                        ID,
                        uName,
                        uRole}, this.UpdateUserOperationCompleted, userState);
        }
        
        private void OnUpdateUserOperationCompleted(object arg) {
            if ((this.UpdateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateUserCompleted(this, new UpdateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int DeleteUser(int id) {
            object[] results = this.Invoke("DeleteUser", new object[] {
                        id});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteUserAsync(int id) {
            this.DeleteUserAsync(id, null);
        }
        
        /// <remarks/>
        public void DeleteUserAsync(int id, object userState) {
            if ((this.DeleteUserOperationCompleted == null)) {
                this.DeleteUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteUserOperationCompleted);
            }
            this.InvokeAsync("DeleteUser", new object[] {
                        id}, this.DeleteUserOperationCompleted, userState);
        }
        
        private void OnDeleteUserOperationCompleted(object arg) {
            if ((this.DeleteUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteUserCompleted(this, new DeleteUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsValidUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string IsValidUser(string uName, string Pasword) {
            object[] results = this.Invoke("IsValidUser", new object[] {
                        uName,
                        Pasword});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void IsValidUserAsync(string uName, string Pasword) {
            this.IsValidUserAsync(uName, Pasword, null);
        }
        
        /// <remarks/>
        public void IsValidUserAsync(string uName, string Pasword, object userState) {
            if ((this.IsValidUserOperationCompleted == null)) {
                this.IsValidUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsValidUserOperationCompleted);
            }
            this.InvokeAsync("IsValidUser", new object[] {
                        uName,
                        Pasword}, this.IsValidUserOperationCompleted, userState);
        }
        
        private void OnIsValidUserOperationCompleted(object arg) {
            if ((this.IsValidUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsValidUserCompleted(this, new IsValidUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserRole", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserRole(string uName) {
            object[] results = this.Invoke("GetUserRole", new object[] {
                        uName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserRoleAsync(string uName) {
            this.GetUserRoleAsync(uName, null);
        }
        
        /// <remarks/>
        public void GetUserRoleAsync(string uName, object userState) {
            if ((this.GetUserRoleOperationCompleted == null)) {
                this.GetUserRoleOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserRoleOperationCompleted);
            }
            this.InvokeAsync("GetUserRole", new object[] {
                        uName}, this.GetUserRoleOperationCompleted, userState);
        }
        
        private void OnGetUserRoleOperationCompleted(object arg) {
            if ((this.GetUserRoleCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserRoleCompleted(this, new GetUserRoleCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllUsers", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetAllUsers() {
            object[] results = this.Invoke("GetAllUsers", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllUsersAsync() {
            this.GetAllUsersAsync(null);
        }
        
        /// <remarks/>
        public void GetAllUsersAsync(object userState) {
            if ((this.GetAllUsersOperationCompleted == null)) {
                this.GetAllUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllUsersOperationCompleted);
            }
            this.InvokeAsync("GetAllUsers", new object[0], this.GetAllUsersOperationCompleted, userState);
        }
        
        private void OnGetAllUsersOperationCompleted(object arg) {
            if ((this.GetAllUsersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllUsersCompleted(this, new GetAllUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet FindUser(int id) {
            object[] results = this.Invoke("FindUser", new object[] {
                        id});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FindUserAsync(int id) {
            this.FindUserAsync(id, null);
        }
        
        /// <remarks/>
        public void FindUserAsync(int id, object userState) {
            if ((this.FindUserOperationCompleted == null)) {
                this.FindUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindUserOperationCompleted);
            }
            this.InvokeAsync("FindUser", new object[] {
                        id}, this.FindUserOperationCompleted, userState);
        }
        
        private void OnFindUserOperationCompleted(object arg) {
            if ((this.FindUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindUserCompleted(this, new FindUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUserID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetUserID(string uName, string Pasword) {
            object[] results = this.Invoke("GetUserID", new object[] {
                        uName,
                        Pasword});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserIDAsync(string uName, string Pasword) {
            this.GetUserIDAsync(uName, Pasword, null);
        }
        
        /// <remarks/>
        public void GetUserIDAsync(string uName, string Pasword, object userState) {
            if ((this.GetUserIDOperationCompleted == null)) {
                this.GetUserIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserIDOperationCompleted);
            }
            this.InvokeAsync("GetUserID", new object[] {
                        uName,
                        Pasword}, this.GetUserIDOperationCompleted, userState);
        }
        
        private void OnGetUserIDOperationCompleted(object arg) {
            if ((this.GetUserIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserIDCompleted(this, new GetUserIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void InsertUserCompletedEventHandler(object sender, InsertUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void UpdateUserCompletedEventHandler(object sender, UpdateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void DeleteUserCompletedEventHandler(object sender, DeleteUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void IsValidUserCompletedEventHandler(object sender, IsValidUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsValidUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsValidUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetUserRoleCompletedEventHandler(object sender, GetUserRoleCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserRoleCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserRoleCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetAllUsersCompletedEventHandler(object sender, GetAllUsersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void FindUserCompletedEventHandler(object sender, FindUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetUserIDCompletedEventHandler(object sender, GetUserIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591