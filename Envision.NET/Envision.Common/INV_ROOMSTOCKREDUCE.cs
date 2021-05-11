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
    [Table(Name = "dbo.INV_ROOMSTOCKREDUCE")]
    public partial class INV_ROOMSTOCKREDUCE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ROOM_ID;

        private int _UNIT_ID;

        private System.Nullable<byte> _SL_NO;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_ROOM> _HR_ROOM;

        private EntityRef<INV_UNIT> _INV_UNIT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnROOM_IDChanging(int value);
        partial void OnROOM_IDChanged();
        partial void OnUNIT_IDChanging(int value);
        partial void OnUNIT_IDChanged();
        partial void OnSL_NOChanging(System.Nullable<byte> value);
        partial void OnSL_NOChanged();
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

        public INV_ROOMSTOCKREDUCE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_ROOM = default(EntityRef<HR_ROOM>);
            this._INV_UNIT = default(EntityRef<INV_UNIT>);
            OnCreated();
        }

        [Column(Storage = "_ROOM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ROOM_ID
        {
            get
            {
                return this._ROOM_ID;
            }
            set
            {
                if ((this._ROOM_ID != value))
                {
                    if (this._HR_ROOM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnROOM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ROOM_ID = value;
                    this.SendPropertyChanged("ROOM_ID");
                    this.OnROOM_IDChanged();
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    if (this._INV_UNIT.HasLoadedOrAssignedValue)
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

        [Column(Storage = "_SL_NO", DbType = "TinyInt")]
        public System.Nullable<byte> SL_NO
        {
            get
            {
                return this._SL_NO;
            }
            set
            {
                if ((this._SL_NO != value))
                {
                    this.OnSL_NOChanging(value);
                    this.SendPropertyChanging();
                    this._SL_NO = value;
                    this.SendPropertyChanged("SL_NO");
                    this.OnSL_NOChanged();
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

        [Association(Name = "GBL_ENV_INV_ROOMSTOCKREDUCE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.INV_ROOMSTOCKREDUCEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ROOMSTOCKREDUCEs.Add(this);
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

        [Association(Name = "HR_ROOM_INV_ROOMSTOCKREDUCE", Storage = "_HR_ROOM", ThisKey = "ROOM_ID", OtherKey = "ROOM_ID", IsForeignKey = true)]
        public HR_ROOM HR_ROOM
        {
            get
            {
                return this._HR_ROOM.Entity;
            }
            set
            {
                HR_ROOM previousValue = this._HR_ROOM.Entity;
                if (((previousValue != value)
                            || (this._HR_ROOM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_ROOM.Entity = null;
                        previousValue.INV_ROOMSTOCKREDUCEs.Remove(this);
                    }
                    this._HR_ROOM.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ROOMSTOCKREDUCEs.Add(this);
                        this._ROOM_ID = value.ROOM_ID;
                    }
                    else
                    {
                        this._ROOM_ID = default(int);
                    }
                    this.SendPropertyChanged("HR_ROOM");
                }
            }
        }

        [Association(Name = "INV_UNIT_INV_ROOMSTOCKREDUCE", Storage = "_INV_UNIT", ThisKey = "UNIT_ID", OtherKey = "UNIT_ID", IsForeignKey = true)]
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
                        previousValue.INV_ROOMSTOCKREDUCEs.Remove(this);
                    }
                    this._INV_UNIT.Entity = value;
                    if ((value != null))
                    {
                        value.INV_ROOMSTOCKREDUCEs.Add(this);
                        this._UNIT_ID = value.UNIT_ID;
                    }
                    else
                    {
                        this._UNIT_ID = default(int);
                    }
                    this.SendPropertyChanged("INV_UNIT");
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
