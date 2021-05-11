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
    [Table(Name = "dbo.GBLV_ORDERINGDEPARTMENT")]
    public partial class GBLV_ORDERINGDEPARTMENT
    {

        private string _FNAME;

        private string _MNAME;

        private string _LNAME;

        private string _UNIT_NAME;

        private string _ACCESSION_NO;

        private System.Nullable<int> _REF_UNIT;

        private System.Nullable<int> _REF_DOC;

        private string _PHONE_NO;

        public GBLV_ORDERINGDEPARTMENT()
        {
        }

        [Column(Storage = "_FNAME", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_MNAME", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_LNAME", DbType = "NVarChar(50)")]
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

        [Column(Storage = "_REF_UNIT", DbType = "Int")]
        public System.Nullable<int> REF_UNIT
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

        [Column(Storage = "_REF_DOC", DbType = "Int")]
        public System.Nullable<int> REF_DOC
        {
            get
            {
                return this._REF_DOC;
            }
            set
            {
                if ((this._REF_DOC != value))
                {
                    this._REF_DOC = value;
                }
            }
        }

        [Column(Storage = "_PHONE_NO", DbType = "NVarChar(50)")]
        public string PHONE_NO
        {
            get
            {
                return this._PHONE_NO;
            }
            set
            {
                if ((this._PHONE_NO != value))
                {
                    this._PHONE_NO = value;
                }
            }
        }
    }
}
