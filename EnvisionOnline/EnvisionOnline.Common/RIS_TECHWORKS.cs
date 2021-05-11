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
    [Table(Name = "dbo.RIS_TECHWORKS")]
    public partial class RIS_TECHWORK : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_ON;

        private byte _TAKE;

        private System.Nullable<System.DateTime> _START_TIME;

        private System.Nullable<System.DateTime> _END_TIME;

        private string _EXPOSURE_TECHNIQUE;

        private string _PROTOCOL;

        private string _KV;

        private string _mA;

        private string _SEC;

        private System.Nullable<char> _STATUS;

        private string _COMMENTS;

        private System.Nullable<int> _NO_OF_IMAGES;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<int> _PERFORMANCED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_TECHWORK> _RIS_TECHWORK2;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_TECHWORK> _RIS_TECHWORK1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_ONChanging(string value);
        partial void OnACCESSION_ONChanged();
        partial void OnTAKEChanging(byte value);
        partial void OnTAKEChanged();
        partial void OnSTART_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnSTART_TIMEChanged();
        partial void OnEND_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEND_TIMEChanged();
        partial void OnEXPOSURE_TECHNIQUEChanging(string value);
        partial void OnEXPOSURE_TECHNIQUEChanged();
        partial void OnPROTOCOLChanging(string value);
        partial void OnPROTOCOLChanged();
        partial void OnKVChanging(string value);
        partial void OnKVChanged();
        partial void OnmAChanging(string value);
        partial void OnmAChanged();
        partial void OnSECChanging(string value);
        partial void OnSECChanged();
        partial void OnSTATUSChanging(System.Nullable<char> value);
        partial void OnSTATUSChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnNO_OF_IMAGESChanging(System.Nullable<int> value);
        partial void OnNO_OF_IMAGESChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnPERFORMANCED_BYChanging(System.Nullable<int> value);
        partial void OnPERFORMANCED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_TECHWORK()
        {
            this._RIS_TECHWORK2 = default(EntityRef<RIS_TECHWORK>);
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_TECHWORK1 = default(EntityRef<RIS_TECHWORK>);
            OnCreated();
        }

        [Column(Storage = "_ACCESSION_ON", DbType = "NVarChar(30) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ACCESSION_ON
        {
            get
            {
                return this._ACCESSION_ON;
            }
            set
            {
                if ((this._ACCESSION_ON != value))
                {
                    if (this._RIS_TECHWORK1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnACCESSION_ONChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_ON = value;
                    this.SendPropertyChanged("ACCESSION_ON");
                    this.OnACCESSION_ONChanged();
                }
            }
        }

        [Column(Storage = "_TAKE", DbType = "TinyInt NOT NULL", IsPrimaryKey = true)]
        public byte TAKE
        {
            get
            {
                return this._TAKE;
            }
            set
            {
                if ((this._TAKE != value))
                {
                    if (this._RIS_TECHWORK1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTAKEChanging(value);
                    this.SendPropertyChanging();
                    this._TAKE = value;
                    this.SendPropertyChanged("TAKE");
                    this.OnTAKEChanged();
                }
            }
        }

        [Column(Storage = "_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_TIME
        {
            get
            {
                return this._START_TIME;
            }
            set
            {
                if ((this._START_TIME != value))
                {
                    this.OnSTART_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._START_TIME = value;
                    this.SendPropertyChanged("START_TIME");
                    this.OnSTART_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_END_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_TIME
        {
            get
            {
                return this._END_TIME;
            }
            set
            {
                if ((this._END_TIME != value))
                {
                    this.OnEND_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._END_TIME = value;
                    this.SendPropertyChanged("END_TIME");
                    this.OnEND_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_EXPOSURE_TECHNIQUE", DbType = "NVarChar(200)")]
        public string EXPOSURE_TECHNIQUE
        {
            get
            {
                return this._EXPOSURE_TECHNIQUE;
            }
            set
            {
                if ((this._EXPOSURE_TECHNIQUE != value))
                {
                    this.OnEXPOSURE_TECHNIQUEChanging(value);
                    this.SendPropertyChanging();
                    this._EXPOSURE_TECHNIQUE = value;
                    this.SendPropertyChanged("EXPOSURE_TECHNIQUE");
                    this.OnEXPOSURE_TECHNIQUEChanged();
                }
            }
        }

        [Column(Storage = "_PROTOCOL", DbType = "NVarChar(200)")]
        public string PROTOCOL
        {
            get
            {
                return this._PROTOCOL;
            }
            set
            {
                if ((this._PROTOCOL != value))
                {
                    this.OnPROTOCOLChanging(value);
                    this.SendPropertyChanging();
                    this._PROTOCOL = value;
                    this.SendPropertyChanged("PROTOCOL");
                    this.OnPROTOCOLChanged();
                }
            }
        }

        [Column(Storage = "_KV", DbType = "NVarChar(20)")]
        public string KV
        {
            get
            {
                return this._KV;
            }
            set
            {
                if ((this._KV != value))
                {
                    this.OnKVChanging(value);
                    this.SendPropertyChanging();
                    this._KV = value;
                    this.SendPropertyChanged("KV");
                    this.OnKVChanged();
                }
            }
        }

        [Column(Storage = "_mA", DbType = "NVarChar(20)")]
        public string mA
        {
            get
            {
                return this._mA;
            }
            set
            {
                if ((this._mA != value))
                {
                    this.OnmAChanging(value);
                    this.SendPropertyChanging();
                    this._mA = value;
                    this.SendPropertyChanged("mA");
                    this.OnmAChanged();
                }
            }
        }

        [Column(Storage = "_SEC", DbType = "NVarChar(20)")]
        public string SEC
        {
            get
            {
                return this._SEC;
            }
            set
            {
                if ((this._SEC != value))
                {
                    this.OnSECChanging(value);
                    this.SendPropertyChanging();
                    this._SEC = value;
                    this.SendPropertyChanged("SEC");
                    this.OnSECChanged();
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

        [Column(Storage = "_NO_OF_IMAGES", DbType = "Int")]
        public System.Nullable<int> NO_OF_IMAGES
        {
            get
            {
                return this._NO_OF_IMAGES;
            }
            set
            {
                if ((this._NO_OF_IMAGES != value))
                {
                    this.OnNO_OF_IMAGESChanging(value);
                    this.SendPropertyChanging();
                    this._NO_OF_IMAGES = value;
                    this.SendPropertyChanged("NO_OF_IMAGES");
                    this.OnNO_OF_IMAGESChanged();
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

        [Column(Storage = "_PERFORMANCED_BY", DbType = "Int")]
        public System.Nullable<int> PERFORMANCED_BY
        {
            get
            {
                return this._PERFORMANCED_BY;
            }
            set
            {
                if ((this._PERFORMANCED_BY != value))
                {
                    this.OnPERFORMANCED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._PERFORMANCED_BY = value;
                    this.SendPropertyChanged("PERFORMANCED_BY");
                    this.OnPERFORMANCED_BYChanged();
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

        [Association(Name = "RIS_TECHWORK_RIS_TECHWORK", Storage = "_RIS_TECHWORK2", ThisKey = "ACCESSION_ON,TAKE", OtherKey = "ACCESSION_ON,TAKE", IsUnique = true, IsForeignKey = false)]
        public RIS_TECHWORK RIS_TECHWORK2
        {
            get
            {
                return this._RIS_TECHWORK2.Entity;
            }
            set
            {
                RIS_TECHWORK previousValue = this._RIS_TECHWORK2.Entity;
                if (((previousValue != value)
                            || (this._RIS_TECHWORK2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_TECHWORK2.Entity = null;
                        previousValue.RIS_TECHWORK1 = null;
                    }
                    this._RIS_TECHWORK2.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_TECHWORK1 = this;
                    }
                    this.SendPropertyChanged("RIS_TECHWORK2");
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_TECHWORK", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_TECHWORKs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_TECHWORKs.Add(this);
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

        [Association(Name = "RIS_TECHWORK_RIS_TECHWORK", Storage = "_RIS_TECHWORK1", ThisKey = "ACCESSION_ON,TAKE", OtherKey = "ACCESSION_ON,TAKE", IsForeignKey = true)]
        public RIS_TECHWORK RIS_TECHWORK1
        {
            get
            {
                return this._RIS_TECHWORK1.Entity;
            }
            set
            {
                RIS_TECHWORK previousValue = this._RIS_TECHWORK1.Entity;
                if (((previousValue != value)
                            || (this._RIS_TECHWORK1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_TECHWORK1.Entity = null;
                        previousValue.RIS_TECHWORK2 = null;
                    }
                    this._RIS_TECHWORK1.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_TECHWORK2 = this;
                        this._ACCESSION_ON = value.ACCESSION_ON;
                        this._TAKE = value.TAKE;
                    }
                    else
                    {
                        this._ACCESSION_ON = default(string);
                        this._TAKE = default(byte);
                    }
                    this.SendPropertyChanged("RIS_TECHWORK1");
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
