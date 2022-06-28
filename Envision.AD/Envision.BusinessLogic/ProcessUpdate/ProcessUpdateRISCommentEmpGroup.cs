using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISCommentEmpGroup
    {
        public RIS_COMMENTSYSTEM_GROUP RIS_COMMENTSYSTEM_GROUP { get; set; }

        public ProcessUpdateRISCommentEmpGroup()
        {
            RIS_COMMENTSYSTEM_GROUP = new RIS_COMMENTSYSTEM_GROUP();
        }

        public void Update(int id, string name, string desc, string tag, int userId)
        {
            RISCommentEmpGroupUpdate msgUpdate = new RISCommentEmpGroupUpdate();
            msgUpdate.RIS_COMMENTSYSTEM_GROUP.GROUP_ID = id;
            msgUpdate.RIS_COMMENTSYSTEM_GROUP.GROUP_NAME = name;
            msgUpdate.RIS_COMMENTSYSTEM_GROUP.GROUP_DESC = desc;
            msgUpdate.RIS_COMMENTSYSTEM_GROUP.GROUP_TAG = tag;
            msgUpdate.RIS_COMMENTSYSTEM_GROUP.LAST_MODIFIED_BY = userId;
            msgUpdate.UpdateGroup();
        }
    }
}
