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
    [Table(Name = "dbo.RIS_EXAMRESULTLOCKS")]
    public partial class RIS_EXAMRESULTLOCK : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private byte _SL_NO;

        private System.Nullable<char> _IS_LOCKED;

        private System.Nullable<int> _WORKING_RAD;

        private System.Nullable<int> _UNLOCKED_BY;

        private System.Nullable<System.DateTime> _UNLOCKED_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnSL_NOChanging(byte value);
        partial void OnSL_NOChanged();
        partial void OnIS_LOCKEDChanging(System.Nullable<char> value);
        partial void OnIS_LOCKEDChanged();
        partial void OnWORKING_RADChanging(System.Nullable<int> value);
        partial void OnWORKING_RADChanged();
        partial void OnUNLOCKED_BYChanging(System.Nullable<int> value);
        partial void OnUNLOCKED_BYChanged();
        partial void OnUNLOCKED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnUNLOCKED_ONChanged();
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

        public RIS_EXAMRESULTLOCK()
        {
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
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_SL_NO", DbType = "TinyInt NOT NULL", IsPrimaryKey = true)]
        public byte SL_NO
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

        [Column(Storage = "_IS_LOCKED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_LOCKED
        {
            get
            {
                return this._IS_LOCKED;
            }
            set
            {
                if ((this._IS_LOCKED != value))
                {
                    this.OnIS_LOCKEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_LOCKED = value;
                    this.SendPropertyChanged("IS_LOCKED");
                    this.OnIS_LOCKEDChanged();
                }
            }
        }

        [Column(Storage = "_WORKING_RAD", DbType = "Int")]
        public System.Nullable<int> WORKING_RAD
        {
            get
            {
                return this._WORKING_RAD;
            }
            set
            {
                if ((this._WORKING_RAD != value))
                {
                    this.OnWORKING_RADChanging(value);
                    this.SendPropertyChanging();
                    this._WORKING_RAD = value;
                    this.SendPropertyChanged("WORKING_RAD");
                    this.OnWORKING_RADChanged();
                }
            }
        }

        [Column(Storage = "_UNLOCKED_BY", DbType = "Int")]
        public System.Nullable<int> UNLOCKED_BY
        {
            get
            {
                return this._UNLOCKED_BY;
            }
            set
            {
                if ((this._UNLOCKED_BY != value))
                {
                    this.OnUNLOCKED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._UNLOCKED_BY = value;
                    this.SendPropertyChanged("UNLOCKED_BY");
                    this.OnUNLOCKED_BYChanged();
                }
            }
        }

        [Column(Storage = "_UNLOCKED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> UNLOCKED_ON
        {
            get
            {
                return this._UNLOCKED_ON;
            }
            set
            {
                if ((this._UNLOCKED_ON != value))
                {
                    this.OnUNLOCKED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._UNLOCKED_ON = value;
                    this.SendPropertyChanged("UNLOCKED_ON");
                    this.OnUNLOCKED_ONChanged();
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

        public string MODE { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }

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
