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
    [Table(Name = "dbo.GBLV_RESULTREPRINT")]
    public partial class GBLV_RESULTREPRINT
    {

        private int _ORDER_ID;

        private string _HN;

        private System.DateTime _ORDER_DT;

        private int _EXAM_ID;

        private string _ACCESSION_NO;

        private System.Nullable<int> _ASSIGNED_TO;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<char> _PRIORITY;

        private string _FNAME;

        private string _LNAME;

        private string _EXAM_NAME;

        private string _RESULT_TEXT_HTML;

        private System.Nullable<char> _RESULT_STATUS;

        private string _UNIT_NAME;

        private System.Nullable<System.DateTime> _Expr1;

        private string _EXAM_UID;

        private string _TITLE;

        private string _RFNAME;

        private string _RLNAME;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        public GBLV_RESULTREPRINT()
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

        [Column(Storage = "_PRIORITY", DbType = "NVarChar(1)")]
        public System.Nullable<char> PRIORITY
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

        [Column(Storage = "_FNAME", DbType = "NVarChar(100)")]
        public string FNAME
        {
            get
            {
                return this._FNAME;
            }
            set
            {
                if ((this._FNAME != value))
                {
                    this._FNAME = value;
                }
            }
        }

        [Column(Storage = "_LNAME", DbType = "NVarChar(100)")]
        public string LNAME
        {
            get
            {
                return this._LNAME;
            }
            set
            {
                if ((this._LNAME != value))
                {
                    this._LNAME = value;
                }
            }
        }

        [Column(Storage = "_EXAM_NAME", DbType = "NVarChar(300) NOT NULL", CanBeNull = false)]
        public string EXAM_NAME
        {
            get
            {
                return this._EXAM_NAME;
            }
            set
            {
                if ((this._EXAM_NAME != value))
                {
                    this._EXAM_NAME = value;
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_HTML", DbType = "NVarChar(MAX)")]
        public string RESULT_TEXT_HTML
        {
            get
            {
                return this._RESULT_TEXT_HTML;
            }
            set
            {
                if ((this._RESULT_TEXT_HTML != value))
                {
                    this._RESULT_TEXT_HTML = value;
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

        [Column(Storage = "_UNIT_NAME", DbType = "NVarChar(100)")]
        public string UNIT_NAME
        {
            get
            {
                return this._UNIT_NAME;
            }
            set
            {
                if ((this._UNIT_NAME != value))
                {
                    this._UNIT_NAME = value;
                }
            }
        }

        [Column(Storage = "_Expr1", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Expr1
        {
            get
            {
                return this._Expr1;
            }
            set
            {
                if ((this._Expr1 != value))
                {
                    this._Expr1 = value;
                }
            }
        }

        [Column(Storage = "_EXAM_UID", DbType = "NVarChar(30)")]
        public string EXAM_UID
        {
            get
            {
                return this._EXAM_UID;
            }
            set
            {
                if ((this._EXAM_UID != value))
                {
                    this._EXAM_UID = value;
                }
            }
        }

        [Column(Storage = "_TITLE", DbType = "NVarChar(100)")]
        public string TITLE
        {
            get
            {
                return this._TITLE;
            }
            set
            {
                if ((this._TITLE != value))
                {
                    this._TITLE = value;
                }
            }
        }

        [Column(Storage = "_RFNAME", DbType = "NVarChar(50)")]
        public string RFNAME
        {
            get
            {
                return this._RFNAME;
            }
            set
            {
                if ((this._RFNAME != value))
                {
                    this._RFNAME = value;
                }
            }
        }

        [Column(Storage = "_RLNAME", DbType = "NVarChar(50)")]
        public string RLNAME
        {
            get
            {
                return this._RLNAME;
            }
            set
            {
                if ((this._RLNAME != value))
                {
                    this._RLNAME = value;
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
    }
}
