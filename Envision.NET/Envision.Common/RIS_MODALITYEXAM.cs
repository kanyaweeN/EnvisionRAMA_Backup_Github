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
    [Table(Name = "dbo.RIS_MODALITYEXAM")]
    public partial class RIS_MODALITYEXAM : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _MODALITY_EXAM_ID;

        private int _MODALITY_ID;

        private int _EXAM_ID;

        private System.Nullable<char> _TECH_BYPASS;

        private System.Nullable<char> _QA_BYPASS;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _IS_DEFAULT_MODALITY;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_MODALITY> _RIS_MODALITY;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMODALITY_EXAM_IDChanging(int value);
        partial void OnMODALITY_EXAM_IDChanged();
        partial void OnMODALITY_IDChanging(int value);
        partial void OnMODALITY_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnTECH_BYPASSChanging(System.Nullable<char> value);
        partial void OnTECH_BYPASSChanged();
        partial void OnQA_BYPASSChanging(System.Nullable<char> value);
        partial void OnQA_BYPASSChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnIS_DEFAULT_MODALITYChanging(System.Nullable<char> value);
        partial void OnIS_DEFAULT_MODALITYChanged();
        partial void OnIS_UPDATEDChanging(System.Nullable<char> value);
        partial void OnIS_UPDATEDChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
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

        public RIS_MODALITYEXAM()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_MODALITY = default(EntityRef<RIS_MODALITY>);
            OnCreated();
        }

        [Column(Storage = "_MODALITY_EXAM_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int MODALITY_EXAM_ID
        {
            get
            {
                return this._MODALITY_EXAM_ID;
            }
            set
            {
                if ((this._MODALITY_EXAM_ID != value))
                {
                    this.OnMODALITY_EXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_EXAM_ID = value;
                    this.SendPropertyChanged("MODALITY_EXAM_ID");
                    this.OnMODALITY_EXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int NOT NULL")]
        public int MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    if (this._RIS_MODALITY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
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
                    if (this._RIS_EXAM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_TECH_BYPASS", DbType = "NVarChar(1)")]
        public System.Nullable<char> TECH_BYPASS
        {
            get
            {
                return this._TECH_BYPASS;
            }
            set
            {
                if ((this._TECH_BYPASS != value))
                {
                    this.OnTECH_BYPASSChanging(value);
                    this.SendPropertyChanging();
                    this._TECH_BYPASS = value;
                    this.SendPropertyChanged("TECH_BYPASS");
                    this.OnTECH_BYPASSChanged();
                }
            }
        }

        [Column(Storage = "_QA_BYPASS", DbType = "NVarChar(1)")]
        public System.Nullable<char> QA_BYPASS
        {
            get
            {
                return this._QA_BYPASS;
            }
            set
            {
                if ((this._QA_BYPASS != value))
                {
                    this.OnQA_BYPASSChanging(value);
                    this.SendPropertyChanging();
                    this._QA_BYPASS = value;
                    this.SendPropertyChanged("QA_BYPASS");
                    this.OnQA_BYPASSChanged();
                }
            }
        }

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this.OnIS_ACTIVEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_ACTIVE = value;
                    this.SendPropertyChanged("IS_ACTIVE");
                    this.OnIS_ACTIVEChanged();
                }
            }
        }

        [Column(Storage = "_IS_DEFAULT_MODALITY", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DEFAULT_MODALITY
        {
            get
            {
                return this._IS_DEFAULT_MODALITY;
            }
            set
            {
                if ((this._IS_DEFAULT_MODALITY != value))
                {
                    this.OnIS_DEFAULT_MODALITYChanging(value);
                    this.SendPropertyChanging();
                    this._IS_DEFAULT_MODALITY = value;
                    this.SendPropertyChanged("IS_DEFAULT_MODALITY");
                    this.OnIS_DEFAULT_MODALITYChanged();
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

        [Association(Name = "GBL_ENV_RIS_MODALITYEXAM", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_MODALITYEXAMs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITYEXAMs.Add(this);
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

        [Association(Name = "RIS_EXAM_RIS_MODALITYEXAM", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
        public RIS_EXAM RIS_EXAM
        {
            get
            {
                return this._RIS_EXAM.Entity;
            }
            set
            {
                RIS_EXAM previousValue = this._RIS_EXAM.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAM.Entity = null;
                        previousValue.RIS_MODALITYEXAMs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITYEXAMs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_MODALITYEXAM", Storage = "_RIS_MODALITY", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID", IsForeignKey = true)]
        public RIS_MODALITY RIS_MODALITY
        {
            get
            {
                return this._RIS_MODALITY.Entity;
            }
            set
            {
                RIS_MODALITY previousValue = this._RIS_MODALITY.Entity;
                if (((previousValue != value)
                            || (this._RIS_MODALITY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_MODALITY.Entity = null;
                        previousValue.RIS_MODALITYEXAMs.Remove(this);
                    }
                    this._RIS_MODALITY.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_MODALITYEXAMs.Add(this);
                        this._MODALITY_ID = value.MODALITY_ID;
                    }
                    else
                    {
                        this._MODALITY_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_MODALITY");
                }
            }
        }

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
