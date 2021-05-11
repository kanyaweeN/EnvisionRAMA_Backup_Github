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
    [Table(Name = "dbo.RISV_FINALIZED")]
    public partial class RISV_FINALIZED
    {

        private string _FULLNAME;

        private string _EMP_UID;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<int> _SEVERITY_ID;

        private System.Nullable<char> _RESULT_STATUS;

        private string _RESULT_TEXT_PLAIN;

        private string _HN;

        private System.Nullable<System.DateTime> _ORDER_START_TIME;

        private int _MODALITY_ID;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _PAT_STATUS;

        private System.Nullable<int> _CLINIC_TYPE;

        private string _PRIORITY;

        private string _STATUS;

        private System.Nullable<int> _INSURANCE_TYPE_ID;

        private System.Nullable<int> _ASSIGNED_TO;

        private System.Nullable<System.DateTime> _FINALIZED_DATE;

        private int _ORDER_ID;

        private System.Nullable<int> _FINALIZED_BY;

        private string _ACCESSION_NO;

        private int _EXAM_ID;

        private System.Nullable<decimal> _RATE;

        public RISV_FINALIZED()
        {
        }

        [Column(Storage = "_FULLNAME", DbType = "NVarChar(172)")]
        public string FULLNAME
        {
            get
            {
                return this._FULLNAME;
            }
            set
            {
                if ((this._FULLNAME != value))
                {
                    this._FULLNAME = value;
                }
            }
        }

        [Column(Storage = "_EMP_UID", DbType = "NVarChar(50)")]
        public string EMP_UID
        {
            get
            {
                return this._EMP_UID;
            }
            set
            {
                if ((this._EMP_UID != value))
                {
                    this._EMP_UID = value;
                }
            }
        }

        [Column(Storage = "_FINALIZED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> FINALIZED_ON
        {
            get
            {
                return this._FINALIZED_ON;
            }
            set
            {
                if ((this._FINALIZED_ON != value))
                {
                    this._FINALIZED_ON = value;
                }
            }
        }

        [Column(Storage = "_SEVERITY_ID", DbType = "Int")]
        public System.Nullable<int> SEVERITY_ID
        {
            get
            {
                return this._SEVERITY_ID;
            }
            set
            {
                if ((this._SEVERITY_ID != value))
                {
                    this._SEVERITY_ID = value;
                }
            }
        }

        [Column(Storage = "_RESULT_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> RESULT_STATUS
        {
            get
            {
                return this._RESULT_STATUS;
            }
            set
            {
                if ((this._RESULT_STATUS != value))
                {
                    this._RESULT_STATUS = value;
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_PLAIN", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_PLAIN
        {
            get
            {
                return this._RESULT_TEXT_PLAIN;
            }
            set
            {
                if ((this._RESULT_TEXT_PLAIN != value))
                {
                    this._RESULT_TEXT_PLAIN = value;
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

        [Column(Storage = "_FINALIZED_DATE", DbType = "DateTime")]
        public System.Nullable<System.DateTime> FINALIZED_DATE
        {
            get
            {
                return this._FINALIZED_DATE;
            }
            set
            {
                if ((this._FINALIZED_DATE != value))
                {
                    this._FINALIZED_DATE = value;
                }
            }
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

        [Column(Storage = "_FINALIZED_BY", DbType = "Int")]
        public System.Nullable<int> FINALIZED_BY
        {
            get
            {
                return this._FINALIZED_BY;
            }
            set
            {
                if ((this._FINALIZED_BY != value))
                {
                    this._FINALIZED_BY = value;
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
