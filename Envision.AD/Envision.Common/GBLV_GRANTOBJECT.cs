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
    [Table(Name = "dbo.GBLV_GRANTOBJECT")]
    public partial class GBLV_GRANTOBJECT
    {

        private int _EMP_ID;

        private int _ORG_ID;

        private int _GRANTOBJECT_ID;

        private int _SUBMENU_ID;

        private System.Nullable<int> _CAN_VIEW;

        private System.Nullable<int> _CAN_MODIFY;

        private System.Nullable<int> _CAN_REMOVE;

        private System.Nullable<int> _CAN_SHARE;

        private System.Nullable<int> _CAN_CREATE;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _IS_UPDATED;

        public GBLV_GRANTOBJECT()
        {
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

        [Column(Storage = "_GRANTOBJECT_ID", DbType = "Int NOT NULL")]
        public int GRANTOBJECT_ID
        {
            get
            {
                return this._GRANTOBJECT_ID;
            }
            set
            {
                if ((this._GRANTOBJECT_ID != value))
                {
                    this._GRANTOBJECT_ID = value;
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

        [Column(Storage = "_CAN_VIEW", DbType = "Int")]
        public System.Nullable<int> CAN_VIEW
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

        [Column(Storage = "_CAN_MODIFY", DbType = "Int")]
        public System.Nullable<int> CAN_MODIFY
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

        [Column(Storage = "_CAN_REMOVE", DbType = "Int")]
        public System.Nullable<int> CAN_REMOVE
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

        [Column(Storage = "_CAN_SHARE", DbType = "Int")]
        public System.Nullable<int> CAN_SHARE
        {
            get
            {
                return this._CAN_SHARE;
            }
            set
            {
                if ((this._CAN_SHARE != value))
                {
                    this._CAN_SHARE = value;
                }
            }
        }

        [Column(Storage = "_CAN_CREATE", DbType = "Int")]
        public System.Nullable<int> CAN_CREATE
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
    }
}
