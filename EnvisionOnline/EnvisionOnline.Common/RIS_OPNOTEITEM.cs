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
    [Table(Name = "dbo.RIS_OPNOTEITEM")]
    public partial class RIS_OPNOTEITEM : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _OP_ITEM_ID;

        private string _OP_ITEM_UID;

        private string _OP_ITEM_NAME;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_OPNOTEITEMTEMPLATE> _RIS_OPNOTEITEMTEMPLATEs;

        private EntityRef<HR_UNIT> _HR_UNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnOP_ITEM_IDChanging(int value);
        partial void OnOP_ITEM_IDChanged();
        partial void OnOP_ITEM_UIDChanging(string value);
        partial void OnOP_ITEM_UIDChanged();
        partial void OnOP_ITEM_NAMEChanging(string value);
        partial void OnOP_ITEM_NAMEChanged();
        partial void OnUNIT_IDChanging(System.Nullable<int> value);
        partial void OnUNIT_IDChanged();
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

        public RIS_OPNOTEITEM()
        {
            this._RIS_OPNOTEITEMTEMPLATEs = new EntitySet<RIS_OPNOTEITEMTEMPLATE>(new Action<RIS_OPNOTEITEMTEMPLATE>(this.attach_RIS_OPNOTEITEMTEMPLATEs), new Action<RIS_OPNOTEITEMTEMPLATE>(this.detach_RIS_OPNOTEITEMTEMPLATEs));
            this._HR_UNIT = default(EntityRef<HR_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_OP_ITEM_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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
                    this.OnOP_ITEM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OP_ITEM_ID = value;
                    this.SendPropertyChanged("OP_ITEM_ID");
                    this.OnOP_ITEM_IDChanged();
                }
            }
        }

        [Column(Storage = "_OP_ITEM_UID", DbType = "NVarChar(50)")]
        public string OP_ITEM_UID
        {
            get
            {
                return this._OP_ITEM_UID;
            }
            set
            {
                if ((this._OP_ITEM_UID != value))
                {
                    this.OnOP_ITEM_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._OP_ITEM_UID = value;
                    this.SendPropertyChanged("OP_ITEM_UID");
                    this.OnOP_ITEM_UIDChanged();
                }
            }
        }

        [Column(Storage = "_OP_ITEM_NAME", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string OP_ITEM_NAME
        {
            get
            {
                return this._OP_ITEM_NAME;
            }
            set
            {
                if ((this._OP_ITEM_NAME != value))
                {
                    this.OnOP_ITEM_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._OP_ITEM_NAME = value;
                    this.SendPropertyChanged("OP_ITEM_NAME");
                    this.OnOP_ITEM_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int")]
        public System.Nullable<int> UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    if (this._HR_UNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
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

        [Association(Name = "RIS_OPNOTEITEM_RIS_OPNOTEITEMTEMPLATE", Storage = "_RIS_OPNOTEITEMTEMPLATEs", ThisKey = "OP_ITEM_ID", OtherKey = "OP_ITEM_ID")]
        public EntitySet<RIS_OPNOTEITEMTEMPLATE> RIS_OPNOTEITEMTEMPLATEs
        {
            get
            {
                return this._RIS_OPNOTEITEMTEMPLATEs;
            }
            set
            {
                this._RIS_OPNOTEITEMTEMPLATEs.Assign(value);
            }
        }

        [Association(Name = "HR_UNIT_RIS_OPNOTEITEM", Storage = "_HR_UNIT", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public HR_UNIT HR_UNIT
        {
            get
            {
                return this._HR_UNIT.Entity;
            }
            set
            {
                HR_UNIT previousValue = this._HR_UNIT.Entity;
                if (((previousValue != value)
                            || (this._HR_UNIT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_UNIT.Entity = null;
                        previousValue.RIS_OPNOTEITEMs.Remove(this);
                    }
                    this._HR_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_OPNOTEITEMs.Add(this);
                        this._UNIT_ID = value.UNIT_ID;
                    }
                    else
                    {
                        this._UNIT_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_UNIT");
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

        private void attach_RIS_OPNOTEITEMTEMPLATEs(RIS_OPNOTEITEMTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_OPNOTEITEM = this;
        }

        private void detach_RIS_OPNOTEITEMTEMPLATEs(RIS_OPNOTEITEMTEMPLATE entity)
        {
            this.SendPropertyChanging();
            entity.RIS_OPNOTEITEM = null;
        }
    }
}
