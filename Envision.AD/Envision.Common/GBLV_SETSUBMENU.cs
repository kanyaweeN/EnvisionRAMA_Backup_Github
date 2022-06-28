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
    [Table(Name = "dbo.GBLV_SETSUBMENU")]
    public partial class GBLV_SETSUBMENU
    {

        private int _MENU_ID;

        private string _MENU_UID;

        private string _MENU_NAME;

        private string _MENU_NAMESPACE;

        private string _Menu_Descr;

        private int _PARENT1;

        private System.Nullable<int> _Menu_SLNO;

        private System.Nullable<char> _MenuIsActive;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private int _SUBMENU_ID;

        private string _SUBMENU_UID;

        private System.Nullable<int> _Expr1;

        private System.Nullable<char> _SUBMENU_TYPE;

        private string _SUBMENU_CLASS_NAME;

        private string _SUBMENU_NAME_SYS;

        private string _SUBMENU_NAME_USER;

        private int _PARENT;

        private string _DESCR;

        private System.Nullable<int> _SL_NO;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _ADD_TO_HOME;

        private System.Nullable<char> _CAN_VIEW;

        private System.Nullable<char> _CAN_MODIFY;

        private System.Nullable<char> _CAN_REMOVE;

        private System.Nullable<char> _CAN_CREATE;

        public GBLV_SETSUBMENU()
        {
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

        [Column(Storage = "_MENU_UID", DbType = "NVarChar(30)")]
        public string MENU_UID
        {
            get
            {
                return this._MENU_UID;
            }
            set
            {
                if ((this._MENU_UID != value))
                {
                    this._MENU_UID = value;
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

        [Column(Storage = "_Menu_Descr", DbType = "NVarChar(100)")]
        public string Menu_Descr
        {
            get
            {
                return this._Menu_Descr;
            }
            set
            {
                if ((this._Menu_Descr != value))
                {
                    this._Menu_Descr = value;
                }
            }
        }

        [Column(Storage = "_PARENT1", DbType = "Int NOT NULL")]
        public int PARENT1
        {
            get
            {
                return this._PARENT1;
            }
            set
            {
                if ((this._PARENT1 != value))
                {
                    this._PARENT1 = value;
                }
            }
        }

        [Column(Storage = "_Menu_SLNO", DbType = "Int")]
        public System.Nullable<int> Menu_SLNO
        {
            get
            {
                return this._Menu_SLNO;
            }
            set
            {
                if ((this._Menu_SLNO != value))
                {
                    this._Menu_SLNO = value;
                }
            }
        }

        [Column(Storage = "_MenuIsActive", DbType = "NVarChar(1)")]
        public System.Nullable<char> MenuIsActive
        {
            get
            {
                return this._MenuIsActive;
            }
            set
            {
                if ((this._MenuIsActive != value))
                {
                    this._MenuIsActive = value;
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

        [Column(Storage = "_CREATED_BY", DbType = "Int")]
        public System.Nullable<int> CREATED_BY
        {
            get
            {
                return this._CREATED_BY;
            }
            set
            {
                if ((this._CREATED_BY != value))
                {
                    this._CREATED_BY = value;
                }
            }
        }

        [Column(Storage = "_CREATED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CREATED_ON
        {
            get
            {
                return this._CREATED_ON;
            }
            set
            {
                if ((this._CREATED_ON != value))
                {
                    this._CREATED_ON = value;
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_BY", DbType = "Int")]
        public System.Nullable<int> LAST_MODIFIED_BY
        {
            get
            {
                return this._LAST_MODIFIED_BY;
            }
            set
            {
                if ((this._LAST_MODIFIED_BY != value))
                {
                    this._LAST_MODIFIED_BY = value;
                }
            }
        }

        [Column(Storage = "_LAST_MODIFIED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> LAST_MODIFIED_ON
        {
            get
            {
                return this._LAST_MODIFIED_ON;
            }
            set
            {
                if ((this._LAST_MODIFIED_ON != value))
                {
                    this._LAST_MODIFIED_ON = value;
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

        [Column(Storage = "_SUBMENU_UID", DbType = "NVarChar(30)")]
        public string SUBMENU_UID
        {
            get
            {
                return this._SUBMENU_UID;
            }
            set
            {
                if ((this._SUBMENU_UID != value))
                {
                    this._SUBMENU_UID = value;
                }
            }
        }

        [Column(Storage = "_Expr1", DbType = "Int")]
        public System.Nullable<int> Expr1
        {
            get
            {
                return this._Expr1;
            }
            set
            {
                if ((this._Expr1 != value))
                {
                    this._Expr1 = value;
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

        [Column(Storage = "_SUBMENU_NAME_SYS", DbType = "NVarChar(50)")]
        public string SUBMENU_NAME_SYS
        {
            get
            {
                return this._SUBMENU_NAME_SYS;
            }
            set
            {
                if ((this._SUBMENU_NAME_SYS != value))
                {
                    this._SUBMENU_NAME_SYS = value;
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

        [Column(Storage = "_PARENT", DbType = "Int NOT NULL")]
        public int PARENT
        {
            get
            {
                return this._PARENT;
            }
            set
            {
                if ((this._PARENT != value))
                {
                    this._PARENT = value;
                }
            }
        }

        [Column(Storage = "_DESCR", DbType = "NVarChar(100)")]
        public string DESCR
        {
            get
            {
                return this._DESCR;
            }
            set
            {
                if ((this._DESCR != value))
                {
                    this._DESCR = value;
                }
            }
        }

        [Column(Storage = "_SL_NO", DbType = "Int")]
        public System.Nullable<int> SL_NO
        {
            get
            {
                return this._SL_NO;
            }
            set
            {
                if ((this._SL_NO != value))
                {
                    this._SL_NO = value;
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

        [Column(Storage = "_ADD_TO_HOME", DbType = "NVarChar(1)")]
        public System.Nullable<char> ADD_TO_HOME
        {
            get
            {
                return this._ADD_TO_HOME;
            }
            set
            {
                if ((this._ADD_TO_HOME != value))
                {
                    this._ADD_TO_HOME = value;
                }
            }
        }

        [Column(Storage = "_CAN_VIEW", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_VIEW
        {
            get
            {
                return this._CAN_VIEW;
            }
            set
            {
                if ((this._CAN_VIEW != value))
                {
                    this._CAN_VIEW = value;
                }
            }
        }

        [Column(Storage = "_CAN_MODIFY", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_MODIFY
        {
            get
            {
                return this._CAN_MODIFY;
            }
            set
            {
                if ((this._CAN_MODIFY != value))
                {
                    this._CAN_MODIFY = value;
                }
            }
        }

        [Column(Storage = "_CAN_REMOVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_REMOVE
        {
            get
            {
                return this._CAN_REMOVE;
            }
            set
            {
                if ((this._CAN_REMOVE != value))
                {
                    this._CAN_REMOVE = value;
                }
            }
        }

        [Column(Storage = "_CAN_CREATE", DbType = "NVarChar(1)")]
        public System.Nullable<char> CAN_CREATE
        {
            get
            {
                return this._CAN_CREATE;
            }
            set
            {
                if ((this._CAN_CREATE != value))
                {
                    this._CAN_CREATE = value;
                }
            }
        }
    }
}
