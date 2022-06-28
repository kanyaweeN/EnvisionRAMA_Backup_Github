using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;

namespace Envision.BusinessLogic
{
    public class PatientDestinationInfo
    {
        private static PatientDestination[] patientDestination = { };
        static PatientDestinationInfo()
        {
            ProcessGetRISPatientDestination processGetRISPatientDestination = new ProcessGetRISPatientDestination();
            processGetRISPatientDestination.RIS_PATIENTDESTINATION.ORG_ID = new Envision.Common.GBLEnvVariable().OrgID;
            processGetRISPatientDestination.Invoke();
            List<PatientDestination> patientDestinationSet = new List<PatientDestination>();
            foreach (DataRow eachPatientDestination in processGetRISPatientDestination.Result.Tables[0].Rows)
            {
                PatientDestination ppatientDestination = new PatientDestination();
                ppatientDestination.EncounterClinicType = !string.IsNullOrEmpty(eachPatientDestination["ENCOUNTER_CLINIC_TYPE"].ToString()) ? eachPatientDestination["ENCOUNTER_CLINIC_TYPE"].ToString() : string.Empty;
                ppatientDestination.EncounterType = !string.IsNullOrEmpty(eachPatientDestination["ENCOUNTER_TYPE"].ToString()) ? eachPatientDestination["ENCOUNTER_TYPE"].ToString() : string.Empty;
                ppatientDestination.ExamUnit = !string.IsNullOrEmpty(eachPatientDestination["EXAM_UNIT"].ToString()) ? Convert.ToInt32(eachPatientDestination["EXAM_UNIT"].ToString()) : 0;
                ppatientDestination.Id = Convert.ToInt32(eachPatientDestination["PAT_DEST_ID"].ToString());
                ppatientDestination.Label = eachPatientDestination["LABEL"].ToString();
                ppatientDestination.OrderingDept = string.IsNullOrEmpty(eachPatientDestination["LABEL"].ToString()) ? new string[] { } : GetOrderingDept(eachPatientDestination["ORDERING_DEPT"].ToString());
                ppatientDestination.Type = eachPatientDestination["TYPE"].ToString() == "=" ? ConditionTypes.Equal : ConditionTypes.NotEqual;
                patientDestinationSet.Add(ppatientDestination);
            }
            patientDestination = patientDestinationSet.ToArray();
        }
        /// <summary>
        /// This method use to get destination
        /// </summary>
        /// <param name="examUnit">exam unit</param>
        /// <param name="HN">HN</param>
        /// <param name="Clinic Type Id">Clinic Type Id</param>        /// 
        /// <param name="ordering_unit">ordering unit</param>
        /// <returns>destination label</returns>
        public static string GetDestination(int examUnitId, string HN, int clinicTypeId, string ref_unit)
        {
            string encClinic = string.Empty;
            string encType = string.Empty;
            string encId = string.Empty;
            switch (clinicTypeId)
            {
                case 1: encClinic = "RGL"; break;
                case 7: encClinic = "SPC"; break;
                case 6: encClinic = "PM"; break;
                case 8: encClinic = "PRX"; break;
            }
            EncounterManagement.LoadEncounter(HN, ref_unit, ref encId, ref encType); // Load Encounter
            
            //MessageBox.Show("Get destination");
            //GB_GblInfo = new GblInfo(); 
            string select_destination = string.Empty;
            //Check destination
            foreach (PatientDestination eachPatientDest in patientDestination)
            {
                // Check Type
                if (eachPatientDest.Type == ConditionTypes.Equal)
                {
                    if (string.IsNullOrEmpty(eachPatientDest.EncounterClinicType))
                    {
                        // no encounter clinic type data

                        if (string.IsNullOrEmpty(eachPatientDest.EncounterType))
                        {
                            // no encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // no ordering dept data
                                if (eachPatientDest.OrderingDept.Where(elm => elm == ref_unit).Count() > 0)
                                {
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                }
                                else
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // have ordering dept
                                // no exam unit assigned
                                if (eachPatientDest.ExamUnit == 0)
                                    continue;
                                else
                                {
                                    if (eachPatientDest.ExamUnit == examUnitId)
                                        return eachPatientDest.Label;
                                    else
                                        continue;
                                }
                                //continue; //nothing to do...
                            }
                        }
                        else
                        {
                            // have encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm == ref_unit).Count() > 0
                                    && eachPatientDest.EncounterType == encType)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        continue;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterType == encType)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                        }
                    }
                    else
                    {
                        // have encounter clinic type data

                        if (string.IsNullOrEmpty(eachPatientDest.EncounterType))
                        {
                            // no encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm == ref_unit).Count() > 0
                                    && eachPatientDest.EncounterClinicType == encClinic)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        continue;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterClinicType == encClinic)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    continue; //nothing to do...
                            }
                        }
                        else
                        {
                            // have encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm == ref_unit).Count() > 0
                                    && eachPatientDest.EncounterType == encType
                                    && eachPatientDest.EncounterClinicType == encClinic)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterClinicType == encClinic
                                    && eachPatientDest.EncounterType == encType)
                                    //return eachPatientDest.Label;
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(eachPatientDest.EncounterClinicType))
                    {
                        // no encounter clinic type data

                        if (string.IsNullOrEmpty(eachPatientDest.EncounterType))
                        {
                            // no encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // no order ing dept data
                                if (eachPatientDest.OrderingDept.Where(elm => elm != ref_unit).Count() > 0)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // have ordering dept
                                continue; //nothing to do...
                            }
                        }
                        else
                        {
                            // have encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm != ref_unit).Count() > 0
                                    && eachPatientDest.EncounterType != encType)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterType != encType)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                        }
                    }
                    else
                    {
                        // have encounter clinic type data

                        if (string.IsNullOrEmpty(eachPatientDest.EncounterType))
                        {
                            // no encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm != ref_unit).Count() > 0
                                    && eachPatientDest.EncounterClinicType != encClinic)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterClinicType != encClinic)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                        }
                        else
                        {
                            // have encounter type data

                            if (eachPatientDest.OrderingDept.Count() > 0)
                            {
                                // have ordering dept
                                if (eachPatientDest.OrderingDept.Where(elm => elm != ref_unit).Count() > 0
                                    && eachPatientDest.EncounterType != encType
                                    && eachPatientDest.EncounterClinicType != encClinic)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else

                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                            else
                            {
                                // no order ing dept data
                                if (eachPatientDest.EncounterClinicType != encClinic
                                    && eachPatientDest.EncounterType != encType)
                                    // no exam unit assigned
                                    if (eachPatientDest.ExamUnit == 0)
                                        return eachPatientDest.Label;
                                    else
                                    {
                                        if (eachPatientDest.ExamUnit == examUnitId)
                                            return eachPatientDest.Label;
                                        else
                                            continue;
                                    }
                                //return eachPatientDest.Label;
                                else
                                    // no exam unit assigned
                                    continue; //nothing to do...
                            }
                        }
                    }
                }
            }

            return select_destination;
        }
        /// <summary>
        /// Get destination id
        /// </summary>
        /// <param name="p">label</param>
        /// <returns>patient destination id</returns>
        public static int GetDestinationId(string patientDestinationLabel)
        {
            if (string.IsNullOrEmpty(patientDestinationLabel))
                return 0;
            return patientDestination.Where(elm => elm.Label == patientDestinationLabel).FirstOrDefault().Id;
        }
        /// <summary>
        /// Get or set 
        /// </summary>
        /// <param name="orderingDeptlist">original ordering dept</param>
        /// <returns>array of ordering dept</returns>
        private static string[] GetOrderingDept(string orderingDeptlist)
        {
            string str = orderingDeptlist.Replace(',', ' ');
            return str.Split(' ').Where(elm => elm != string.Empty).ToArray();
        }
        /// <summary>
        /// This method use use to get destination id by
        /// </summary>
        /// <param name="HN">HN</param>
        /// <param name="EXAM_UNIT_ID">Exam unit id</param>
        /// <param name="CLINIC_TYPE_ID">clinical type id</param>
        /// <param name="REF_UNIT_UID">ref unit uid</param>
        /// <returns>Destination Id</returns>
        public static int GetDestination(string HN, int EXAM_UNIT_ID, int CLINIC_TYPE_ID, string REF_UNIT_UID) 
        {
            return GetDestinationId(GetDestination(EXAM_UNIT_ID, HN, CLINIC_TYPE_ID, REF_UNIT_UID));
        }
    }
}
