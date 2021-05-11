//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Select
{
	public class RISExaminstructionsSelectData : DataAccessBase
    {
        #region members
        private RISExaminstructions	_risexaminstructions = new RISExaminstructions();
        private int _action;
        #endregion

        #region constructor
        public  RISExaminstructionsSelectData(RISExaminstructions common, int action)
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMINSTRUCTIONS_Select.ToString();
            this.RISExaminstructions = common;
            this._action = action;
        }
        #endregion

        private  RISExaminstructions	RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public DataSet GetData()
		{
            //switch (StoredProcedureName)
            //{
            //    case "Prc_RIS_EXAMINATIONS_Select":
            //        _risexaminstructionsinsertdataparameters = new RISExaminstructionsSelectDataParameters();
            //        break;
            //    case "Prc_RIS_EXAMINATIONS_SelectByExamID":
            //        _risexaminstructionsinsertdataparameters = new RISExaminstructionsSelectDataParameters(this._examid);
            //        break;
            //}
            RISExaminstructionsSelectDataParameters _risexaminstructionsinsertdataparameters = new RISExaminstructionsSelectDataParameters(RISExaminstructions,this._action);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_risexaminstructionsinsertdataparameters.Parameters);
			return ds;
		}

	}
	public class RISExaminstructionsSelectDataParameters
    {
        #region members
        private RISExaminstructions _risexaminstructions;
		private SqlParameter[] _parameters;
        private int _action;
        #endregion

        public RISExaminstructionsSelectDataParameters(RISExaminstructions common, int action)
        {
            RISExaminstructions = common;
            this._action = action;
            Build();
        }
		public  RISExaminstructions	RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{

            //SqlParameter param1 = new SqlParameter("@", this._action == null ? DBNull.Value : this._action);
           
            //param1.Value = DBNull.Value;



			SqlParameter[] parameters ={
                new SqlParameter("@SP_TYPE",this._action),
                //new SqlParameter("@INS_ID",RISExaminstructions.INS_ID),
                new SqlParameter("@INS_UID",RISExaminstructions.INS_UID),
                new SqlParameter("@EXAM_UID",RISExaminstructions.EXAM_UID),
                //new SqlParameter("@INS_TEXT",RISExaminstructions.INS_TEXT),
                //new SqlParameter("@INHERIT_GROUP",RISExaminstructions.INHERIT_GROUP),
                //new SqlParameter("@IS_UPDATED",RISExaminstructions.IS_UPDATED),
                new SqlParameter("@IS_DELETED","N"),
                new SqlParameter("@ORG_ID",RISExaminstructions.ORG_ID),
                new SqlParameter("@EXAM_ID",RISExaminstructions.EXAM_ID)
                //new SqlParameter("@CREATED_BY",RISExaminstructions.CREATED_BY),
                //new SqlParameter("@CREATED_ON",RISExaminstructions.CREATED_ON),
                //new SqlParameter("@LAST_MODIFIED_BY",RISExaminstructions.LAST_MODIFIED_BY),
                //new SqlParameter("@LAST_MODIFIED_ON",RISExaminstructions.LAST_MODIFIED_ON)};
        };
			Parameters = parameters;
		}
	}
}

