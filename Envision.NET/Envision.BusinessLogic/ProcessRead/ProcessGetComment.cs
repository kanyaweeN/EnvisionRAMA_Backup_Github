using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetComment : IBusinessLogic
    {
        public enum InvokModes
        {
            GetComment, GetContact, GetOrderByPatient, None
        }
        public RIS_COMMENTSONPATIENT QueryParameters { get; set; }
        public DataSet Result { get; set; }
        private InvokModes _invokeMode = InvokModes.None;
        public int ORG_ID { get; set; }
        public InvokModes InvokeMode
        {
            get { return _invokeMode; }
            set { _invokeMode = value; }
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENT_SELECT process = new RIS_COMMENT_SELECT();
            process.CParameter = QueryParameters;
            if (this.InvokeMode == InvokModes.GetComment)
                this.Result = process.GetCommentData();
            else if (this.InvokeMode == InvokModes.GetContact)
                this.Result = process.GetContactListData(this.ORG_ID);
            else if (this.InvokeMode == InvokModes.GetOrderByPatient)
                this.Result = process.GetOrderByPatientData();
        }

        #endregion

        public DataTable GetCommentDetail()
        {
            RIS_COMMENT_SELECT proc = new RIS_COMMENT_SELECT();
            proc.CParameter = QueryParameters;
            return proc.GetCommentDetail();
        }
    }
}
