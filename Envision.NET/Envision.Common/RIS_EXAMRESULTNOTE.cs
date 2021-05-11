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
    [Table(Name = "dbo.RIS_EXAMRESULTNOTE")]
    public partial class RIS_EXAMRESULTNOTE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ORDER_ID;

        private int _EXAM_ID;

        private string _ACCESSION_NO;

        private int _NOTE_NO;

        private string _NOTE_TEXT;

        private System.Nullable<int> _NOTE_BY;

        private System.Nullable<System.DateTime> _NOTE_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private string _NOTE_TEXT_RTF;

        

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<RIS_EXAMRESULT> _RIS_EXAMRESULT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnORDER_IDChanging(int value);
        partial void OnORDER_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnNOTE_NOChanging(int value);
        partial void OnNOTE_NOChanged();
        partial void OnNOTE_TEXTChanging(string value);
        partial void OnNOTE_TEXTChanged();
        partial void OnNOTE_BYChanging(System.Nullable<int> value);
        partial void OnNOTE_BYChanged();
        partial void OnNOTE_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnNOTE_ONChanged();
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
        partial void OnNOTE_TEXT_RTFChanging(string value);
        partial void OnNOTE_TEXT_RTFChanged();
        #endregion

        public RIS_EXAMRESULTNOTE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._RIS_EXAMRESULT = default(EntityRef<RIS_EXAMRESULT>);
            OnCreated();
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
                    if (this._RIS_EXAMRESULT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_NOTE_NO", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int NOTE_NO
        {
            get
            {
                return this._NOTE_NO;
            }
            set
            {
                if ((this._NOTE_NO != value))
                {
                    this.OnNOTE_NOChanging(value);
                    this.SendPropertyChanging();
                    this._NOTE_NO = value;
                    this.SendPropertyChanged("NOTE_NO");
                    this.OnNOTE_NOChanged();
                }
            }
        }

        [Column(Storage = "_NOTE_TEXT", DbType = "NVarChar(MAX)")]
        public string NOTE_TEXT
        {
            get
            {
                return this._NOTE_TEXT;
            }
            set
            {
                if ((this._NOTE_TEXT != value))
                {
                    this.OnNOTE_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._NOTE_TEXT = value;
                    this.SendPropertyChanged("NOTE_TEXT");
                    this.OnNOTE_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_NOTE_BY", DbType = "Int")]
        public System.Nullable<int> NOTE_BY
        {
            get
            {
                return this._NOTE_BY;
            }
            set
            {
                if ((this._NOTE_BY != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnNOTE_BYChanging(value);
                    this.SendPropertyChanging();
                    this._NOTE_BY = value;
                    this.SendPropertyChanged("NOTE_BY");
                    this.OnNOTE_BYChanged();
                }
            }
        }

        [Column(Storage = "_NOTE_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> NOTE_ON
        {
            get
            {
                return this._NOTE_ON;
            }
            set
            {
                if ((this._NOTE_ON != value))
                {
                    this.OnNOTE_ONChanging(value);
                    this.SendPropertyChanging();
                    this._NOTE_ON = value;
                    this.SendPropertyChanged("NOTE_ON");
                    this.OnNOTE_ONChanged();
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

        [Column(Storage = "_NOTE_TEXT_RTF", DbType = "NVarChar(MAX)")]
        public string NOTE_TEXT_RTF
        {
            get
            {
                return this._NOTE_TEXT_RTF;
            }
            set
            {
                if ((this._NOTE_TEXT_RTF != value))
                {
                    this.OnNOTE_TEXT_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._NOTE_TEXT_RTF = value;
                    this.SendPropertyChanged("NOTE_TEXT_RTF");
                    this.OnNOTE_TEXT_RTFChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_EXAMRESULTNOTE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTNOTEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTNOTEs.Add(this);
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

        [Association(Name = "HR_EMP_RIS_EXAMRESULTNOTE", Storage = "_HR_EMP", ThisKey = "NOTE_BY", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMRESULTNOTEs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTNOTEs.Add(this);
                        this._NOTE_BY = value.EMP_ID;
                    }
                    else
                    {
                        this._NOTE_BY = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "RIS_EXAMRESULT_RIS_EXAMRESULTNOTE", Storage = "_RIS_EXAMRESULT", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO", IsForeignKey = true)]
        public RIS_EXAMRESULT RIS_EXAMRESULT
        {
            get
            {
                return this._RIS_EXAMRESULT.Entity;
            }
            set
            {
                RIS_EXAMRESULT previousValue = this._RIS_EXAMRESULT.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAMRESULT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAMRESULT.Entity = null;
                        previousValue.RIS_EXAMRESULTNOTEs.Remove(this);
                    }
                    this._RIS_EXAMRESULT.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMRESULTNOTEs.Add(this);
                        this._ACCESSION_NO = value.ACCESSION_NO;
                    }
                    else
                    {
                        this._ACCESSION_NO = default(string);
                    }
                    this.SendPropertyChanged("RIS_EXAMRESULT");
                }
            }
        }

        public string HL7_TEXT { get; set; }

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
    }
}
