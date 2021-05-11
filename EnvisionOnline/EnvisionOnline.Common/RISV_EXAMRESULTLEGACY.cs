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
    [Table(Name = "dbo.RISV_EXAMRESULTLEGACY")]
    public partial class RISV_EXAMRESULTLEGACY
    {

        private string _Status;

        private string _HN;

        private string _Accession_No;

        private string _Exam_Code;

        private string _Exam_Name;

        private string _Radiologist;

        private System.Nullable<System.DateTime> _Result_Time;

        private string _Released_by;

        private System.Nullable<System.DateTime> _Released_Time;

        private string _Finalized_by;

        private System.Nullable<System.DateTime> _Finalized_Time;

        private string _RESULT_TEXT_HTML;

        public RISV_EXAMRESULTLEGACY()
        {
        }

        [Column(Storage = "_Status", DbType = "VarChar(9) NOT NULL", CanBeNull = false)]
        public string Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                if ((this._Status != value))
                {
                    this._Status = value;
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

        [Column(Name = "[Accession No]", Storage = "_Accession_No", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string Accession_No
        {
            get
            {
                return this._Accession_No;
            }
            set
            {
                if ((this._Accession_No != value))
                {
                    this._Accession_No = value;
                }
            }
        }

        [Column(Name = "[Exam Code]", Storage = "_Exam_Code", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string Exam_Code
        {
            get
            {
                return this._Exam_Code;
            }
            set
            {
                if ((this._Exam_Code != value))
                {
                    this._Exam_Code = value;
                }
            }
        }

        [Column(Name = "[Exam Name]", Storage = "_Exam_Name", DbType = "NVarChar(300)")]
        public string Exam_Name
        {
            get
            {
                return this._Exam_Name;
            }
            set
            {
                if ((this._Exam_Name != value))
                {
                    this._Exam_Name = value;
                }
            }
        }

        [Column(Storage = "_Radiologist", DbType = "NVarChar(152) NOT NULL", CanBeNull = false)]
        public string Radiologist
        {
            get
            {
                return this._Radiologist;
            }
            set
            {
                if ((this._Radiologist != value))
                {
                    this._Radiologist = value;
                }
            }
        }

        [Column(Name = "[Result Time]", Storage = "_Result_Time", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Result_Time
        {
            get
            {
                return this._Result_Time;
            }
            set
            {
                if ((this._Result_Time != value))
                {
                    this._Result_Time = value;
                }
            }
        }

        [Column(Name = "[Released by]", Storage = "_Released_by", DbType = "NVarChar(152) NOT NULL", CanBeNull = false)]
        public string Released_by
        {
            get
            {
                return this._Released_by;
            }
            set
            {
                if ((this._Released_by != value))
                {
                    this._Released_by = value;
                }
            }
        }

        [Column(Name = "[Released Time]", Storage = "_Released_Time", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Released_Time
        {
            get
            {
                return this._Released_Time;
            }
            set
            {
                if ((this._Released_Time != value))
                {
                    this._Released_Time = value;
                }
            }
        }

        [Column(Name = "[Finalized by]", Storage = "_Finalized_by", DbType = "NVarChar(152) NOT NULL", CanBeNull = false)]
        public string Finalized_by
        {
            get
            {
                return this._Finalized_by;
            }
            set
            {
                if ((this._Finalized_by != value))
                {
                    this._Finalized_by = value;
                }
            }
        }

        [Column(Name = "[Finalized Time]", Storage = "_Finalized_Time", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Finalized_Time
        {
            get
            {
                return this._Finalized_Time;
            }
            set
            {
                if ((this._Finalized_Time != value))
                {
                    this._Finalized_Time = value;
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
    }
}
