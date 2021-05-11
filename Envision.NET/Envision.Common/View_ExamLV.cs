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
    [Table(Name = "dbo.View_ExamLV")]
    public partial class View_ExamLV
    {

        private int _EXAM_ID;

        private string _EXAM_UID;

        private string _EXAM_NAME;

        private string _EXAM_TYPE_UID;

        private string _EXAM_TYPE_TEXT;

        private string _EXAM_TYPE_ABBR;

        public View_ExamLV()
        {
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

        [Column(Storage = "_EXAM_TYPE_UID", DbType = "NVarChar(30)")]
        public string EXAM_TYPE_UID
        {
            get
            {
                return this._EXAM_TYPE_UID;
            }
            set
            {
                if ((this._EXAM_TYPE_UID != value))
                {
                    this._EXAM_TYPE_UID = value;
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE_TEXT", DbType = "NVarChar(30)")]
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

        [Column(Storage = "_EXAM_TYPE_ABBR", DbType = "NVarChar(50)")]
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
    }
}
