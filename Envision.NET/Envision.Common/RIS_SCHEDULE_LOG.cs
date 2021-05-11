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
    [Table(Name = "dbo.RIS_SCHEDULE_LOG")]
    public partial class RIS_SCHEDULE_LOG
    {

        private int _ID;

        private System.Nullable<int> _SCHEDULE_ID;

        private System.Nullable<int> _REG_ID;

        private string _HN;

        private System.Nullable<int> _MODALITY_ID;

        private System.Nullable<int> _EXAM_ID;

        private System.Nullable<System.DateTime> _START_DATETIME;

        private System.Nullable<System.DateTime> _END_DATETIME;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private System.Nullable<char> _STATUS;

        private string _REASON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        public RIS_SCHEDULE_LOG()
        {
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this._ID = value;
                }
            }
        }

        [Column(Storage = "_SCHEDULE_ID", DbType = "Int")]
        public System.Nullable<int> SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    this._SCHEDULE_ID = value;
                }
            }
        }

        [Column(Storage = "_REG_ID", DbType = "Int")]
        public System.Nullable<int> REG_ID
        {
            get
            {
                return this._REG_ID;
            }
            set
            {
                if ((this._REG_ID != value))
                {
                    this._REG_ID = value;
                }
            }
        }

        [Column(Storage = "_HN", DbType = "NVarChar(30)")]
        public string HN
        {
            get
            {
                return this._HN;
            }
            set
            {
                if ((this._HN != value))
                {
                    this._HN = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int")]
        public System.Nullable<int> MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    this._MODALITY_ID = value;
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    this._EXAM_ID = value;
                }
            }
        }

        [Column(Storage = "_START_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> START_DATETIME
        {
            get
            {
                return this._START_DATETIME;
            }
            set
            {
                if ((this._START_DATETIME != value))
                {
                    this._START_DATETIME = value;
                }
            }
        }

        [Column(Storage = "_END_DATETIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> END_DATETIME
        {
            get
            {
                return this._END_DATETIME;
            }
            set
            {
                if ((this._END_DATETIME != value))
                {
                    this._END_DATETIME = value;
                }
            }
        }

        [Column(Storage = "_REF_UNIT", DbType = "Int")]
        public System.Nullable<int> REF_UNIT
        {
            get
            {
                return this._REF_UNIT;
            }
            set
            {
                if ((this._REF_UNIT != value))
                {
                    this._REF_UNIT = value;
                }
            }
        }

        [Column(Storage = "_REF_DOC", DbType = "Int")]
        public System.Nullable<int> REF_DOC
        {
            get
            {
                return this._REF_DOC;
            }
            set
            {
                if ((this._REF_DOC != value))
                {
                    this._REF_DOC = value;
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
                    this._STATUS = value;
                }
            }
        }

        [Column(Storage = "_REASON", DbType = "NVarChar(1000)")]
        public string REASON
        {
            get
            {
                return this._REASON;
            }
            set
            {
                if ((this._REASON != value))
                {
                    this._REASON = value;
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
                    this._LAST_MODIFIED_BY = value;
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
                    this._LAST_MODIFIED_ON = value;
                }
            }
        }
        public DateTime FROMDATE { get; set; }
        public DateTime TODATE { get; set; }
        public string MODE { get; set; }
    }
}
