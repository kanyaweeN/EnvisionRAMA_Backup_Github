using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetInvAuthorisation : IDisposable
    {
        DataTable _table;
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }

        public ProcessGetInvAuthorisation()
        {
            _table = new DataTable();
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
        }

        public void Invoke()
        {
            InvAuthoriserSelectData select = new InvAuthoriserSelectData();
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
