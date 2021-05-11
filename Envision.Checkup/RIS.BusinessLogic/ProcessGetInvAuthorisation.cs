using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvAuthorisation : IDisposable
    {
        DataTable _table;
        INV_AUTHORISATION common;

        public ProcessGetInvAuthorisation()
        { 
        }

        public void Invoke()
        {
            InvAuthorisationSelectData select = new InvAuthorisationSelectData();
            DataSet ds = select.Query();
            _table = ds.Tables[0];
        }

        public DataTable ResultTable
        {
            get { return _table; }
            set { _table = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
