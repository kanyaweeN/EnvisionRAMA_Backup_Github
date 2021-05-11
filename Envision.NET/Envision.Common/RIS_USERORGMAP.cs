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
    [Table(Name = "dbo.RIS_USERORGMAP")]
    public partial class RIS_USERORGMAP : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _EMP_ID;

        private int _ACCESS_ORG_ID;

        private int _UNIT_ID;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEMP_IDChanging(int value);
        partial void OnEMP_IDChanged();
        partial void OnACCESS_ORG_IDChanging(int value);
        partial void OnACCESS_ORG_IDChanged();
        partial void OnUNIT_IDChanging(int value);
        partial void OnUNIT_IDChanged();
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

        public RIS_USERORGMAP()
        {
            OnCreated();
        }

        [Column(Storage = "_EMP_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    this.OnEMP_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_ID = value;
                    this.SendPropertyChanged("EMP_ID");
                    this.OnEMP_IDChanged();
                }
            }
        }

        [Column(Storage = "_ACCESS_ORG_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ACCESS_ORG_ID
        {
            get
            {
                return this._ACCESS_ORG_ID;
            }
            set
            {
                if ((this._ACCESS_ORG_ID != value))
                {
                    this.OnACCESS_ORG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESS_ORG_ID = value;
                    this.SendPropertyChanged("ACCESS_ORG_ID");
                    this.OnACCESS_ORG_IDChanged();
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
                    this.OnUNIT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._UNIT_ID = value;
                    this.SendPropertyChanged("UNIT_ID");
                    this.OnUNIT_IDChanged();
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
        public int MODE { get; set; }

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
