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
    [Table(Name = "dbo.RIS_SEARCH_DTL")]
    public partial class RIS_SEARCH_DTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private int _KEY_ID;

        private System.Nullable<int> _KEY_FREQ;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_EXAMRESULT> _RIS_EXAMRESULT;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnKEY_IDChanging(int value);
        partial void OnKEY_IDChanged();
        partial void OnKEY_FREQChanging(System.Nullable<int> value);
        partial void OnKEY_FREQChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_SEARCH_DTL()
        {
            this._RIS_EXAMRESULT = default(EntityRef<RIS_EXAMRESULT>);
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

        [Column(Storage = "_KEY_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int KEY_ID
        {
            get
            {
                return this._KEY_ID;
            }
            set
            {
                if ((this._KEY_ID != value))
                {
                    this.OnKEY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._KEY_ID = value;
                    this.SendPropertyChanged("KEY_ID");
                    this.OnKEY_IDChanged();
                }
            }
        }

        [Column(Storage = "_KEY_FREQ", DbType = "Int")]
        public System.Nullable<int> KEY_FREQ
        {
            get
            {
                return this._KEY_FREQ;
            }
            set
            {
                if ((this._KEY_FREQ != value))
                {
                    this.OnKEY_FREQChanging(value);
                    this.SendPropertyChanging();
                    this._KEY_FREQ = value;
                    this.SendPropertyChanged("KEY_FREQ");
                    this.OnKEY_FREQChanged();
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

        [Association(Name = "RIS_EXAMRESULT_RIS_SEARCH_DTL", Storage = "_RIS_EXAMRESULT", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO", IsForeignKey = true)]
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
                        previousValue.RIS_SEARCH_DTLs.Remove(this);
                    }
                    this._RIS_EXAMRESULT.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_SEARCH_DTLs.Add(this);
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
