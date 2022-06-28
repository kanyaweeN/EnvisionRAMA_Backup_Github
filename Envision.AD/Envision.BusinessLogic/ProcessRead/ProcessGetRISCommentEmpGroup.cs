using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISCommentEmpGroup
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public DataTable getGroupEmp(int usetId)
        {
            RISCommentEmpGroupSelect msgSelect = new RISCommentEmpGroupSelect();
            msgSelect.RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID = usetId;
            DataTable dtGroup = msgSelect.GetGroupEmp().Tables[0];

            dtGroup.Columns.Add("mergeGroup", typeof(int));
            foreach (DataRow row in dtGroup.Rows)
                row["mergeGroup"] = 1;

            return dtGroup;
        }
        public DataTable getAllEmp()
        {
            RISCommentEmpGroupSelect msgSelect = new RISCommentEmpGroupSelect();
            DataTable dtEmp = msgSelect.GetAllEmp().Tables[0];
            dtEmp.Columns.Add("mergeGroup", typeof(int));
            foreach (DataRow row in dtEmp.Rows)
                row["mergeGroup"] = 2;
            return dtEmp;
        }
        public DataTable getEmpInGroup(int groupID)
        {
            RISCommentEmpGroupSelect msgSelect = new RISCommentEmpGroupSelect();
            msgSelect.RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID = groupID;
            return msgSelect.GetEmpInGroup().Tables[0];
        }
        public DataTable checkGroupDefault(int groupID)
        {
            RISCommentEmpGroupSelect msgSelect = new RISCommentEmpGroupSelect();
            msgSelect.RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID = groupID;
            return msgSelect.checkGroupDefault().Tables[0];
        }


        
    }
}
