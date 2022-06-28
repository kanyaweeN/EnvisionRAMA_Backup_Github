using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;
using Envision.DataAccess.Insert;
using Envision.DataAccess.Update;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic
{
    public class ProcessRisPrGroup
    {
        public RIS_PRGROUP RIS_PRGROUP { get; set; }
        public RIS_PRGROUPDTL RIS_PRGROUPDTL { get; set; }

        public ProcessRisPrGroup()
        {
            RIS_PRGROUP = new RIS_PRGROUP();
            RIS_PRGROUPDTL = new RIS_PRGROUPDTL();
        }

        public DataTable getGroupEmp(int orgId)
        {
            RisRadGroupSelect msgSelect = new RisRadGroupSelect();
            //msgSelect.RIS_PRGROUPDTL.RAD_ID = usetId;
            msgSelect.RIS_PRGROUP.ORG_ID = orgId;
            DataTable dtGroup = msgSelect.GetGroupEmp().Tables[0];

            //dtGroup.Columns.Add("mergeGroup", typeof(int));
            //foreach (DataRow row in dtGroup.Rows)
            //    row["mergeGroup"] = 1;

            return dtGroup;
        }
        public DataTable chkGroupName(string groupName, int orgId)
        {
            RisRadGroupSelect msgSelect = new RisRadGroupSelect();
            msgSelect.RIS_PRGROUP.PR_GROUP_NAME = groupName;
            msgSelect.RIS_PRGROUP.ORG_ID = orgId;
            DataTable dtGroup = msgSelect.ChkGroupName().Tables[0];

            return dtGroup;
        }
        public DataTable getAllEmp()
        {
            RisRadGroupSelect msgSelect = new RisRadGroupSelect();
            DataTable dtEmp = msgSelect.GetAllEmp().Tables[0];
            //dtEmp.Columns.Add("mergeGroup", typeof(int));
            //foreach (DataRow row in dtEmp.Rows)
            //    row["mergeGroup"] = 2;
            return dtEmp;
        }
        public DataTable getEmpInGroup(int groupID, int orgId)
        {
            RisRadGroupSelect groupSelect = new RisRadGroupSelect();
            groupSelect.RIS_PRGROUPDTL.PR_GROUP_ID = groupID;
            groupSelect.RIS_PRGROUPDTL.ORG_ID = orgId;
            return groupSelect.GetEmpInGroup().Tables[0];
        }
        //public DataTable checkGroupDefault(int groupID)
        //{
        //    RisRadGroupSelect msgSelect = new RisRadGroupSelect();
        //    msgSelect.RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID = groupID;
        //    return msgSelect.checkGroupDefault().Tables[0];
        //}

        

        public int createdNewGroup(string name, int orgId, int empId)
        {
            RisRadGroupInsert msgInsert = new RisRadGroupInsert();
            msgInsert.RIS_PRGROUP.PR_GROUP_NAME = name;
            msgInsert.RIS_PRGROUP.ORG_ID = orgId;
            msgInsert.RIS_PRGROUP.CREATED_BY = empId;
            return msgInsert.Add();
        }

        public void createdEmpToGroup(int id, int empId, int orgId, int userId)
        {
            RisRadGroupInsert msgInsert = new RisRadGroupInsert();
            msgInsert.RIS_PRGROUPDTL.PR_GROUP_ID = id;
            msgInsert.RIS_PRGROUPDTL.RAD_ID = empId;
            msgInsert.RIS_PRGROUP.ORG_ID = orgId;
            msgInsert.RIS_PRGROUPDTL.CREATED_BY = userId;
            msgInsert.AddEmpToGroup();
        }



        public void Update(int id, string name, int orgId , int userId)
        {
            RisRadGroupUpdate msgUpdate = new RisRadGroupUpdate();
            msgUpdate.RIS_PRGROUP.PR_GROUP_ID = id;
            msgUpdate.RIS_PRGROUP.PR_GROUP_NAME = name;
            msgUpdate.RIS_PRGROUP.ORG_ID = orgId;
            msgUpdate.RIS_PRGROUP.LAST_MODIFIED_BY = userId;
            msgUpdate.UpdateGroup();
        }



        public void deleteEmpInGroup(int id)
        {
            RisRadGroupDelete msgDelete = new RisRadGroupDelete();
            msgDelete.RIS_PRGROUPDTL.PR_GROUP_ID = id;
            msgDelete.DeleteEmp();
        }

        public void deleteGroup(int id)
        {
            RisRadGroupDelete msgDelete = new RisRadGroupDelete();
            msgDelete.RIS_PRGROUP.PR_GROUP_ID = id;
            msgDelete.DeleteGroup();
        }
    }
}
