using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data.SqlClient;

namespace RIS.BusinessLogic
{
    public class ProcessAddRISNursesData :  IBusinessLogic
    {
        private RISNursesData _risnursesdata;
        private SqlTransaction tran = null;
        //private bool useTran;
        public ProcessAddRISNursesData()
		{
            _risnursesdata = new RISNursesData();
		}
        public ProcessAddRISNursesData(SqlTransaction transaction)
        {
            _risnursesdata = new RISNursesData();
            tran = transaction;

        }
        public RISNursesData RISNursesData
		{
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public void Invoke()
		{
            RISNursesDataInsertData _proc = new RISNursesDataInsertData();
            _proc.RISNursesData = this.RISNursesData;
            if (tran == null)
            {
                _proc.Add(); 
            }
            else
            {
                _proc.Add(tran);
            }
            this.RISNursesData.NURSE_DATA_UK_ID = _proc.GetID();
		}
    }
}
