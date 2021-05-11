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
    [Table(Name = "dbo.RIS_RADSTUDYGROUP")]
    public partial class RIS_RADSTUDYGROUP : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RADIOLOGIST_ID;

        private string _ACCESSION_NO;

        private System.Nullable<bool> _IS_FAVOURITE;

        private System.Nullable<bool> _IS_TEACHING;

        private System.Nullable<bool> _IS_OTHERS;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.String _MODE;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<RIS_ORDERDTL> _RIS_ORDERDTL;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnRADIOLOGIST_IDChanging(int value);
        partial void OnRADIOLOGIST_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnIS_FAVOURITEChanging(System.Nullable<bool> value);
        partial void OnIS_FAVOURITEChanged();
        partial void OnIS_TEACHINGChanging(System.Nullable<bool> value);
        partial void OnIS_TEACHINGChanged();
        partial void OnIS_OTHERSChanging(System.Nullable<bool> value);
        partial void OnIS_OTHERSChanged();
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

        public RIS_RADSTUDYGROUP()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._RIS_ORDERDTL = default(EntityRef<RIS_ORDERDTL>);
            OnCreated();
        }

        [Column(Storage = "_RADIOLOGIST_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int RADIOLOGIST_ID
        {
            get
            {
                return this._RADIOLOGIST_ID;
            }
            set
            {
                if ((this._RADIOLOGIST_ID != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRADIOLOGIST_IDChanging(value);
                    this.SendPropertyChanging();
                    this._RADIOLOGIST_ID = value;
                    this.SendPropertyChanged("RADIOLOGIST_ID");
                    this.OnRADIOLOGIST_IDChanged();
                }
            }
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

        [Column(Storage = "_IS_FAVOURITE", DbType = "Bit")]
        public System.Nullable<bool> IS_FAVOURITE
        {
            get
            {
                return this._IS_FAVOURITE;
            }
            set
            {
                if ((this._IS_FAVOURITE != value))
                {
                    this.OnIS_FAVOURITEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_FAVOURITE = value;
                    this.SendPropertyChanged("IS_FAVOURITE");
                    this.OnIS_FAVOURITEChanged();
                }
            }
        }

        [Column(Storage = "_IS_TEACHING", DbType = "Bit")]
        public System.Nullable<bool> IS_TEACHING
        {
            get
            {
                return this._IS_TEACHING;
            }
            set
            {
                if ((this._IS_TEACHING != value))
                {
                    this.OnIS_TEACHINGChanging(value);
                    this.SendPropertyChanging();
                    this._IS_TEACHING = value;
                    this.SendPropertyChanged("IS_TEACHING");
                    this.OnIS_TEACHINGChanged();
                }
            }
        }

        [Column(Storage = "_IS_OTHERS", DbType = "Bit")]
        public System.Nullable<bool> IS_OTHERS
        {
            get
            {
                return this._IS_OTHERS;
            }
            set
            {
                if ((this._IS_OTHERS != value))
                {
                    this.OnIS_OTHERSChanging(value);
                    this.SendPropertyChanging();
                    this._IS_OTHERS = value;
                    this.SendPropertyChanged("IS_OTHERS");
                    this.OnIS_OTHERSChanged();
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

        [Association(Name = "GBL_ENV_RIS_RADSTUDYGROUP", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_RADSTUDYGROUPs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RADSTUDYGROUPs.Add(this);
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

        [Association(Name = "HR_EMP_RIS_RADSTUDYGROUP", Storage = "_HR_EMP", ThisKey = "RADIOLOGIST_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.RIS_RADSTUDYGROUPs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RADSTUDYGROUPs.Add(this);
                        this._RADIOLOGIST_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._RADIOLOGIST_ID = default(int);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_RADSTUDYGROUP", Storage = "_RIS_ORDERDTL", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO", IsForeignKey = true)]
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
                        previousValue.RIS_RADSTUDYGROUPs.Remove(this);
                    }
                    this._RIS_ORDERDTL.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_RADSTUDYGROUPs.Add(this);
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

        public System.String MODE
        {
            get { return _MODE; }
            set { _MODE = value; }
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
