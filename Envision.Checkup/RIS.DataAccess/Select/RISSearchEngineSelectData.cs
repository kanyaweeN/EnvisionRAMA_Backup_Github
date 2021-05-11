using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISSearchEngineSelectData : DataAccess.DataAccessBase
    {
        private RISSearchEngine _se;

        public RISSearchEngineSelectData()
        {

        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();

            if (RISSearchEngine.MODE == "1")
            {
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SEARCH_Select1.ToString();

                SqlParameter[] pr = 
                {
                    new SqlParameter("@Key1",RISSearchEngine.KEYS[0]==""?"":RISSearchEngine.KEYS[0]),
                    new SqlParameter("@Key2",RISSearchEngine.KEYS[1]==""?null:RISSearchEngine.KEYS[1]),
                    new SqlParameter("@Key3",RISSearchEngine.KEYS[2]==""?null:RISSearchEngine.KEYS[2]),
                    new SqlParameter("@Key4",RISSearchEngine.KEYS[3]==""?null:RISSearchEngine.KEYS[3]),
                    new SqlParameter("@Key5",RISSearchEngine.KEYS[4]==""?null:RISSearchEngine.KEYS[4]),
                    new SqlParameter("@Key6",RISSearchEngine.KEYS[5]==""?null:RISSearchEngine.KEYS[5]),
                    new SqlParameter("@Key7",RISSearchEngine.KEYS[6]==""?null:RISSearchEngine.KEYS[6]),
                    new SqlParameter("@Key8",RISSearchEngine.KEYS[7]==""?null:RISSearchEngine.KEYS[7]),
                    new SqlParameter("@Key9",RISSearchEngine.KEYS[8]==""?null:RISSearchEngine.KEYS[8]),
                };

                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                ds = dbhelper.Run(base.ConnectionString, pr);
            }
            else if (RISSearchEngine.MODE == "2")
            {
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SEARCH_Select2.ToString();

                SqlParameter[] pr = 
                {
                    new SqlParameter("@ACCESSION_NO",RISSearchEngine.ACCESSION_NO)
                };

                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                ds = dbhelper.Run(base.ConnectionString, pr);
            }
            else if (RISSearchEngine.MODE == "3")
            {
                StoredProcedureName = StoredProcedure.Name.Prc_RIS_SEARCH_Select3.ToString();

                SqlParameter[] pr = 
                {
                    new SqlParameter("@Key1",RISSearchEngine.KEYS[0]==""?"":RISSearchEngine.KEYS[0]),
                    new SqlParameter("@Key2",RISSearchEngine.KEYS[1]==""?null:RISSearchEngine.KEYS[1]),
                    new SqlParameter("@Key3",RISSearchEngine.KEYS[2]==""?null:RISSearchEngine.KEYS[2]),
                    new SqlParameter("@Key4",RISSearchEngine.KEYS[3]==""?null:RISSearchEngine.KEYS[3]),
                    new SqlParameter("@Key5",RISSearchEngine.KEYS[4]==""?null:RISSearchEngine.KEYS[4]),
                    new SqlParameter("@Key6",RISSearchEngine.KEYS[5]==""?null:RISSearchEngine.KEYS[5]),
                    new SqlParameter("@Key7",RISSearchEngine.KEYS[6]==""?null:RISSearchEngine.KEYS[6]),
                    new SqlParameter("@Key8",RISSearchEngine.KEYS[7]==""?null:RISSearchEngine.KEYS[7]),
                    new SqlParameter("@Key9",RISSearchEngine.KEYS[8]==""?null:RISSearchEngine.KEYS[8]),
                    new SqlParameter("@HN",RISSearchEngine.HN==""?null:RISSearchEngine.HN),
                    new SqlParameter("@AGE",RISSearchEngine.AGE==0?null:RISSearchEngine.AGE),
                    new SqlParameter("@GENDER",RISSearchEngine.GENDER==""?null:RISSearchEngine.GENDER.Substring(0,1).ToUpper()),
                    new SqlParameter("@EXAM_NAME",RISSearchEngine.EXAM_NAME==0?null:RISSearchEngine.EXAM_NAME),
                    new SqlParameter("@EXAM_TYPE",RISSearchEngine.EXAM_TYPE==0?null:RISSearchEngine.EXAM_TYPE),
                    new SqlParameter("@REPORTDATE_FROM",RISSearchEngine.REPORTDATE_FROM==""?null:RISSearchEngine.REPORTDATE_FROM),
                    new SqlParameter("@REPORTDATE_TO",RISSearchEngine.REPORTDATE_TO==""?null:RISSearchEngine.REPORTDATE_TO),
                    new SqlParameter("@STUDYDATE_FROM",RISSearchEngine.STUDYDATE_FROM==""?null:RISSearchEngine.STUDYDATE_FROM),
                    new SqlParameter("@STUDYDATE_TO",RISSearchEngine.STUDYDATE_TO==""?null:RISSearchEngine.STUDYDATE_TO),
                    new SqlParameter("@EMP_ID",RISSearchEngine.EMP_ID==0?null:RISSearchEngine.EMP_ID),
                };
                foreach (System.Data.SqlClient.SqlParameter pm in pr)
                    Console.WriteLine(pm.ParameterName.ToString() + ": " + pm.Value);
                DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                ds = dbhelper.Run(base.ConnectionString, pr);
            }

            return ds;
        }

        public RISSearchEngine RISSearchEngine
        {
            get { return _se; }
            set { _se = value; }
        }
    }
}
