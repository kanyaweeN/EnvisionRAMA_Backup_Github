using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data.SqlClient;

namespace RIS.BusinessLogic
{
    public class ProcessAddRISNursesDataDtl : IBusinessLogic
    {
         private RISNursesDataDtl _risnursesdatadtl;
        private SqlTransaction tran = null;
        //private bool useTran;
        public ProcessAddRISNursesDataDtl()
		{
            _risnursesdatadtl = new RISNursesDataDtl();
		}
        public ProcessAddRISNursesDataDtl(SqlTransaction transaction)
        {
            _risnursesdatadtl = new RISNursesDataDtl();
            tran = transaction;

        }
        public RISNursesDataDtl RISNursesDataDtl
		{
            get { return _risnursesdatadtl; }
            set { _risnursesdatadtl = value; }
		}
		public void Invoke()
		{
            RISNursesDataDtlInsertData _proc = new RISNursesDataDtlInsertData();
            _proc.RISNursesDataDtl = this.RISNursesDataDtl;
            if (tran == null)
            {
                _proc.Add(); 
            }
            else
            {
                _proc.Add(tran);
            }
		}
    }
}
