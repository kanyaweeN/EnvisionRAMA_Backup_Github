/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
    public class ModalityLoadSelectData : DataAccessBase
    {

        private ModalityLoadSelectDataParameters _modalityselectdataparameters;

        public ModalityLoadSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_Modality_Load.ToString();
        }

        public DataSet Get(int _sptype, DateTime _scdate)
        {
            
            DataSet ds;
            _modalityselectdataparameters = new ModalityLoadSelectDataParameters(_sptype, _scdate);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _modalityselectdataparameters.Parameters);
            return ds;

        }

        
    }

    public class ModalityLoadSelectDataParameters
    {
       
        private SqlParameter[] _parameters;

        public ModalityLoadSelectDataParameters(int sptype, DateTime scdate)
        {
           Build(sptype, scdate);
        }

        private void Build(int _sptyp, DateTime scdt)
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, _sptyp),
                new SqlParameter( "@SCHEDULE_DT"		    , scdt ),
                new SqlParameter( "@ORG_ID"		    , new GBLEnvVariable().OrgID ),
 				
		    };

            Parameters = parameters;
        }


        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
