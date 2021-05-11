using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISExamhospital : IBusinessLogic
	{
		private RISExamhospital _risexamhospital;
        private SqlTransaction tran = null;
		public ProcessAddRISExamhospital()
		{
			_risexamhospital = new  RISExamhospital();
		}
        public ProcessAddRISExamhospital(SqlTransaction transaction)
        {
            _risexamhospital = new RISExamhospital();
            tran = transaction;
        }
		public RISExamhospital RISExamhospital		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public void Invoke()
		{
			RISExamhospitalInsertData _proc=new RISExamhospitalInsertData();
			_proc.RISExamhospital=this.RISExamhospital;
			_proc.Add(tran);
		}
	}
}

