using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class RISNursesDataInsertData : DataAccessBase
    {
        private RISNursesData	_risnursesdata;
        int _id = 0;
		private RISNursesDataInsertDataParameters	param;
		public  RISNursesDataInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_NURSESDATA_Insert.ToString();
		}
		public  RISNursesData	RISNursesData
		{
			get{return _risnursesdata;}
			set{_risnursesdata=value;}
		}
		public void Add()
		{
			param= new RISNursesDataInsertDataParameters(RISNursesData);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(base.ConnectionString,param.Parameters);
            _id = (int)param.Parameters[0].Value;
		}
        public void Add(SqlTransaction tran)
        {
            param = new RISNursesDataInsertDataParameters(RISNursesData);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, param.Parameters);
            _id = (int)param.Parameters[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
	}
	public class RISNursesDataInsertDataParameters 
	{
		private RISNursesData _risnursesdata;
		private SqlParameter[] _parameters;
        public RISNursesDataInsertDataParameters(RISNursesData risnursesdata)
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
          

            SqlParameter param1 = new SqlParameter("@NURSE_DATA_UK_ID", RISNursesData.NURSE_DATA_UK_ID);
            param1.Direction = ParameterDirection.Output;

			SqlParameter[] parameters ={
			    param1
                ,new SqlParameter("@NURSE_ID",RISNursesData.NURSE_ID)
                ,new SqlParameter("@ACCESSION_NO",RISNursesData.ACCESSION_NO)
                //,new SqlParameter("@INPUT_DT_ID",RISNursesData.INPUT_DT)
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
                ,new SqlParameter("@CREATED_BY",RISNursesData.CREATED_BY)
                ,new SqlParameter("@LAST_MODIFIED_BY",RISNursesData.LAST_MODIFIED_BY)
			};
			_parameters = parameters;
		}
    }
}
