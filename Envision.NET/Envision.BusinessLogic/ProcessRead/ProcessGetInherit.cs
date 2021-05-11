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
    public class ProcessGetInherit : IBusinessLogic
    {
        private string _uuid;
        private int _type;
		private DataSet _resultset;

        public ProcessGetInherit()
		{

		}

		public void Invoke()
		{
            GBLGrantObjectSelectInherit inheritObject = new GBLGrantObjectSelectInherit();
            inheritObject.UUID = this._uuid;
            inheritObject.Type = this._type;
            ResultSet = inheritObject.Get();
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

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

		
    }
}
