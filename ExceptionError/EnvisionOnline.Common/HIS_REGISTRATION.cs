using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;
namespace EnvisionOnline.Common
{
    [Table(Name = "dbo.HIS_REGISTRATION")]
    public partial class HIS_REGISTRATION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _REG_ID;

        private string _HN;

        private string _TITLE;

        private System.Nullable<System.DateTime> _REG_DT;

        private string _FNAME;

        private string _MNAME;

        private string _LNAME;

        private string _TITLE_ENG;

        private string _FNAME_ENG;

        private string _MNAME_ENG;

        private string _LNAME_ENG;

        private string _SSN;

        private System.Nullable<System.DateTime> _DOB;

        private System.Nullable<int> _AGE;

        private string _ADDR1;

        private string _ADDR2;

        private string _ADDR3;

        private string _ADDR4;

        private string _ADDR5;

        private string _PHONE1;

        private string _PHONE2;

        private string _PHONE3;

        private string _EMAIL;

        private System.Nullable<char> _GENDER;

        private System.Nullable<char> _MARITAL_STATUS;

        private System.Nullable<int> _OCCUPATION_ID;

        private string _NATIONALITY;

        private string _PASSPORT_NO;

        private string _BLOOD_GROUP;

        private string _RELIGION;

        private System.Nullable<char> _PATIENT_TYPE;

        private System.Nullable<char> _BLOCK_PATIENT;

        private string _EM_CONTACT_PERSON;

        private string _EM_RELATION;

        private string _EM_ADDR;

        private string _EM_PHONE;

        private string _INSURANCE_TYPE;

        private string _HL7_FORMAT;

        private System.Nullable<char> _HL7_SEND;

        private System.Nullable<char> _LINK_DOWN;

        private string _ALLERGIES;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_JOHNDOE;

        private EntitySet<FIN_INVOICE> _FIN_INVOICEs;

        private EntitySet<FIN_PAYMENT> _FIN_PAYMENTs;

        private EntitySet<RIS_ORDER> _RIS_ORDERs;

        private EntitySet<RIS_ORDERIMAGE> _RIS_ORDERIMAGEs;

        private EntitySet<RIS_SCHEDULE> _RIS_SCHEDULEs;

        private EntityRef<HR_OCCUPATION> _HR_OCCUPATION;

