using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EnvisionOnline.Common
{
    public class ONL_PARAMETER
    {
        private string _order_id;
        private string _schedule_id;
        private string _exam_id;
        private string _CanID;
        private string _EmpName;
        private string _USER_NAME;
        private string strHN;
        private string strFORM;
        private string ref_unit_uid;
        private string enc_clinic;
        private string insurance_type_uid;
        private string role;
        private string encounter_type;
        private string clinic_type;
        private string clinical_instruction;
        private string ref_doc_instruction;
        private string flagStatus = "N";
        private string flagChecked = "N";
        private bool flagCTMR;

        private int ref_unit_id;
        private int reg_id;
        private int insurance_type_id;
        private int clinic_type_id;
        private int pat_dest_id;

        private List<string> temp_clinicalindication;
        private List<string> temp_clinicalindicationtype;

        private DataTable _dvGrid;
        private DataTable _dvGridDtl;
        private DataTable _dvGridDtl_Remove;
        private DataTable _dvGridDtlRebind;
        private DataTable _dvICDTemp;
        private DataTable _dvExamFavorite;
        private DataTable _dvExamTop10;
        private DataTable _dvAppoint;
        private DataTable _dvAppointSP;
        private DataTable _dvAppointPM;
        private DataTable _dvAppointCNMI;
        private DataTable _dt_clinicalindicationtype;
        private DataTable _dt_CLINICALINDICATION;
        private DataTable _dt_CLINICALINDICATIONTYPEFAVORITE;
        private DataTable _dt_CLINICALINDICATIONFAVORITE;
        private DataTable _dt_RIS_CLINICALINDICATIONLASTVISIT;
        private DataTable _dt_RIS_CLINICALINDICATIONTYPELASTVISIT;
        private DataTable _dtExamGroup;
        private DataTable _dtMod_ID;
        private DataTable _dtOrderClinicalindication;
        private DataTable _dtOrderClinicalindicationtype;
        private DataTable _dtBasicData;
        private DataTable _dtKeepCNMICase;

        private DataSet _dsPatientData;

        private bool is_childen;
        private bool is_nonresident;
        private bool is_telemed;

        public ONL_PARAMETER()
        {
        }
        #region Set bool
        public bool IS_CHILDEN
        {
            get { return is_childen; }
            set { is_childen = value; }
        }
        public bool IS_NONRESIDENT
        {
            get { return is_nonresident; }
            set { is_nonresident = value; }
        }
        public bool IS_TELEMED
        {
            get { return is_telemed; }
            set { is_telemed = value; }
        }
        #endregion
        #region Set String
        public string ORDER_ID
        {
            get { return _order_id; }
            set { _order_id = value; }
        }
        public string SCHEDULE_ID
        {
            get { return _schedule_id; }
            set { _schedule_id = value; }
        }
        public string EXAM_ID
        {
            get { return _exam_id; }
            set { _exam_id = value; }
        }
        public string CanID
        {
            get { return _CanID; }
            set { _CanID = value; }
        }
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; }
        }
        public string USER_NAME
        {
            get { return _USER_NAME; }
            set { _USER_NAME = value; }
        }
        public string HN
        {
            get { return strHN; }
            set { strHN = value; }
        }
        public string FORM
        {
            get { return strFORM; }
            set { strFORM = value; }
        }
        public string REF_UNIT_UID
        {
            get { return ref_unit_uid; }
            set { ref_unit_uid = value; }
        }
        public string ENC_CLINIC
        {
            get { return enc_clinic; }
            set { enc_clinic = value; }
        }
        public string INSURANCE_TYPE_UID
        {
            get { return insurance_type_uid; }
            set { insurance_type_uid = value; }
        }
        public string ROLE
        {
            get { return role; }
            set { role = value; }
        }
        public string ENCOUNTER_TYPE
        {
            get { return encounter_type; }
            set { encounter_type = value; }
        }
        public string CLINIC_TYPE
        {
            get { return clinic_type; }
            set { clinic_type = value; }
        }
        public string CLINICAL_INSTRUCTION
        {
            get { return clinical_instruction; }
            set { clinical_instruction = value; }
        }
        public string REF_DOC_INSTRUCTION
        {
            get { return ref_doc_instruction; }
            set { ref_doc_instruction = value; }
        }
        public string QUICKEXAM_MODE { get; set; }
        public string QUICKEXAM_ID { get; set; }
        public string FlagStatus
        {
            get { return flagStatus; }
            set { flagStatus = value; }
        }
        public string FlagChecked
        {
            get { return flagChecked; }
            set { flagChecked = value; }
        }
        public bool FlagCTMR
        {
            get { return flagCTMR; }
            set { flagCTMR = value; }
        }
        
        #endregion
        #region Set int
        public int REG_ID
        {
            get { return reg_id; }
            set { reg_id = value; }
        }
        public int INSURANCE_TYPE_ID
        {
            get { return insurance_type_id; }
            set { insurance_type_id = value; }
        }
        public int REF_UNIT_ID
        {
            get { return ref_unit_id; }
            set { ref_unit_id = value; }
        }
        public int CLINIC_TYPE_ID
        {
            get { return clinic_type_id; }
            set { clinic_type_id = value; }
        }
        public int PAT_DEST_ID
        {
            get { return pat_dest_id; }
            set { pat_dest_id = value; }
        }
        public int QUICKEXAM1_ID { get; set; }
        public int QUICKEXAM2_ID { get; set; }
        public int QUICKEXAM3_ID { get; set; }
        public int QUICKEXAM4_ID { get; set; }
        public int QUICKEXAM5_ID { get; set; }
        public int QUICKEXAM6_ID { get; set; }
        public int QUICKEXAM7_ID { get; set; }
        public int QUICKEXAM8_ID { get; set; }
        public int QUICKEXAM9_ID { get; set; }
        public int QUICKEXAM10_ID { get; set; }
        public int ENC_ID { get; set; }
        #endregion
        #region Set List<>

        public List<string> TEMP_CLINICALINDICATION
        {
            get { return temp_clinicalindication; }
            set { temp_clinicalindication = value; }
        }
        public List<string> TEMP_CLINICALINDICATIONTYPE
        {
            get { return temp_clinicalindicationtype; }
            set { temp_clinicalindicationtype = value; }
        } 
        #endregion
        #region Set Datatable
        public DataTable dvGrid
        {
            get { return _dvGrid; }
            set { _dvGrid = value; }
        }
        public DataTable dvGridDtl
        {
            get { return _dvGridDtl; }
            set { _dvGridDtl = value; }
        }
        public DataTable dvGridDtl_Remove
        {
            get { return _dvGridDtl_Remove; }
            set { _dvGridDtl_Remove = value; }
        }
        public DataTable dvGridDtlRebind
        {
            get { return _dvGridDtlRebind; }
            set { _dvGridDtlRebind = value; }
        }
        public DataTable dvICDTemp
        {
            get { return _dvICDTemp; }
            set { _dvICDTemp = value; }
        }
        public DataTable dvExamFavorite
        {
            get { return _dvExamFavorite; }
            set { _dvExamFavorite = value; }
        }
        public DataTable dvExamTop10
        {
            get { return _dvExamTop10; }
            set { _dvExamTop10 = value; }
        }
        public DataTable dvAppoint
        {
            get { return _dvAppoint; }
            set { _dvAppoint = value; }
        }
        public DataTable dvAppointSP
        {
            get { return _dvAppointSP; }
            set { _dvAppointSP = value; }
        }
        public DataTable dvAppointPM
        {
            get { return _dvAppointPM; }
            set { _dvAppointPM = value; }
        }
        public DataTable dvAppointCNMI
        {
            get { return _dvAppointCNMI; }
            set { _dvAppointCNMI = value; }
        }
        public DataTable dtCLINICALINDICATIONTYPE
        {
            get { return _dt_clinicalindicationtype; }
            set { _dt_clinicalindicationtype = value; }
        }
        public DataTable dtCLINICALINDICATION
        {
            get { return _dt_CLINICALINDICATION; }
            set { _dt_CLINICALINDICATION = value; }
        }
        public DataTable dtCLINICALINDICATIONTYPEFAVORITE
        {
            get { return _dt_CLINICALINDICATIONTYPEFAVORITE; }
            set { _dt_CLINICALINDICATIONTYPEFAVORITE = value; }
        }
        public DataTable dtCLINICALINDICATIONFAVORITE
        {
            get { return _dt_CLINICALINDICATIONFAVORITE; }
            set { _dt_CLINICALINDICATIONFAVORITE = value; }
        }
        public DataTable dtCLINICALINDICATIONLASTVISIT
        {
            get { return _dt_RIS_CLINICALINDICATIONLASTVISIT; }
            set { _dt_RIS_CLINICALINDICATIONLASTVISIT = value; }
        }
        public DataTable dtCLINICALINDICATIONTYPELASTVISIT
        {
            get { return _dt_RIS_CLINICALINDICATIONTYPELASTVISIT; }
            set { _dt_RIS_CLINICALINDICATIONTYPELASTVISIT = value; }
        }
        public DataTable dtExamGroup
        {
            get { return _dtExamGroup; }
            set { _dtExamGroup = value; }
        }
        public DataTable dtMod_ID
        {
            get { return _dtMod_ID; }
            set { _dtMod_ID = value; }
        }
        public DataTable dtOrderClinicalIndication
        {
            get { return _dtOrderClinicalindication; }
            set { _dtOrderClinicalindication = value; }
        }
        public DataTable dtOrderClinicalIndicationType
        {
            get { return _dtOrderClinicalindicationtype; }
            set { _dtOrderClinicalindicationtype = value; }
        }
        public DataSet dsPatientData
        {
            get { return _dsPatientData; }
            set { _dsPatientData = value; }
        }
        public DataTable dtBasicData
        {
            get { return _dtBasicData; }
            set { _dtBasicData = value; }
        }
        public DataTable dtKeepCNMICase
        {
            get { return _dtKeepCNMICase; }
            set { _dtKeepCNMICase = value; }
        }
        #endregion
    }
}
