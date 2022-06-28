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
    [Table(Name = "dbo.RIS_PATIENTPREPARATION")]
    public partial class RIS_PATIENTPREPARATION : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PREPARATION_ID;

        private string _PREPARATION_UID;

        private string _PREPARATION_DESC;

        private EntitySet<RIS_SCHEDULE> _RIS_SCHEDULEs;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPREPARATION_IDChanging(int value);
        partial void OnPREPARATION_IDChanged();
        partial void OnPREPARATION_UIDChanging(string value);
        partial void OnPREPARATION_UIDChanged();
        partial void OnPREPARATION_DESCChanging(string value);
        partial void OnPREPARATION_DESCChanged();
        #endregion

        public RIS_PATIENTPREPARATION()
        {
            OnCreated();
        }

        [Column(Storage = "_PREPARATION_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PREPARATION_ID
        {
            get
            {
                return this._PREPARATION_ID;
            }
            set
            {
                if ((this._PREPARATION_ID != value))
                {
                    this.OnPREPARATION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_ID = value;
                    this.SendPropertyChanged("PREPARATION_ID");
                    this.OnPREPARATION_IDChanged();
                }
            }
        }

        [Column(Storage = "_PREPARATION_UID", DbType = "NVarChar(30)")]
        public string PREPARATION_UID
        {
            get
            {
                return this._PREPARATION_UID;
            }
            set
            {
                if ((this._PREPARATION_UID != value))
                {
                    this.OnPREPARATION_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_UID = value;
                    this.SendPropertyChanged("PREPARATION_UID");
                    this.OnPREPARATION_UIDChanged();
                }
            }
        }

        [Column(Storage = "_PREPARATION_DESC", DbType = "NVarChar(300)")]
        public string PREPARATION_DESC
        {
            get
            {
                return this._PREPARATION_DESC;
            }
            set
            {
                if ((this._PREPARATION_DESC != value))
                {
                    this.OnPREPARATION_DESCChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_DESC = value;
                    this.SendPropertyChanged("PREPARATION_DESC");
                    this.OnPREPARATION_DESCChanged();
                }
            }
        }

        [Association(Name = "RIS_PATIENTPREPARATION_RIS_SCHEDULE", Storage = "_RIS_SCHEDULEs", ThisKey = "PREPARATION_ID", OtherKey = "PREPARATION_ID")]
        public EntitySet<RIS_SCHEDULE> RIS_SCHEDULEs
        {
            get
            {
                return this._RIS_SCHEDULEs;
            }
            set
            {
                this._RIS_SCHEDULEs.Assign(value);
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
