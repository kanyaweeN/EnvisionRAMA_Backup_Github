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
    [Table(Name = "dbo.GBLV_HL7MONITORING")]
    public partial class GBLV_HL7MONITORING
    {

        private string _HN;

        private string _NAME;

        private string _EXAM_CODE;

        private string _EXAM_NAME;

        private string _ACCESSION_NO;

        private System.Nullable<char> _HL7_SEND;

        private System.DateTime _ORDER_TIME;

        private string _MSG_TYPE;

        public GBLV_HL7MONITORING()
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

        [Column(Storage = "_NAME", DbType = "NVarChar(304) NOT NULL", CanBeNull = false)]
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

        [Column(Name = "[EXAM CODE]", Storage = "_EXAM_CODE", DbType = "NVarChar(30)")]
        public string EXAM_CODE
        {
            get
            {
                return this._EXAM_CODE;
            }
            set
            {
                if ((this._EXAM_CODE != value))
                {
                    this._EXAM_CODE = value;
                }
            }
        }

        [Column(Name = "[EXAM NAME]", Storage = "_EXAM_NAME", DbType = "NVarChar(300) NOT NULL", CanBeNull = false)]
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

        [Column(Name = "[ACCESSION NO]", Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
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

        [Column(Name = "[HL7 SEND]", Storage = "_HL7_SEND", DbType = "NVarChar(1)")]
        public System.Nullable<char> HL7_SEND
        {
            get
            {
                return this._HL7_SEND;
            }
            set
            {
                if ((this._HL7_SEND != value))
                {
                    this._HL7_SEND = value;
                }
            }
        }

        [Column(Name = "[ORDER TIME]", Storage = "_ORDER_TIME", DbType = "DateTime NOT NULL")]
        public System.DateTime ORDER_TIME
        {
            get
            {
                return this._ORDER_TIME;
            }
            set
            {
                if ((this._ORDER_TIME != value))
                {
                    this._ORDER_TIME = value;
                }
            }
        }

        [Column(Name = "[MSG TYPE]", Storage = "_MSG_TYPE", DbType = "VarChar(3) NOT NULL", CanBeNull = false)]
        public string MSG_TYPE
        {
            get
            {
                return this._MSG_TYPE;
            }
            set
            {
                if ((this._MSG_TYPE != value))
                {
                    this._MSG_TYPE = value;
                }
            }
        }
    }
}
