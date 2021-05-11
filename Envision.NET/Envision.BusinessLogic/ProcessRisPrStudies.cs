using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;
using Envision.DataAccess.Insert;
using Envision.DataAccess.Delete;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic
{
    public class ProcessRisPrStudies
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }

        public ProcessRisPrStudies()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }


        public DataTable getGroupFromPrStudiesByGroupIdAndAlgorithmId(int groupId, int algorithmId, int orgId)
        {
            RISPRStudiesSelectData msgSelect = new RISPRStudiesSelectData();
            msgSelect.RIS_PRSTUDIES.PR_GROUP_ID = groupId;
            msgSelect.RIS_PRSTUDIES.PR_ALGORITHM_ID = algorithmId;
            msgSelect.RIS_PRSTUDIES.ORG_ID = orgId;
            DataTable dtGroup = msgSelect.getGroupFromPrStudiesByGroupIdAndAlgorithmId().Tables[0];

            return dtGroup;
        }

        public DataTable getGroupFromPrStudies(int orgId, DateTime dtStart, DateTime dtEnd)
        {
            RISPRStudiesSelectData msgSelect = new RISPRStudiesSelectData();
            msgSelect.RIS_PRSTUDIES.ORG_ID = orgId;
            DataTable dtGroup = msgSelect.GetGroupFromPrStudies(dtStart, dtEnd).Tables[0];

            return dtGroup;
        }

        public void createdPrStudies(string accessionNo, int groupId, int algorithmId, int radId, int orgId, int empId)
        {
            RisPrStudiesInsert msgInsert = new RisPrStudiesInsert();
            msgInsert.RIS_PRSTUDIES.ACCESSION_NO    = accessionNo;
            msgInsert.RIS_PRSTUDIES.ITERATION       = 1;
            msgInsert.RIS_PRSTUDIES.PR_GROUP_ID     = groupId;
            msgInsert.RIS_PRSTUDIES.PR_ALGORITHM_ID = algorithmId;
            msgInsert.RIS_PRSTUDIES.RAD_ID          = radId;
            msgInsert.RIS_PRSTUDIES.PR_STATUS       = "N";
            msgInsert.RIS_PRSTUDIES.ORG_ID          = orgId;
            msgInsert.RIS_PRSTUDIES.CREATED_BY      = empId;
            msgInsert.Add();
        }

        public void update()
        {
            RisPrStudiesUpdate studiesUpdate = new RisPrStudiesUpdate();
            studiesUpdate.RIS_PRSTUDIES.STUDY_ID         = RIS_PRSTUDIES.STUDY_ID;
            studiesUpdate.RIS_PRSTUDIES.RAD_OPINION      = RIS_PRSTUDIES.RAD_OPINION;
            studiesUpdate.RIS_PRSTUDIES.IS_CLINICALLY_SIGNIFICANT = RIS_PRSTUDIES.IS_CLINICALLY_SIGNIFICANT;
            studiesUpdate.RIS_PRSTUDIES.RAD_COMMENTS     = RIS_PRSTUDIES.RAD_COMMENTS;
            studiesUpdate.RIS_PRSTUDIES.PR_STATUS        = RIS_PRSTUDIES.PR_STATUS;
            studiesUpdate.RIS_PRSTUDIES.REPORT_LANG_ID   = RIS_PRSTUDIES.REPORT_LANG_ID;
            studiesUpdate.RIS_PRSTUDIES.REPORT_LANG_COMMENTS = RIS_PRSTUDIES.REPORT_LANG_COMMENTS;
            studiesUpdate.RIS_PRSTUDIES.ORG_ID           = RIS_PRSTUDIES.ORG_ID;
            studiesUpdate.RIS_PRSTUDIES.LAST_MODIFIED_BY = RIS_PRSTUDIES.LAST_MODIFIED_BY;
            studiesUpdate.Update();
        }

        public void delete(int grId, int algorithmId)
        {
            RisPrStudiesDelete studiesDelete = new RisPrStudiesDelete();
            studiesDelete.RIS_PRSTUDIES.PR_GROUP_ID = grId;
            studiesDelete.RIS_PRSTUDIES.PR_ALGORITHM_ID = algorithmId;
            studiesDelete.Delete();
        }

    }
}
