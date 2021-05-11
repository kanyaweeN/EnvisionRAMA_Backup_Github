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
    [Table(Name = "dbo.RIS_EXAMTRANSFERLOG")]
    public partial class RIS_EXAMTRANSFERLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private byte _SL_NO;

        private System.Nullable<int> _FROM_RAD;

        private System.Nullable<int> _TO_RAD;

        private System.Nullable<char> _STATUS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_ORDERDTL> _RIS_ORDERDTL;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnSL_NOChanging(byte value);
        partial void OnSL_NOChanged();
        partial void OnFROM_RADChanging(System.Nullable<int> value);
        partial void OnFROM_RADChanged();
        partial void OnTO_RADChanging(System.Nullable<int> value);
        partial void OnTO_RADChanged();
        partial void OnSTATUSChanging(System.Nullable<char> value);
        partial void OnSTATUSChanged();
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

        public RIS_EXAMTRANSFERLOG()
        {
            this._RIS_ORDERDTL = default(EntityRef<RIS_ORDERDTL>);
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
                    if (this._RIS_ORDERDTL.HasLoadedOrAssignedValue)
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

        [Column(Storage = "_FROM_RAD", DbType = "Int")]
        public System.Nullable<int> FROM_RAD
        {
            get
            {
                return this._FROM_RAD;
            }
            set
            {
                if ((this._FROM_RAD != value))
                {
                    this.OnFROM_RADChanging(value);
                    this.SendPropertyChanging();
                    this._FROM_RAD = value;
                    this.SendPropertyChanged("FROM_RAD");
                    this.OnFROM_RADChanged();
                }
            }
        }

        [Column(Storage = "_TO_RAD", DbType = "Int")]
        public System.Nullable<int> TO_RAD
        {
            get
            {
                return this._TO_RAD;
            }
            set
            {
                if ((this._TO_RAD != value))
                {
                    this.OnTO_RADChanging(value);
                    this.SendPropertyChanging();
                    this._TO_RAD = value;
                    this.SendPropertyChanged("TO_RAD");
                    this.OnTO_RADChanged();
                }
            }
        }

        [Column(Storage = "_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                if ((this._STATUS != value))
                {
                    this.OnSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS = value;
                    this.SendPropertyChanged("STATUS");
                    this.OnSTATUSChanged();
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

        [Association(Name = "RIS_ORDERDTL_RIS_EXAMTRANSFERLOG", Storage = "_RIS_ORDERDTL", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO", IsForeignKey = true)]
        public RIS_ORDERDTL RIS_ORDERDTL
        {
            get
            {
                return this._RIS_ORDERDTL.Entity;
            }
            set
            {
                RIS_ORDERDTL previousValue = this._RIS_ORDERDTL.Entity;
                if (((previousValue != value)
                            || (this._RIS_ORDERDTL.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_ORDERDTL.Entity = null;
                        previousValue.RIS_EXAMTRANSFERLOGs.Remove(this);
                    }
                    this._RIS_ORDERDTL.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_EXAMTRANSFERLOGs.Add(this);
                        this._ACCESSION_NO = value.ACCESSION_NO;
                    }
                    else
                    {
                        this._ACCESSION_NO = default(string);
                    }
                    this.SendPropertyChanged("RIS_ORDERDTL");
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
