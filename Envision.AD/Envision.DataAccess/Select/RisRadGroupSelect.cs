using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RisRadGroupSelect : DataAccessBase
    {
        public RIS_PRGROUP RIS_PRGROUP { get; set; }
        public RIS_PRGROUPDTL RIS_PRGROUPDTL { get; set; }

        public RisRadGroupSelect()
        {
            RIS_PRGROUP = new RIS_PRGROUP();
            RIS_PRGROUPDTL = new RIS_PRGROUPDTL();
        }

        public DataSet GetAllEmp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_SelectALLEmp;
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
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             //Parameter( "@EMP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRGROUP.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet ChkGroupName()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUP_ChkGroupName;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@PR_GROUP_NAME"	, RIS_PRGROUP.PR_GROUP_NAME ),
                                             Parameter( "@ORG_ID"	        , RIS_PRGROUP.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetEmpInGroup()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRGROUPDTL_Select;
            DataSet ds = new DataSet();
            DbParameter[] parameters = { 
                                             Parameter( "@PR_GROUP_ID"	        , RIS_PRGROUPDTL.PR_GROUP_ID ),
                                             Parameter( "@ORG_ID"	        , RIS_PRGROUPDTL.ORG_ID ),
                                       };
            ParameterList = parameters;
            ds = ExecuteDataSet();
            return ds;
        }
        //public DataSet checkGroupDefault()
        //{
        //    StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEM_GROUP_SelectForCheckDefault;
        //    DataSet ds = new DataSet();
        //    DbParameter[] parameters = { 
        //                                     Parameter( "@GROUP_ID"	        , RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID ),
        //                               };
        //    ParameterList = parameters;
        //    ds = ExecuteDataSet();
        //    return ds;
        //}

        
    }
}
