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
    [Table(Name = "dbo.GBL_SEQUENCES")]
    public partial class GBL_SEQUENCE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _Seq_Name;

        private int _Seed;

        private int _Incr;

        private System.Nullable<int> _Curr_val;

        private System.Nullable<System.DateTime> _DateStart;

        private System.Nullable<int> _ORG_ID;

        private EntityRef<GBL_ENV> _GBL_ENV;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSeq_NameChanging(string value);
        partial void OnSeq_NameChanged();
        partial void OnSeedChanging(int value);
        partial void OnSeedChanged();
        partial void OnIncrChanging(int value);
        partial void OnIncrChanged();
        partial void OnCurr_valChanging(System.Nullable<int> value);
        partial void OnCurr_valChanged();
        partial void OnDateStartChanging(System.Nullable<System.DateTime> value);
        partial void OnDateStartChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        #endregion

        public GBL_SEQUENCE()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            OnCreated();
        }

        [Column(Storage = "_Seq_Name", DbType = "NVarChar(255) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string Seq_Name
        {
            get
            {
                return this._Seq_Name;
            }
            set
            {
                if ((this._Seq_Name != value))
                {
                    this.OnSeq_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Seq_Name = value;
                    this.SendPropertyChanged("Seq_Name");
                    this.OnSeq_NameChanged();
                }
            }
        }

        [Column(Storage = "_Seed", DbType = "Int NOT NULL")]
        public int Seed
        {
            get
            {
                return this._Seed;
            }
            set
            {
                if ((this._Seed != value))
                {
                    this.OnSeedChanging(value);
                    this.SendPropertyChanging();
                    this._Seed = value;
                    this.SendPropertyChanged("Seed");
                    this.OnSeedChanged();
                }
            }
        }

        [Column(Storage = "_Incr", DbType = "Int NOT NULL")]
        public int Incr
        {
            get
            {
                return this._Incr;
            }
            set
            {
                if ((this._Incr != value))
                {
                    this.OnIncrChanging(value);
                    this.SendPropertyChanging();
                    this._Incr = value;
                    this.SendPropertyChanged("Incr");
                    this.OnIncrChanged();
                }
            }
        }

        [Column(Storage = "_Curr_val", DbType = "Int")]
        public System.Nullable<int> Curr_val
        {
            get
            {
                return this._Curr_val;
            }
            set
            {
                if ((this._Curr_val != value))
                {
                    this.OnCurr_valChanging(value);
                    this.SendPropertyChanging();
                    this._Curr_val = value;
                    this.SendPropertyChanged("Curr_val");
                    this.OnCurr_valChanged();
                }
            }
        }

        [Column(Storage = "_DateStart", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DateStart
        {
            get
            {
                return this._DateStart;
            }
            set
            {
                if ((this._DateStart != value))
                {
                    this.OnDateStartChanging(value);
                    this.SendPropertyChanging();
                    this._DateStart = value;
                    this.SendPropertyChanged("DateStart");
                    this.OnDateStartChanged();
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

        [Association(Name = "GBL_ENV_GBL_SEQUENCE", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.GBL_SEQUENCEs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_SEQUENCEs.Add(this);
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
