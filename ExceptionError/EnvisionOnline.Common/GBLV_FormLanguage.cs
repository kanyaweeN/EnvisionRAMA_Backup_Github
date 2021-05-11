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
    [Table(Name = "dbo.GBLV_FormLanguage")]
    public partial class GBLV_FormLanguage
    {

        private int _SUBMENU_ID;

        private string _SUBMENU_NAME_USER;

        private int _OBJECT_ID;

        private string _OBJECT_TYPE;

        private string _OBJECT_NAME;

        private int _LANG_ID;

        private string _LANG_NAME;

        private string _LABEL;

        private System.Nullable<char> _IS_DEFAULT;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<int> _ORG_ID;

        public GBLV_FormLanguage()
        {
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

        [Column(Storage = "_OBJECT_ID", DbType = "Int NOT NULL")]
        public int OBJECT_ID
        {
            get
            {
                return this._OBJECT_ID;
            }
            set
            {
                if ((this._OBJECT_ID != value))
                {
                    this._OBJECT_ID = value;
                }
            }
        }

        [Column(Storage = "_OBJECT_TYPE", DbType = "NChar(10)")]
        public string OBJECT_TYPE
        {
            get
            {
                return this._OBJECT_TYPE;
            }
            set
            {
                if ((this._OBJECT_TYPE != value))
                {
                    this._OBJECT_TYPE = value;
                }
            }
        }

        [Column(Storage = "_OBJECT_NAME", DbType = "NChar(100)")]
        public string OBJECT_NAME
        {
            get
            {
                return this._OBJECT_NAME;
            }
            set
            {
                if ((this._OBJECT_NAME != value))
                {
                    this._OBJECT_NAME = value;
                }
            }
        }

        [Column(Storage = "_LANG_ID", DbType = "Int NOT NULL")]
        public int LANG_ID
        {
            get
            {
                return this._LANG_ID;
            }
            set
            {
                if ((this._LANG_ID != value))
                {
                    this._LANG_ID = value;
                }
            }
        }

        [Column(Storage = "_LANG_NAME", DbType = "NVarChar(100)")]
        public string LANG_NAME
        {
            get
            {
                return this._LANG_NAME;
            }
            set
            {
                if ((this._LANG_NAME != value))
                {
                    this._LANG_NAME = value;
                }
            }
        }

        [Column(Storage = "_LABEL", DbType = "NChar(300)")]
        public string LABEL
        {
            get
            {
                return this._LABEL;
            }
            set
            {
                if ((this._LABEL != value))
                {
                    this._LABEL = value;
                }
            }
        }

        [Column(Storage = "_IS_DEFAULT", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_DEFAULT
        {
            get
            {
                return this._IS_DEFAULT;
            }
            set
            {
                if ((this._IS_DEFAULT != value))
                {
                    this._IS_DEFAULT = value;
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
    }
}
