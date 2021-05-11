using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Schedule
{
    public class ScheduleCheckupData
    {
        public string hn { get; set; }
        public string initial_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string initial_name_eng { get; set; }
        public string first_name_eng { get; set; }
        public string last_name_eng { get; set; }
        public string middle_name_eng { get; set; }
        public string id_card_no { get; set; }
        public string nation_code { get; set; }
        public string nationality { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string amphur { get; set; }
        public string province { get; set; }
        public string zipcode { get; set; }
        public string tel_no { get; set; }
        public string mobile_no { get; set; }
        public string email { get; set; }
        public string emergency_contact { get; set; }

        public string order_dt { get; set; }
        public string insurance_code { get; set; }
        public string insurance_name { get; set; }
        public string ref_unit_code { get; set; }
        public string ref_unit_name { get; set; }
        public string ref_doc_code { get; set; }
        public string ref_doc_fname { get; set; }
        public string ref_doc_lname { get; set; }
        public string clinical_instruction { get; set; }
        public string created_by_code { get; set; }
        public string created_by_fname { get; set; }
        public string created_by_lname { get; set; }
        public string enc_clinic { get; set; }
        public string enc_type { get; set; }
        public ScheduleDtlCheckupData[] exam_list { get; set; }
    }
}

