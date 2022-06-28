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
    [Table(Name = "dbo.GBLV_SETMENU")]
    public partial class GBLV_SETMENU
    {

        private int _ORG_ID;

        private int _ROLE_ID;

        private string _ROLE_UID;

        private string _ROLE_NAME;

        private System.Nullable<char> _ROLE_IS_ACTIVE;

        private int _EMP_ID;

        private string _USER_NAME;

        private System.Nullable<char> _EMP_IS_ACTIVE;

        private int _SUBMENU_ID;

        private string _SUBMENU_CLASS_NAME;

        private string _SUBMENU_NAME_USER;

        private System.Nullable<int> _SUBMENU_SL_NO;

        private System.Nullable<char> _SUBMENU_TYPE;

        private System.Nullable<char> _SUBMENU_IS_ACTIVE;

        private int _MENU_ID;

        private System.Nullable<int> _MENU_SL_NO;

        private string _MENU_NAME;

        private string _MENU_NAMESPACE;

        private System.Nullable<char> _MENU_IS_ACTIVE;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _GRANTROLE_IS_DELETED;

        private System.Nullable<char> _GRANTROLE_IS_UPDATED;

        public GBLV_SETMENU()
        {
        }

        [Column(Storage = "_ORG_ID", DbType = "Int NOT NULL")]
        public int ORG_ID
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

        [Column(Storage = "_ROLE_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ROLE_IS_ACTIVE
        {
            get
            {
                return this._ROLE_IS_ACTIVE;
            }
            set
            {
                if ((this._ROLE_IS_ACTIVE != value))
                {
                    this._ROLE_IS_ACTIVE = value;
                }
            }
        }

        [Column(Storage = "_EMP_ID", DbType = "Int NOT NULL")]
        public int EMP_ID
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

        [Column(Storage = "_EMP_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> EMP_IS_ACTIVE
        {
            get
            {
                return this._EMP_IS_ACTIVE;
            }
            set
            {
                if ((this._EMP_IS_ACTIVE != value))
                {
                    this._EMP_IS_ACTIVE = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_ID", DbType = "Int NOT NULL")]
        public int SUBMENU_ID
        {
            get
            {
                return this._SUBMENU_ID;
            }
            set
            {
                if ((this._SUBMENU_ID != value))
                {
                    this._SUBMENU_ID = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_CLASS_NAME", DbType = "NVarChar(50)")]
        public string SUBMENU_CLASS_NAME
        {
            get
            {
                return this._SUBMENU_CLASS_NAME;
            }
            set
            {
                if ((this._SUBMENU_CLASS_NAME != value))
                {
                    this._SUBMENU_CLASS_NAME = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_NAME_USER", DbType = "NVarChar(50)")]
        public string SUBMENU_NAME_USER
        {
            get
            {
                return this._SUBMENU_NAME_USER;
            }
            set
            {
                if ((this._SUBMENU_NAME_USER != value))
                {
                    this._SUBMENU_NAME_USER = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_SL_NO", DbType = "Int")]
        public System.Nullable<int> SUBMENU_SL_NO
        {
            get
            {
                return this._SUBMENU_SL_NO;
            }
            set
            {
                if ((this._SUBMENU_SL_NO != value))
                {
                    this._SUBMENU_SL_NO = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> SUBMENU_TYPE
        {
            get
            {
                return this._SUBMENU_TYPE;
            }
            set
            {
                if ((this._SUBMENU_TYPE != value))
                {
                    this._SUBMENU_TYPE = value;
                }
            }
        }

        [Column(Storage = "_SUBMENU_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> SUBMENU_IS_ACTIVE
        {
            get
            {
                return this._SUBMENU_IS_ACTIVE;
            }
            set
            {
                if ((this._SUBMENU_IS_ACTIVE != value))
                {
                    this._SUBMENU_IS_ACTIVE = value;
                }
            }
        }

        [Column(Storage = "_MENU_ID", DbType = "Int NOT NULL")]
        public int MENU_ID
        {
            get
            {
                return this._MENU_ID;
            }
            set
            {
                if ((this._MENU_ID != value))
                {
                    this._MENU_ID = value;
                }
            }
        }

        [Column(Storage = "_MENU_SL_NO", DbType = "Int")]
        public System.Nullable<int> MENU_SL_NO
        {
            get
            {
                return this._MENU_SL_NO;
            }
            set
            {
                if ((this._MENU_SL_NO != value))
                {
                    this._MENU_SL_NO = value;
                }
            }
        }

        [Column(Storage = "_MENU_NAME", DbType = "NVarChar(50)")]
        public string MENU_NAME
        {
            get
            {
                return this._MENU_NAME;
            }
            set
            {
                if ((this._MENU_NAME != value))
                {
                    this._MENU_NAME = value;
                }
            }
        }

        [Column(Storage = "_MENU_NAMESPACE", DbType = "NVarChar(100)")]
        public string MENU_NAMESPACE
        {
            get
            {
                return this._MENU_NAMESPACE;
            }
            set
            {
                if ((this._MENU_NAMESPACE != value))
                {
                    this._MENU_NAMESPACE = value;
                }
            }
        }

        [Column(Storage = "_MENU_IS_ACTIVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> MENU_IS_ACTIVE
        {
            get
            {
                return this._MENU_IS_ACTIVE;
            }
            set
            {
                if ((this._MENU_IS_ACTIVE != value))
                {
                    this._MENU_IS_ACTIVE = value;
                }
            }
        }

        [Column(Storage = "_IS_UPDATED", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_UPDATED
        {
            get
            {
                return this._IS_UPDATED;
            }
            set
            {
                if ((this._IS_UPDATED != value))
                {
                    this._IS_UPDATED = value;
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

        [Column(Storage = "_GRANTROLE_IS_DELETED", DbType = "NVarChar(1)")]
        public System.Nullable<char> GRANTROLE_IS_DELETED
        {
            get
            {
                return this._GRANTROLE_IS_DELETED;
            }
            set
            {
                if ((this._GRANTROLE_IS_DELETED != value))
                {
                    this._GRANTROLE_IS_DELETED = value;
                }
            }
        }

        [Column(Storage = "_GRANTROLE_IS_UPDATED", DbType = "NVarChar(1)")]
        public System.Nullable<char> GRANTROLE_IS_UPDATED
        {
            get
            {
                return this._GRANTROLE_IS_UPDATED;
            }
            set
            {
                if ((this._GRANTROLE_IS_UPDATED != value))
                {
                    this._GRANTROLE_IS_UPDATED = value;
                }
            }
        }
    }
}
