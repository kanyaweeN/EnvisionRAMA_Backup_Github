//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISModalitytypeDeleteData : DataAccessBase 
	{
		private string	_modalitytypeID;
		private RISModalitytypeInsertDataParameters	_rismodalitytypeinsertdataparameters;
		public  RISModalitytypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYTYPE_Delete.ToString();
		}

        public string ModalityTypeID
        {
            get { return _modalitytypeID; }
            set { _modalitytypeID = value; }
        }
		public void Delete()
		{
            _rismodalitytypeinsertdataparameters = new RISModalitytypeInsertDataParameters(ModalityTypeID);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rismodalitytypeinsertdataparameters.Parameters);
		}
	}
	public class RISModalitytypeInsertDataParameters 
	{
		private string rismodalitytypeID;
		private SqlParameter[] _parameters;

        public RISModalitytypeInsertDataParameters(string rismodalitytypeID)
        {
            this.rismodalitytypeID = rismodalitytypeID;
            Build();
        }

		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 
                new SqlParameter("@TYPE_ID",this.rismodalitytypeID)};
			Parameters = parameters;
		}
	}
}

