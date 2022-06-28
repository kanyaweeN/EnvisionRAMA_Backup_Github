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
    public class ProcessGetInvSettings : IDisposable
    {
        public INV_SETTING INV_SETTING { get; set; }
        DataTable _table;

        public ProcessGetInvSettings()
        {
            INV_SETTING = new INV_SETTING();
        }

        public void Invoke()
        {
            InvSettingsSelectData select = new InvSettingsSelectData();
            //select.INV_SETTING = this.INV_SETTING;
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
