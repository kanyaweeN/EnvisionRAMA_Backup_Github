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
    [Table(Name = "dbo.GBLV_GRANTROLE_ROLE")]
    public partial class GBLV_GRANTROLE_ROLE
    {

        private System.Nullable<int> _GRANTROLE_ID;

        private System.Nullable<int> _CAN_GRANT;

        private System.Nullable<int> _EMP_ID;

        private string _EMP_UID;

        private string _USER_NAME;

        private System.Nullable<int> _UNIT_ID;

        private System.Nullable<int> _JOBTITLE_ID;

        private int _ROLE_ID;

        private string _ROLE_UID;

        private string _ROLE_NAME;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<char> _IS_DELETED;

        public GBLV_GRANTROLE_ROLE()
        {
        }

        [Column(Storage = "_GRANTROLE_ID", DbType = "Int")]
        public System.Nullable<int> GRANTROLE_ID
        {
            get
            {
                return this._GRANTROLE_ID;
            }
            set
            {
                if ((this._GRANTROLE_ID != value))
                {
                    this._GRANTROLE_ID = value;
                }
            }
        }

        [Column(Storage = "_CAN_GRANT", DbType = "Int")]
        public System.Nullable<int> CAN_GRANT
        {
            get
            {
                return this._CAN_GRANT;
            }
            set
            {
                if ((this._CAN_GRANT != value))
                {
                    this._CAN_GRANT = value;
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int")]
        public System.Nullable<int> EMP_ID
        {
            get
            {
                return this._EMP_ID;
            }
            set
            {
                if ((this._EMP_ID != value))
                {
                    this._EMP_ID = value;
                }
            }
        }

        [Column(Storage = "_EMP_UID", DbType = "NVarChar(50)")]
        public string EMP_UID
        {
            get
            {
                return this._EMP_UID;
            }
            set
            {
                if ((this._EMP_UID != value))
                {
                    this._EMP_UID = value;
                }
            }
        }

        [Column(Storage = "_USER_NAME", DbType = "NVarChar(50)")]
        public string USER_NAME
        {
            get
            {
                return this._USER_NAME;
            }
            set
            {
                if ((this._USER_NAME != value))
                {
                    this._USER_NAME = value;
                }
            }
        }

        [Column(Storage = "_UNIT_ID", DbType = "Int")]
        public System.Nullable<int> UNIT_ID
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

        [Column(Storage = "_JOBTITLE_ID", DbType = "Int")]
        public System.Nullable<int> JOBTITLE_ID
        {
            get
            {
                return this._JOBTITLE_ID;
            }
            set
            {
                if ((this._JOBTITLE_ID != value))
                {
                    this._JOBTITLE_ID = value;
                }
            }
        }

        [Column(Storage = "_ROLE_ID", DbType = "Int NOT NULL")]
        public int ROLE_ID
        {
            get
            {
                return this._ROLE_ID;
            }
            set
            {
                if ((this._ROLE_ID != value))
                {
                    this._ROLE_ID = value;
                }
            }
        }

        [Column(Storage = "_ROLE_UID", DbType = "NVarChar(50)")]
        public string ROLE_UID
        {
            get
            {
                return this._ROLE_UID;
            }
            set
            {
                if ((this._ROLE_UID != value))
                {
                    this._ROLE_UID = value;
                }
            }
        }

        [Column(Storage = "_ROLE_NAME", DbType = "NVarChar(50)")]
        public string ROLE_NAME
        {
            get
            {
                return this._ROLE_NAME;
            }
            set
            {
                if ((this._ROLE_NAME != value))
                {
                    this._ROLE_NAME = value;
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
    }
}
