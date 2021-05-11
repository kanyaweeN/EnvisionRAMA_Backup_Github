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
    [Table(Name = "dbo.RIS_TIMELEVEL")]
    public partial class RIS_TIMELEVEL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _DateTime;

        private System.Nullable<System.DateTime> _DatetimeOnCreate;

        private string _EnglishDay;

        private string _ThaiDay;

        private System.Nullable<int> _DayNumberOfMonth;

        private string _EnglishMonth;

        private string _ThaiMonth;

        private System.Nullable<int> _MonthNumberOfYear;

        private System.Nullable<int> _EnglishYear;

        private System.Nullable<int> _ThaiYear;

        private System.Nullable<int> _DayOfWeek;

        private System.Nullable<int> _CalendarHalfYear;

        private System.Nullable<int> _CalendarQuarter;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnDateTimeChanging(string value);
        partial void OnDateTimeChanged();
        partial void OnDatetimeOnCreateChanging(System.Nullable<System.DateTime> value);
        partial void OnDatetimeOnCreateChanged();
        partial void OnEnglishDayChanging(string value);
        partial void OnEnglishDayChanged();
        partial void OnThaiDayChanging(string value);
        partial void OnThaiDayChanged();
        partial void OnDayNumberOfMonthChanging(System.Nullable<int> value);
        partial void OnDayNumberOfMonthChanged();
        partial void OnEnglishMonthChanging(string value);
        partial void OnEnglishMonthChanged();
        partial void OnThaiMonthChanging(string value);
        partial void OnThaiMonthChanged();
        partial void OnMonthNumberOfYearChanging(System.Nullable<int> value);
        partial void OnMonthNumberOfYearChanged();
        partial void OnEnglishYearChanging(System.Nullable<int> value);
        partial void OnEnglishYearChanged();
        partial void OnThaiYearChanging(System.Nullable<int> value);
        partial void OnThaiYearChanged();
        partial void OnDayOfWeekChanging(System.Nullable<int> value);
        partial void OnDayOfWeekChanged();
        partial void OnCalendarHalfYearChanging(System.Nullable<int> value);
        partial void OnCalendarHalfYearChanged();
        partial void OnCalendarQuarterChanging(System.Nullable<int> value);
        partial void OnCalendarQuarterChanged();
        #endregion

        public RIS_TIMELEVEL()
        {
            OnCreated();
        }

        [Column(Storage = "_DateTime", DbType = "NVarChar(10) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string DateTime
        {
            get
            {
                return this._DateTime;
            }
            set
            {
                if ((this._DateTime != value))
                {
                    this.OnDateTimeChanging(value);
                    this.SendPropertyChanging();
                    this._DateTime = value;
                    this.SendPropertyChanged("DateTime");
                    this.OnDateTimeChanged();
                }
            }
        }

        [Column(Storage = "_DatetimeOnCreate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DatetimeOnCreate
        {
            get
            {
                return this._DatetimeOnCreate;
            }
            set
            {
                if ((this._DatetimeOnCreate != value))
                {
                    this.OnDatetimeOnCreateChanging(value);
                    this.SendPropertyChanging();
                    this._DatetimeOnCreate = value;
                    this.SendPropertyChanged("DatetimeOnCreate");
                    this.OnDatetimeOnCreateChanged();
                }
            }
        }

        [Column(Storage = "_EnglishDay", DbType = "NVarChar(50)")]
        public string EnglishDay
        {
            get
            {
                return this._EnglishDay;
            }
            set
            {
                if ((this._EnglishDay != value))
                {
                    this.OnEnglishDayChanging(value);
                    this.SendPropertyChanging();
                    this._EnglishDay = value;
                    this.SendPropertyChanged("EnglishDay");
                    this.OnEnglishDayChanged();
                }
            }
        }

        [Column(Storage = "_ThaiDay", DbType = "NVarChar(50)")]
        public string ThaiDay
        {
            get
            {
                return this._ThaiDay;
            }
            set
            {
                if ((this._ThaiDay != value))
                {
                    this.OnThaiDayChanging(value);
                    this.SendPropertyChanging();
                    this._ThaiDay = value;
                    this.SendPropertyChanged("ThaiDay");
                    this.OnThaiDayChanged();
                }
            }
        }

        [Column(Storage = "_DayNumberOfMonth", DbType = "Int")]
        public System.Nullable<int> DayNumberOfMonth
        {
            get
            {
                return this._DayNumberOfMonth;
            }
            set
            {
                if ((this._DayNumberOfMonth != value))
                {
                    this.OnDayNumberOfMonthChanging(value);
                    this.SendPropertyChanging();
                    this._DayNumberOfMonth = value;
                    this.SendPropertyChanged("DayNumberOfMonth");
                    this.OnDayNumberOfMonthChanged();
                }
            }
        }

        [Column(Storage = "_EnglishMonth", DbType = "NVarChar(50)")]
        public string EnglishMonth
        {
            get
            {
                return this._EnglishMonth;
            }
            set
            {
                if ((this._EnglishMonth != value))
                {
                    this.OnEnglishMonthChanging(value);
                    this.SendPropertyChanging();
                    this._EnglishMonth = value;
                    this.SendPropertyChanged("EnglishMonth");
                    this.OnEnglishMonthChanged();
                }
            }
        }

        [Column(Storage = "_ThaiMonth", DbType = "NVarChar(50)")]
        public string ThaiMonth
        {
            get
            {
                return this._ThaiMonth;
            }
            set
            {
                if ((this._ThaiMonth != value))
                {
                    this.OnThaiMonthChanging(value);
                    this.SendPropertyChanging();
                    this._ThaiMonth = value;
                    this.SendPropertyChanged("ThaiMonth");
                    this.OnThaiMonthChanged();
                }
            }
        }

        [Column(Storage = "_MonthNumberOfYear", DbType = "Int")]
        public System.Nullable<int> MonthNumberOfYear
        {
            get
            {
                return this._MonthNumberOfYear;
            }
            set
            {
                if ((this._MonthNumberOfYear != value))
                {
                    this.OnMonthNumberOfYearChanging(value);
                    this.SendPropertyChanging();
                    this._MonthNumberOfYear = value;
                    this.SendPropertyChanged("MonthNumberOfYear");
                    this.OnMonthNumberOfYearChanged();
                }
            }
        }

        [Column(Storage = "_EnglishYear", DbType = "Int")]
        public System.Nullable<int> EnglishYear
        {
            get
            {
                return this._EnglishYear;
            }
            set
            {
                if ((this._EnglishYear != value))
                {
                    this.OnEnglishYearChanging(value);
                    this.SendPropertyChanging();
                    this._EnglishYear = value;
                    this.SendPropertyChanged("EnglishYear");
                    this.OnEnglishYearChanged();
                }
            }
        }

        [Column(Storage = "_ThaiYear", DbType = "Int")]
        public System.Nullable<int> ThaiYear
        {
            get
            {
                return this._ThaiYear;
            }
            set
            {
                if ((this._ThaiYear != value))
                {
                    this.OnThaiYearChanging(value);
                    this.SendPropertyChanging();
                    this._ThaiYear = value;
                    this.SendPropertyChanged("ThaiYear");
                    this.OnThaiYearChanged();
                }
            }
        }

        [Column(Storage = "_DayOfWeek", DbType = "Int")]
        public System.Nullable<int> DayOfWeek
        {
            get
            {
                return this._DayOfWeek;
            }
            set
            {
                if ((this._DayOfWeek != value))
                {
                    this.OnDayOfWeekChanging(value);
                    this.SendPropertyChanging();
                    this._DayOfWeek = value;
                    this.SendPropertyChanged("DayOfWeek");
                    this.OnDayOfWeekChanged();
                }
            }
        }

        [Column(Storage = "_CalendarHalfYear", DbType = "Int")]
        public System.Nullable<int> CalendarHalfYear
        {
            get
            {
                return this._CalendarHalfYear;
            }
            set
            {
                if ((this._CalendarHalfYear != value))
                {
                    this.OnCalendarHalfYearChanging(value);
                    this.SendPropertyChanging();
                    this._CalendarHalfYear = value;
                    this.SendPropertyChanged("CalendarHalfYear");
                    this.OnCalendarHalfYearChanged();
                }
            }
        }

        [Column(Storage = "_CalendarQuarter", DbType = "Int")]
        public System.Nullable<int> CalendarQuarter
        {
            get
            {
                return this._CalendarQuarter;
            }
            set
            {
                if ((this._CalendarQuarter != value))
                {
                    this.OnCalendarQuarterChanging(value);
                    this.SendPropertyChanging();
                    this._CalendarQuarter = value;
                    this.SendPropertyChanged("CalendarQuarter");
                    this.OnCalendarQuarterChanged();
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
