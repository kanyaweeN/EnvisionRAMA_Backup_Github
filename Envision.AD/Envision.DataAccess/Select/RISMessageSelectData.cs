using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISMessageSelectData: DataAccessBase 
	{
        public RIS_MESSAGE RIS_MESSAGE { get; set; }

        public RISMessageSelectData()
		{
            RIS_MESSAGE = new RIS_MESSAGE();
            StoredProcedureName = StoredProcedure.Prc_RIS_MESSAGE_Select;
		}
        public DataSet GetPatientData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MESSAGE_Select_PatientDetail;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@ACCESSION_NO"	        , RIS_MESSAGE.ACCESSION_NO ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
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
                                             Parameter( "@ACCESSION_NO"	        , RIS_MESSAGE.ACCESSION_NO ),
                                       };
            return parameters;
        }
	}
}

