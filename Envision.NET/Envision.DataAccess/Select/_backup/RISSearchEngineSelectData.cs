using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISSearchEngineSelectData : DataAccess.DataAccessBase
    {
        public RISSearchEngine RISSearchEngine { get; set; }
        public RISSearchEngineSelectData()
        {
            RISSearchEngine = new RISSearchEngine();
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();

            if (RISSearchEngine.MODE == "1")
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_SEARCH_Select1;
                ParameterList = buildParameterMode1();
                ds = ExecuteDataSet();
            }
            else if (RISSearchEngine.MODE == "2")
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_SEARCH_Select2;
                ParameterList = buildParameterMode2();
                ds = ExecuteDataSet();
            }
            else if (RISSearchEngine.MODE == "3")
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_SEARCH_Select3;
                ParameterList = buildParameterMode3();
                ds = ExecuteDataSet();
            }

            return ds;
        }

        private DbParameter[] buildParameterMode1()
        {
            DbParameter[] parameters ={			
                    Parameter("@Key1",RISSearchEngine.KEYS[0]==""?"":RISSearchEngine.KEYS[0]),
                    Parameter("@Key2",RISSearchEngine.KEYS[1]==""?null:RISSearchEngine.KEYS[1]),
                    Parameter("@Key3",RISSearchEngine.KEYS[2]==""?null:RISSearchEngine.KEYS[2]),
                    Parameter("@Key4",RISSearchEngine.KEYS[3]==""?null:RISSearchEngine.KEYS[3]),
                    Parameter("@Key5",RISSearchEngine.KEYS[4]==""?null:RISSearchEngine.KEYS[4]),
                    Parameter("@Key6",RISSearchEngine.KEYS[5]==""?null:RISSearchEngine.KEYS[5]),
                    Parameter("@Key7",RISSearchEngine.KEYS[6]==""?null:RISSearchEngine.KEYS[6]),
                    Parameter("@Key8",RISSearchEngine.KEYS[7]==""?null:RISSearchEngine.KEYS[7]),
                    Parameter("@Key9",RISSearchEngine.KEYS[8]==""?null:RISSearchEngine.KEYS[8]),
			};
            return parameters;
        }
        private DbParameter[] buildParameterMode2()
        {
            DbParameter[] parameters ={			
                    Parameter("@ACCESSION_NO",RISSearchEngine.ACCESSION_NO),
			};
            return parameters;
        }
        private DbParameter[] buildParameterMode3()
        {
            DbParameter[] parameters ={			
                     Parameter("@Key1",RISSearchEngine.KEYS[0]==""?"":RISSearchEngine.KEYS[0]),
                     Parameter("@Key2",RISSearchEngine.KEYS[1]==""?null:RISSearchEngine.KEYS[1]),
                     Parameter("@Key3",RISSearchEngine.KEYS[2]==""?null:RISSearchEngine.KEYS[2]),
                     Parameter("@Key4",RISSearchEngine.KEYS[3]==""?null:RISSearchEngine.KEYS[3]),
                     Parameter("@Key5",RISSearchEngine.KEYS[4]==""?null:RISSearchEngine.KEYS[4]),
                     Parameter("@Key6",RISSearchEngine.KEYS[5]==""?null:RISSearchEngine.KEYS[5]),
                     Parameter("@Key7",RISSearchEngine.KEYS[6]==""?null:RISSearchEngine.KEYS[6]),
                     Parameter("@Key8",RISSearchEngine.KEYS[7]==""?null:RISSearchEngine.KEYS[7]),
                     Parameter("@Key9",RISSearchEngine.KEYS[8]==""?null:RISSearchEngine.KEYS[8]),
                     Parameter("@HN",RISSearchEngine.HN==""?null:RISSearchEngine.HN),
                     Parameter("@AGE",RISSearchEngine.AGE==0?null:RISSearchEngine.AGE),
                     Parameter("@GENDER",RISSearchEngine.GENDER==""?null:RISSearchEngine.GENDER.Substring(0,1).ToUpper()),
                     Parameter("@EXAM_NAME",RISSearchEngine.EXAM_NAME==0?null:RISSearchEngine.EXAM_NAME),
                     Parameter("@EXAM_TYPE",RISSearchEngine.EXAM_TYPE==0?null:RISSearchEngine.EXAM_TYPE),
                     Parameter("@REPORTDATE_FROM",RISSearchEngine.REPORTDATE_FROM==""?null:RISSearchEngine.REPORTDATE_FROM),
                     Parameter("@REPORTDATE_TO",RISSearchEngine.REPORTDATE_TO==""?null:RISSearchEngine.REPORTDATE_TO),
                     Parameter("@STUDYDATE_FROM",RISSearchEngine.STUDYDATE_FROM==""?null:RISSearchEngine.STUDYDATE_FROM),
                     Parameter("@STUDYDATE_TO",RISSearchEngine.STUDYDATE_TO==""?null:RISSearchEngine.STUDYDATE_TO),
                     Parameter("@EMP_ID",RISSearchEngine.EMP_ID==0?null:RISSearchEngine.EMP_ID),
			};
            return parameters;
        }
    }
}
