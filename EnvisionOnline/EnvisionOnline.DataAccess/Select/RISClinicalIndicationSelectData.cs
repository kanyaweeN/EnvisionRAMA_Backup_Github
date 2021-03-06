using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using EnvisionOnline.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISClinicalIndicationSelectData : DataAccessBase
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }
        public RISClinicalIndicationSelectData()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATION_Select;
        }

        public DataSet GetCI_ID(string ci_desc,string parent_desc, string mode)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATION_Select_CIID;
            DataSet ds = new DataSet();
            ParameterList = buildParameterCIID(ci_desc, parent_desc,mode);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterCIID(string ci_desc, string parent_desc,string mode)
        {
            DbParameter[] parameters = { 
                                            Parameter( "@CASE"	        , mode ),    
                                             Parameter( "@CI_DESC"	        , ci_desc ),
                                             Parameter( "@PARENT_DESC"		    , parent_desc ) ,
                                       };
            return parameters;
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
                                             Parameter( "@ORG_ID"	        , RIS_CLINICALINDICATION.ORG_ID ),
                                             Parameter( "@EMP_ID"		    , RIS_CLINICALINDICATION.EMP_ID ) ,
                                       };
            return parameters;
        }
        public DataSet GetDataCovid()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_CLINICALINDICATION_SelectCovid;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
    }
}

