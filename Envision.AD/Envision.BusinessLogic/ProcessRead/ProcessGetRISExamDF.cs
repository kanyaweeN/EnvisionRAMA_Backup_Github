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
	public class ProcessGetRISExamDF
	{
        public RIS_EXAMDF RIS_EXAMDF { get; set; }

        public ProcessGetRISExamDF()
        {
            RIS_EXAMDF = new RIS_EXAMDF();
        }

        public DataSet GetData()
        {
            RISExamDFSelectData getData = new RISExamDFSelectData();
            getData.RIS_EXAMDF = this.RIS_EXAMDF;
            DataSet dsResult = getData.GetData();

            //if (dsResult.Tables.Count > 0)
            //{
            //    dsResult.Tables[0].TableName = "RAD_RGL";
            //    dsResult.Tables[1].TableName = "RAD_SPC";
            //    dsResult.Tables[2].TableName = "RAD_PRM";
            //    dsResult.Tables[3].TableName = "TECH_RGL";
            //    dsResult.Tables[4].TableName = "TECH_SPC";
            //    dsResult.Tables[5].TableName = "TECH_PRM";
            //    dsResult.Tables[6].TableName = "NURSE_RGL";
            //    dsResult.Tables[7].TableName = "NURSE_SPC";
            //    dsResult.Tables[8].TableName = "NURSE_PRM";
            //}

            return dsResult;
        }
    }
}

