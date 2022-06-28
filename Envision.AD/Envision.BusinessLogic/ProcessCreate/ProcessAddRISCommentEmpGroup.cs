using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISCommentEmpGroup
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public ProcessAddRISCommentEmpGroup()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
            RIS_COMMENTSYSTEM_GROUPDTL = new RIS_COMMENTSYSTEM_GROUPDTL();
        }

        public int createdNewGroup(string name, string desc, string tag, int empId)
        {
            RISCommentEmpGroupInsert msgInsert = new RISCommentEmpGroupInsert();
            msgInsert.RIS_COMMENTSYSTEM_GROUP.GROUP_NAME = name;
            msgInsert.RIS_COMMENTSYSTEM_GROUP.GROUP_DESC = desc;
            msgInsert.RIS_COMMENTSYSTEM_GROUP.GROUP_TAG = tag;
            msgInsert.RIS_COMMENTSYSTEM_GROUP.CREATED_BY = empId;
            return msgInsert.Add();
        }

        public void createdEmpToGroup(int id, int empId, int userId)
        {
            RISCommentEmpGroupInsert msgInsert = new RISCommentEmpGroupInsert();
            msgInsert.RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID = id;
            msgInsert.RIS_COMMENTSYSTEM_GROUPDTL.EMP_ID = empId;
            msgInsert.RIS_COMMENTSYSTEM_GROUPDTL.CREATED_BY = userId;
            msgInsert.AddEmpToGroup();
        }
    }
}
