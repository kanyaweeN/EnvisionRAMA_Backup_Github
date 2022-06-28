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
    [Table(Name = "dbo.RISV_ORDERREPORTALL")]
    public partial class RISV_ORDERREPORTALL
    {

        private System.DateTime _ORDER_DT;

        private string _HN;

        private string _PATNAME;

        private System.Nullable<System.DateTime> _DOB;

        private string _AGE;

        private string _PAT_STATUS;

        private string _UNIT_UID;

        private string _UNIT_NAME;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private string _PREPARATION_UID;

        private string _PREPARATION_DESC;

        private string _RADNAME;

        private string _STATUS_TEXT;

        private int _MODALITY_ID;

        private string _MODALITY_NAME;

        private string _MODALITY_UID;

        public RISV_ORDERREPORTALL()
        {
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

        [Column(Storage = "_PATNAME", DbType = "NVarChar(402) NOT NULL", CanBeNull = false)]
        public string PATNAME
        {
            get
            {
                return this._PATNAME;
            }
            set
            {
                if ((this._PATNAME != value))
                {
                    this._PATNAME = value;
                }
            }
        }

        [Column(Storage = "_DOB", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DOB
        {
            get
            {
                return this._DOB;
            }
            set
            {
                if ((this._DOB != value))
                {
                    this._DOB = value;
                }
            }
        }

        [Column(Storage = "_AGE", DbType = "NVarChar(MAX)")]
        public string AGE
        {
            get
            {
                return this._AGE;
            }
            set
            {
                if ((this._AGE != value))
                {
                    this._AGE = value;
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

        [Column(Storage = "_UNIT_UID", DbType = "NVarChar(30)")]
        public string UNIT_UID
        {
            get
            {
                return this._UNIT_UID;
            }
            set
            {
                if ((this._UNIT_UID != value))
                {
                    this._UNIT_UID = value;
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
                    this._PREPARATION_UID = value;
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
                    this._PREPARATION_DESC = value;
                }
            }
        }

        [Column(Storage = "_RADNAME", DbType = "NVarChar(172) NOT NULL", CanBeNull = false)]
        public string RADNAME
        {
            get
            {
                return this._RADNAME;
            }
            set
            {
                if ((this._RADNAME != value))
                {
                    this._RADNAME = value;
                }
            }
        }

        [Column(Storage = "_STATUS_TEXT", DbType = "NVarChar(100)")]
        public string STATUS_TEXT
        {
            get
            {
                return this._STATUS_TEXT;
            }
            set
            {
                if ((this._STATUS_TEXT != value))
                {
                    this._STATUS_TEXT = value;
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

        [Column(Storage = "_MODALITY_NAME", DbType = "NVarChar(100)")]
        public string MODALITY_NAME
        {
            get
            {
                return this._MODALITY_NAME;
            }
            set
            {
                if ((this._MODALITY_NAME != value))
                {
                    this._MODALITY_NAME = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_UID", DbType = "NVarChar(50)")]
        public string MODALITY_UID
        {
            get
            {
                return this._MODALITY_UID;
            }
            set
            {
                if ((this._MODALITY_UID != value))
                {
                    this._MODALITY_UID = value;
                }
            }
        }
    }
}
