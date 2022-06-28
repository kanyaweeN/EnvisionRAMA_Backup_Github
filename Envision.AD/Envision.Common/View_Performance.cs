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
    [Table(Name = "dbo.View_Performance")]
    public partial class View_Performance
    {

        private int _ORDER_ID;

        private int _EXAM_ID;

        private int _EXAM_TYPE;

        private System.Nullable<int> _CLINIC_TYPE;

        private System.Nullable<int> _MODALITY_ID;

        private System.Nullable<int> _MODALITY_TYPE;

        private int _REF_UNIT;

        private System.Nullable<int> _ORDER_CREATE_BY;

        private System.Nullable<int> _PRELIM_BY;

        private System.Nullable<int> _FINALIZED_BY;

        private System.Nullable<int> _INSURANCE_TYPE_ID;

        private int _NumberOfPrelim;

        private int _NumberOfFinalized;

        private int _NumberOfOrder;

        private System.Nullable<int> _Hour_Of_PRELIM;

        private System.Nullable<int> _Hour_Of_FINALIZED;

        private decimal _RATE;

        private string _OrderCreate;

        private System.Nullable<System.DateTime> _FINALIZED_ON;

        private System.Nullable<System.DateTime> _RELEASED_ON;

        public View_Performance()
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

        [Column(Storage = "_EXAM_TYPE", DbType = "Int NOT NULL")]
        public int EXAM_TYPE
        {
            get
            {
                return this._EXAM_TYPE;
            }
            set
            {
                if ((this._EXAM_TYPE != value))
                {
                    this._EXAM_TYPE = value;
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

        [Column(Storage = "_MODALITY_ID", DbType = "Int")]
        public System.Nullable<int> MODALITY_ID
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

        [Column(Storage = "_MODALITY_TYPE", DbType = "Int")]
        public System.Nullable<int> MODALITY_TYPE
        {
            get
            {
                return this._MODALITY_TYPE;
            }
            set
            {
                if ((this._MODALITY_TYPE != value))
                {
                    this._MODALITY_TYPE = value;
                }
            }
        }

        [Column(Storage = "_REF_UNIT", DbType = "Int NOT NULL")]
        public int REF_UNIT
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

        [Column(Storage = "_ORDER_CREATE_BY", DbType = "Int")]
        public System.Nullable<int> ORDER_CREATE_BY
        {
            get
            {
                return this._ORDER_CREATE_BY;
            }
            set
            {
                if ((this._ORDER_CREATE_BY != value))
                {
                    this._ORDER_CREATE_BY = value;
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

        [Column(Storage = "_NumberOfPrelim", DbType = "Int NOT NULL")]
        public int NumberOfPrelim
        {
            get
            {
                return this._NumberOfPrelim;
            }
            set
            {
                if ((this._NumberOfPrelim != value))
                {
                    this._NumberOfPrelim = value;
                }
            }
        }

        [Column(Storage = "_NumberOfFinalized", DbType = "Int NOT NULL")]
        public int NumberOfFinalized
        {
            get
            {
                return this._NumberOfFinalized;
            }
            set
            {
                if ((this._NumberOfFinalized != value))
                {
                    this._NumberOfFinalized = value;
                }
            }
        }

        [Column(Storage = "_NumberOfOrder", DbType = "Int NOT NULL")]
        public int NumberOfOrder
        {
            get
            {
                return this._NumberOfOrder;
            }
            set
            {
                if ((this._NumberOfOrder != value))
                {
                    this._NumberOfOrder = value;
                }
            }
        }

        [Column(Storage = "_Hour_Of_PRELIM", DbType = "Int")]
        public System.Nullable<int> Hour_Of_PRELIM
        {
            get
            {
                return this._Hour_Of_PRELIM;
            }
            set
            {
                if ((this._Hour_Of_PRELIM != value))
                {
                    this._Hour_Of_PRELIM = value;
                }
            }
        }

        [Column(Storage = "_Hour_Of_FINALIZED", DbType = "Int")]
        public System.Nullable<int> Hour_Of_FINALIZED
        {
            get
            {
                return this._Hour_Of_FINALIZED;
            }
            set
            {
                if ((this._Hour_Of_FINALIZED != value))
                {
                    this._Hour_Of_FINALIZED = value;
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(18,2) NOT NULL")]
        public decimal RATE
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

        [Column(Storage = "_OrderCreate", DbType = "NVarChar(10)")]
        public string OrderCreate
        {
            get
            {
                return this._OrderCreate;
            }
            set
            {
                if ((this._OrderCreate != value))
                {
                    this._OrderCreate = value;
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

        [Column(Storage = "_RELEASED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RELEASED_ON
        {
            get
            {
                return this._RELEASED_ON;
            }
            set
            {
                if ((this._RELEASED_ON != value))
                {
                    this._RELEASED_ON = value;
                }
            }
        }
    }
}
