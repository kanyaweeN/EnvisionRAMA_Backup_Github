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
    [Table(Name = "dbo.RISV_RESULTENTRYREPORT")]
    public partial class RISV_RESULTENTRYREPORT
    {

        private string _HN;

        private int _ORDER_ID;

        private System.DateTime _ORDER_DT;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private string _PATIENT_NAME;

        private System.Nullable<System.DateTime> _DOB;

        private string _UNIT_NAME_ALIAS;

        private string _ACCESSION_NO;

        private System.Nullable<char> _RESULT_STATUS;

        private string _RESULT_TEXT_PLAIN;

        private System.Nullable<int> _PRELIM_BY;

        private string _PRELIM_FOOTER1;

        private string _PRELIM_FOOTER2;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<int> _FINALIZED_BY;

        private string _FINAL_FOOTER1;

        private string _FINAL_FOOTER2;

        private string _UNIT_NAME;

        private string _Age;

        private string _RefDoctor;

        private string _ResultDoctor;

        private char _VN;

        private char _CreateOrder;

        private char _Expr1;

        private string _INSURANCE_TYPE_DESC;

        private string _ORG_NAME;

        private string _ORG_SLOGAN1;

        private string _ORG_SLOGAN2;

        private string _ORG_ADDR1;

        private string _ORG_ADDR2;

        private string _ORG_ADDR3;

        private string _ORG_ADDR4;

        private string _ORG_TEL1;

        private string _ORG_TEL2;

        private string _ORG_FAX;

        private string _ORG_EMAIL1;

        private string _ORG_WEBSITE;

        private System.Data.Linq.Binary _ORG_IMG;

        public RISV_RESULTENTRYREPORT()
        {
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

        [Column(Storage = "_PATIENT_NAME", DbType = "NVarChar(513)")]
        public string PATIENT_NAME
        {
            get
            {
                return this._PATIENT_NAME;
            }
            set
            {
                if ((this._PATIENT_NAME != value))
                {
                    this._PATIENT_NAME = value;
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

        [Column(Storage = "_UNIT_NAME_ALIAS", DbType = "NVarChar(100)")]
        public string UNIT_NAME_ALIAS
        {
            get
            {
                return this._UNIT_NAME_ALIAS;
            }
            set
            {
                if ((this._UNIT_NAME_ALIAS != value))
                {
                    this._UNIT_NAME_ALIAS = value;
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

        [Column(Storage = "_PRELIM_BY", DbType = "Int")]
        public System.Nullable<int> PRELIM_BY
        {
            get
            {
                return this._PRELIM_BY;
            }
            set
            {
                if ((this._PRELIM_BY != value))
                {
                    this._PRELIM_BY = value;
                }
            }
        }

        [Column(Storage = "_PRELIM_FOOTER1", DbType = "NVarChar(223)")]
        public string PRELIM_FOOTER1
        {
            get
            {
                return this._PRELIM_FOOTER1;
            }
            set
            {
                if ((this._PRELIM_FOOTER1 != value))
                {
                    this._PRELIM_FOOTER1 = value;
                }
            }
        }

        [Column(Storage = "_PRELIM_FOOTER2", DbType = "NVarChar(223)")]
        public string PRELIM_FOOTER2
        {
            get
            {
                return this._PRELIM_FOOTER2;
            }
            set
            {
                if ((this._PRELIM_FOOTER2 != value))
                {
                    this._PRELIM_FOOTER2 = value;
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

        [Column(Storage = "_FINAL_FOOTER1", DbType = "NVarChar(223)")]
        public string FINAL_FOOTER1
        {
            get
            {
                return this._FINAL_FOOTER1;
            }
            set
            {
                if ((this._FINAL_FOOTER1 != value))
                {
                    this._FINAL_FOOTER1 = value;
                }
            }
        }

        [Column(Storage = "_FINAL_FOOTER2", DbType = "NVarChar(223)")]
        public string FINAL_FOOTER2
        {
            get
            {
                return this._FINAL_FOOTER2;
            }
            set
            {
                if ((this._FINAL_FOOTER2 != value))
                {
                    this._FINAL_FOOTER2 = value;
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

        [Column(Storage = "_Age", DbType = "NVarChar(MAX)")]
        public string Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                if ((this._Age != value))
                {
                    this._Age = value;
                }
            }
        }

        [Column(Storage = "_RefDoctor", DbType = "NVarChar(MAX)")]
        public string RefDoctor
        {
            get
            {
                return this._RefDoctor;
            }
            set
            {
                if ((this._RefDoctor != value))
                {
                    this._RefDoctor = value;
                }
            }
        }

        [Column(Storage = "_ResultDoctor", DbType = "NVarChar(MAX)")]
        public string ResultDoctor
        {
            get
            {
                return this._ResultDoctor;
            }
            set
            {
                if ((this._ResultDoctor != value))
                {
                    this._ResultDoctor = value;
                }
            }
        }

        [Column(Storage = "_VN", DbType = "VarChar(1) NOT NULL")]
        public char VN
        {
            get
            {
                return this._VN;
            }
            set
            {
                if ((this._VN != value))
                {
                    this._VN = value;
                }
            }
        }

        [Column(Storage = "_CreateOrder", DbType = "VarChar(1) NOT NULL")]
        public char CreateOrder
        {
            get
            {
                return this._CreateOrder;
            }
            set
            {
                if ((this._CreateOrder != value))
                {
                    this._CreateOrder = value;
                }
            }
        }

        [Column(Storage = "_Expr1", DbType = "VarChar(1) NOT NULL")]
        public char Expr1
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

        [Column(Storage = "_INSURANCE_TYPE_DESC", DbType = "NVarChar(200)")]
        public string INSURANCE_TYPE_DESC
        {
            get
            {
                return this._INSURANCE_TYPE_DESC;
            }
            set
            {
                if ((this._INSURANCE_TYPE_DESC != value))
                {
                    this._INSURANCE_TYPE_DESC = value;
                }
            }
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

        [Column(Storage = "_ORG_SLOGAN1", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN1
        {
            get
            {
                return this._ORG_SLOGAN1;
            }
            set
            {
                if ((this._ORG_SLOGAN1 != value))
                {
                    this._ORG_SLOGAN1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_SLOGAN2", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN2
        {
            get
            {
                return this._ORG_SLOGAN2;
            }
            set
            {
                if ((this._ORG_SLOGAN2 != value))
                {
                    this._ORG_SLOGAN2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR1", DbType = "NVarChar(100)")]
        public string ORG_ADDR1
        {
            get
            {
                return this._ORG_ADDR1;
            }
            set
            {
                if ((this._ORG_ADDR1 != value))
                {
                    this._ORG_ADDR1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR2", DbType = "NVarChar(100)")]
        public string ORG_ADDR2
        {
            get
            {
                return this._ORG_ADDR2;
            }
            set
            {
                if ((this._ORG_ADDR2 != value))
                {
                    this._ORG_ADDR2 = value;
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

        [Column(Storage = "_ORG_TEL1", DbType = "NVarChar(100)")]
        public string ORG_TEL1
        {
            get
            {
                return this._ORG_TEL1;
            }
            set
            {
                if ((this._ORG_TEL1 != value))
                {
                    this._ORG_TEL1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_TEL2", DbType = "NVarChar(100)")]
        public string ORG_TEL2
        {
            get
            {
                return this._ORG_TEL2;
            }
            set
            {
                if ((this._ORG_TEL2 != value))
                {
                    this._ORG_TEL2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_FAX", DbType = "NVarChar(100)")]
        public string ORG_FAX
        {
            get
            {
                return this._ORG_FAX;
            }
            set
            {
                if ((this._ORG_FAX != value))
                {
                    this._ORG_FAX = value;
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL1", DbType = "NVarChar(100)")]
        public string ORG_EMAIL1
        {
            get
            {
                return this._ORG_EMAIL1;
            }
            set
            {
                if ((this._ORG_EMAIL1 != value))
                {
                    this._ORG_EMAIL1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_WEBSITE", DbType = "NVarChar(100)")]
        public string ORG_WEBSITE
        {
            get
            {
                return this._ORG_WEBSITE;
            }
            set
            {
                if ((this._ORG_WEBSITE != value))
                {
                    this._ORG_WEBSITE = value;
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
    }
}
