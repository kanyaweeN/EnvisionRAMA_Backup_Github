using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Envision.BusinessLogic
{
    public class InsuranceManagement
    {
        /// <summary>
        /// This method use to get admissiom number (AN)
        /// </summary>
        /// <param name="HN">HN</param>
        /// <returns>Admission No</returns>
        private static string LoadAdmissionNoFromHIS(string HN)
        {
            string AN = "";
            HIS_Patient p = new HIS_Patient();
            DataSet ds = p.Get_ipd_detail(HN.Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                AN = ds.Tables[0].Rows[0]["an"].ToString();
            }
            else
                AN = "";

            return AN;
        }

        /// <summary>
        /// This method use to get Insurance Detail from HIS webService
        /// </summary>
        /// <param name="HN">HN</param>
        /// <param name="ENC_ID">Encounter Id</param>
        /// <param name="ENC_TYPE">Encounter Type</param>
        /// <param name="SDLOC">Sdloc</param>
        /// <param name="PerfDate">Perfer Date (Today)</param>
        /// <param name="CLINIC_TYPE">Clinic Type</param>
        /// <returns>Insurance Type Code</returns>
        public static string LoadInsuranceCodeFromHIS(string HN, string ENC_ID, string ENC_TYPE, string SDLOC, string PerfDate, string CLINIC_TYPE)
        {
            HIS_Patient p = new HIS_Patient();

            #region load get_ipd_deatil
            string AN = LoadAdmissionNoFromHIS(HN);
            #endregion

            if (AN.Trim().Length == 0)
            {
                DataSet ds = p.GetEligibilityInsuranceDetail(HN, ENC_TYPE, ENC_ID, SDLOC, PerfDate, CLINIC_TYPE);
                DataTable dt = ds.Tables[0];
                return dt.Rows[0]["insurance"].ToString();
            }
            else
            {
                DataSet ds = p.GetEligibilityInsuranceDetail(HN, "IMP", AN, SDLOC, PerfDate, CLINIC_TYPE);
                DataTable dt = ds.Tables[0];
                return dt.Rows[0]["insurance"].ToString();
            }
        }
    }
}
