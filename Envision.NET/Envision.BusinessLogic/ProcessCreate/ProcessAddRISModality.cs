using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISModality : IBusinessLogic
	{
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public DataSet DataResult { get; set; }
        public ProcessAddRISModality()
        { 
            RIS_MODALITY = new RIS_MODALITY();
            DataResult = new DataSet();
        }
		public void Invoke()
		{
			RISModalityInsertData _proc=new RISModalityInsertData();
            _proc.RIS_MODALITY = this.RIS_MODALITY;
            DataResult = _proc.Add();
		}
	}
}

