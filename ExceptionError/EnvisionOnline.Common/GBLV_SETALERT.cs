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
    [Table(Name = "dbo.GBLV_SETALERT")]
    public partial class GBLV_SETALERT
    {

        private int _ALT_ID;

        private string _ALT_UID;

        private System.Nullable<int> _ORG_ID;

        private int _LANG_ID;

        private string _ALT_TEXT;

        private System.Nullable<char> _ALT_TYPE;

        private string _ALT_TITLE;

        private System.Nullable<int> _ALT_BUTTON;

        private string _CAPTION_BTN1;

        private string _CAPTION_BTN2;

        private string _CAPTION_BTN3;

        private System.Nullable<char> _IS_ACTIVE;

        private System.Nullable<char> _IS_DELETED;

        private int _ALT_DTL_ID;

        private System.Nullable<byte> _DEFAULT_BTN;

        private System.Nullable<byte> _TIME_SEC;

        public GBLV_SETALERT()
        {
        }

        [Column(Storage = "_ALT_ID", DbType = "Int NOT NULL")]
        public int ALT_ID
        {
            get
            {
                return this._ALT_ID;
            }
            set
            {
                if ((this._ALT_ID != value))
                {
                    this._ALT_ID = value;
                }
            }
        }

        [Column(Storage = "_ALT_UID", DbType = "NVarChar(30)")]
        public string ALT_UID
        {
            get
            {
                return this._ALT_UID;
            }
            set
            {
                if ((this._ALT_UID != value))
                {
                    this._ALT_UID = value;
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

        [Column(Storage = "_ALT_TEXT", DbType = "NVarChar(300)")]
        public string ALT_TEXT
        {
            get
            {
                return this._ALT_TEXT;
            }
            set
            {
                if ((this._ALT_TEXT != value))
                {
                    this._ALT_TEXT = value;
                }
            }
        }

        [Column(Storage = "_ALT_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> ALT_TYPE
        {
            get
            {
                return this._ALT_TYPE;
            }
            set
            {
                if ((this._ALT_TYPE != value))
                {
                    this._ALT_TYPE = value;
                }
            }
        }

        [Column(Storage = "_ALT_TITLE", DbType = "NVarChar(50)")]
        public string ALT_TITLE
        {
            get
            {
                return this._ALT_TITLE;
            }
            set
            {
                if ((this._ALT_TITLE != value))
                {
                    this._ALT_TITLE = value;
                }
            }
        }

        [Column(Storage = "_ALT_BUTTON", DbType = "Int")]
        public System.Nullable<int> ALT_BUTTON
        {
            get
            {
                return this._ALT_BUTTON;
            }
            set
            {
                if ((this._ALT_BUTTON != value))
                {
                    this._ALT_BUTTON = value;
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN1", DbType = "NVarChar(25)")]
        public string CAPTION_BTN1
        {
            get
            {
                return this._CAPTION_BTN1;
            }
            set
            {
                if ((this._CAPTION_BTN1 != value))
                {
                    this._CAPTION_BTN1 = value;
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN2", DbType = "NVarChar(25)")]
        public string CAPTION_BTN2
        {
            get
            {
                return this._CAPTION_BTN2;
            }
            set
            {
                if ((this._CAPTION_BTN2 != value))
                {
                    this._CAPTION_BTN2 = value;
                }
            }
        }

        [Column(Storage = "_CAPTION_BTN3", DbType = "NVarChar(25)")]
        public string CAPTION_BTN3
        {
            get
            {
                return this._CAPTION_BTN3;
            }
            set
            {
                if ((this._CAPTION_BTN3 != value))
                {
                    this._CAPTION_BTN3 = value;
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

        [Column(Storage = "_ALT_DTL_ID", DbType = "Int NOT NULL")]
        public int ALT_DTL_ID
        {
            get
            {
                return this._ALT_DTL_ID;
            }
            set
            {
                if ((this._ALT_DTL_ID != value))
                {
                    this._ALT_DTL_ID = value;
                }
            }
        }

        [Column(Storage = "_DEFAULT_BTN", DbType = "TinyInt")]
        public System.Nullable<byte> DEFAULT_BTN
        {
            get
            {
                return this._DEFAULT_BTN;
            }
            set
            {
                if ((this._DEFAULT_BTN != value))
                {
                    this._DEFAULT_BTN = value;
                }
            }
        }

        [Column(Storage = "_TIME_SEC", DbType = "TinyInt")]
        public System.Nullable<byte> TIME_SEC
        {
            get
            {
                return this._TIME_SEC;
            }
            set
            {
                if ((this._TIME_SEC != value))
                {
                    this._TIME_SEC = value;
                }
            }
        }
    }
}
