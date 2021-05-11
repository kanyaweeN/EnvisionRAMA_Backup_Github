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
using System.Data;
using System.Data.SqlClient;

using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Insert
{
    public class SplitOrderInsertData : DataAccessBase
    {
        private SplitOrder _splitorder;

        private SplitOrderInsertDataParameters _splitorderinsertdataparameters;

        public SplitOrderInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_SplitOrder.ToString();
        }

        public void Add()
        {
            _splitorderinsertdataparameters = new SplitOrderInsertDataParameters(SplitOrder);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _splitorderinsertdataparameters.Parameters);

        }

        public SplitOrder SplitOrder
        {
            get { return _splitorder; }
            set { _splitorder = value; }
        }
    }

    public class SplitOrderInsertDataParameters
    {
        private SplitOrder _splitorder;
        private SqlParameter[] _parameters;

        public SplitOrderInsertDataParameters(SplitOrder splitorder)
        {
            SplitOrder = splitorder;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@OrdID"	, SplitOrder.OrderID ) ,
				new SqlParameter( "@AccessionNo"        , SplitOrder.AccessionNo ) ,
				new SqlParameter( "@NewAccession"	, SplitOrder.NewAccession ) ,
				new SqlParameter( "@PatientHN"	    , SplitOrder.PatientHN ) ,
				new SqlParameter( "@OrgID"		, new GBLEnvVariable().OrgID ) ,
				new SqlParameter( "@CreatedBy"	    , new GBLEnvVariable().UserID )
                

			};

            Parameters = parameters;
        }

        public SplitOrder SplitOrder
        {
            get { return _splitorder; }
            set { _splitorder = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
