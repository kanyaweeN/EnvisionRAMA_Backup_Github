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
    [Table(Name = "dbo.RIS_OPNOTEITEMTEMPLATE")]
    public partial class RIS_OPNOTEITEMTEMPLATE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _OP_ITEM_ID;

        private int _EXAM_ID;

        private string _ITEM_VALUE;

        private string _ITEM_UNIT;

        private char _OPNOTE_TYPE;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_OPNOTEITEM> _RIS_OPNOTEITEM;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnOP_ITEM_IDChanging(int value);
        partial void OnOP_ITEM_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnITEM_VALUEChanging(string value);
        partial void OnITEM_VALUEChanged();
        partial void OnITEM_UNITChanging(string value);
        partial void OnITEM_UNITChanged();
        partial void OnOPNOTE_TYPEChanging(char value);
        partial void OnOPNOTE_TYPEChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_OPNOTEITEMTEMPLATE()
        {
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_OPNOTEITEM = default(EntityRef<RIS_OPNOTEITEM>);
            OnCreated();
        }

        [Column(Storage = "_OP_ITEM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int OP_ITEM_ID
        {
            get
            {
                return this._OP_ITEM_ID;
            }
            set
            {
                if ((this._OP_ITEM_ID != value))
                {
                    if (this._RIS_OPNOTEITEM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnOP_ITEM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OP_ITEM_ID = value;
                    this.SendPropertyChanged("OP_ITEM_ID");
                    this.OnOP_ITEM_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        [Column(Storage = "_ITEM_VALUE", DbType = "NVarChar(MAX)")]
        public string ITEM_VALUE
        {
            get
            {
                return this._ITEM_VALUE;
            }
            set
            {
                if ((this._ITEM_VALUE != value))
                {
                    this.OnITEM_VALUEChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_VALUE = value;
                    this.SendPropertyChanged("ITEM_VALUE");
                    this.OnITEM_VALUEChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_UNIT", DbType = "NVarChar(50)")]
        public string ITEM_UNIT
        {
            get
            {
                return this._ITEM_UNIT;
            }
            set
            {
                if ((this._ITEM_UNIT != value))
                {
                    this.OnITEM_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_UNIT = value;
                    this.SendPropertyChanged("ITEM_UNIT");
                    this.OnITEM_UNITChanged();
                }
            }
        }

        [Column(Storage = "_OPNOTE_TYPE", DbType = "NVarChar(1) NOT NULL", IsPrimaryKey = true)]
        public char OPNOTE_TYPE
        {
            get
            {
                return this._OPNOTE_TYPE;
            }
            set
            {
                if ((this._OPNOTE_TYPE != value))
                {
                    this.OnOPNOTE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._OPNOTE_TYPE = value;
                    this.SendPropertyChanged("OPNOTE_TYPE");
                    this.OnOPNOTE_TYPEChanged();
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

        [Association(Name = "RIS_EXAM_RIS_OPNOTEITEMTEMPLATE", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
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
                        previousValue.RIS_OPNOTEITEMTEMPLATEs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_OPNOTEITEMTEMPLATEs.Add(this);
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

        [Association(Name = "RIS_OPNOTEITEM_RIS_OPNOTEITEMTEMPLATE", Storage = "_RIS_OPNOTEITEM", ThisKey = "OP_ITEM_ID", OtherKey = "OP_ITEM_ID", IsForeignKey = true)]
        public RIS_OPNOTEITEM RIS_OPNOTEITEM
        {
            get
            {
                return this._RIS_OPNOTEITEM.Entity;
            }
            set
            {
                RIS_OPNOTEITEM previousValue = this._RIS_OPNOTEITEM.Entity;
                if (((previousValue != value)
                            || (this._RIS_OPNOTEITEM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_OPNOTEITEM.Entity = null;
                        previousValue.RIS_OPNOTEITEMTEMPLATEs.Remove(this);
                    }
                    this._RIS_OPNOTEITEM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_OPNOTEITEMTEMPLATEs.Add(this);
                        this._OP_ITEM_ID = value.OP_ITEM_ID;
                    }
                    else
                    {
                        this._OP_ITEM_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_OPNOTEITEM");
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
