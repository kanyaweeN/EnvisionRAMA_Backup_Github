﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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
// This source code was auto-generated by wsdl, Version=4.0.30319.1.
// 

namespace SynapseSearchByHN.Webservice
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "QueryImageCountSoap", Namespace = "http://tempuri.org/")]
    public partial class QueryImageCount : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;

        private System.Threading.SendOrPostCallback QueryImageOperationCompleted;

        private System.Threading.SendOrPostCallback checkWindowsAuthenOperationCompleted;

        /// <remarks/>
        public QueryImageCount()
        {
            this.Url = "http://localhost/EnvisionQueryImageCount/QueryImageCount.asmx";
        }

        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;

        /// <remarks/>
        public event QueryImageCompletedEventHandler QueryImageCompleted;

        /// <remarks/>
        public event checkWindowsAuthenCompletedEventHandler checkWindowsAuthenCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld()
        {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void HelloWorldAsync()
        {
            this.HelloWorldAsync(null);
        }

        /// <remarks/>
        public void HelloWorldAsync(object userState)
        {
            if ((this.HelloWorldOperationCompleted == null))
            {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }

        private void OnHelloWorldOperationCompleted(object arg)
        {
            if ((this.HelloWorldCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QueryImage", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int QueryImage(string _hn)
        {
            object[] results = this.Invoke("QueryImage", new object[] {
                    _hn});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginQueryImage(string _hn, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("QueryImage", new object[] {
                    _hn}, callback, asyncState);
        }

        /// <remarks/>
        public int EndQueryImage(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void QueryImageAsync(string _hn)
        {
            this.QueryImageAsync(_hn, null);
        }

        /// <remarks/>
        public void QueryImageAsync(string _hn, object userState)
        {
            if ((this.QueryImageOperationCompleted == null))
            {
                this.QueryImageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnQueryImageOperationCompleted);
            }
            this.InvokeAsync("QueryImage", new object[] {
                    _hn}, this.QueryImageOperationCompleted, userState);
        }

        private void OnQueryImageOperationCompleted(object arg)
        {
            if ((this.QueryImageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.QueryImageCompleted(this, new QueryImageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/checkWindowsAuthen", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool checkWindowsAuthen(string username)
        {
            object[] results = this.Invoke("checkWindowsAuthen", new object[] {
                    username});
            return ((bool)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BegincheckWindowsAuthen(string username, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("checkWindowsAuthen", new object[] {
                    username}, callback, asyncState);
        }

        /// <remarks/>
        public bool EndcheckWindowsAuthen(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }

        /// <remarks/>
        public void checkWindowsAuthenAsync(string username)
        {
            this.checkWindowsAuthenAsync(username, null);
        }

        /// <remarks/>
        public void checkWindowsAuthenAsync(string username, object userState)
        {
            if ((this.checkWindowsAuthenOperationCompleted == null))
            {
                this.checkWindowsAuthenOperationCompleted = new System.Threading.SendOrPostCallback(this.OncheckWindowsAuthenOperationCompleted);
            }
            this.InvokeAsync("checkWindowsAuthen", new object[] {
                    username}, this.checkWindowsAuthenOperationCompleted, userState);
        }

        private void OncheckWindowsAuthenOperationCompleted(object arg)
        {
            if ((this.checkWindowsAuthenCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.checkWindowsAuthenCompleted(this, new checkWindowsAuthenCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void QueryImageCompletedEventHandler(object sender, QueryImageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class QueryImageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal QueryImageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void checkWindowsAuthenCompletedEventHandler(object sender, checkWindowsAuthenCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class checkWindowsAuthenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal checkWindowsAuthenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public bool Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}