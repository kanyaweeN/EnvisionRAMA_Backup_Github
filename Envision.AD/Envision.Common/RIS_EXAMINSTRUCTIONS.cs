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
    [Table(Name = "dbo.RIS_EXAMINSTRUCTIONS")]
    public partial class RIS_EXAMINSTRUCTION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _INS_ID;

        private System.Nullable<int> _EXAM_TYPE_ID;

        private System.Nullable<int> _EXAM_ID;

        private string _INS_UID;

        private string _INS_TEXT;

        private System.Nullable<char> _INHERIT_GROUP;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_EXAMTYPE> _RIS_EXAMTYPE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnINS_IDChanging(int value);
        partial void OnINS_IDChanged();
        partial void OnEXAM_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_TYPE_IDChanged();
        partial void OnEXAM_IDChanging(System.Nullable<int> value);
        partial void OnEXAM_IDChanged();
        partial void OnINS_UIDChanging(string value);
        partial void OnINS_UIDChanged();
        partial void OnINS_TEXTChanging(string value);
        partial void OnINS_TEXTChanged();
        partial void OnINHERIT_GROUPChanging(System.Nullable<char> value);
        partial void OnINHERIT_GROUPChanged();
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

        public RIS_EXAMINSTRUCTION()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_EXAMTYPE = default(EntityRef<RIS_EXAMTYPE>);
            OnCreated();
        }

        [Column(Storage = "_INS_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int INS_ID
        {
            get
            {
                return this._INS_ID;
            }
            set
            {
                if ((this._INS_ID != value))
                {
                    this.OnINS_IDChanging(value);
                    this.SendPropertyChanging();
                    this._INS_ID = value;
                    this.SendPropertyChanged("INS_ID");
                    this.OnINS_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_TYPE_ID
        {
            get
            {
                return this._EXAM_TYPE_ID;
            }
            set
            {
                if ((this._EXAM_TYPE_ID != value))
                {
                    if (this._RIS_EXAMTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXAM_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_TYPE_ID = value;
                    this.SendPropertyChanged("EXAM_TYPE_ID");
                    this.OnEXAM_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
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

        [Column(Storage = "_INS_UID", DbType = "NVarChar(30)")]
        public string INS_UID
        {
            get
            {
                return this._INS_UID;
            }
            set
            {
                if ((this._INS_UID != value))
                {
                    this.OnINS_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._INS_UID = value;
                    this.SendPropertyChanged("INS_UID");
                    this.OnINS_UIDChanged();
                }
            }
        }

        [Column(Storage = "_INS_TEXT", DbType = "NVarChar(4000)")]
        public string INS_TEXT
        {
            get
            {
                return this._INS_TEXT;
            }
            set
            {
                if ((this._INS_TEXT != value))
                {
                    this.OnINS_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._INS_TEXT = value;
                    this.SendPropertyChanged("INS_TEXT");
                    this.OnINS_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_INHERIT_GROUP", DbType = "NVarChar(1)")]
        public System.Nullable<char> INHERIT_GROUP
        {
            get
            {
                return this._INHERIT_GROUP;
            }
            set
            {
                if ((this._INHERIT_GROUP != value))
                {
                    this.OnINHERIT_GROUPChanging(value);
                    this.SendPropertyChanging();
                    this._INHERIT_GROUP = value;
                    this.SendPropertyChanged("INHERIT_GROUP");
                    this.OnINHERIT_GROUPChanged();
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

        [Association(Name = "GBL_ENV_RIS_EXAMINSTRUCTION", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMINSTRUCTIONs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMINSTRUCTIONs.Add(this);
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

        [Association(Name = "RIS_EXAM_RIS_EXAMINSTRUCTION", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
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
                        previousValue.RIS_EXAMINSTRUCTIONs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMINSTRUCTIONs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_EXAMTYPE_RIS_EXAMINSTRUCTION", Storage = "_RIS_EXAMTYPE", ThisKey = "EXAM_TYPE_ID", OtherKey = "EXAM_TYPE_ID", IsForeignKey = true)]
        public RIS_EXAMTYPE RIS_EXAMTYPE
        {
            get
            {
                return this._RIS_EXAMTYPE.Entity;
            }
            set
            {
                RIS_EXAMTYPE previousValue = this._RIS_EXAMTYPE.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAMTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAMTYPE.Entity = null;
                        previousValue.RIS_EXAMINSTRUCTIONs.Remove(this);
                    }
                    this._RIS_EXAMTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMINSTRUCTIONs.Add(this);
                        this._EXAM_TYPE_ID = value.EXAM_TYPE_ID;
                    }
                    else
                    {
                        this._EXAM_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_EXAMTYPE");
                }
            }
        }

        public string EXAM_UID { get; set; }
        public int SP_TYPE { get; set; }
        public int UNIT_ID { get; set; }
        public string UNIT_INS { get; set; }
        public string EXAM_TYPE_INS { get; set; }
        public string EXAM_TYPE_INS_KID { get; set; }


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
