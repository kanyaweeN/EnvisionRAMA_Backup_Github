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
    [Table(Name = "dbo.GBLV_PATIENTPOSITION")]
    public partial class GBLV_PATIENTPOSITION
    {

        private int _REG_ID;

        private string _HN;

        private System.Nullable<System.DateTime> _REG_DT;

        private string _NAME;

        private string _ENGLISH_NAME;

        private string _SSN;

        private System.Nullable<System.DateTime> _DOB;

        private string _PHONE1;

        private System.Nullable<char> _GENDER;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private int _ORDER_ID;

        private System.DateTime _ORDER_DT;

        private string _ORDERING_UNIT;

        private string _ORDERING_DOC;

        private string _ACCESSION_NO;

        private System.Nullable<System.DateTime> _EST_START_TIME;

        private string _RESULT_TEXT_HTML;

        private string _RADIOLOGIST;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        public GBLV_PATIENTPOSITION()
        {
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

        [Column(Storage = "_HN", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_REG_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> REG_DT
        {
            get
            {
                return this._REG_DT;
            }
            set
            {
                if ((this._REG_DT != value))
                {
                    this._REG_DT = value;
                }
            }
        }

        [Column(Storage = "_NAME", DbType = "NVarChar(403)")]
        public string NAME
        {
            get
            {
                return this._NAME;
            }
            set
            {
                if ((this._NAME != value))
                {
                    this._NAME = value;
                }
            }
        }

        [Column(Storage = "_ENGLISH_NAME", DbType = "NVarChar(403)")]
        public string ENGLISH_NAME
        {
            get
            {
                return this._ENGLISH_NAME;
            }
            set
            {
                if ((this._ENGLISH_NAME != value))
                {
                    this._ENGLISH_NAME = value;
                }
            }
        }

        [Column(Storage = "_SSN", DbType = "NVarChar(100)")]
        public string SSN
        {
            get
            {
                return this._SSN;
            }
            set
            {
                if ((this._SSN != value))
                {
                    this._SSN = value;
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

        [Column(Storage = "_PHONE1", DbType = "NVarChar(100)")]
        public string PHONE1
        {
            get
            {
                return this._PHONE1;
            }
            set
            {
                if ((this._PHONE1 != value))
                {
                    this._PHONE1 = value;
                }
            }
        }

        [Column(Storage = "_GENDER", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENDER
        {
            get
            {
                return this._GENDER;
            }
            set
            {
                if ((this._GENDER != value))
                {
                    this._GENDER = value;
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

        [Column(Storage = "_ORDERING_UNIT", DbType = "NVarChar(100)")]
        public string ORDERING_UNIT
        {
            get
            {
                return this._ORDERING_UNIT;
            }
            set
            {
                if ((this._ORDERING_UNIT != value))
                {
                    this._ORDERING_UNIT = value;
                }
            }
        }

        [Column(Storage = "_ORDERING_DOC", DbType = "NVarChar(54)")]
        public string ORDERING_DOC
        {
            get
            {
                return this._ORDERING_DOC;
            }
            set
            {
                if ((this._ORDERING_DOC != value))
                {
                    this._ORDERING_DOC = value;
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

        [Column(Storage = "_EST_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EST_START_TIME
        {
            get
            {
                return this._EST_START_TIME;
            }
            set
            {
                if ((this._EST_START_TIME != value))
                {
                    this._EST_START_TIME = value;
                }
            }
        }

        [Column(Storage = "_RESULT_TEXT_HTML", DbType = "NVarChar(4000)")]
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

        [Column(Storage = "_RADIOLOGIST", DbType = "NVarChar(54)")]
        public string RADIOLOGIST
        {
            get
            {
                return this._RADIOLOGIST;
            }
            set
            {
                if ((this._RADIOLOGIST != value))
                {
                    this._RADIOLOGIST = value;
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
