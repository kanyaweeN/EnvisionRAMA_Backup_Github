//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.3038.
// 

namespace RAMA.WSDLServiceBilling
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "BillingServiceSoap11Binding", Namespace = "http://billing.his.rama.org")]
    public partial class BillingService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback Set_billingOperationCompleted;

        private System.Threading.SendOrPostCallback Get_VersionOperationCompleted;

        private System.Threading.SendOrPostCallback Cancel_billingOperationCompleted;

        /// <remarks/>
        public BillingService()
        {
            this.Url = "http://10.6.86.101:8080/BillingService/services/BillingService.BillingServiceHttp" +
                "Soap11Endpoint/";
        }

        /// <remarks/>
        public event Set_billingCompletedEventHandler Set_billingCompleted;

        /// <remarks/>
        public event Get_VersionCompletedEventHandler Get_VersionCompleted;

        /// <remarks/>
        public event Cancel_billingCompletedEventHandler Cancel_billingCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:Set_billing", RequestNamespace = "http://billing.his.rama.org", ResponseNamespace = "http://billing.his.rama.org", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public string Set_billing([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string str_sb)
        {
            object[] results = this.Invoke("Set_billing", new object[] {
                    str_sb});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSet_billing(string str_sb, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Set_billing", new object[] {
                    str_sb}, callback, asyncState);
        }

        /// <remarks/>
        public string EndSet_billing(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void Set_billingAsync(string str_sb)
        {
            this.Set_billingAsync(str_sb, null);
        }

        /// <remarks/>
        public void Set_billingAsync(string str_sb, object userState)
        {
            if ((this.Set_billingOperationCompleted == null))
            {
                this.Set_billingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSet_billingOperationCompleted);
            }
            this.InvokeAsync("Set_billing", new object[] {
                    str_sb}, this.Set_billingOperationCompleted, userState);
        }

        private void OnSet_billingOperationCompleted(object arg)
        {
            if ((this.Set_billingCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Set_billingCompleted(this, new Set_billingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:Get_Version", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("Get_VersionResponse", Namespace = "http://billing.his.rama.org")]
        public Get_VersionResponse Get_Version()
        {
            object[] results = this.Invoke("Get_Version", new object[0]);
            return ((Get_VersionResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGet_Version(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Get_Version", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public Get_VersionResponse EndGet_Version(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((Get_VersionResponse)(results[0]));
        }

        /// <remarks/>
        public void Get_VersionAsync()
        {
            this.Get_VersionAsync(null);
        }

        /// <remarks/>
        public void Get_VersionAsync(object userState)
        {
            if ((this.Get_VersionOperationCompleted == null))
            {
                this.Get_VersionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGet_VersionOperationCompleted);
            }
            this.InvokeAsync("Get_Version", new object[0], this.Get_VersionOperationCompleted, userState);
        }

        private void OnGet_VersionOperationCompleted(object arg)
        {
            if ((this.Get_VersionCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Get_VersionCompleted(this, new Get_VersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:Cancel_billing", RequestNamespace = "http://billing.his.rama.org", ResponseNamespace = "http://billing.his.rama.org", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable = true)]
        public string Cancel_billing([System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string hn, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string accessno, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string an, [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)] string iseq)
        {
            object[] results = this.Invoke("Cancel_billing", new object[] {
                    hn,
                    accessno,
                    an,
                    iseq});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCancel_billing(string hn, string accessno, string an, string iseq, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Cancel_billing", new object[] {
                    hn,
                    accessno,
                    an,
                    iseq}, callback, asyncState);
        }

        /// <remarks/>
        public string EndCancel_billing(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void Cancel_billingAsync(string hn, string accessno, string an, string iseq)
        {
            this.Cancel_billingAsync(hn, accessno, an, iseq, null);
        }

        /// <remarks/>
        public void Cancel_billingAsync(string hn, string accessno, string an, string iseq, object userState)
        {
            if ((this.Cancel_billingOperationCompleted == null))
            {
                this.Cancel_billingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancel_billingOperationCompleted);
            }
            this.InvokeAsync("Cancel_billing", new object[] {
                    hn,
                    accessno,
                    an,
                    iseq}, this.Cancel_billingOperationCompleted, userState);
        }

        private void OnCancel_billingOperationCompleted(object arg)
        {
            if ((this.Cancel_billingCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Cancel_billingCompleted(this, new Cancel_billingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://billing.his.rama.org")]
    public partial class Get_VersionResponse
    {

        private string returnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string @return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void Set_billingCompletedEventHandler(object sender, Set_billingCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Set_billingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal Set_billingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void Get_VersionCompletedEventHandler(object sender, Get_VersionCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Get_VersionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal Get_VersionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public Get_VersionResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((Get_VersionResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void Cancel_billingCompletedEventHandler(object sender, Cancel_billingCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Cancel_billingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal Cancel_billingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}