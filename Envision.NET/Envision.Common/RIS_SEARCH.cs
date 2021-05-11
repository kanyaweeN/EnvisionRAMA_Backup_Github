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
    [Table(Name = "dbo.RIS_SEARCH")]
    public partial class RIS_SEARCH : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _KEYWORD;

        private System.Nullable<int> _FREQUENCY;

        private System.Nullable<double> _WEIGHT;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private string _SOUNDEX;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnKEYWORDChanging(string value);
        partial void OnKEYWORDChanged();
        partial void OnFREQUENCYChanging(System.Nullable<int> value);
        partial void OnFREQUENCYChanged();
        partial void OnWEIGHTChanging(System.Nullable<double> value);
        partial void OnWEIGHTChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnSOUNDEXChanging(string value);
        partial void OnSOUNDEXChanged();
        #endregion

        public RIS_SEARCH()
        {
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_KEYWORD", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
        public string KEYWORD
        {
            get
            {
                return this._KEYWORD;
            }
            set
            {
                if ((this._KEYWORD != value))
                {
                    this.OnKEYWORDChanging(value);
                    this.SendPropertyChanging();
                    this._KEYWORD = value;
                    this.SendPropertyChanged("KEYWORD");
                    this.OnKEYWORDChanged();
                }
            }
        }

        [Column(Storage = "_FREQUENCY", DbType = "Int")]
        public System.Nullable<int> FREQUENCY
        {
            get
            {
                return this._FREQUENCY;
            }
            set
            {
                if ((this._FREQUENCY != value))
                {
                    this.OnFREQUENCYChanging(value);
                    this.SendPropertyChanging();
                    this._FREQUENCY = value;
                    this.SendPropertyChanged("FREQUENCY");
                    this.OnFREQUENCYChanged();
                }
            }
        }

        [Column(Storage = "_WEIGHT", DbType = "Float")]
        public System.Nullable<double> WEIGHT
        {
            get
            {
                return this._WEIGHT;
            }
            set
            {
                if ((this._WEIGHT != value))
                {
                    this.OnWEIGHTChanging(value);
                    this.SendPropertyChanging();
                    this._WEIGHT = value;
                    this.SendPropertyChanged("WEIGHT");
                    this.OnWEIGHTChanged();
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

        [Column(Storage = "_SOUNDEX", DbType = "NVarChar(10)")]
        public string SOUNDEX
        {
            get
            {
                return this._SOUNDEX;
            }
            set
            {
                if ((this._SOUNDEX != value))
                {
                    this.OnSOUNDEXChanging(value);
                    this.SendPropertyChanging();
                    this._SOUNDEX = value;
                    this.SendPropertyChanged("SOUNDEX");
                    this.OnSOUNDEXChanged();
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
