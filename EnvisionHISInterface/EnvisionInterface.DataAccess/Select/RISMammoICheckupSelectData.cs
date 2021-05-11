using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace EnvisionInterface.DataAccess.Select
{
    public class RISMammoICheckupSelectData : DataAccessBase
    {

        public RISMammoICheckupSelectData()
        {
        }
        public DataSet GetData(string hn, string enc_id, string enc_type)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_MammoICheckup_Select;

            ParameterList = buildParameter(hn, enc_id, enc_type);
            ds = ExecuteDataSet();

            return ds;
        }
        public DataSet GetDataByDate(string resultDate)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_MammoICheckup_SelectByDate;
            ParameterList = buildParameterByDate(resultDate);
            ds = ExecuteDataSet();

            return ds;
        }
        private DbParameter[] buildParameterByDate(string resultDate)
        {
            DbParameter[] parameters ={		
                                          Parameter( "@RESULTDATE", resultDate ) ,
			};
            return parameters;
        }
        private DbParameter[] buildParameter(string hn, string enc_id, string enc_type)
        {
            DbParameter[] parameters ={		
                                          Parameter( "@HN", hn ) ,
                                          Parameter( "@ENC_ID", enc_id ) ,
                                          Parameter( "@ENC_TYPE", enc_type ) 
			};
            return parameters;
        }
    }
}