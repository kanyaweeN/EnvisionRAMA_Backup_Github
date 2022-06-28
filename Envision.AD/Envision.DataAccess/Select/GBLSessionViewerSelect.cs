using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class GBLSessionViewerSelect : DataAccessBase
    {
        private DataSet ds;
        private DateTime start;
        private DateTime end;
        private int mode;

        public GBLSessionViewerSelect()
        {
        }
        public GBLSessionViewerSelect(int mode)
        {
            this.mode = mode;
        }

        public DateTime Start
        {
            get { return start; }
            set { start = value; }
        }
        public DateTime End
        {
            get { return end; }
            set { end = value; }
        }
        public DataSet GetSubMenu()
        {
            ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                      Parameter("@SP_Types",mode)
                                                    , Parameter("@SP_UID","")
                                                    , Parameter("@ST_DATE",start)
                                                    , Parameter("@FN_DATE",end)
                                       };
            return parameters;
        }
        public DataSet GetSessionAltMsg(int EMP_ID)
        {
            ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_GBL_SESSION_SelectLastKillBy;
            ParameterList = new DbParameter[] { Parameter("@EMP_ID", EMP_ID) };
            ds = ExecuteDataSet();
            return ds;
        }
    }
}
