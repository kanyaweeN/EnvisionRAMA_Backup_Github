using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresultKeyimage : IBusinessLogic
    { 
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}
        public DbTransaction Transaction { get; set; }

		public ProcessAddRISExamresultKeyimage()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            Transaction = null;
		}
        public ProcessAddRISExamresultKeyimage(DbTransaction tran)
        {
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            Transaction = tran;
        }
		public void Invoke()
		{
            RISExamresultKeyimageInsertData _proc = new RISExamresultKeyimageInsertData();
            _proc.RIS_EXAMRESULTKEYIMAGES = this.RIS_EXAMRESULTKEYIMAGES;
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