        private string _S_HN;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnREG_IDChanging(int value);
        partial void OnREG_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnTITLEChanging(string value);
        partial void OnTITLEChanged();
        partial void OnREG_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnREG_DTChanged();
        partial void OnFNAMEChanging(string value);
        partial void OnFNAMEChanged();
        partial void OnMNAMEChanging(string value);
        partial void OnMNAMEChanged();
        partial void OnLNAMEChanging(string value);
        partial void OnLNAMEChanged();
        partial void OnTITLE_ENGChanging(string value);
        partial void OnTITLE_ENGChanged();
        partial void OnFNAME_ENGChanging(string value);
        partial void OnFNAME_ENGChanged();
        partial void OnMNAME_ENGChanging(string value);
        partial void OnMNAME_ENGChanged();
        partial void OnLNAME_ENGChanging(string value);
        partial void OnLNAME_ENGChanged();
        partial void OnSSNChanging(string value);
        partial void OnSSNChanged();
        partial void OnDOBChanging(System.Nullable<System.DateTime> value);
        partial void OnDOBChanged();
        partial void OnAGEChanging(System.Nullable<int> value);
        partial void OnAGEChanged();
        partial void OnADDR1Changing(string value);
        partial void OnADDR1Changed();
        partial void OnADDR2Changing(string value);
        partial void OnADDR2Changed();
        partial void OnADDR3Changing(string value);
        partial void OnADDR3Changed();
        partial void OnADDR4Changing(string value);
        partial void OnADDR4Changed();
        partial void OnADDR5Changing(string value);
        partial void OnADDR5Changed();
        partial void OnPHONE1Changing(string value);
        partial void OnPHONE1Changed();
        partial void OnPHONE2Changing(string value);
        partial void OnPHONE2Changed();
        partial void OnPHONE3Changing(string value);
        partial void OnPHONE3Changed();
        partial void OnEMAILChanging(string value);
        partial void OnEMAILChanged();
        partial void OnGENDERChanging(System.Nullable<char> value);
        partial void OnGENDERChanged();
        partial void OnMARITAL_STATUSChanging(System.Nullable<char> value);
        partial void OnMARITAL_STATUSChanged();
        partial void OnOCCUPATION_IDChanging(System.Nullable<int> value);
        partial void OnOCCUPATION_IDChanged();
        partial void OnNATIONALITYChanging(string value);
        partial void OnNATIONALITYChanged();
        partial void OnPASSPORT_NOChanging(string value);
        partial void OnPASSPORT_NOChanged();
        partial void OnBLOOD_GROUPChanging(string value);
        partial void OnBLOOD_GROUPChanged();
        partial void OnRELIGIONChanging(string value);
        partial void OnRELIGIONChanged();
        partial void OnPATIENT_TYPEChanging(System.Nullable<char> value);
        partial void OnPATIENT_TYPEChanged();
        partial void OnBLOCK_PATIENTChanging(System.Nullable<char> value);
        partial void OnBLOCK_PATIENTChanged();
        partial void OnEM_CONTACT_PERSONChanging(string value);
        partial void OnEM_CONTACT_PERSONChanged();
        partial void OnEM_RELATIONChanging(string value);
        partial void OnEM_RELATIONChanged();
        partial void OnEM_ADDRChanging(string value);
        partial void OnEM_ADDRChanged();
        partial void OnEM_PHONEChanging(string value);
        partial void OnEM_PHONEChanged();
        partial void OnINSURANCE_TYPEChanging(string value);
        partial void OnINSURANCE_TYPEChanged();
        partial void OnHL7_FORMATChanging(string value);
        partial void OnHL7_FORMATChanged();
        partial void OnHL7_SENDChanging(System.Nullable<char> value);
        partial void OnHL7_SENDChanged();
        partial void OnLINK_DOWNChanging(System.Nullable<char> value);
        partial void OnLINK_DOWNChanged();
        partial void OnALLERGIESChanging(string value);
        partial void OnALLERGIESChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_JOHNDOEChanging(System.Nullable<char> value);
        partial void OnIS_JOHNDOEChanged();
        #endregion

        public HIS_REGISTRATION()
        {
            this._FIN_INVOICEs = new EntitySet<FIN_INVOICE>(new Action<FIN_INVOICE>(this.attach_FIN_INVOICEs), new Action<FIN_INVOICE>(this.detach_FIN_INVOICEs));
            this._FIN_PAYMENTs = new EntitySet<FIN_PAYMENT>(new Action<FIN_PAYMENT>(this.attach_FIN_PAYMENTs), new Action<FIN_PAYMENT>(this.detach_FIN_PAYMENTs));
            this._RIS_ORDERs = new EntitySet<RIS_ORDER>(new Action<RIS_ORDER>(this.attach_RIS_ORDERs), new Action<RIS_ORDER>(this.detach_RIS_ORDERs));
            this._RIS_ORDERIMAGEs = new EntitySet<RIS_ORDERIMAGE>(new Action<RIS_ORDERIMAGE>(this.attach_RIS_ORDERIMAGEs), new Action<RIS_ORDERIMAGE>(this.detach_RIS_ORDERIMAGEs));
            this._RIS_SCHEDULEs = new EntitySet<RIS_SCHEDULE>(new Action<RIS_SCHEDULE>(this.attach_RIS_SCHEDULEs), new Action<RIS_SCHEDULE>(this.detach_RIS_SCHEDULEs));
            this._HR_OCCUPATION = default(EntityRef<HR_OCCUPATION>);
            OnCreated();
        }

