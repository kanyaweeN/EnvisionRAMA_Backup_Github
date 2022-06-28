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
    [Table(Name = "dbo.RISV_CLINIC")]
    public partial class RISV_CLINIC
    {

        private string _CLINIC_TYPE_TEXT;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        private string _CLINIC_TYPE_UID;

        private int _CLINIC_TYPE_ID;

        private string _SESSION_NAME;

        public RISV_CLINIC()
        {
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

        [Column(Storage = "_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_ACTIVE
        {
            get
            {
                return this._IS_ACTIVE;
            }
            set
            {
                if ((this._IS_ACTIVE != value))
                {
                    this._IS_ACTIVE = value;
                }
            }
        }

        [Column(Storage = "_ORG_ID", DbType = "Int")]
        public System.Nullable<int> ORG_ID
        {
            get
            {
                return this._ORG_ID;
            }
            set
            {
                if ((this._ORG_ID != value))
                {
                    this._ORG_ID = value;
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE_UID", DbType = "NVarChar(30)")]
        public string CLINIC_TYPE_UID
        {
            get
            {
                return this._CLINIC_TYPE_UID;
            }
            set
            {
                if ((this._CLINIC_TYPE_UID != value))
                {
                    this._CLINIC_TYPE_UID = value;
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE_ID", DbType = "Int NOT NULL")]
        public int CLINIC_TYPE_ID
        {
            get
            {
                return this._CLINIC_TYPE_ID;
            }
            set
            {
                if ((this._CLINIC_TYPE_ID != value))
                {
                    this._CLINIC_TYPE_ID = value;
                }
            }
        }

        [Column(Storage = "_SESSION_NAME", DbType = "NVarChar(300)")]
        public string SESSION_NAME
        {
            get
            {
                return this._SESSION_NAME;
            }
            set
            {
                if ((this._SESSION_NAME != value))
                {
                    this._SESSION_NAME = value;
                }
            }
        }
    }
}
