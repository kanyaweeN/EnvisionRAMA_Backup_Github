using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISCommentEmpGroupSelect : DataAccessBase
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public RISCommentEmpGroupSelect()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
            RIS_COMMENTSYSTEM_GROUPDTL = new RIS_COMMENTSYSTEM_GROUPDTL();
        }

        public DataSet GetAllEmp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_SelectALLEmp;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet GetGroupEmp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetEmpInGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUPDTL_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@GROUP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet checkGroupDefault()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_SelectForCheckDefault;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@GROUP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
       
    }
}
