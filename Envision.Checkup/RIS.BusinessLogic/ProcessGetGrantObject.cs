/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Select;
using System.Data;
using RIS.Common;

namespace RIS.BusinessLogic
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
