using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.Operational
{
    public static class SpecifyData
    {
        public static int setShowRowAppointment()
        {
            return 5;
        }
        #region setAutoPriority
        public static string setAutoPriority(string unit_uid)
        {
            foreach (string str in unit_auto_state)
                if (str == unit_uid)
                    return "S";
            foreach (string str in unit_auto_urgent)
                if (str == unit_uid)
                    return "U";
            return "R";
        }
        private static readonly List<string> unit_auto_state = new List<string> { 
            "OER101","SDPFM01","SDOC01", "1OW", "2OW", "3OW", "4OW", "4TIC", "4IT", "4TW"};
        private static readonly List<string> unit_auto_urgent = new List<string> { 
            "2TP","3IC","4NE1","4NE2","4SP",
            "5IC","5NE","6NEE","6NEY","6NEY1",
            "6NK","7NE","7NK","8NE","8NK1",
            "8NK2","9NK1","9NK2","9NK3"
        };
        #endregion
        #region Force Waiting list
        public static bool checkForceWaitingList(DataTable unit_data, string ref_unit_code)
        {
            bool flag = true;
            if (Utilities.IsHaveData(unit_data))
            {
                DataView dv = unit_data.DefaultView;
                dv.RowFilter = "LOC_ALIAS='IPD' AND UNIT_UID='" + ref_unit_code + "'";
                int _count = 0;
                _count = dv.Count;
                if (_count > 0)
                    flag = false;
            }
            return flag;
        }
        #endregion
        #region Force Clinic with UNIT_UID
        public static string checkClinic(string unit_uid)
        {
            string str_clinic = string.Empty;
            #region Regular
            foreach (string str in unit_Normal_clinic)
                if (str == unit_uid)
                    str_clinic = "RGL";
            #endregion
            #region Special
            foreach (string str in unit_special_clinic)
                if (str == unit_uid)
                    str_clinic = "SPC";
            #endregion
            #region Premium
            foreach (string str in unit_premium_clinic)
                if (str == unit_uid)
                    str_clinic = "PM";
            if (unit_uid.Length > 0 && unit_uid != "*" && unit_uid != "0")
            {
                if (unit_uid.Substring(0, 2) == "VB")
                    str_clinic = "PM";
                if (unit_uid.Substring(0, 3) == "SDP")
                    str_clinic = "PM";
                if (unit_uid.Substring(0, 3) == "SDI")
                    if (unit_uid != "SDIPD85" && unit_uid != "SDIPD81")
                        str_clinic = "PM";
            }
            #endregion
            return str_clinic;
        }
        private static readonly List<string> unit_Normal_clinic = new List<string>
        {

        };
        private static readonly List<string> unit_special_clinic = new List<string>
        {
            "SDORP11", "SDOMD27", "SDOSU20", "OFM18", "SDOBY21", "SDODM25", "ORT202", "OGY111"
        };
        private static readonly List<string> unit_premium_clinic = new List<string>
        {

        };
        #endregion
        #region Disable Modality
        public static bool checkDisableModality(int modality_id)
        {
            bool flag = false;
            foreach (int _id in disable_modality_id)
                if (_id == modality_id)
                    flag = true;
            return flag;
        }
        private static readonly List<int> disable_modality_id = new List<int>
        {
         10,11,12   
        };
        #endregion

        public static bool checkCanOrderwithUnit(string unit_uid, int exam_type)
        {
            bool flag = true;
            bool flagAllowUnit = false;

            List<string> allowCT = new List<string> 
            { 
            "OER101", "1OW", "2OW", "3OW", "4OW", "4IT", "4TW","SDIPD85"
            };

            foreach (string aCT in allowCT)
                if (unit_uid == aCT)
                    flagAllowUnit = true;


            if (flagAllowUnit)
            {
                if (exam_type == 1)
                    flag = false;
            }
            else
            {
                int[] band = { 1, 2 };
                foreach (int erVl in band)
                    if (erVl == exam_type)
                        flag = false;
            }
            return flag;
        }
        public static bool checkCanOrderwithDestination2(int destination, int exam_type)
        {
            bool flag = true;
            switch (destination)
            {
                case 1: int[] ERband = { 1 };
                    foreach (int erVl in ERband)
                        if (erVl == exam_type)
                            flag = false;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 8:
                    int[] band = { 1, 2 };
                    foreach (int Vl in band)
                        if (Vl == exam_type)
                            flag = false;
                    break;
            }
            return flag;
        }
        
        public static string checkPatientType(bool is_children, DataTable dtUnitAll, int unit_id, string clinic)
        {
            string patient_type = "";
            if (is_children)
                patient_type = "PED";
            else if (clinic == "SPC" || clinic == "Special")
                patient_type = "SPC";
            else
            {
                DataRow[] rowUnit = dtUnitAll.Select("UNIT_ID=" + unit_id.ToString());
                if (rowUnit.Length > 0)
                {
                    patient_type = rowUnit[0]["LOC_ALIAS"].ToString();

                    if (rowUnit[0]["UNIT_UID"].ToString().Substring(0, 2) == "VB")
                        patient_type = "SPC";
                    if (rowUnit[0]["UNIT_UID"].ToString().Substring(0, 3) == "OPD")
                        patient_type = "PED";
                }

            }
            return patient_type;
        }
    }
}
