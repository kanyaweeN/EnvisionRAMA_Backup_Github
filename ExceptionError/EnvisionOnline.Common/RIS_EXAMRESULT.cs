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
    [Table(Name = "dbo.RIS_EXAMRESULT")]
    public partial class RIS_EXAMRESULT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private int _ORDER_ID;

        private int _EXAM_ID;

        private string _RESULT_TEXT_HTML;

        private string _RESULT_TEXT_PLAIN;

        private string _RESULT_TEXT_RTF;

        private System.Nullable<char> _RESULT_STATUS;

        private System.Nullable<int> _ICD_ID;

        private System.Nullable<int> _SEVERITY_ID;

        private string _HL7_TEXT;

        private System.Nullable<char> _HL7_SEND;

        private System.Nullable<int> _RELEASED_BY;

        private System.Nullable<System.DateTime> _RELEASED_ON;

        private System.Nullable<int> _FINALIZED_BY;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_EXAMRESULTNOTE> _RIS_EXAMRESULTNOTEs;

        private EntitySet<RIS_SEARCH_DTL> _RIS_SEARCH_DTLs;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<HR_EMP> _HR_EMP1;

        private EntityRef<RIS_EXAMRESULTSEVERITY> _RIS_EXAMRESULTSEVERITY;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnORDER_IDChanging(int value);
        partial void OnORDER_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnRESULT_TEXT_HTMLChanging(string value);
        partial void OnRESULT_TEXT_HTMLChanged();
        partial void OnRESULT_TEXT_PLAINChanging(string value);
        partial void OnRESULT_TEXT_PLAINChanged();
        partial void OnRESULT_TEXT_RTFChanging(string value);
        partial void OnRESULT_TEXT_RTFChanged();
        partial void OnRESULT_STATUSChanging(System.Nullable<char> value);
        partial void OnRESULT_STATUSChanged();
        partial void OnICD_IDChanging(System.Nullable<int> value);
        partial void OnICD_IDChanged();
        partial void OnSEVERITY_IDChanging(System.Nullable<int> value);
        partial void OnSEVERITY_IDChanged();
        partial void OnHL7_TEXTChanging(string value);
        partial void OnHL7_TEXTChanged();
        partial void OnHL7_SENDChanging(System.Nullable<char> value);
        partial void OnHL7_SENDChanged();
        partial void OnRELEASED_BYChanging(System.Nullable<int> value);
        partial void OnRELEASED_BYChanged();
        partial void OnRELEASED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnRELEASED_ONChanged();
        partial void OnFINALIZED_BYChanging(System.Nullable<int> value);
        partial void OnFINALIZED_BYChanged();
        partial void OnFINALIZED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnFINALIZED_ONChanged();
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
        #endregion

        public RIS_EXAMRESULT()
        {
            this._RIS_EXAMRESULTNOTEs = new EntitySet<RIS_EXAMRESULTNOTE>(new Action<RIS_EXAMRESULTNOTE>(this.attach_RIS_EXAMRESULTNOTEs), new Action<RIS_EXAMRESULTNOTE>(this.detach_RIS_EXAMRESULTNOTEs));
            this._RIS_SEARCH_DTLs = new EntitySet<RIS_SEARCH_DTL>(new Action<RIS_SEARCH_DTL>(this.attach_RIS_SEARCH_DTLs), new Action<RIS_SEARCH_DTL>(this.detach_RIS_SEARCH_DTLs));
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._HR_EMP1 = default(EntityRef<HR_EMP>);
            this._RIS_EXAMRESULTSEVERITY = default(EntityRef<RIS_EXAMRESULTSEVERITY>);
            OnCreated();
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ACCESSION_NO
        {
            get
            {
                return this._ACCESSION_NO;
            }
            set
            {
                if ((this._ACCESSION_NO != value))
                {
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_ORDER_ID", DbType = "Int NOT NULL")]
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

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL")]
        public int EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_HTML", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_HTML
        {
            get
            {
                return this._RESULT_TEXT_HTML;
            }
            set
            {
                if ((this._RESULT_TEXT_HTML != value))
                {
                    this.OnRESULT_TEXT_HTMLChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_HTML = value;
                    this.SendPropertyChanged("RESULT_TEXT_HTML");
                    this.OnRESULT_TEXT_HTMLChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_PLAIN", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_PLAIN
        {
            get
            {
                return this._RESULT_TEXT_PLAIN;
            }
            set
            {
                if ((this._RESULT_TEXT_PLAIN != value))
                {
                    this.OnRESULT_TEXT_PLAINChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_PLAIN = value;
                    this.SendPropertyChanged("RESULT_TEXT_PLAIN");
                    this.OnRESULT_TEXT_PLAINChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_RTF", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_RTF
        {
            get
            {
                return this._RESULT_TEXT_RTF;
            }
            set
            {
                if ((this._RESULT_TEXT_RTF != value))
                {
                    this.OnRESULT_TEXT_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_TEXT_RTF = value;
                    this.SendPropertyChanged("RESULT_TEXT_RTF");
                    this.OnRESULT_TEXT_RTFChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> RESULT_STATUS
        {
            get
            {
                return this._RESULT_STATUS;
            }
            set
            {
                if ((this._RESULT_STATUS != value))
                {
                    this.OnRESULT_STATUSChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_STATUS = value;
                    this.SendPropertyChanged("RESULT_STATUS");
                    this.OnRESULT_STATUSChanged();
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

        [Column(Storage = "_SEVERITY_ID", DbType = "Int")]
        public System.Nullable<int> SEVERITY_ID
        {
            get
            {
                return this._SEVERITY_ID;
            }
            set
            {
                if ((this._SEVERITY_ID != value))
                {
                    if (this._RIS_EXAMRESULTSEVERITY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSEVERITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SEVERITY_ID = value;
                    this.SendPropertyChanged("SEVERITY_ID");
                    this.OnSEVERITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_HL7_TEXT", DbType = "NVarChar(MAX)")]
        public string HL7_TEXT
        {
            get
            {
                return this._HL7_TEXT;
            }
            set
            {
                if ((this._HL7_TEXT != value))
                {
                    this.OnHL7_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_TEXT = value;
                    this.SendPropertyChanged("HL7_TEXT");
                    this.OnHL7_TEXTChanged();
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

        [Column(Storage = "_RELEASED_BY", DbType = "Int")]
        public System.Nullable<int> RELEASED_BY
        {
            get
            {
                return this._RELEASED_BY;
            }
            set
            {
                if ((this._RELEASED_BY != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRELEASED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_BY = value;
                    this.SendPropertyChanged("RELEASED_BY");
                    this.OnRELEASED_BYChanged();
                }
            }
        }

        [Column(Storage = "_RELEASED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RELEASED_ON
        {
            get
            {
                return this._RELEASED_ON;
            }
            set
            {
                if ((this._RELEASED_ON != value))
                {
                    this.OnRELEASED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._RELEASED_ON = value;
                    this.SendPropertyChanged("RELEASED_ON");
                    this.OnRELEASED_ONChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_BY", DbType = "Int")]
        public System.Nullable<int> FINALIZED_BY
        {
            get
            {
                return this._FINALIZED_BY;
            }
            set
            {
                if ((this._FINALIZED_BY != value))
                {
                    if (this._HR_EMP1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFINALIZED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_BY = value;
                    this.SendPropertyChanged("FINALIZED_BY");
                    this.OnFINALIZED_BYChanged();
                }
            }
        }

        [Column(Storage = "_FINALIZED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> FINALIZED_ON
        {
            get
            {
                return this._FINALIZED_ON;
            }
            set
            {
                if ((this._FINALIZED_ON != value))
                {
                    this.OnFINALIZED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._FINALIZED_ON = value;
                    this.SendPropertyChanged("FINALIZED_ON");
                    this.OnFINALIZED_ONChanged();
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

        [Association(Name = "RIS_EXAMRESULT_RIS_EXAMRESULTNOTE", Storage = "_RIS_EXAMRESULTNOTEs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_EXAMRESULTNOTE> RIS_EXAMRESULTNOTEs
        {
            get
            {
                return this._RIS_EXAMRESULTNOTEs;
            }
            set
            {
                this._RIS_EXAMRESULTNOTEs.Assign(value);
            }
        }

        [Association(Name = "RIS_EXAMRESULT_RIS_SEARCH_DTL", Storage = "_RIS_SEARCH_DTLs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_SEARCH_DTL> RIS_SEARCH_DTLs
        {
            get
            {
                return this._RIS_SEARCH_DTLs;
            }
            set
            {
                this._RIS_SEARCH_DTLs.Assign(value);
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTs.Add(this);
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULT", Storage = "_HR_EMP", ThisKey = "RELEASED_BY", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTs.Add(this);
                        this._RELEASED_BY = value.EMP_ID;
                    }
                    else
                    {
                        this._RELEASED_BY = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "HR_EMP_RIS_EXAMRESULT1", Storage = "_HR_EMP1", ThisKey = "FINALIZED_BY", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP1
        {
            get
            {
                return this._HR_EMP1.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP1.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP1.Entity = null;
                        previousValue.RIS_EXAMRESULTs1.Remove(this);
                    }
                    this._HR_EMP1.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTs1.Add(this);
                        this._FINALIZED_BY = value.EMP_ID;
                    }
                    else
                    {
                        this._FINALIZED_BY = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP1");
                }
            }
        }

        [Association(Name = "RIS_EXAMRESULTSEVERITY_RIS_EXAMRESULT", Storage = "_RIS_EXAMRESULTSEVERITY", ThisKey = "SEVERITY_ID", OtherKey = "SEVERITY_ID", IsForeignKey = true)]
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY
        {
            get
            {
                return this._RIS_EXAMRESULTSEVERITY.Entity;
            }
            set
            {
                RIS_EXAMRESULTSEVERITY previousValue = this._RIS_EXAMRESULTSEVERITY.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAMRESULTSEVERITY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAMRESULTSEVERITY.Entity = null;
                        previousValue.RIS_EXAMRESULTs.Remove(this);
                    }
                    this._RIS_EXAMRESULTSEVERITY.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTs.Add(this);
                        this._SEVERITY_ID = value.SEVERITY_ID;
                    }
                    else
                    {
                        this._SEVERITY_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_EXAMRESULTSEVERITY");
                }
            }
        }

        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public int EMP_ID { get; set; }
        public int MODE { get; set; }
        public string STATUS { get; set; }
        public string HN { get; set; }
        public string MERGE { get; set; }
        public string MERGE_WITH { get; set; }
        public int ASSIGNED_TO { get; set; }
        public string TEMPMODE { get; set; }
        public int REASON { get; set; }

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

        private void attach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULT = this;
        }

        private void detach_RIS_EXAMRESULTNOTEs(RIS_EXAMRESULTNOTE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULT = null;
        }

        private void attach_RIS_SEARCH_DTLs(RIS_SEARCH_DTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULT = this;
        }

        private void detach_RIS_SEARCH_DTLs(RIS_SEARCH_DTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_EXAMRESULT = null;
        }
    }
}
