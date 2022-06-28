using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresultrads : IBusinessLogic
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS{get;set;}
        public DbTransaction Transaction {get;set;}

        public ProcessAddRISExamresultrads()
        {
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            Transaction = null;
        }
        public ProcessAddRISExamresultrads(DbTransaction tran)
        {
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            Transaction = tran;
        }
		public void Invoke()
		{
            RISExamresultradsInsertData _proc = new RISExamresultradsInsertData();
            _proc.RIS_EXAMRESULTRADS = this.RIS_EXAMRESULTRADS;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
		}
    }
}
