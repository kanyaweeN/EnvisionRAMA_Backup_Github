using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetInvSettings : IDisposable
    {
        DataTable _table;
        INV_SETTINGS common;

        public ProcessGetInvSettings()
        { 
        }

        public void Invoke()
        {
            InvSettingsSelectData select = new InvSettingsSelectData();
            select.INV_SETTINGS = this.INV_SETTINGS;
            DataSet ds = select.Query();
            _table = ds.Tables[0];
        }

        public DataTable ResultTable
        {
            get { return _table; }
            set { _table = value; }
        }

        public INV_SETTINGS INV_SETTINGS
        {
            get { return common; }
            set { common = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
