using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{
    [Table(Name = "dbo.RIS_ORDER")]
    public partial class RIS_ORDER : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ORDER_ID;

        private int _REG_ID;

        private string _HN;

        private string _VISIT_NO;

        private string _ADMISSION_NO;

        private string _XRAY_NO;

        private System.DateTime _ORDER_DT;

        private System.Nullable<int> _SCHEDULE_ID;

        private System.Nullable<int> _INSURANCE_TYPE_ID;

        private System.Nullable<System.DateTime> _ORDER_START_TIME;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _PAT_STATUS;

        private string _REF_DOC_INSTRUCTION;

        private string _CLINICAL_INSTRUCTION;

        private string _REASON;

        private string _DIAGNOSIS;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<int> _ARRIVAL_BY;

        private System.Nullable<System.DateTime> _ARRIVAL_ON;

        private System.Nullable<char> _IS_CANCELED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<System.DateTime> _LMP_DT;

        private EntitySet<RIS_BILL> _RIS_BILLs;

        private EntitySet<RIS_ORDERDTL> _RIS_ORDERDTLs;

        private EntitySet<RIS_ORDERIMAGE> _RIS_ORDERIMAGEs;

        private EntitySet<RIS_RELEASEMEDIA> _RIS_RELEASEMEDIAs;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HIS_REGISTRATION> _HIS_REGISTRATION;

        private EntityRef<RIS_INSURANCETYPE> _RIS_INSURANCETYPE;

        private EntityRef<RIS_SCHEDULE> _RIS_SCHEDULE;

        private string _ENC_ID;
        private string _ENC_TYPE;
        private string _ENC_CLINIC;
        private string _IS_ALERT_CLINICAL_INSTRUCTION;
        private string _CLINICAL_INSTRUCTION_TAG;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnORDER_IDChanging(int value);
        partial void OnORDER_IDChanged();
        partial void OnREG_IDChanging(int value);
        partial void OnREG_IDChanged();
        partial void OnHNChanging(string value);
        partial void OnHNChanged();
        partial void OnVISIT_NOChanging(string value);
        partial void OnVISIT_NOChanged();
        partial void OnXRAY_NOChanging(string value);
        partial void OnXRAY_NOChanged();
        partial void OnADMISSION_NOChanging(string value);
        partial void OnADMISSION_NOChanged();
        partial void OnORDER_DTChanging(System.DateTime value);
        partial void OnORDER_DTChanged();
        partial void OnSCHEDULE_IDChanging(System.Nullable<int> value);
        partial void OnSCHEDULE_IDChanged();
        partial void OnINSURANCE_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnINSURANCE_TYPE_IDChanged();
        partial void OnORDER_START_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnORDER_START_TIMEChanged();
        partial void OnREF_UNITChanging(System.Nullable<int> value);
        partial void OnREF_UNITChanged();
        partial void OnREF_DOCChanging(System.Nullable<int> value);
        partial void OnREF_DOCChanged();
        partial void OnPAT_STATUSChanging(string value);
        partial void OnPAT_STATUSChanged();
        partial void OnREF_DOC_INSTRUCTIONChanging(string value);
        partial void OnREF_DOC_INSTRUCTIONChanged();
        partial void OnCLINICAL_INSTRUCTIONChanging(string value);
        partial void OnCLINICAL_INSTRUCTIONChanged();
        partial void OnREASONChanging(string value);
        partial void OnREASONChanged();
        partial void OnDIAGNOSISChanging(string value);
        partial void OnDIAGNOSISChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnARRIVAL_BYChanging(System.Nullable<int> value);
        partial void OnARRIVAL_BYChanged();
        partial void OnARRIVAL_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnARRIVAL_ONChanged();
        partial void OnIS_CANCELEDChanging(System.Nullable<char> value);
        partial void OnIS_CANCELEDChanged();
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
        partial void OnLMP_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnLMP_DTChanged();
        #endregion

        public RIS_ORDER()
        {
            this._RIS_BILLs = new EntitySet<RIS_BILL>(new Action<RIS_BILL>(this.attach_RIS_BILLs), new Action<RIS_BILL>(this.detach_RIS_BILLs));
            this._RIS_ORDERDTLs = new EntitySet<RIS_ORDERDTL>(new Action<RIS_ORDERDTL>(this.attach_RIS_ORDERDTLs), new Action<RIS_ORDERDTL>(this.detach_RIS_ORDERDTLs));
            this._RIS_ORDERIMAGEs = new EntitySet<RIS_ORDERIMAGE>(new Action<RIS_ORDERIMAGE>(this.attach_RIS_ORDERIMAGEs), new Action<RIS_ORDERIMAGE>(this.detach_RIS_ORDERIMAGEs));
            this._RIS_RELEASEMEDIAs = new EntitySet<RIS_RELEASEMEDIA>(new Action<RIS_RELEASEMEDIA>(this.attach_RIS_RELEASEMEDIAs), new Action<RIS_RELEASEMEDIA>(this.detach_RIS_RELEASEMEDIAs));
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HIS_REGISTRATION = default(EntityRef<HIS_REGISTRATION>);
            this._RIS_INSURANCETYPE = default(EntityRef<RIS_INSURANCETYPE>);
            this._RIS_SCHEDULE = default(EntityRef<RIS_SCHEDULE>);
            OnCreated();
        }

        [Column(Storage = "_ORDER_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Column(Storage = "_REG_ID", DbType = "Int NOT NULL")]
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
                    if (this._HIS_REGISTRATION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnREG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REG_ID = value;
                    this.SendPropertyChanged("REG_ID");
                    this.OnREG_IDChanged();
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30)")]
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

        [Column(Storage = "_VISIT_NO", DbType = "NVarChar(30)")]
        public string VISIT_NO
        {
            get
            {
                return this._VISIT_NO;
            }
            set
            {
                if ((this._VISIT_NO != value))
                {
                    this.OnVISIT_NOChanging(value);
                    this.SendPropertyChanging();
                    this._VISIT_NO = value;
                    this.SendPropertyChanged("VISIT_NO");
                    this.OnVISIT_NOChanged();
                }
            }
        }

        [Column(Storage = "_XRAY_NO", DbType = "NVarChar(30)")]
        public string XRAY_NO
        {
            get
            {
                return this._XRAY_NO;
            }
            set
            {
                if ((this._XRAY_NO != value))
                {
                    this.OnXRAY_NOChanging(value);
                    this.SendPropertyChanging();
                    this._XRAY_NO = value;
                    this.SendPropertyChanged("XRAY_NO");
                    this.OnXRAY_NOChanged();
                }
            }
        }

        [Column(Storage = "_ADMISSION_NO", DbType = "NVarChar(30)")]
        public string ADMISSION_NO
        {
            get
            {
                return this._ADMISSION_NO;
            }
            set
            {
                if ((this._ADMISSION_NO != value))
                {
                    this.OnADMISSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ADMISSION_NO = value;
                    this.SendPropertyChanged("ADMISSION_NO");
                    this.OnADMISSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime ORDER_DT
        {
            get
            {
                return this._ORDER_DT;
            }
            set
            {
                if ((this._ORDER_DT != value))
                {
                    this.OnORDER_DTChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_DT = value;
                    this.SendPropertyChanged("ORDER_DT");
                    this.OnORDER_DTChanged();
                }
            }
        }

        [Column(Storage = "_SCHEDULE_ID", DbType = "Int")]
        public System.Nullable<int> SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    if (this._RIS_SCHEDULE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSCHEDULE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID = value;
                    this.SendPropertyChanged("SCHEDULE_ID");
                    this.OnSCHEDULE_IDChanged();
                }
            }
        }

        [Column(Storage = "_INSURANCE_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> INSURANCE_TYPE_ID
        {
            get
            {
                return this._INSURANCE_TYPE_ID;
            }
            set
            {
                if ((this._INSURANCE_TYPE_ID != value))
                {
                    if (this._RIS_INSURANCETYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnINSURANCE_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._INSURANCE_TYPE_ID = value;
                    this.SendPropertyChanged("INSURANCE_TYPE_ID");
                    this.OnINSURANCE_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ORDER_START_TIME
        {
            get
            {
                return this._ORDER_START_TIME;
            }
            set
            {
                if ((this._ORDER_START_TIME != value))
                {
                    this.OnORDER_START_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_START_TIME = value;
                    this.SendPropertyChanged("ORDER_START_TIME");
                    this.OnORDER_START_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_REF_UNIT", DbType = "Int")]
        public System.Nullable<int> REF_UNIT
        {
            get
            {
                return this._REF_UNIT;
            }
            set
            {
                if ((this._REF_UNIT != value))
                {
                    this.OnREF_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._REF_UNIT = value;
                    this.SendPropertyChanged("REF_UNIT");
                    this.OnREF_UNITChanged();
                }
            }
        }

        [Column(Storage = "_REF_DOC", DbType = "Int")]
        public System.Nullable<int> REF_DOC
        {
            get
            {
                return this._REF_DOC;
            }
            set
            {
                if ((this._REF_DOC != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnREF_DOCChanging(value);
                    this.SendPropertyChanging();
                    this._REF_DOC = value;
                    this.SendPropertyChanged("REF_DOC");
                    this.OnREF_DOCChanged();
                }
            }
        }

        [Column(Storage = "_PAT_STATUS", DbType = "NVarChar(3)")]
        public string PAT_STATUS
        {
            get
            {
                return this._PAT_STATUS;
            }
            set
            {
                if ((this._PAT_STATUS != value))
                {
                    this.OnPAT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._PAT_STATUS = value;
                    this.SendPropertyChanged("PAT_STATUS");
                    this.OnPAT_STATUSChanged();
                }
            }
        }

        [Column(Storage = "_REF_DOC_INSTRUCTION", DbType = "NVarChar(500)")]
        public string REF_DOC_INSTRUCTION
        {
            get
            {
                return this._REF_DOC_INSTRUCTION;
            }
            set
            {
                if ((this._REF_DOC_INSTRUCTION != value))
                {
                    this.OnREF_DOC_INSTRUCTIONChanging(value);
                    this.SendPropertyChanging();
                    this._REF_DOC_INSTRUCTION = value;
                    this.SendPropertyChanged("REF_DOC_INSTRUCTION");
                    this.OnREF_DOC_INSTRUCTIONChanged();
                }
            }
        }

        [Column(Storage = "_CLINICAL_INSTRUCTION", DbType = "NVarChar(2000)")]
        public string CLINICAL_INSTRUCTION
        {
            get
            {
                return this._CLINICAL_INSTRUCTION;
            }
            set
            {
                if ((this._CLINICAL_INSTRUCTION != value))
                {
                    this.OnCLINICAL_INSTRUCTIONChanging(value);
                    this.SendPropertyChanging();
                    this._CLINICAL_INSTRUCTION = value;
                    this.SendPropertyChanged("CLINICAL_INSTRUCTION");
                    this.OnCLINICAL_INSTRUCTIONChanged();
                }
            }
        }

        [Column(Storage = "_REASON", DbType = "NVarChar(1000)")]
        public string REASON
        {
            get
            {
                return this._REASON;
            }
            set
            {
                if ((this._REASON != value))
                {
                    this.OnREASONChanging(value);
                    this.SendPropertyChanging();
                    this._REASON = value;
                    this.SendPropertyChanged("REASON");
                    this.OnREASONChanged();
                }
            }
        }

        [Column(Storage = "_DIAGNOSIS", DbType = "NVarChar(1000)")]
        public string DIAGNOSIS
        {
            get
            {
                return this._DIAGNOSIS;
            }
            set
            {
                if ((this._DIAGNOSIS != value))
                {
                    this.OnDIAGNOSISChanging(value);
                    this.SendPropertyChanging();
                    this._DIAGNOSIS = value;
                    this.SendPropertyChanged("DIAGNOSIS");
                    this.OnDIAGNOSISChanged();
                }
            }
        }

        [Column(Storage = "_ICD_ID", DbType = "Int")]
        public System.Nullable<int> ICD_ID
        {
            get
            {
                return this._ICD_ID;
            }
            set
            {
                if ((this._ICD_ID != value))
                {
                    this.OnICD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ICD_ID = value;
                    this.SendPropertyChanged("ICD_ID");
                    this.OnICD_IDChanged();
                }
            }
        }

        [Column(Storage = "_ARRIVAL_BY", DbType = "Int")]
        public System.Nullable<int> ARRIVAL_BY
        {
            get
            {
                return this._ARRIVAL_BY;
            }
            set
            {
                if ((this._ARRIVAL_BY != value))
                {
                    this.OnARRIVAL_BYChanging(value);
                    this.SendPropertyChanging();
                    this._ARRIVAL_BY = value;
                    this.SendPropertyChanged("ARRIVAL_BY");
                    this.OnARRIVAL_BYChanged();
                }
            }
        }

        [Column(Storage = "_ARRIVAL_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ARRIVAL_ON
        {
            get
            {
                return this._ARRIVAL_ON;
            }
            set
            {
                if ((this._ARRIVAL_ON != value))
                {
                    this.OnARRIVAL_ONChanging(value);
                    this.SendPropertyChanging();
                    this._ARRIVAL_ON = value;
                    this.SendPropertyChanged("ARRIVAL_ON");
                    this.OnARRIVAL_ONChanged();
                }
            }
        }

        [Column(Storage = "_IS_CANCELED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_CANCELED
        {
            get
            {
                return this._IS_CANCELED;
            }
            set
            {
                if ((this._IS_CANCELED != value))
                {
                    this.OnIS_CANCELEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_CANCELED = value;
                    this.SendPropertyChanged("IS_CANCELED");
                    this.OnIS_CANCELEDChanged();
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
                    if (this._GBL_ENV.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [Column(Storage = "_LMP_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LMP_DT
        {
            get
            {
                return this._LMP_DT;
            }
            set
            {
                if ((this._LMP_DT != value))
                {
                    this.OnLMP_DTChanging(value);
                    this.SendPropertyChanging();
                    this._LMP_DT = value;
                    this.SendPropertyChanged("LMP_DT");
                    this.OnLMP_DTChanged();
                }
            }
        }

        public string ENC_ID
        {
            get
            {
                return this._ENC_ID;
            }
            set
            {
                this._ENC_ID = value;
            }
        }

        public string ENC_TYPE
        {
            get
            {
                return this._ENC_TYPE;
            }
            set
            {
                this._ENC_TYPE = value;
            }
        }

        public string ENC_CLINIC
        {
            get
            {
                return this._ENC_CLINIC;
            }
            set
            {
                this._ENC_CLINIC = value;
            }
        }

        public string IS_ALERT_CLINICAL_INSTRUCTION
        {
            get
            {
                return this._IS_ALERT_CLINICAL_INSTRUCTION;
            }
            set
            {
                this._IS_ALERT_CLINICAL_INSTRUCTION = value;
            }
        }

        public string CLINICAL_INSTRUCTION_TAG
        {
            get
            {
                return this._CLINICAL_INSTRUCTION_TAG;
            }
            set
            {
                this._CLINICAL_INSTRUCTION_TAG = value;
            }
        }

        [Association(Name = "RIS_ORDER_RIS_BILL", Storage = "_RIS_BILLs", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID")]
        public EntitySet<RIS_BILL> RIS_BILLs
        {
            get
            {
                return this._RIS_BILLs;
            }
            set
            {
                this._RIS_BILLs.Assign(value);
            }
        }

        [Association(Name = "RIS_ORDER_RIS_ORDERDTL", Storage = "_RIS_ORDERDTLs", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID")]
        public EntitySet<RIS_ORDERDTL> RIS_ORDERDTLs
        {
            get
            {
                return this._RIS_ORDERDTLs;
            }
            set
            {
                this._RIS_ORDERDTLs.Assign(value);
            }
        }

        [Association(Name = "RIS_ORDER_RIS_ORDERIMAGE", Storage = "_RIS_ORDERIMAGEs", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID")]
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

        [Association(Name = "RIS_ORDER_RIS_RELEASEMEDIA", Storage = "_RIS_RELEASEMEDIAs", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID")]
        public EntitySet<RIS_RELEASEMEDIA> RIS_RELEASEMEDIAs
        {
            get
            {
                return this._RIS_RELEASEMEDIAs;
            }
            set
            {
                this._RIS_RELEASEMEDIAs.Assign(value);
            }
        }

        [Association(Name = "HR_EMP_RIS_ORDER", Storage = "_HR_EMP", ThisKey = "REF_DOC", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.RIS_ORDERs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERs.Add(this);
                        this._REF_DOC = value.EMP_ID;
                    }
                    else
                    {
                        this._REF_DOC = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDER", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV
        {
            get
            {
                return this._GBL_ENV.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV.Entity = null;
                        previousValue.RIS_ORDERs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERs.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV");
                }
            }
        }

        [Association(Name = "HIS_REGISTRATION_RIS_ORDER", Storage = "_HIS_REGISTRATION", ThisKey = "REG_ID", OtherKey = "REG_ID", IsForeignKey = true)]
        public HIS_REGISTRATION HIS_REGISTRATION
        {
            get
            {
                return this._HIS_REGISTRATION.Entity;
            }
            set
            {
                HIS_REGISTRATION previousValue = this._HIS_REGISTRATION.Entity;
                if (((previousValue != value)
                            || (this._HIS_REGISTRATION.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HIS_REGISTRATION.Entity = null;
                        previousValue.RIS_ORDERs.Remove(this);
                    }
                    this._HIS_REGISTRATION.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERs.Add(this);
                        this._REG_ID = value.REG_ID;
                    }
                    else
                    {
                        this._REG_ID = default(int);
                    }
                    this.SendPropertyChanged("HIS_REGISTRATION");
                }
            }
        }

        [Association(Name = "RIS_INSURANCETYPE_RIS_ORDER", Storage = "_RIS_INSURANCETYPE", ThisKey = "INSURANCE_TYPE_ID", OtherKey = "INSURANCE_TYPE_ID", IsForeignKey = true)]
        public RIS_INSURANCETYPE RIS_INSURANCETYPE
        {
            get
            {
                return this._RIS_INSURANCETYPE.Entity;
            }
            set
            {
                RIS_INSURANCETYPE previousValue = this._RIS_INSURANCETYPE.Entity;
                if (((previousValue != value)
                            || (this._RIS_INSURANCETYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_INSURANCETYPE.Entity = null;
                        previousValue.RIS_ORDERs.Remove(this);
                    }
                    this._RIS_INSURANCETYPE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERs.Add(this);
                        this._INSURANCE_TYPE_ID = value.INSURANCE_TYPE_ID;
                    }
                    else
                    {
                        this._INSURANCE_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_INSURANCETYPE");
                }
            }
        }

        [Association(Name = "RIS_SCHEDULE_RIS_ORDER", Storage = "_RIS_SCHEDULE", ThisKey = "SCHEDULE_ID", OtherKey = "SCHEDULE_ID", IsForeignKey = true)]
        public RIS_SCHEDULE RIS_SCHEDULE
        {
            get
            {
                return this._RIS_SCHEDULE.Entity;
            }
            set
            {
                RIS_SCHEDULE previousValue = this._RIS_SCHEDULE.Entity;
                if (((previousValue != value)
                            || (this._RIS_SCHEDULE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_SCHEDULE.Entity = null;
                        previousValue.RIS_ORDERs.Remove(this);
                    }
                    this._RIS_SCHEDULE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERs.Add(this);
                        this._SCHEDULE_ID = value.SCHEDULE_ID;
                    }
                    else
                    {
                        this._SCHEDULE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_SCHEDULE");
                }
            }
        }

        public string SELF_ARRIVAL { get; set; }
        public string REQUESTNO { get; set; }
        public string IS_REQONLINE { get; set; }
        public DateTime REQUEST_RESULT_DATETIME { get; set; }
        public bool HAS_REQUEST_RESULT { get; set; }

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

        private void attach_RIS_BILLs(RIS_BILL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = this;
        }

        private void detach_RIS_BILLs(RIS_BILL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = null;
        }

        private void attach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = this;
        }

        private void detach_RIS_ORDERDTLs(RIS_ORDERDTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = null;
        }

        private void attach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = this;
        }

        private void detach_RIS_ORDERIMAGEs(RIS_ORDERIMAGE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = null;
        }

        private void attach_RIS_RELEASEMEDIAs(RIS_RELEASEMEDIA entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = this;
        }

        private void detach_RIS_RELEASEMEDIAs(RIS_RELEASEMEDIA entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDER = null;
        }
    }
}
