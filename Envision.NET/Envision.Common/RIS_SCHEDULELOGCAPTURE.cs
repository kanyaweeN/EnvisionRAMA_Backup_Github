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
    [Table(Name = "dbo.RIS_SCHEDULELOGCAPTURE")]
    public partial class RIS_SCHEDULELOGCAPTURE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _CAPTURE_ID;

        private System.DateTime _START_TIME;

        private System.Data.Linq.Binary _MIN_LSN;

        private System.Data.Linq.Binary _MAX_LSN;

        private System.DateTime _END_TIME;

        private int _INSERT_COUNT;

        private int _UPDATE_COUNT;

        private int _DELETE_COUNT;

        private int _STATUS_CODE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnCAPTURE_IDChanging(int value);
        partial void OnCAPTURE_IDChanged();
        partial void OnSTART_TIMEChanging(System.DateTime value);
        partial void OnSTART_TIMEChanged();
        partial void OnMIN_LSNChanging(System.Data.Linq.Binary value);
        partial void OnMIN_LSNChanged();
        partial void OnMAX_LSNChanging(System.Data.Linq.Binary value);
        partial void OnMAX_LSNChanged();
        partial void OnEND_TIMEChanging(System.DateTime value);
        partial void OnEND_TIMEChanged();
        partial void OnINSERT_COUNTChanging(int value);
        partial void OnINSERT_COUNTChanged();
        partial void OnUPDATE_COUNTChanging(int value);
        partial void OnUPDATE_COUNTChanged();
        partial void OnDELETE_COUNTChanging(int value);
        partial void OnDELETE_COUNTChanged();
        partial void OnSTATUS_CODEChanging(int value);
        partial void OnSTATUS_CODEChanged();
        #endregion

        public RIS_SCHEDULELOGCAPTURE()
        {
            OnCreated();
        }

        [Column(Storage = "_CAPTURE_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int CAPTURE_ID
        {
            get
            {
                return this._CAPTURE_ID;
            }
            set
            {
                if ((this._CAPTURE_ID != value))
                {
                    this.OnCAPTURE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._CAPTURE_ID = value;
                    this.SendPropertyChanged("CAPTURE_ID");
                    this.OnCAPTURE_IDChanged();
                }
            }
        }

        [Column(Storage = "_START_TIME", DbType = "DateTime NOT NULL")]
        public System.DateTime START_TIME
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

        [Column(Storage = "_MIN_LSN", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary MIN_LSN
        {
            get
            {
                return this._MIN_LSN;
            }
            set
            {
                if ((this._MIN_LSN != value))
                {
                    this.OnMIN_LSNChanging(value);
                    this.SendPropertyChanging();
                    this._MIN_LSN = value;
                    this.SendPropertyChanged("MIN_LSN");
                    this.OnMIN_LSNChanged();
                }
            }
        }

        [Column(Storage = "_MAX_LSN", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary MAX_LSN
        {
            get
            {
                return this._MAX_LSN;
            }
            set
            {
                if ((this._MAX_LSN != value))
                {
                    this.OnMAX_LSNChanging(value);
                    this.SendPropertyChanging();
                    this._MAX_LSN = value;
                    this.SendPropertyChanged("MAX_LSN");
                    this.OnMAX_LSNChanged();
                }
            }
        }

        [Column(Storage = "_END_TIME", DbType = "DateTime NOT NULL")]
        public System.DateTime END_TIME
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

        [Column(Storage = "_INSERT_COUNT", DbType = "Int NOT NULL")]
        public int INSERT_COUNT
        {
            get
            {
                return this._INSERT_COUNT;
            }
            set
            {
                if ((this._INSERT_COUNT != value))
                {
                    this.OnINSERT_COUNTChanging(value);
                    this.SendPropertyChanging();
                    this._INSERT_COUNT = value;
                    this.SendPropertyChanged("INSERT_COUNT");
                    this.OnINSERT_COUNTChanged();
                }
            }
        }

        [Column(Storage = "_UPDATE_COUNT", DbType = "Int NOT NULL")]
        public int UPDATE_COUNT
        {
            get
            {
                return this._UPDATE_COUNT;
            }
            set
            {
                if ((this._UPDATE_COUNT != value))
                {
                    this.OnUPDATE_COUNTChanging(value);
                    this.SendPropertyChanging();
                    this._UPDATE_COUNT = value;
                    this.SendPropertyChanged("UPDATE_COUNT");
                    this.OnUPDATE_COUNTChanged();
                }
            }
        }

        [Column(Storage = "_DELETE_COUNT", DbType = "Int NOT NULL")]
        public int DELETE_COUNT
        {
            get
            {
                return this._DELETE_COUNT;
            }
            set
            {
                if ((this._DELETE_COUNT != value))
                {
                    this.OnDELETE_COUNTChanging(value);
                    this.SendPropertyChanging();
                    this._DELETE_COUNT = value;
                    this.SendPropertyChanged("DELETE_COUNT");
                    this.OnDELETE_COUNTChanged();
                }
            }
        }

        [Column(Storage = "_STATUS_CODE", DbType = "Int NOT NULL")]
        public int STATUS_CODE
        {
            get
            {
                return this._STATUS_CODE;
            }
            set
            {
                if ((this._STATUS_CODE != value))
                {
                    this.OnSTATUS_CODEChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS_CODE = value;
                    this.SendPropertyChanged("STATUS_CODE");
                    this.OnSTATUS_CODEChanged();
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
