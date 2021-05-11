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
    [Table(Name = "dbo.RIS_AUTOMERGECONFIG")]
    public partial class RIS_AUTOMERGECONFIG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _AUTO_MERGE_ID;

        private int _merger_unit_id;

        private int _merger_exam_id;

        private int _mergee_unit_id;

        private int _mergee_exam_id;

        private char _AUTO_APPLY;

        private string _CONFIG_NAME;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnAUTO_MERGE_IDChanging(int value);
        partial void OnAUTO_MERGE_IDChanged();
        partial void Onmerger_unit_idChanging(int value);
        partial void Onmerger_unit_idChanged();
        partial void Onmerger_exam_idChanging(int value);
        partial void Onmerger_exam_idChanged();
        partial void Onmergee_unit_idChanging(int value);
        partial void Onmergee_unit_idChanged();
        partial void Onmergee_exam_idChanging(int value);
        partial void Onmergee_exam_idChanged();
        partial void OnAUTO_APPLYChanging(char value);
        partial void OnAUTO_APPLYChanged();
        partial void OnCONFIG_NAMEChanging(string value);
        partial void OnCONFIG_NAMEChanged();
        partial void OnIS_ACTIVEChanging(System.Nullable<char> value);
        partial void OnIS_ACTIVEChanged();
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

        public RIS_AUTOMERGECONFIG()
        {
            OnCreated();
        }

        [Column(Storage = "_AUTO_MERGE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int AUTO_MERGE_ID
        {
            get
            {
                return this._AUTO_MERGE_ID;
            }
            set
            {
                if ((this._AUTO_MERGE_ID != value))
                {
                    this.OnAUTO_MERGE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_MERGE_ID = value;
                    this.SendPropertyChanged("AUTO_MERGE_ID");
                    this.OnAUTO_MERGE_IDChanged();
                }
            }
        }

        [Column(Storage = "_merger_unit_id", DbType = "Int NOT NULL")]
        public int merger_unit_id
        {
            get
            {
                return this._merger_unit_id;
            }
            set
            {
                if ((this._merger_unit_id != value))
                {
                    this.Onmerger_unit_idChanging(value);
                    this.SendPropertyChanging();
                    this._merger_unit_id = value;
                    this.SendPropertyChanged("merger_unit_id");
                    this.Onmerger_unit_idChanged();
                }
            }
        }

        [Column(Storage = "_merger_exam_id", DbType = "Int NOT NULL")]
        public int merger_exam_id
        {
            get
            {
                return this._merger_exam_id;
            }
            set
            {
                if ((this._merger_exam_id != value))
                {
                    this.Onmerger_exam_idChanging(value);
                    this.SendPropertyChanging();
                    this._merger_exam_id = value;
                    this.SendPropertyChanged("merger_exam_id");
                    this.Onmerger_exam_idChanged();
                }
            }
        }

        [Column(Storage = "_mergee_unit_id", DbType = "Int NOT NULL")]
        public int mergee_unit_id
        {
            get
            {
                return this._mergee_unit_id;
            }
            set
            {
                if ((this._mergee_unit_id != value))
                {
                    this.Onmergee_unit_idChanging(value);
                    this.SendPropertyChanging();
                    this._mergee_unit_id = value;
                    this.SendPropertyChanged("mergee_unit_id");
                    this.Onmergee_unit_idChanged();
                }
            }
        }

        [Column(Storage = "_mergee_exam_id", DbType = "Int NOT NULL")]
        public int mergee_exam_id
        {
            get
            {
                return this._mergee_exam_id;
            }
            set
            {
                if ((this._mergee_exam_id != value))
                {
                    this.Onmergee_exam_idChanging(value);
                    this.SendPropertyChanging();
                    this._mergee_exam_id = value;
                    this.SendPropertyChanged("mergee_exam_id");
                    this.Onmergee_exam_idChanged();
                }
            }
        }

        [Column(Storage = "_AUTO_APPLY", DbType = "NVarChar(1) NOT NULL")]
        public char AUTO_APPLY
        {
            get
            {
                return this._AUTO_APPLY;
            }
            set
            {
                if ((this._AUTO_APPLY != value))
                {
                    this.OnAUTO_APPLYChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_APPLY = value;
                    this.SendPropertyChanged("AUTO_APPLY");
                    this.OnAUTO_APPLYChanged();
                }
            }
        }

        [Column(Storage = "_CONFIG_NAME", DbType = "NVarChar(200)")]
        public string CONFIG_NAME
        {
            get
            {
                return this._CONFIG_NAME;
            }
            set
            {
                if ((this._CONFIG_NAME != value))
                {
                    this.OnCONFIG_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._CONFIG_NAME = value;
                    this.SendPropertyChanged("CONFIG_NAME");
                    this.OnCONFIG_NAMEChanged();
                }
            }
        }

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this.OnIS_ACTIVEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_ACTIVE = value;
                    this.SendPropertyChanged("IS_ACTIVE");
                    this.OnIS_ACTIVEChanged();
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
