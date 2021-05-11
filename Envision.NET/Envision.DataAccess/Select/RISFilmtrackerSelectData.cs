//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2553 01:30:46
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class RISFilmtrackerSelectData : DataAccessBase 
	{
        //private RIS_FILMTRACKER _risfilmtracker;
        int mode;
		public  RISFilmtrackerSelectData(int mode)
		{
            this.mode = mode;
            RIS_FILMTRACKER = new RIS_FILMTRACKER();
        }
        //public RIS_FILMTRACKER RIS_FILMTRACKER
        //{
        //    get{return _risfilmtracker;}
        //    set{_risfilmtracker=value;}
        //}
        public RIS_FILMTRACKER RIS_FILMTRACKER { get; set; }
		public DataSet GetData()
		{
            if (mode == 1)
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_FILMTRACKER_Select_ReturnForm;
                DataSet ds = new DataSet();
                //ParameterList = buildParameter_mode1();
                ds = ExecuteDataSet();
                return ds;
            }
            else //mode == 0
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_FILMTRACKER_Select_IssueForm;
                DataSet ds = new DataSet();
                ParameterList = buildParameter_mode0();
                ds = ExecuteDataSet();
                return ds;
            }
		}
        //public DbParameter[] buildParameter_mode1()
        //{
        //    DbParameter[] parameters ={			
        //        Parameter("@HN",RISFilmtracker.HN)
        //    };
        //    return parameters;
        //}
        public DbParameter[] buildParameter_mode0()
        {
            DbParameter[] parameters ={			
                Parameter("@HN",RIS_FILMTRACKER.HN)
            };
            return parameters;
        }
	}
}

