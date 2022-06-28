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
    [Table(Name = "dbo.RISV_PATIENTFLOWDATA")]
    public partial class RISV_PATIENTFLOWDATA
    {

        private System.DateTime _ORDER_DT;

        private string _HN;

        private int _ORDER_ID;

        private string _ORDERING_DEPT;

        private int _EXAM_ID;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private string _ACCESSION_NO;

        private string _MODALITY_NAME;

        private string _ORDERING_BY;

        private System.Nullable<System.DateTime> _ORDER_ENTERED_ON;

        private string _CAPTURED_BY;

        private System.Nullable<System.DateTime> _IMAGE_CAPTURED_ON;

        private string _QA_BY;

        private System.Nullable<System.DateTime> _QA_ON;

        private string _PRELIM_BY;

        private System.Nullable<System.DateTime> _PRELIM_ON;

        private string _FINALIZE_BY;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private string _RAD_ID;

        private System.Nullable<System.DateTime> _APPOINT_DT;

        private System.Nullable<System.DateTime> _SCHEDULE_DT;

        public RISV_PATIENTFLOWDATA()
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

        [Column(Storage = "_ORDERING_DEPT", DbType = "NVarChar(100)")]
        public string ORDERING_DEPT
        {
            get
            {
                return this._ORDERING_DEPT;
            }
            set
            {
                if ((this._ORDERING_DEPT != value))
                {
                    this._ORDERING_DEPT = value;
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

        [Column(Storage = "_ORDERING_BY", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string ORDERING_BY
        {
            get
            {
                return this._ORDERING_BY;
            }
            set
            {
                if ((this._ORDERING_BY != value))
                {
                    this._ORDERING_BY = value;
                }
            }
        }

        [Column(Storage = "_ORDER_ENTERED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ORDER_ENTERED_ON
        {
            get
            {
                return this._ORDER_ENTERED_ON;
            }
            set
            {
                if ((this._ORDER_ENTERED_ON != value))
                {
                    this._ORDER_ENTERED_ON = value;
                }
            }
        }

        [Column(Storage = "_CAPTURED_BY", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string CAPTURED_BY
        {
            get
            {
                return this._CAPTURED_BY;
            }
            set
            {
                if ((this._CAPTURED_BY != value))
                {
                    this._CAPTURED_BY = value;
                }
            }
        }

        [Column(Storage = "_IMAGE_CAPTURED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> IMAGE_CAPTURED_ON
        {
            get
            {
                return this._IMAGE_CAPTURED_ON;
            }
            set
            {
                if ((this._IMAGE_CAPTURED_ON != value))
                {
                    this._IMAGE_CAPTURED_ON = value;
                }
            }
        }

        [Column(Storage = "_QA_BY", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string QA_BY
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

        [Column(Storage = "_PRELIM_BY", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string PRELIM_BY
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

        [Column(Storage = "_PRELIM_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> PRELIM_ON
        {
            get
            {
                return this._PRELIM_ON;
            }
            set
            {
                if ((this._PRELIM_ON != value))
                {
                    this._PRELIM_ON = value;
                }
            }
        }

        [Column(Storage = "_FINALIZE_BY", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string FINALIZE_BY
        {
            get
            {
                return this._FINALIZE_BY;
            }
            set
            {
                if ((this._FINALIZE_BY != value))
                {
                    this._FINALIZE_BY = value;
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

        [Column(Storage = "_RAD_ID", DbType = "NVarChar(122) NOT NULL", CanBeNull = false)]
        public string RAD_ID
        {
            get
            {
                return this._RAD_ID;
            }
            set
            {
                if ((this._RAD_ID != value))
                {
                    this._RAD_ID = value;
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

        [Column(Storage = "_SCHEDULE_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> SCHEDULE_DT
        {
            get
            {
                return this._SCHEDULE_DT;
            }
            set
            {
                if ((this._SCHEDULE_DT != value))
                {
                    this._SCHEDULE_DT = value;
                }
            }
        }
    }
}
