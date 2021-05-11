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
    [Table(Name = "dbo.RIS_TIME")]
    public partial class RIS_TIME : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private System.DateTime _PK_Date;

        private string _Date_Name;

        private System.Nullable<System.DateTime> _Year;

        private string _Year_Name;

        private System.Nullable<System.DateTime> _Month;

        private string _Month_Name;

        private System.Nullable<int> _Day_Of_Year;

        private string _Day_Of_Year_Name;

        private System.Nullable<int> _Day_Of_Month;

        private string _Day_Of_Month_Name;

        private System.Nullable<int> _Month_Of_Year;

        private string _Month_Of_Year_Name;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPK_DateChanging(System.DateTime value);
        partial void OnPK_DateChanged();
        partial void OnDate_NameChanging(string value);
        partial void OnDate_NameChanged();
        partial void OnYearChanging(System.Nullable<System.DateTime> value);
        partial void OnYearChanged();
        partial void OnYear_NameChanging(string value);
        partial void OnYear_NameChanged();
        partial void OnMonthChanging(System.Nullable<System.DateTime> value);
        partial void OnMonthChanged();
        partial void OnMonth_NameChanging(string value);
        partial void OnMonth_NameChanged();
        partial void OnDay_Of_YearChanging(System.Nullable<int> value);
        partial void OnDay_Of_YearChanged();
        partial void OnDay_Of_Year_NameChanging(string value);
        partial void OnDay_Of_Year_NameChanged();
        partial void OnDay_Of_MonthChanging(System.Nullable<int> value);
        partial void OnDay_Of_MonthChanged();
        partial void OnDay_Of_Month_NameChanging(string value);
        partial void OnDay_Of_Month_NameChanged();
        partial void OnMonth_Of_YearChanging(System.Nullable<int> value);
        partial void OnMonth_Of_YearChanged();
        partial void OnMonth_Of_Year_NameChanging(string value);
        partial void OnMonth_Of_Year_NameChanged();
        #endregion

        public RIS_TIME()
        {
            OnCreated();
        }

        [Column(Storage = "_PK_Date", DbType = "DateTime NOT NULL", IsPrimaryKey = true)]
        public System.DateTime PK_Date
        {
            get
            {
                return this._PK_Date;
            }
            set
            {
                if ((this._PK_Date != value))
                {
                    this.OnPK_DateChanging(value);
                    this.SendPropertyChanging();
                    this._PK_Date = value;
                    this.SendPropertyChanged("PK_Date");
                    this.OnPK_DateChanged();
                }
            }
        }

        [Column(Storage = "_Date_Name", DbType = "NVarChar(50)")]
        public string Date_Name
        {
            get
            {
                return this._Date_Name;
            }
            set
            {
                if ((this._Date_Name != value))
                {
                    this.OnDate_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Date_Name = value;
                    this.SendPropertyChanged("Date_Name");
                    this.OnDate_NameChanged();
                }
            }
        }

        [Column(Storage = "_Year", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Year
        {
            get
            {
                return this._Year;
            }
            set
            {
                if ((this._Year != value))
                {
                    this.OnYearChanging(value);
                    this.SendPropertyChanging();
                    this._Year = value;
                    this.SendPropertyChanged("Year");
                    this.OnYearChanged();
                }
            }
        }

        [Column(Storage = "_Year_Name", DbType = "NVarChar(50)")]
        public string Year_Name
        {
            get
            {
                return this._Year_Name;
            }
            set
            {
                if ((this._Year_Name != value))
                {
                    this.OnYear_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Year_Name = value;
                    this.SendPropertyChanged("Year_Name");
                    this.OnYear_NameChanged();
                }
            }
        }

        [Column(Storage = "_Month", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Month
        {
            get
            {
                return this._Month;
            }
            set
            {
                if ((this._Month != value))
                {
                    this.OnMonthChanging(value);
                    this.SendPropertyChanging();
                    this._Month = value;
                    this.SendPropertyChanged("Month");
                    this.OnMonthChanged();
                }
            }
        }

        [Column(Storage = "_Month_Name", DbType = "NVarChar(50)")]
        public string Month_Name
        {
            get
            {
                return this._Month_Name;
            }
            set
            {
                if ((this._Month_Name != value))
                {
                    this.OnMonth_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Month_Name = value;
                    this.SendPropertyChanged("Month_Name");
                    this.OnMonth_NameChanged();
                }
            }
        }

        [Column(Storage = "_Day_Of_Year", DbType = "Int")]
        public System.Nullable<int> Day_Of_Year
        {
            get
            {
                return this._Day_Of_Year;
            }
            set
            {
                if ((this._Day_Of_Year != value))
                {
                    this.OnDay_Of_YearChanging(value);
                    this.SendPropertyChanging();
                    this._Day_Of_Year = value;
                    this.SendPropertyChanged("Day_Of_Year");
                    this.OnDay_Of_YearChanged();
                }
            }
        }

        [Column(Storage = "_Day_Of_Year_Name", DbType = "NVarChar(50)")]
        public string Day_Of_Year_Name
        {
            get
            {
                return this._Day_Of_Year_Name;
            }
            set
            {
                if ((this._Day_Of_Year_Name != value))
                {
                    this.OnDay_Of_Year_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Day_Of_Year_Name = value;
                    this.SendPropertyChanged("Day_Of_Year_Name");
                    this.OnDay_Of_Year_NameChanged();
                }
            }
        }

        [Column(Storage = "_Day_Of_Month", DbType = "Int")]
        public System.Nullable<int> Day_Of_Month
        {
            get
            {
                return this._Day_Of_Month;
            }
            set
            {
                if ((this._Day_Of_Month != value))
                {
                    this.OnDay_Of_MonthChanging(value);
                    this.SendPropertyChanging();
                    this._Day_Of_Month = value;
                    this.SendPropertyChanged("Day_Of_Month");
                    this.OnDay_Of_MonthChanged();
                }
            }
        }

        [Column(Storage = "_Day_Of_Month_Name", DbType = "NVarChar(50)")]
        public string Day_Of_Month_Name
        {
            get
            {
                return this._Day_Of_Month_Name;
            }
            set
            {
                if ((this._Day_Of_Month_Name != value))
                {
                    this.OnDay_Of_Month_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Day_Of_Month_Name = value;
                    this.SendPropertyChanged("Day_Of_Month_Name");
                    this.OnDay_Of_Month_NameChanged();
                }
            }
        }

        [Column(Storage = "_Month_Of_Year", DbType = "Int")]
        public System.Nullable<int> Month_Of_Year
        {
            get
            {
                return this._Month_Of_Year;
            }
            set
            {
                if ((this._Month_Of_Year != value))
                {
                    this.OnMonth_Of_YearChanging(value);
                    this.SendPropertyChanging();
                    this._Month_Of_Year = value;
                    this.SendPropertyChanged("Month_Of_Year");
                    this.OnMonth_Of_YearChanged();
                }
            }
        }

        [Column(Storage = "_Month_Of_Year_Name", DbType = "NVarChar(50)")]
        public string Month_Of_Year_Name
        {
            get
            {
                return this._Month_Of_Year_Name;
            }
            set
            {
                if ((this._Month_Of_Year_Name != value))
                {
                    this.OnMonth_Of_Year_NameChanging(value);
                    this.SendPropertyChanging();
                    this._Month_Of_Year_Name = value;
                    this.SendPropertyChanged("Month_Of_Year_Name");
                    this.OnMonth_Of_Year_NameChanged();
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
