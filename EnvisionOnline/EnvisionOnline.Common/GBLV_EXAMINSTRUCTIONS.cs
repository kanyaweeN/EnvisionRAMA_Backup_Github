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
    [Table(Name = "dbo.GBLV_EXAMINSTRUCTIONS")]
    public partial class GBLV_EXAMINSTRUCTION
    {

        private int _INS_ID;

        private string _INS_UID;

        private string _EXAM_UID;

        private string _INS_TEXT;

        private System.Nullable<char> _INHERIT_GROUP;

        private System.Nullable<char> _IS_DELETED;

        private string _GOVT_ID;

        private string _EXAM_NAME;

        private string _SERVICE_TYPE;

        private int _UNIT_ID;

        private string _UNIT_UID;

        private string _UNIT_NAME;

        private System.Nullable<int> _EXAM_TYPE_ID;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _EXAM_ID;

        private string _EXAM_TYPE_UID;

        private string _EXAM_TYPE_TEXT;

        private System.Nullable<char> _IS_ACTIVE;

        private string _UNIT_INS;

        private string _EXAM_TYPE_INS;

        private string _EXAM_TYPE_INS_KID;

        public GBLV_EXAMINSTRUCTION()
        {
        }

        [Column(Storage = "_INS_ID", DbType = "Int NOT NULL")]
        public int INS_ID
        {
            get
            {
                return this._INS_ID;
            }
            set
            {
                if ((this._INS_ID != value))
                {
                    this._INS_ID = value;
                }
            }
        }

        [Column(Storage = "_INS_UID", DbType = "NVarChar(30)")]
        public string INS_UID
        {
            get
            {
                return this._INS_UID;
            }
            set
            {
                if ((this._INS_UID != value))
                {
                    this._INS_UID = value;
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

        [Column(Storage = "_INS_TEXT", DbType = "NVarChar(4000)")]
        public string INS_TEXT
        {
            get
            {
                return this._INS_TEXT;
            }
            set
            {
                if ((this._INS_TEXT != value))
                {
                    this._INS_TEXT = value;
                }
            }
        }

        [Column(Storage = "_INHERIT_GROUP", DbType = "NVarChar(1)")]
        public System.Nullable<char> INHERIT_GROUP
        {
            get
            {
                return this._INHERIT_GROUP;
            }
            set
            {
                if ((this._INHERIT_GROUP != value))
                {
                    this._INHERIT_GROUP = value;
                }
            }
        }

        [Column(Storage = "_IS_DELETED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DELETED
        {
            get
            {
                return this._IS_DELETED;
            }
            set
            {
                if ((this._IS_DELETED != value))
                {
                    this._IS_DELETED = value;
                }
            }
        }

        [Column(Storage = "_GOVT_ID", DbType = "NVarChar(30)")]
        public string GOVT_ID
        {
            get
            {
                return this._GOVT_ID;
            }
            set
            {
                if ((this._GOVT_ID != value))
                {
                    this._GOVT_ID = value;
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

        [Column(Storage = "_SERVICE_TYPE", DbType = "NVarChar(2) NOT NULL", CanBeNull = false)]
        public string SERVICE_TYPE
        {
            get
            {
                return this._SERVICE_TYPE;
            }
            set
            {
                if ((this._SERVICE_TYPE != value))
                {
                    this._SERVICE_TYPE = value;
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int NOT NULL")]
        public int UNIT_ID
        {
            get
            {
                return this._UNIT_ID;
            }
            set
            {
                if ((this._UNIT_ID != value))
                {
                    this._UNIT_ID = value;
                }
            }
        }

        [Column(Storage = "_UNIT_UID", DbType = "NVarChar(30)")]
        public string UNIT_UID
        {
            get
            {
                return this._UNIT_UID;
            }
            set
            {
                if ((this._UNIT_UID != value))
                {
                    this._UNIT_UID = value;
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

        [Column(Storage = "_EXAM_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_TYPE_ID
        {
            get
            {
                return this._EXAM_TYPE_ID;
            }
            set
            {
                if ((this._EXAM_TYPE_ID != value))
                {
                    this._EXAM_TYPE_ID = value;
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

        [Column(Storage = "_EXAM_ID", DbType = "Int")]
        public System.Nullable<int> EXAM_ID
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

        [Column(Storage = "_UNIT_INS", DbType = "NVarChar(4000)")]
        public string UNIT_INS
        {
            get
            {
                return this._UNIT_INS;
            }
            set
            {
                if ((this._UNIT_INS != value))
                {
                    this._UNIT_INS = value;
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE_INS", DbType = "NVarChar(4000)")]
        public string EXAM_TYPE_INS
        {
            get
            {
                return this._EXAM_TYPE_INS;
            }
            set
            {
                if ((this._EXAM_TYPE_INS != value))
                {
                    this._EXAM_TYPE_INS = value;
                }
            }
        }

        [Column(Storage = "_EXAM_TYPE_INS_KID", DbType = "NVarChar(4000)")]
        public string EXAM_TYPE_INS_KID
        {
            get
            {
                return this._EXAM_TYPE_INS_KID;
            }
            set
            {
                if ((this._EXAM_TYPE_INS_KID != value))
                {
                    this._EXAM_TYPE_INS_KID = value;
                }
            }
        }
    }
}
