using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.BusinessLogic
{
    public class EncounterManagement
    {
        /// <summary>
        /// This method use to load encounter form HIS Webservice
        /// </summary>
        /// <param name="HN">HN</param>
        /// <param name="UNIT_UID">Unit Code</param>
        /// <param name="ENC_ID">Encounter Id</param>
        /// <param name="ENC_TYPE">Encounter Type</param>
        public static void LoadEncounter(string HN, string UnidCode, ref string encId, ref string encType)
        {
            try
            {

                if (HN.Trim().Length == 0) return;
                if (UnidCode.Trim().Length == 0) return;

                DataSet dsInsurance = new DataSet();
                DataSet dsExcount = new DataSet();

                string enc_id = " ";
                string enc_type = " ";
                DataRow[] rows_insurance;
                //string sdloc = " ";

                HIS_Patient p = new HIS_Patient();
                dsExcount = p.GetEncounterDetailByMRNForToday(HN);
                if (dsExcount.Tables[0].Rows.Count > 0)
                {
                    rows_insurance = dsExcount.Tables[0].Select
                        ("sdloc_id='" + UnidCode + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                    if (rows_insurance.Length > 0)
                    {
                        enc_id = rows_insurance[0]["enc_id"].ToString();
                        enc_type = rows_insurance[0]["enc_type"].ToString();
                    }
                    else
                    {
                        dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                        if (dsExcount.Tables[0].Rows.Count < 1)
                        {
                            enc_id = " ";
                            enc_type = " ";
                        }
                        else
                        {
                            rows_insurance = dsExcount.Tables[0].Select
                                ("sdloc_id='" + UnidCode + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                            if (rows_insurance.Length > 0)
                            {
                                enc_id = rows_insurance[0]["enc_id"].ToString();
                                enc_type = rows_insurance[0]["enc_type"].ToString();
                            }
                            else
                            {
                                enc_id = " ";
                                enc_type = " ";
                            }
                        }
                    }
                }
                else
                {
                    dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                    if (dsExcount.Tables[0].Rows.Count < 1)
                    {
                        enc_id = " ";
                        enc_type = " ";
                    }
                    else
                    {
                        rows_insurance = dsExcount.Tables[0].Select
                            ("sdloc_id='" + UnidCode + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                        if (rows_insurance.Length > 0)
                        {
                            enc_id = rows_insurance[0]["enc_id"].ToString();
                            enc_type = rows_insurance[0]["enc_type"].ToString();
                        }
                        else
                        {
                            enc_id = " ";
                            enc_type = " ";
                        }
                    }
                }

                encId = enc_id == null ? " " : enc_id;
                encType = enc_type;
            }
            catch (Exception ex)
            {
                encId = " ";
                encType = " ";
            }
        }

        /// <summary>
        /// This method use to load current encounter
        /// </summary>
        /// <param name="ACCESSION_NO">accession no</param>
        /// <returns>current encounter</returns>
        public static DataTable LoadCurrentEncounter(string ACCESSION_NO)
        {
            RISOrderSelectData dataAccess = new RISOrderSelectData();
            DataTable tb = dataAccess.GetOrderDataByAccession(ACCESSION_NO).Tables[0];
            return tb;
        }

        /// <summary>
        /// This method use to update encounter
        /// </summary>
        /// <param name="ORDER_ID">order id</param>
        /// <param name="ENC_ID">encounter id</param>
        /// <param name="ENC_TYPE">encounter type</param>
        public static void UpdateEncounter(int ORDER_ID, string ENC_ID, string ENC_TYPE)
        {
            ProcessUpdateRISOrderEncounter update = new ProcessUpdateRISOrderEncounter();
            update.RIS_ORDER.ORDER_ID = ORDER_ID;
            update.RIS_ORDER.ENC_ID = ENC_ID;
            update.RIS_ORDER.ENC_TYPE = ENC_TYPE;
            update.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="HN"></param>
        /// <returns></returns>
        public static string LoadAdmissinNo(string HN)
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
    }
}
