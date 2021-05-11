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
    [Table(Name = "dbo.RISV_SCHEDULEREPORT")]
    public partial class RISV_SCHEDULEREPORT
    {

        private string _ORG_NAME;

        private string _HN;

        private string _TITLE;

        private string _FNAME;

        private string _MNAME;

        private string _LNAME;

        private string _TITLE_ENG;

        private string _FNAME_ENG;

        private string _MNAME_ENG;

        private string _LNAME_ENG;

        private System.Nullable<System.DateTime> _DOB;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private System.Nullable<System.DateTime> _APPOINT_DT;

        private System.Nullable<decimal> _RATE;

        private string _CLINIC_TYPE_TEXT;

        private string _MODALITY_NAME;

        private System.Nullable<int> _CREATED_BY;

        private System.Data.Linq.Binary _ORG_IMG;

        private string _ORG_ADDR3;

        private string _ORG_ADDR4;

        private int _MODALITY_ID;

        private string _VENDOR_H2;

        public RISV_SCHEDULEREPORT()
        {
        }

        [Column(Storage = "_ORG_NAME", DbType = "NVarChar(100)")]
        public string ORG_NAME
        {
            get
            {
                return this._ORG_NAME;
            }
            set
            {
                if ((this._ORG_NAME != value))
                {
                    this._ORG_NAME = value;
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

        [Column(Storage = "_MNAME", DbType = "NVarChar(100)")]
        public string MNAME
        {
            get
            {
                return this._MNAME;
            }
            set
            {
                if ((this._MNAME != value))
                {
                    this._MNAME = value;
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

        [Column(Storage = "_TITLE_ENG", DbType = "NVarChar(100)")]
        public string TITLE_ENG
        {
            get
            {
                return this._TITLE_ENG;
            }
            set
            {
                if ((this._TITLE_ENG != value))
                {
                    this._TITLE_ENG = value;
                }
            }
        }

        [Column(Storage = "_FNAME_ENG", DbType = "NVarChar(100)")]
        public string FNAME_ENG
        {
            get
            {
                return this._FNAME_ENG;
            }
            set
            {
                if ((this._FNAME_ENG != value))
                {
                    this._FNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_MNAME_ENG", DbType = "NVarChar(100)")]
        public string MNAME_ENG
        {
            get
            {
                return this._MNAME_ENG;
            }
            set
            {
                if ((this._MNAME_ENG != value))
                {
                    this._MNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_LNAME_ENG", DbType = "NVarChar(100)")]
        public string LNAME_ENG
        {
            get
            {
                return this._LNAME_ENG;
            }
            set
            {
                if ((this._LNAME_ENG != value))
                {
                    this._LNAME_ENG = value;
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

        [Column(Storage = "_APPOINT_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> APPOINT_DT
        {
            get
            {
                return this._APPOINT_DT;
            }
            set
            {
                if ((this._APPOINT_DT != value))
                {
                    this._APPOINT_DT = value;
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

        [Column(Storage = "_CLINIC_TYPE_TEXT", DbType = "NVarChar(200)")]
        public string CLINIC_TYPE_TEXT
        {
            get
            {
                return this._CLINIC_TYPE_TEXT;
            }
            set
            {
                if ((this._CLINIC_TYPE_TEXT != value))
                {
                    this._CLINIC_TYPE_TEXT = value;
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

        [Column(Storage = "_ORG_IMG", DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary ORG_IMG
        {
            get
            {
                return this._ORG_IMG;
            }
            set
            {
                if ((this._ORG_IMG != value))
                {
                    this._ORG_IMG = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR3", DbType = "NVarChar(100)")]
        public string ORG_ADDR3
        {
            get
            {
                return this._ORG_ADDR3;
            }
            set
            {
                if ((this._ORG_ADDR3 != value))
                {
                    this._ORG_ADDR3 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR4", DbType = "NVarChar(100)")]
        public string ORG_ADDR4
        {
            get
            {
                return this._ORG_ADDR4;
            }
            set
            {
                if ((this._ORG_ADDR4 != value))
                {
                    this._ORG_ADDR4 = value;
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

        [Column(Storage = "_VENDOR_H2", DbType = "NVarChar(300)")]
        public string VENDOR_H2
        {
            get
            {
                return this._VENDOR_H2;
            }
            set
            {
                if ((this._VENDOR_H2 != value))
                {
                    this._VENDOR_H2 = value;
                }
            }
        }
    }
}
