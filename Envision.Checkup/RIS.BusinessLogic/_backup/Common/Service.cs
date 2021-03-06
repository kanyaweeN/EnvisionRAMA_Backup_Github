//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace RIS.BusinessLogic.Common.HISService
{
    // 
    // This source code was auto-generated by wsdl, Version=2.0.50727.3038.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "ServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback GetDemographicOperationCompleted;

        private System.Threading.SendOrPostCallback GetDemographicLaborOperationCompleted;

        private System.Threading.SendOrPostCallback GetDoctorOperationCompleted;

        private System.Threading.SendOrPostCallback GetLocationOperationCompleted;

        private System.Threading.SendOrPostCallback GetInsuranceOperationCompleted;

        private System.Threading.SendOrPostCallback SetBillOperationCompleted;

        private System.Threading.SendOrPostCallback CancelBillOperationCompleted;

        private System.Threading.SendOrPostCallback EditBillOperationCompleted;

        /// <remarks/>
        public Service()
        {
            this.Url = "http://192.168.4.79/patientservice/Service.asmx";
        }

        /// <remarks/>
        public event GetDemographicCompletedEventHandler GetDemographicCompleted;

        /// <remarks/>
        public event GetDemographicLaborCompletedEventHandler GetDemographicLaborCompleted;

        /// <remarks/>
        public event GetDoctorCompletedEventHandler GetDoctorCompleted;

        /// <remarks/>
        public event GetLocationCompletedEventHandler GetLocationCompleted;

        /// <remarks/>
        public event GetInsuranceCompletedEventHandler GetInsuranceCompleted;

        /// <remarks/>
        public event SetBillCompletedEventHandler SetBillCompleted;

        /// <remarks/>
        public event CancelBillCompletedEventHandler CancelBillCompleted;

        /// <remarks/>
        public event EditBillCompletedEventHandler EditBillCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDemographic", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDemographic(string HN)
        {
            object[] results = this.Invoke("GetDemographic", new object[] {
                    HN});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetDemographic(string HN, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetDemographic", new object[] {
                    HN}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndGetDemographic(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void GetDemographicAsync(string HN)
        {
            this.GetDemographicAsync(HN, null);
        }

        /// <remarks/>
        public void GetDemographicAsync(string HN, object userState)
        {
            if ((this.GetDemographicOperationCompleted == null))
            {
                this.GetDemographicOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDemographicOperationCompleted);
            }
            this.InvokeAsync("GetDemographic", new object[] {
                    HN}, this.GetDemographicOperationCompleted, userState);
        }

        private void OnGetDemographicOperationCompleted(object arg)
        {
            if ((this.GetDemographicCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDemographicCompleted(this, new GetDemographicCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDemographicLabor", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDemographicLabor(string LHN)
        {
            object[] results = this.Invoke("GetDemographicLabor", new object[] {
                    LHN});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetDemographicLabor(string LHN, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetDemographicLabor", new object[] {
                    LHN}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndGetDemographicLabor(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void GetDemographicLaborAsync(string LHN)
        {
            this.GetDemographicLaborAsync(LHN, null);
        }

        /// <remarks/>
        public void GetDemographicLaborAsync(string LHN, object userState)
        {
            if ((this.GetDemographicLaborOperationCompleted == null))
            {
                this.GetDemographicLaborOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDemographicLaborOperationCompleted);
            }
            this.InvokeAsync("GetDemographicLabor", new object[] {
                    LHN}, this.GetDemographicLaborOperationCompleted, userState);
        }

        private void OnGetDemographicLaborOperationCompleted(object arg)
        {
            if ((this.GetDemographicLaborCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDemographicLaborCompleted(this, new GetDemographicLaborCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDoctor", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetDoctor(string DoctorCode)
        {
            object[] results = this.Invoke("GetDoctor", new object[] {
                    DoctorCode});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetDoctor(string DoctorCode, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetDoctor", new object[] {
                    DoctorCode}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndGetDoctor(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void GetDoctorAsync(string DoctorCode)
        {
            this.GetDoctorAsync(DoctorCode, null);
        }

        /// <remarks/>
        public void GetDoctorAsync(string DoctorCode, object userState)
        {
            if ((this.GetDoctorOperationCompleted == null))
            {
                this.GetDoctorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDoctorOperationCompleted);
            }
            this.InvokeAsync("GetDoctor", new object[] {
                    DoctorCode}, this.GetDoctorOperationCompleted, userState);
        }

        private void OnGetDoctorOperationCompleted(object arg)
        {
            if ((this.GetDoctorCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDoctorCompleted(this, new GetDoctorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLocation", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetLocation(string Location)
        {
            object[] results = this.Invoke("GetLocation", new object[] {
                    Location});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetLocation(string Location, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetLocation", new object[] {
                    Location}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndGetLocation(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void GetLocationAsync(string Location)
        {
            this.GetLocationAsync(Location, null);
        }

        /// <remarks/>
        public void GetLocationAsync(string Location, object userState)
        {
            if ((this.GetLocationOperationCompleted == null))
            {
                this.GetLocationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLocationOperationCompleted);
            }
            this.InvokeAsync("GetLocation", new object[] {
                    Location}, this.GetLocationOperationCompleted, userState);
        }

        private void OnGetLocationOperationCompleted(object arg)
        {
            if ((this.GetLocationCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLocationCompleted(this, new GetLocationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetInsurance", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetInsurance(string Code)
        {
            object[] results = this.Invoke("GetInsurance", new object[] {
                    Code});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetInsurance(string Code, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetInsurance", new object[] {
                    Code}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndGetInsurance(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void GetInsuranceAsync(string Code)
        {
            this.GetInsuranceAsync(Code, null);
        }

        /// <remarks/>
        public void GetInsuranceAsync(string Code, object userState)
        {
            if ((this.GetInsuranceOperationCompleted == null))
            {
                this.GetInsuranceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetInsuranceOperationCompleted);
            }
            this.InvokeAsync("GetInsurance", new object[] {
                    Code}, this.GetInsuranceOperationCompleted, userState);
        }

        private void OnGetInsuranceOperationCompleted(object arg)
        {
            if ((this.GetInsuranceCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetInsuranceCompleted(this, new GetInsuranceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetBill", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet SetBill(int ORDER_ID)
        {
            object[] results = this.Invoke("SetBill", new object[] {
                    ORDER_ID});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSetBill(int ORDER_ID, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SetBill", new object[] {
                    ORDER_ID}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndSetBill(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void SetBillAsync(int ORDER_ID)
        {
            this.SetBillAsync(ORDER_ID, null);
        }

        /// <remarks/>
        public void SetBillAsync(int ORDER_ID, object userState)
        {
            if ((this.SetBillOperationCompleted == null))
            {
                this.SetBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetBillOperationCompleted);
            }
            this.InvokeAsync("SetBill", new object[] {
                    ORDER_ID}, this.SetBillOperationCompleted, userState);
        }

        private void OnSetBillOperationCompleted(object arg)
        {
            if ((this.SetBillCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetBillCompleted(this, new SetBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CancelBill", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet CancelBill(int ORDER_ID)
        {
            object[] results = this.Invoke("CancelBill", new object[] {
                    ORDER_ID});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCancelBill(int ORDER_ID, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CancelBill", new object[] {
                    ORDER_ID}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndCancelBill(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void CancelBillAsync(int ORDER_ID)
        {
            this.CancelBillAsync(ORDER_ID, null);
        }

        /// <remarks/>
        public void CancelBillAsync(int ORDER_ID, object userState)
        {
            if ((this.CancelBillOperationCompleted == null))
            {
                this.CancelBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelBillOperationCompleted);
            }
            this.InvokeAsync("CancelBill", new object[] {
                    ORDER_ID}, this.CancelBillOperationCompleted, userState);
        }

        private void OnCancelBillOperationCompleted(object arg)
        {
            if ((this.CancelBillCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelBillCompleted(this, new CancelBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EditBill", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet EditBill(System.Data.DataSet OldBill, int ORDER_ID)
        {
            object[] results = this.Invoke("EditBill", new object[] {
                    OldBill,
                    ORDER_ID});
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginEditBill(System.Data.DataSet OldBill, int ORDER_ID, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("EditBill", new object[] {
                    OldBill,
                    ORDER_ID}, callback, asyncState);
        }

        /// <remarks/>
        public System.Data.DataSet EndEditBill(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }

        /// <remarks/>
        public void EditBillAsync(System.Data.DataSet OldBill, int ORDER_ID)
        {
            this.EditBillAsync(OldBill, ORDER_ID, null);
        }

        /// <remarks/>
        public void EditBillAsync(System.Data.DataSet OldBill, int ORDER_ID, object userState)
        {
            if ((this.EditBillOperationCompleted == null))
            {
                this.EditBillOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEditBillOperationCompleted);
            }
            this.InvokeAsync("EditBill", new object[] {
                    OldBill,
                    ORDER_ID}, this.EditBillOperationCompleted, userState);
        }

        private void OnEditBillOperationCompleted(object arg)
        {
            if ((this.EditBillCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EditBillCompleted(this, new EditBillCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetDemographicCompletedEventHandler(object sender, GetDemographicCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDemographicCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetDemographicCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void GetDemographicLaborCompletedEventHandler(object sender, GetDemographicLaborCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDemographicLaborCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetDemographicLaborCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void GetDoctorCompletedEventHandler(object sender, GetDoctorCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDoctorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetDoctorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void GetLocationCompletedEventHandler(object sender, GetLocationCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLocationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetLocationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void GetInsuranceCompletedEventHandler(object sender, GetInsuranceCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetInsuranceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetInsuranceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void SetBillCompletedEventHandler(object sender, SetBillCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SetBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void CancelBillCompletedEventHandler(object sender, CancelBillCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CancelBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void EditBillCompletedEventHandler(object sender, EditBillCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EditBillCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal EditBillCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public System.Data.DataSet Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
}