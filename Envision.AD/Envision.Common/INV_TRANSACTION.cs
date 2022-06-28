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
    public enum TranferType
    {
        T,//tranfer
        R,//recieve
        D,//delete
        L,//lost
        E,//etc
        U,//use
    }
    public enum Status
    {
        N, //New
        R, //Recieving
        F, //Force complete
        C // Complete
    }
    [Table(Name = "dbo.INV_TRANSACTION")]
    public partial class INV_TRANSACTION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _TXN_ID;

        private System.Nullable<char> _TXN_TYPE;

        private System.Nullable<int> _REQUISITION_ID;

        private System.Nullable<int> _PO_ID;

        private System.Nullable<int> _FROM_UNIT;

        private System.Nullable<int> _TO_UNIT;

        private string _COMMENTS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<INV_UNIT> _INV_UNIT;

        private EntityRef<INV_UNIT> _INV_UNIT1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTXN_IDChanging(int value);
        partial void OnTXN_IDChanged();
        partial void OnTXN_TYPEChanging(System.Nullable<char> value);
        partial void OnTXN_TYPEChanged();
        partial void OnREQUISITION_IDChanging(System.Nullable<int> value);
        partial void OnREQUISITION_IDChanged();
        partial void OnPO_IDChanging(System.Nullable<int> value);
        partial void OnPO_IDChanged();
        partial void OnFROM_UNITChanging(System.Nullable<int> value);
        partial void OnFROM_UNITChanged();
        partial void OnTO_UNITChanging(System.Nullable<int> value);
        partial void OnTO_UNITChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
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

        public INV_TRANSACTION()
        {
            this._INV_UNIT = default(EntityRef<INV_UNIT>);
            this._INV_UNIT1 = default(EntityRef<INV_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_TXN_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int TXN_ID
        {
            get
            {
                return this._TXN_ID;
            }
            set
            {
                if ((this._TXN_ID != value))
                {
                    this.OnTXN_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_ID = value;
                    this.SendPropertyChanged("TXN_ID");
                    this.OnTXN_IDChanged();
                }
            }
        }

        [Column(Storage = "_TXN_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> TXN_TYPE
        {
            get
            {
                return this._TXN_TYPE;
            }
            set
            {
                if ((this._TXN_TYPE != value))
                {
                    this.OnTXN_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._TXN_TYPE = value;
                    this.SendPropertyChanged("TXN_TYPE");
                    this.OnTXN_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_REQUISITION_ID", DbType = "Int")]
        public System.Nullable<int> REQUISITION_ID
        {
            get
            {
                return this._REQUISITION_ID;
            }
            set
            {
                if ((this._REQUISITION_ID != value))
                {
                    this.OnREQUISITION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._REQUISITION_ID = value;
                    this.SendPropertyChanged("REQUISITION_ID");
                    this.OnREQUISITION_IDChanged();
                }
            }
        }

        [Column(Storage = "_PO_ID", DbType = "Int")]
        public System.Nullable<int> PO_ID
        {
            get
            {
                return this._PO_ID;
            }
            set
            {
                if ((this._PO_ID != value))
                {
                    this.OnPO_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PO_ID = value;
                    this.SendPropertyChanged("PO_ID");
                    this.OnPO_IDChanged();
                }
            }
        }

        [Column(Storage = "_FROM_UNIT", DbType = "Int")]
        public System.Nullable<int> FROM_UNIT
        {
            get
            {
                return this._FROM_UNIT;
            }
            set
            {
                if ((this._FROM_UNIT != value))
                {
                    if (this._INV_UNIT1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFROM_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._FROM_UNIT = value;
                    this.SendPropertyChanged("FROM_UNIT");
                    this.OnFROM_UNITChanged();
                }
            }
        }

        [Column(Storage = "_TO_UNIT", DbType = "Int")]
        public System.Nullable<int> TO_UNIT
        {
            get
            {
                return this._TO_UNIT;
            }
            set
            {
                if ((this._TO_UNIT != value))
                {
                    if (this._INV_UNIT.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTO_UNITChanging(value);
                    this.SendPropertyChanging();
                    this._TO_UNIT = value;
                    this.SendPropertyChanged("TO_UNIT");
                    this.OnTO_UNITChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(200)")]
        public string COMMENTS
        {
            get
            {
                return this._COMMENTS;
            }
            set
            {
                if ((this._COMMENTS != value))
                {
                    this.OnCOMMENTSChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENTS = value;
                    this.SendPropertyChanged("COMMENTS");
                    this.OnCOMMENTSChanged();
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

        [Association(Name = "INV_UNIT_INV_TRANSACTION", Storage = "_INV_UNIT", ThisKey = "TO_UNIT", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public INV_UNIT INV_UNIT
        {
            get
            {
                return this._INV_UNIT.Entity;
            }
            set
            {
                INV_UNIT previousValue = this._INV_UNIT.Entity;
                if (((previousValue != value)
                            || (this._INV_UNIT.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_UNIT.Entity = null;
                        previousValue.INV_TRANSACTIONs.Remove(this);
                    }
                    this._INV_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TRANSACTIONs.Add(this);
                        this._TO_UNIT = value.UNIT_ID;
                    }
                    else
                    {
                        this._TO_UNIT = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_UNIT");
                }
            }
        }

        [Association(Name = "INV_UNIT_INV_TRANSACTION1", Storage = "_INV_UNIT1", ThisKey = "FROM_UNIT", OtherKey = "UNIT_ID", IsForeignKey = true)]
        public INV_UNIT INV_UNIT1
        {
            get
            {
                return this._INV_UNIT1.Entity;
            }
            set
            {
                INV_UNIT previousValue = this._INV_UNIT1.Entity;
                if (((previousValue != value)
                            || (this._INV_UNIT1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_UNIT1.Entity = null;
                        previousValue.INV_TRANSACTIONs1.Remove(this);
                    }
                    this._INV_UNIT1.Entity = value;
                    if ((value != null))
                    {
                        value.INV_TRANSACTIONs1.Add(this);
                        this._FROM_UNIT = value.UNIT_ID;
                    }
                    else
                    {
                        this._FROM_UNIT = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("INV_UNIT1");
                }
            }
        }

        public string STATUS { get; set; }
        public string Doc { get; set; }
        public string xmlDoc { get; set; }

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
