using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;
using System.Data;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteACAssignment : IBusinessLogic
    {
        public AC_ASSIGNMENT AC_ASSIGNMENT { get; set; }

        public ProcessDeleteACAssignment()
        {
            this.AC_ASSIGNMENT = new AC_ASSIGNMENT();
        }
        #region IBusinessLogic Members

        public void Invoke()
        {
            ACAssignmentDeleteData processor = new ACAssignmentDeleteData();
            processor.AC_ASSIGNMENT = this.AC_ASSIGNMENT;
            DataSet dsResult = processor.DeleteData();
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        processor.AC_ASSIGNMENT.ASSIGNEMENT_ID = Convert.ToInt32(dsResult.Tables[0].Rows[0]["ASSIGNEMENT_ID"]);
                    }
                }
            }
        }

        #endregion
    }
}
