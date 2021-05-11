using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Insert;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISCommentEmpGroup
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }
        public RIS_COMMENTSYSTEM_GROUPDTL RIS_COMMENTSYSTEM_GROUPDTL { get; set; }

        public ProcessDeleteRISCommentEmpGroup()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
            RIS_COMMENTSYSTEM_GROUPDTL = new RIS_COMMENTSYSTEM_GROUPDTL();
        }

        public void deleteEmpInGroup(int id)
        {
            RISCommentEmpGroupDelete msgDelete = new RISCommentEmpGroupDelete();
            msgDelete.RIS_COMMENTSYSTEM_GROUPDTL.GROUP_ID = id;
            msgDelete.DeleteEmp();
        }

        public void deleteGroup(int id)
        {
            RISCommentEmpGroupDelete msgDelete = new RISCommentEmpGroupDelete();
            msgDelete.RIS_COMMENTSYSTEM_GROUP.GROUP_ID = id;
            msgDelete.DeleteGroup();
        }
    }
}
