using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
    public class RISNurseDataUpdateData : DataAccessBase
    {
        private RISNursesData	_risnursesdata;
        private RISNurseDataUpdateDataParameters param;
        public RISNurseDataUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATA_Update.ToString();
		}
		public  RISNursesData	RISNursesData
		{
			get{return _risnursesdata;}
			set{_risnursesdata=value;}
		}
		public bool Update()
		{
            param = new RISNurseDataUpdateDataParameters(RISNursesData);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISNurseDataUpdateDataParameters 
	{
		private RISNursesData _risnursesdata;
		private SqlParameter[] _parameters;
        public RISNurseDataUpdateDataParameters(RISNursesData risnursesdata)
		{
            RISNursesData = risnursesdata;
			Build();
		}
        public RISNursesData RISNursesData
		{
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{

            SqlParameter modifyOn = new SqlParameter();
            if (RISNursesData.LAST_MODIFIED_ON == DateTime.MinValue)
                modifyOn.Value = DBNull.Value;
            else
                modifyOn.Value = RISNursesData.LAST_MODIFIED_ON;

			SqlParameter[] parameters ={
new SqlParameter("@NURSE_DATA_UK_ID",RISNursesData.NURSE_DATA_UK_ID)
                ,new SqlParameter("@ANESTHESIA_TECHNIQUE",RISNursesData.ANESTHESIA_TECHNIQUE)
                ,new SqlParameter("@PAST_ILL_DM",RISNursesData.PAST_ILL_DM)
                ,new SqlParameter("@PAST_ILL_HT",RISNursesData.PAST_ILL_HT)
                ,new SqlParameter("@PAST_ILL_HD",RISNursesData.PAST_ILL_HD)
                ,new SqlParameter("@PAST_ILL_ASTHMA",RISNursesData.PAST_ILL_ASTHMA)
                ,new SqlParameter("@PAST_ILL_OTHERS",RISNursesData.PAST_ILL_OTHERS)
                ,new SqlParameter("@PROCEDURE",RISNursesData.PROCEDURE)
                ,new SqlParameter("@DIAGNOSIS",RISNursesData.DIAGNOSIS)
                ,new SqlParameter("@OTHER_DESCRIPTION",RISNursesData.OTHER_DESCRIPTION)
                ,new SqlParameter("@ASSISTANT_ID",RISNursesData.ASSISTANT_ID)
                ,new SqlParameter("@OPERATOR_ID",RISNursesData.OPERATOR_ID)
                ,new SqlParameter("@ORG_ID",RISNursesData.ORG_ID)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISNursesData.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
    }
}
