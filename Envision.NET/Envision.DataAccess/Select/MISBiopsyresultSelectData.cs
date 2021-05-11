using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class MISBiopsyresultSelectData : DataAccessBase 
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
		public  MISBiopsyresultSelectData()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
            StoredProcedureName = StoredProcedure.Prc_MIS_BIOPSYRESULT_Select;
		}
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                    Parameter( "@ACCESSION_NO"	    ,MIS_BIOPSYRESULT.ACCESSION_NO ),
                                       };
            return parameters;
        }
	}
}

