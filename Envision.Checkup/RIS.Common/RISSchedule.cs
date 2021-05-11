//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    09/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class RISSchedule
    {
        #region Constructor
        public RISSchedule()
        {

        }
        #endregion


        #region Member
        private int schedule_id;
        private int reg_id;
        private string hn;
        private int modality_id;
        private int exam_id;
        private int exam_uid;
        private string visit_no;
        private DateTime appoint_dt;
        private byte qty;
        private string comments;
        private string special_clinic;
        private byte[] allproperties;
        private string admission_no;
        private DateTime schedule_dt;
        private DateTime startdatetime;
        private DateTime enddatetime;
        private string refer_from;
        private string ref_doc_instruction;
        private string clinical_instruction;
        private string reason;
        private string diagnosis;
        private int icd_id;
        private string schedule_status;
        private int confirmed_by;
        private DateTime confirmed_on;
        private int org_id;
        private int created_by;
        private DateTime created_on;
        private int last_modified_by;
        private DateTime last_modified_on;
        private int clinic_type;
        private decimal rate;
        private string scheduledata;
        private string block_reason;
        private DateTime dtEnd;
        private int ref_unit;
        private int ref_doc;
        private string is_block;
        private string reasonChange;
        private int gen_dtl_id;
        private int selectcase;
        private int rad_id;
        private int patstatus_id;
        private DateTime lmp_dt;
        private int session_id;
        #endregion


        #region Property
        public int SCHEDULE_ID
        {
            get { return schedule_id; }
            set { schedule_id = value; }
        }
        public int REG_ID
        {
            get { return reg_id; }
            set { reg_id = value; }
        }
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
        public int MODALITY_ID
        {
            get { return modality_id; }
            set { modality_id = value; }
        }
        public int EXAM_UID
        {
            get { return exam_uid; }
            set { exam_uid = value; }
        }
        public string VISIT_NO
        {
            get { return visit_no; }
            set { visit_no = value; }
        }
        public DateTime APPOINT_DT
        {
            get { return appoint_dt; }
            set { appoint_dt = value; }
        }
        public byte QTY
        {
            get { return qty; }
            set { qty = value; }
        }
        public string COMMENTS
        {
            get { return comments; }
            set { comments = value; }
        }
        public string SPECIAL_CLINIC
        {
            get { return special_clinic; }
            set { special_clinic = value; }
        }
        public byte[] AllProperties
        {
            get { return allproperties; }
            set { allproperties = value; }
        }
        public string ADMISSION_NO
        {
            get { return admission_no; }
            set { admission_no = value; }
        }
        public DateTime SCHEDULE_DT
        {
            get { return schedule_dt; }
            set { schedule_dt = value; }
        }
        public DateTime StartDateTime
        {
            get { return startdatetime; }
            set { startdatetime = value; }
        }
        public DateTime EndDateTime
        {
            get { return enddatetime; }
            set { enddatetime = value; }
        }
        public string REFER_FROM
        {
            get { return refer_from; }
            set { refer_from = value; }
        }
        public string REF_DOC_INSTRUCTION
        {
            get { return ref_doc_instruction; }
            set { ref_doc_instruction = value; }
        }
        public string CLINICAL_INSTRUCTION
        {
            get { return clinical_instruction; }
            set { clinical_instruction = value; }
        }
        public string REASON
        {
            get { return reason; }
            set { reason = value; }
        }
        public string DIAGNOSIS
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }
        public int ICD_ID
        {
            get { return icd_id; }
            set { icd_id = value; }
        }
        public string SCHEDULE_STATUS
        {
            get { return schedule_status; }
            set { schedule_status = value; }
        }
        public int CONFIRMED_BY
        {
            get { return confirmed_by; }
            set { confirmed_by = value; }
        }
        public DateTime CONFIRMED_ON
        {
            get { return confirmed_on; }
            set { confirmed_on = value; }
        }
        public int ORG_ID
        {
            get { return org_id; }
            set { org_id = value; }
        }
        public int CREATED_BY
        {
            get { return created_by; }
            set { created_by = value; }
        }
        public DateTime CREATED_ON
        {
            get { return created_on; }
            set { created_on = value; }
        }
        public int LAST_MODIFIED_BY
        {
            get { return last_modified_by; }
            set { last_modified_by = value; }
        }
        public DateTime LAST_MODIFIED_ON
        {
            get { return last_modified_on; }
            set { last_modified_on = value; }
        }
        public int CLINIC_TYPE
        {
            get { return clinic_type; }
            set { clinic_type = value; }
        }
        public decimal RATE
        {
            get { return rate; }
            set { rate = value; }
        }
        public int EXAM_ID {
            get { return exam_id; }
            set { exam_id = value; }
        }
        public string SCHEDULE_DATA {
            get { return scheduledata; }
            set { scheduledata = value; }
        }
        public string BLOCK_REASON {
            get { return block_reason; }
            set { block_reason = value; }
        }
        public DateTime END_DATETIME {
            get { return dtEnd; }
            set { dtEnd = value; }
        }
        public int REF_UNIT {
            get { return ref_unit; }
            set { ref_unit = value; }
        }
        public int REF_DOC
        {
            get { return ref_doc; }
            set { ref_doc = value; }
        }
        public string IS_BLOCK {
            get { return is_block; }
            set { is_block = value; }
        }
        public string REASON_CHANGE {
            get { return reasonChange; }
            set { reasonChange = value; }
        }
        public int GEN_DTL_ID {
            get { return gen_dtl_id; }
            set { gen_dtl_id = value; }
        }
        public int SELECTCASE
        {
            get { return selectcase; }
            set { selectcase = value; }
        }
        public int RAD_ID
        {
            get { return rad_id; }
            set { rad_id = value; }
        }
        public int PATSTATUS_ID
        {
            get { return patstatus_id; }
            set { patstatus_id = value; }
        }
        public DateTime LMP_DT
        {
            get { return lmp_dt; }
            set { lmp_dt = value; }
        }
        public int SESSION_ID
        {
            get { return session_id; }
            set { session_id = value; }
        }
        #endregion
    }
}

