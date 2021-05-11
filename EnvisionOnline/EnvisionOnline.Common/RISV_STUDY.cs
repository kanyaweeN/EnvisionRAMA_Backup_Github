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
    [Table(Name = "dbo.RISV_STUDY")]
    public partial class RISV_STUDY
    {

        private int _ORDER_ID;

        private string _HN;

        private System.DateTime _ORDER_DT;

        private System.Nullable<System.DateTime> _ORDER_START_TIME;

        private string _ACCESSION_NO;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _IS_CANCELED;

        private int _MODALITY_ID;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _PAT_STATUS;

        private System.Nullable<int> _ASSIGNED_BY;

        private System.Nullable<System.DateTime> _ASSIGNED_TIMESTAMP;

        private System.Nullable<int> _CLINIC_TYPE;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private string _PRIORITY;

        private string _STATUS;

        private System.Nullable<int> _INSURANCE_TYPE_ID;

        private System.Nullable<System.DateTime> _QA_ON;

        private System.Nullable<int> _QA_BY;

        private int _REG_ID;

        private System.Nullable<char> _HIS_SYNC;

        private string _HIS_ACK;

        private System.Nullable<int> _ASSIGNED_TO;

        private int _EXAM_ID;

        private System.Nullable<System.DateTime> _LASTMODIFIED_DATE;

        private System.Nullable<decimal> _RATE;

        public RISV_STUDY()
        {
        }

        [Column(Storage = "_ORDER_ID", DbType = "Int NOT NULL")]
        public int ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    this._ORDER_ID = value;
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

        [Column(Storage = "_ORDER_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime ORDER_DT
        {
            get
            {
                return this._ORDER_DT;
            }
            set
            {
                if ((this._ORDER_DT != value))
                {
                    this._ORDER_DT = value;
                }
            }
        }

        [Column(Storage = "_ORDER_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ORDER_START_TIME
        {
            get
            {
                return this._ORDER_START_TIME;
            }
            set
            {
                if ((this._ORDER_START_TIME != value))
                {
                    this._ORDER_START_TIME = value;
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
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
                    this._ACCESSION_NO = value;
                }
            }
        }

        [Column(Storage = "_IS_DELETED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DELETED
        {
            get
            {
                return this._IS_DELETED;
            }
            set
            {
                if ((this._IS_DELETED != value))
                {
                    this._IS_DELETED = value;
                }
            }
        }

        [Column(Storage = "_IS_CANCELED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_CANCELED
        {
            get
            {
                return this._IS_CANCELED;
            }
            set
            {
                if ((this._IS_CANCELED != value))
                {
                    this._IS_CANCELED = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int NOT NULL")]
        public int MODALITY_ID
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

        [Column(Storage = "_PAT_STATUS", DbType = "NVarChar(3)")]
        public string PAT_STATUS
        {
            get
            {
                return this._PAT_STATUS;
            }
            set
            {
                if ((this._PAT_STATUS != value))
                {
                    this._PAT_STATUS = value;
                }
            }
        }

        [Column(Storage = "_ASSIGNED_BY", DbType = "Int")]
        public System.Nullable<int> ASSIGNED_BY
        {
            get
            {
                return this._ASSIGNED_BY;
            }
            set
            {
                if ((this._ASSIGNED_BY != value))
                {
                    this._ASSIGNED_BY = value;
                }
            }
        }

        [Column(Storage = "_ASSIGNED_TIMESTAMP", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ASSIGNED_TIMESTAMP
        {
            get
            {
                return this._ASSIGNED_TIMESTAMP;
            }
            set
            {
                if ((this._ASSIGNED_TIMESTAMP != value))
                {
                    this._ASSIGNED_TIMESTAMP = value;
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE", DbType = "Int")]
        public System.Nullable<int> CLINIC_TYPE
        {
            get
            {
                return this._CLINIC_TYPE;
            }
            set
            {
                if ((this._CLINIC_TYPE != value))
                {
                    this._CLINIC_TYPE = value;
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
                    this._CREATED_BY = value;
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
                    this._CREATED_ON = value;
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

        [Column(Storage = "_PRIORITY", DbType = "VarChar(7)")]
        public string PRIORITY
        {
            get
            {
                return this._PRIORITY;
            }
            set
            {
                if ((this._PRIORITY != value))
                {
                    this._PRIORITY = value;
                }
            }
        }

        [Column(Storage = "_STATUS", DbType = "VarChar(11)")]
        public string STATUS
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

        [Column(Storage = "_INSURANCE_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> INSURANCE_TYPE_ID
        {
            get
            {
                return this._INSURANCE_TYPE_ID;
            }
            set
            {
                if ((this._INSURANCE_TYPE_ID != value))
                {
                    this._INSURANCE_TYPE_ID = value;
                }
            }
        }

        [Column(Storage = "_QA_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> QA_ON
        {
            get
            {
                return this._QA_ON;
            }
            set
            {
                if ((this._QA_ON != value))
                {
                    this._QA_ON = value;
                }
            }
        }

        [Column(Storage = "_QA_BY", DbType = "Int")]
        public System.Nullable<int> QA_BY
        {
            get
            {
                return this._QA_BY;
            }
            set
            {
                if ((this._QA_BY != value))
                {
                    this._QA_BY = value;
                }
            }
        }

        [Column(Storage = "_REG_ID", DbType = "Int NOT NULL")]
        public int REG_ID
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

        [Column(Storage = "_HIS_SYNC", DbType = "NVarChar(1)")]
        public System.Nullable<char> HIS_SYNC
        {
            get
            {
                return this._HIS_SYNC;
            }
            set
            {
                if ((this._HIS_SYNC != value))
                {
                    this._HIS_SYNC = value;
                }
            }
        }

        [Column(Storage = "_HIS_ACK", DbType = "NVarChar(300)")]
        public string HIS_ACK
        {
            get
            {
                return this._HIS_ACK;
            }
            set
            {
                if ((this._HIS_ACK != value))
                {
                    this._HIS_ACK = value;
                }
            }
        }

        [Column(Storage = "_ASSIGNED_TO", DbType = "Int")]
        public System.Nullable<int> ASSIGNED_TO
        {
            get
            {
                return this._ASSIGNED_TO;
            }
            set
            {
                if ((this._ASSIGNED_TO != value))
                {
                    this._ASSIGNED_TO = value;
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL")]
        public int EXAM_ID
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

        [Column(Storage = "_LASTMODIFIED_DATE", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LASTMODIFIED_DATE
        {
            get
            {
                return this._LASTMODIFIED_DATE;
            }
            set
            {
                if ((this._LASTMODIFIED_DATE != value))
                {
                    this._LASTMODIFIED_DATE = value;
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> RATE
        {
            get
            {
                return this._RATE;
            }
            set
            {
                if ((this._RATE != value))
                {
                    this._RATE = value;
                }
            }
        }
    }
}
