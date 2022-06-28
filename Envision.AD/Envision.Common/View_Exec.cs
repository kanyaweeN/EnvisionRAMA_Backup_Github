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
    [Table(Name = "dbo.View_Exec")]
    public partial class View_Exec
    {

        private int _ORDER_ID;

        private string _EXAM_NAME;

        private string _CLINIC_TYPE_TEXT;

        private string _EXAM_TYPE_TEXT;

        private string _EXAM_TYPE_ABBR;

        private string _UNIT_NAME;

        public View_Exec()
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

        [Column(Storage = "_EXAM_TYPE_TEXT", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
        public string EXAM_TYPE_TEXT
        {
            get
            {
                return this._EXAM_TYPE_TEXT;
            }
            set
            {
                if ((this._EXAM_TYPE_TEXT != value))
                {
                    this._EXAM_TYPE_TEXT = value;
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE_ABBR", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string EXAM_TYPE_ABBR
        {
            get
            {
                return this._EXAM_TYPE_ABBR;
            }
            set
            {
                if ((this._EXAM_TYPE_ABBR != value))
                {
                    this._EXAM_TYPE_ABBR = value;
                }
            }
        }

        [Column(Storage = "_UNIT_NAME", DbType = "NVarChar(100) NOT NULL", CanBeNull = false)]
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
    }
}
