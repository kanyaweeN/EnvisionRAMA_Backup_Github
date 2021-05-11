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
    public class ProcessGetGrantObject : IBusinessLogic
    {
        private string _uuid;
		private DataSet _resultset;

        public ProcessGetGrantObject()
		{

		}

		public void Invoke()
		{
            GBLGrantObjectSelectData grantObject = new GBLGrantObjectSelectData();
            grantObject.UUID = this._uuid;
            ResultSet = grantObject.Get();
		}

		public DataSet ResultSet
		{
			get { return _resultset; }
			set { _resultset = value; }
		}

        public string UUID
        {
            get { return _uuid; }
            set { _uuid = value; }
        }
        	

		
    }
}