        [Column(Storage = "_REG_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int REG_ID
        {
            get
            {
                return this._REG_ID;
            }
            set
            {
                if ((this._REG_ID != value))
                {
                    this.OnREG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REG_ID = value;
                    this.SendPropertyChanged("REG_ID");
                    this.OnREG_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string HN
        {
            get
            {
                return this._HN;
            }
            set
            {
                if ((this._HN != value))
                {
                    this.OnHNChanging(value);
                    this.SendPropertyChanging();
                    this._HN = value;
                    this.SendPropertyChanged("HN");
                    this.OnHNChanged();
                }
            }
        }

        [Column(Storage = "_TITLE", DbType = "NVarChar(100)")]
        public string TITLE
        {
            get
            {
                return this._TITLE;
            }
            set
            {
                if ((this._TITLE != value))
                {
                    this.OnTITLEChanging(value);
                    this.SendPropertyChanging();
                    this._TITLE = value;
                    this.SendPropertyChanged("TITLE");
                    this.OnTITLEChanged();
                }
            }
        }

        [Column(Storage = "_REG_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> REG_DT
        {
            get
            {
                return this._REG_DT;
            }
            set
            {
                if ((this._REG_DT != value))
                {
                    this.OnREG_DTChanging(value);
                    this.SendPropertyChanging();
                    this._REG_DT = value;
                    this.SendPropertyChanged("REG_DT");
                    this.OnREG_DTChanged();
                }
            }
        }

        [Column(Storage = "_FNAME", DbType = "NVarChar(100)")]
        public string FNAME
        {
            get
            {
                return this._FNAME;
            }
            set
            {
                if ((this._FNAME != value))
                {
                    this.OnFNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._FNAME = value;
                    this.SendPropertyChanged("FNAME");
                    this.OnFNAMEChanged();
                }
            }
        }

        [Column(Storage = "_MNAME", DbType = "NVarChar(100)")]
        public string MNAME
        {
            get
            {
                return this._MNAME;
            }
            set
            {
                if ((this._MNAME != value))
                {
                    this.OnMNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._MNAME = value;
                    this.SendPropertyChanged("MNAME");
                    this.OnMNAMEChanged();
                }
            }
        }

        [Column(Storage = "_LNAME", DbType = "NVarChar(100)")]
        public string LNAME
        {
            get
            {
                return this._LNAME;
            }
            set
            {
                if ((this._LNAME != value))
                {
                    this.OnLNAMEChanging(value);
                    this.SendPropertyChanging();
                    this._LNAME = value;
                    this.SendPropertyChanged("LNAME");
                    this.OnLNAMEChanged();
                }
            }
        }

        [Column(Storage = "_TITLE_ENG", DbType = "NVarChar(100)")]
        public string TITLE_ENG
        {
            get
            {
                return this._TITLE_ENG;
            }
            set
            {
                if ((this._TITLE_ENG != value))
                {
                    this.OnTITLE_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._TITLE_ENG = value;
                    this.SendPropertyChanged("TITLE_ENG");
                    this.OnTITLE_ENGChanged();
                }
            }
        }

        [Column(Storage = "_FNAME_ENG", DbType = "NVarChar(100)")]
        public string FNAME_ENG
        {
            get
            {
                return this._FNAME_ENG;
            }
            set
            {
                if ((this._FNAME_ENG != value))
                {
                    this.OnFNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._FNAME_ENG = value;
                    this.SendPropertyChanged("FNAME_ENG");
                    this.OnFNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_MNAME_ENG", DbType = "NVarChar(100)")]
        public string MNAME_ENG
        {
            get
            {
                return this._MNAME_ENG;
            }
            set
            {
                if ((this._MNAME_ENG != value))
                {
                    this.OnMNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._MNAME_ENG = value;
                    this.SendPropertyChanged("MNAME_ENG");
                    this.OnMNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_LNAME_ENG", DbType = "NVarChar(100)")]
        public string LNAME_ENG
        {
            get
            {
                return this._LNAME_ENG;
            }
            set
            {
                if ((this._LNAME_ENG != value))
                {
                    this.OnLNAME_ENGChanging(value);
                    this.SendPropertyChanging();
                    this._LNAME_ENG = value;
                    this.SendPropertyChanged("LNAME_ENG");
                    this.OnLNAME_ENGChanged();
                }
            }
        }

        [Column(Storage = "_SSN", DbType = "NVarChar(100)")]
        public string SSN
        {
            get
            {
                return this._SSN;
            }
            set
            {
                if ((this._SSN != value))
                {
                    this.OnSSNChanging(value);
                    this.SendPropertyChanging();
                    this._SSN = value;
                    this.SendPropertyChanged("SSN");
                    this.OnSSNChanged();
                }
            }
        }

        [Column(Storage = "_DOB", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DOB
        {
            get
            {
                return this._DOB;
            }
            set
            {
                if ((this._DOB != value))
                {
                    this.OnDOBChanging(value);
                    this.SendPropertyChanging();
                    this._DOB = value;
                    this.SendPropertyChanged("DOB");
                    this.OnDOBChanged();
                }
            }
        }

        [Column(Storage = "_AGE", DbType = "Int")]
        public System.Nullable<int> AGE
        {
            get
            {
                return this._AGE;
            }
            set
            {
                if ((this._AGE != value))
                {
                    this.OnAGEChanging(value);
                    this.SendPropertyChanging();
                    this._AGE = value;
                    this.SendPropertyChanged("AGE");
                    this.OnAGEChanged();
                }
            }
        }

        [Column(Storage = "_ADDR1", DbType = "NVarChar(100)")]
        public string ADDR1
        {
            get
            {
                return this._ADDR1;
            }
            set
            {
                if ((this._ADDR1 != value))
                {
                    this.OnADDR1Changing(value);
                    this.SendPropertyChanging();
                    this._ADDR1 = value;
                    this.SendPropertyChanged("ADDR1");
                    this.OnADDR1Changed();
                }
            }
        }

        [Column(Storage = "_ADDR2", DbType = "NVarChar(100)")]
        public string ADDR2
        {
            get
            {
                return this._ADDR2;
            }
            set
            {
                if ((this._ADDR2 != value))
                {
                    this.OnADDR2Changing(value);
                    this.SendPropertyChanging();
                    this._ADDR2 = value;
                    this.SendPropertyChanged("ADDR2");
                    this.OnADDR2Changed();
                }
            }
        }

        [Column(Storage = "_ADDR3", DbType = "NVarChar(100)")]
        public string ADDR3
        {
            get
            {
                return this._ADDR3;
            }
            set
            {
                if ((this._ADDR3 != value))
                {
                    this.OnADDR3Changing(value);
                    this.SendPropertyChanging();
                    this._ADDR3 = value;
                    this.SendPropertyChanged("ADDR3");
                    this.OnADDR3Changed();
                }
            }
        }

        [Column(Storage = "_ADDR4", DbType = "NVarChar(100)")]
        public string ADDR4
        {
            get
            {
                return this._ADDR4;
            }
            set
            {
                if ((this._ADDR4 != value))
                {
                    this.OnADDR4Changing(value);
                    this.SendPropertyChanging();
                    this._ADDR4 = value;
                    this.SendPropertyChanged("ADDR4");
                    this.OnADDR4Changed();
                }
            }
        }

        [Column(Storage = "_ADDR5", DbType = "NVarChar(100)")]
        public string ADDR5
        {
            get
            {
                return this._ADDR5;
            }
            set
            {
                if ((this._ADDR5 != value))
                {
                    this.OnADDR5Changing(value);
                    this.SendPropertyChanging();
                    this._ADDR5 = value;
                    this.SendPropertyChanged("ADDR5");
                    this.OnADDR5Changed();
                }
            }
        }

        [Column(Storage = "_PHONE1", DbType = "NVarChar(100)")]
        public string PHONE1
        {
            get
            {
                return this._PHONE1;
            }
            set
            {
                if ((this._PHONE1 != value))
                {
                    this.OnPHONE1Changing(value);
                    this.SendPropertyChanging();
                    this._PHONE1 = value;
                    this.SendPropertyChanged("PHONE1");
                    this.OnPHONE1Changed();
                }
            }
        }

        [Column(Storage = "_PHONE2", DbType = "NVarChar(100)")]
        public string PHONE2
        {
            get
            {
                return this._PHONE2;
            }
            set
            {
                if ((this._PHONE2 != value))
                {
                    this.OnPHONE2Changing(value);
                    this.SendPropertyChanging();
                    this._PHONE2 = value;
                    this.SendPropertyChanged("PHONE2");
                    this.OnPHONE2Changed();
                }
            }
        }

        [Column(Storage = "_PHONE3", DbType = "NVarChar(100)")]
        public string PHONE3
        {
            get
            {
                return this._PHONE3;
            }
            set
            {
                if ((this._PHONE3 != value))
                {
                    this.OnPHONE3Changing(value);
                    this.SendPropertyChanging();
                    this._PHONE3 = value;
                    this.SendPropertyChanged("PHONE3");
                    this.OnPHONE3Changed();
                }
            }
        }

        [Column(Storage = "_EMAIL", DbType = "NVarChar(100)")]
        public string EMAIL
        {
            get
            {
                return this._EMAIL;
            }
            set
            {
                if ((this._EMAIL != value))
                {
                    this.OnEMAILChanging(value);
                    this.SendPropertyChanging();
                    this._EMAIL = value;
                    this.SendPropertyChanged("EMAIL");
                    this.OnEMAILChanged();
                }
            }
        }

        [Column(Storage = "_GENDER", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENDER
        {
            get
            {
                return this._GENDER;
            }
            set
            {
                if ((this._GENDER != value))
                {
                    this.OnGENDERChanging(value);
                    this.SendPropertyChanging();
                    this._GENDER = value;
                    this.SendPropertyChanged("GENDER");
                    this.OnGENDERChanged();
                }
            }
        }

        [Column(Storage = "_MARITAL_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> MARITAL_STATUS
        {
            get
            {
                return this._MARITAL_STATUS;
            }
            set
            {
                if ((this._MARITAL_STATUS != value))
                {
                    this.OnMARITAL_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._MARITAL_STATUS = value;
                    this.SendPropertyChanged("MARITAL_STATUS");
                    this.OnMARITAL_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_OCCUPATION_ID", DbType = "Int")]
        public System.Nullable<int> OCCUPATION_ID
        {
            get
            {
                return this._OCCUPATION_ID;
            }
            set
            {
                if ((this._OCCUPATION_ID != value))
                {
                    if (this._HR_OCCUPATION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnOCCUPATION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OCCUPATION_ID = value;
                    this.SendPropertyChanged("OCCUPATION_ID");
                    this.OnOCCUPATION_IDChanged();
                }
            }
        }

        [Column(Storage = "_NATIONALITY", DbType = "NVarChar(50)")]
        public string NATIONALITY
        {
            get
            {
                return this._NATIONALITY;
            }
            set
            {
                if ((this._NATIONALITY != value))
                {
                    this.OnNATIONALITYChanging(value);
                    this.SendPropertyChanging();
                    this._NATIONALITY = value;
                    this.SendPropertyChanged("NATIONALITY");
                    this.OnNATIONALITYChanged();
                }
            }
        }

        [Column(Storage = "_PASSPORT_NO", DbType = "NVarChar(50)")]
        public string PASSPORT_NO
        {
            get
            {
                return this._PASSPORT_NO;
            }
            set
            {
                if ((this._PASSPORT_NO != value))
                {
                    this.OnPASSPORT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._PASSPORT_NO = value;
                    this.SendPropertyChanged("PASSPORT_NO");
                    this.OnPASSPORT_NOChanged();
                }
            }
        }

        [Column(Storage = "_BLOOD_GROUP", DbType = "NVarChar(20)")]
        public string BLOOD_GROUP
        {
            get
            {
                return this._BLOOD_GROUP;
            }
            set
            {
                if ((this._BLOOD_GROUP != value))
                {
                    this.OnBLOOD_GROUPChanging(value);
                    this.SendPropertyChanging();
                    this._BLOOD_GROUP = value;
                    this.SendPropertyChanged("BLOOD_GROUP");
                    this.OnBLOOD_GROUPChanged();
                }
            }
        }

        [Column(Storage = "_RELIGION", DbType = "NVarChar(30)")]
        public string RELIGION
        {
            get
            {
                return this._RELIGION;
            }
            set
            {
                if ((this._RELIGION != value))
                {
                    this.OnRELIGIONChanging(value);
                    this.SendPropertyChanging();
                    this._RELIGION = value;
                    this.SendPropertyChanged("RELIGION");
                    this.OnRELIGIONChanged();
                }
            }
        }

        [Column(Storage = "_PATIENT_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> PATIENT_TYPE
        {
            get
            {
                return this._PATIENT_TYPE;
            }
            set
            {
                if ((this._PATIENT_TYPE != value))
                {
                    this.OnPATIENT_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._PATIENT_TYPE = value;
                    this.SendPropertyChanged("PATIENT_TYPE");
                    this.OnPATIENT_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_BLOCK_PATIENT", DbType = "NVarChar(1)")]
        public System.Nullable<char> BLOCK_PATIENT
        {
            get
            {
                return this._BLOCK_PATIENT;
            }
            set
            {
                if ((this._BLOCK_PATIENT != value))
                {
                    this.OnBLOCK_PATIENTChanging(value);
                    this.SendPropertyChanging();
                    this._BLOCK_PATIENT = value;
                    this.SendPropertyChanged("BLOCK_PATIENT");
                    this.OnBLOCK_PATIENTChanged();
                }
            }
        }

        [Column(Storage = "_EM_CONTACT_PERSON", DbType = "NVarChar(100)")]
        public string EM_CONTACT_PERSON
        {
            get
            {
                return this._EM_CONTACT_PERSON;
            }
            set
            {
                if ((this._EM_CONTACT_PERSON != value))
                {
                    this.OnEM_CONTACT_PERSONChanging(value);
                    this.SendPropertyChanging();
                    this._EM_CONTACT_PERSON = value;
                    this.SendPropertyChanged("EM_CONTACT_PERSON");
                    this.OnEM_CONTACT_PERSONChanged();
                }
            }
        }

        [Column(Storage = "_EM_RELATION", DbType = "NVarChar(50)")]
        public string EM_RELATION
        {
            get
            {
                return this._EM_RELATION;
            }
            set
            {
                if ((this._EM_RELATION != value))
                {
                    this.OnEM_RELATIONChanging(value);
                    this.SendPropertyChanging();
                    this._EM_RELATION = value;
                    this.SendPropertyChanged("EM_RELATION");
                    this.OnEM_RELATIONChanged();
                }
            }
        }

        [Column(Storage = "_EM_ADDR", DbType = "NVarChar(100)")]
        public string EM_ADDR
        {
            get
            {
                return this._EM_ADDR;
            }
            set
            {
                if ((this._EM_ADDR != value))
                {
                    this.OnEM_ADDRChanging(value);
                    this.SendPropertyChanging();
                    this._EM_ADDR = value;
                    this.SendPropertyChanged("EM_ADDR");
                    this.OnEM_ADDRChanged();
                }
            }
        }

        [Column(Storage = "_EM_PHONE", DbType = "NVarChar(100)")]
        public string EM_PHONE
        {
            get
            {
                return this._EM_PHONE;
            }
            set
            {
                if ((this._EM_PHONE != value))
                {
                    this.OnEM_PHONEChanging(value);
                    this.SendPropertyChanging();
                    this._EM_PHONE = value;
                    this.SendPropertyChanged("EM_PHONE");
                    this.OnEM_PHONEChanged();
                }
            }
        }

        [Column(Storage = "_INSURANCE_TYPE", DbType = "NVarChar(100)")]
        public string INSURANCE_TYPE
        {
            get
            {
                return this._INSURANCE_TYPE;
            }
            set
            {
                if ((this._INSURANCE_TYPE != value))
                {
                    this.OnINSURANCE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._INSURANCE_TYPE = value;
                    this.SendPropertyChanged("INSURANCE_TYPE");
                    this.OnINSURANCE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_HL7_FORMAT", DbType = "NVarChar(4000)")]
        public string HL7_FORMAT
        {
            get
            {
                return this._HL7_FORMAT;
            }
            set
            {
                if ((this._HL7_FORMAT != value))
                {
                    this.OnHL7_FORMATChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_FORMAT = value;
                    this.SendPropertyChanged("HL7_FORMAT");
                    this.OnHL7_FORMATChanged();
                }
            }
        }

        [Column(Storage = "_HL7_SEND", DbType = "NVarChar(1)")]
        public System.Nullable<char> HL7_SEND
        {
            get
            {
                return this._HL7_SEND;
            }
            set
            {
                if ((this._HL7_SEND != value))
                {
                    this.OnHL7_SENDChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_SEND = value;
                    this.SendPropertyChanged("HL7_SEND");
                    this.OnHL7_SENDChanged();
                }
            }
        }

        [Column(Storage = "_LINK_DOWN", DbType = "NVarChar(1)")]
        public System.Nullable<char> LINK_DOWN
        {
            get
            {
                return this._LINK_DOWN;
            }
            set
            {
                if ((this._LINK_DOWN != value))
                {
                    this.OnLINK_DOWNChanging(value);
                    this.SendPropertyChanging();
                    this._LINK_DOWN = value;
                    this.SendPropertyChanged("LINK_DOWN");
                    this.OnLINK_DOWNChanged();
                }
            }
        }

        [Column(Storage = "_ALLERGIES", DbType = "NVarChar(100)")]
        public string ALLERGIES
        {
            get
            {
                return this._ALLERGIES;
            }
            set
            {
                if ((this._ALLERGIES != value))
                {
                    this.OnALLERGIESChanging(value);
                    this.SendPropertyChanging();
                    this._ALLERGIES = value;
                    this.SendPropertyChanged("ALLERGIES");
                    this.OnALLERGIESChanged();
                }
            }
        }

        [Column(Storage = "_ORG_ID", DbType = "Int")]
        public System.Nullable<int> ORG_ID
        {
            get
            {
                return this._ORG_ID;
            }
            set
            {
                if ((this._ORG_ID != value))
                {
                    this.OnORG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ID = value;
                    this.SendPropertyChanged("ORG_ID");
                    this.OnORG_IDChanged();
                }
            }
        }

        [Column(Storage = "_CREATED_BY", DbType = "Int")]
        public System.Nullable<int> CREATED_BY
        {
            get
            {
                return this._CREATED_BY;
            }
            set
            {
                if ((this._CREATED_BY != value))
                {
                    this.OnCREATED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_BY = value;
                    this.SendPropertyChanged("CREATED_BY");
                    this.OnCREATED_BYChanged();
                }
            }
        }

        [Column(Storage = "_CREATED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CREATED_ON
        {
            get
            {
                return this._CREATED_ON;
            }
            set
            {
                if ((this._CREATED_ON != value))
                {
                    this.OnCREATED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_ON = value;
                    this.SendPropertyChanged("CREATED_ON");
                    this.OnCREATED_ONChanged();
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_BY", DbType = "Int")]
        public System.Nullable<int> LAST_MODIFIED_BY
        {
            get
            {
                return this._LAST_MODIFIED_BY;
            }
            set
            {
                if ((this._LAST_MODIFIED_BY != value))
                {
                    this.OnLAST_MODIFIED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_BY = value;
                    this.SendPropertyChanged("LAST_MODIFIED_BY");
                    this.OnLAST_MODIFIED_BYChanged();
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LAST_MODIFIED_ON
        {
            get
            {
                return this._LAST_MODIFIED_ON;
            }
            set
            {
                if ((this._LAST_MODIFIED_ON != value))
                {
                    this.OnLAST_MODIFIED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_ON = value;
                    this.SendPropertyChanged("LAST_MODIFIED_ON");
                    this.OnLAST_MODIFIED_ONChanged();
                }
            }
        }

        [Column(Storage = "_IS_DELETED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DELETED
        {
            get
            {
                return this._IS_DELETED;
            }
            set
            {
                if ((this._IS_DELETED != value))
                {
                    this.OnIS_DELETEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_DELETED = value;
                    this.SendPropertyChanged("IS_DELETED");
                    this.OnIS_DELETEDChanged();
                }
            }
        }

        [Column(Storage = "_IS_UPDATED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_UPDATED
        {
            get
            {
                return this._IS_UPDATED;
            }
            set
            {
                if ((this._IS_UPDATED != value))
                {
                    this.OnIS_UPDATEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_UPDATED = value;
                    this.SendPropertyChanged("IS_UPDATED");
                    this.OnIS_UPDATEDChanged();
                }
            }
        }

        [Column(Storage = "_IS_JOHNDOE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_JOHNDOE
        {
            get
            {
                return this._IS_JOHNDOE;
            }
            set
            {
                if ((this._IS_JOHNDOE != value))
                {
                    this.OnIS_JOHNDOEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_JOHNDOE = value;
                    this.SendPropertyChanged("IS_JOHNDOE");
                    this.OnIS_JOHNDOEChanged();
                }
            }
        }

        [Association(Name = "HIS_REGISTRATION_FIN_INVOICE", Storage = "_FIN_INVOICEs", ThisKey = "HN", OtherKey = "HN")]
        public EntitySet<FIN_INVOICE> FIN_INVOICEs
        {
            get
            {
                return this._FIN_INVOICEs;
            }
            set
            {
                this._FIN_INVOICEs.Assign(value);
            }
        }

        [Association(Name = "HIS_REGISTRATION_FIN_PAYMENT", Storage = "_FIN_PAYMENTs", ThisKey = "HN", OtherKey = "HN")]
        public EntitySet<FIN_PAYMENT> FIN_PAYMENTs
        {
            get
            {
                return this._FIN_PAYMENTs;
            }
            set
            {
                this._FIN_PAYMENTs.Assign(value);
            }
        }

        [Association(Name = "HIS_REGISTRATION_RIS_ORDER", Storage = "_RIS_ORDERs", ThisKey = "REG_ID", OtherKey = "REG_ID")]
        public EntitySet<RIS_ORDER> RIS_ORDERs
        {
            get
            {
                return this._RIS_ORDERs;
            }
            set
            {
                this._RIS_ORDERs.Assign(value);
            }
        }

        [Association(Name = "HIS_REGISTRATION_RIS_ORDERIMAGE", Storage = "_RIS_ORDERIMAGEs", ThisKey = "HN", OtherKey = "HN")]
        public EntitySet<RIS_ORDERIMAGE> RIS_ORDERIMAGEs
        {
            get
            {
                return this._RIS_ORDERIMAGEs;
            }
            set
            {
                this._RIS_ORDERIMAGEs.Assign(value);
            }
        }

        [Association(Name = "HIS_REGISTRATION_RIS_SCHEDULE", Storage = "_RIS_SCHEDULEs", ThisKey = "REG_ID", OtherKey = "REG_ID")]
        public EntitySet<RIS_SCHEDULE> RIS_SCHEDULEs
        {
            get
            {
                return this._RIS_SCHEDULEs;
            }
            set
            {
                this._RIS_SCHEDULEs.Assign(value);
            }
        }

        [Association(Name = "HR_OCCUPATION_HIS_REGISTRATION", Storage = "_HR_OCCUPATION", ThisKey = "OCCUPATION_ID", OtherKey = "OCCUPATION_ID", IsForeignKey = true)]
        public HR_OCCUPATION HR_OCCUPATION
        {
            get
            {
                return this._HR_OCCUPATION.Entity;
            }
            set
            {
                HR_OCCUPATION previousValue = this._HR_OCCUPATION.Entity;
                if (((previousValue != value)
                            || (this._HR_OCCUPATION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_OCCUPATION.Entity = null;
                        previousValue.HIS_REGISTRATIONs.Remove(this);
                    }
                    this._HR_OCCUPATION.Entity = value;
                    if ((value != null))
                    {
                        value.HIS_REGISTRATIONs.Add(this);
                        this._OCCUPATION_ID = value.OCCUPATION_ID;
                    }
                    else
                    {
                        this._OCCUPATION_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_OCCUPATION");
                }
            }
        }
        public Byte[] Picture_Forsave { get; set; }

        public string S_HN { get { return _S_HN; } set { _S_HN = value; } }

        public string IS_FOREIGNER { get; set; }
        public string PATIENT_ID_LABEL { get; set; }
        public string PATIENT_ID_DETAIL { get; set; }


        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void attach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = this;
        }

        private void detach_FIN_INVOICEs(FIN_INVOICE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = null;
        }

        private void attach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = this;
        }

        private void detach_FIN_PAYMENTs(FIN_PAYMENT entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = null;
        }

        private void attach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = this;
        }

        private void detach_RIS_ORDERs(RIS_ORDER entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = null;
        }

        private void attach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = this;
        }

        private void detach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = null;
        }

        private void attach_RIS_SCHEDULEs(RIS_SCHEDULE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = this;
        }

        private void detach_RIS_SCHEDULEs(RIS_SCHEDULE entity)
        {
            this.SendPropertyChanging();
            entity.HIS_REGISTRATION = null;
        }
    }
}
