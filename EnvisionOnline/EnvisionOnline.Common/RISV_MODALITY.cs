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
    [Table(Name = "dbo.RISV_MODALITY")]
    public partial class RISV_MODALITY
    {

        private int _TYPE_ID;

        private int _MODALITY_ID;

        private string _TYPE_UID;

        private string _TYPE_NAME;

        private string _TYPE_NAME_ALIAS;

        private string _MODALITY_UID;

        private string _MODALITY_NAME;

        public RISV_MODALITY()
        {
        }

        [Column(Storage = "_TYPE_ID", DbType = "Int NOT NULL")]
        public int TYPE_ID
        {
            get
            {
                return this._TYPE_ID;
            }
            set
            {
                if ((this._TYPE_ID != value))
                {
                    this._TYPE_ID = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_ID", DbType = "Int NOT NULL")]
        public int MODALITY_ID
        {
            get
            {
                return this._MODALITY_ID;
            }
            set
            {
                if ((this._MODALITY_ID != value))
                {
                    this._MODALITY_ID = value;
                }
            }
        }

        [Column(Storage = "_TYPE_UID", DbType = "NVarChar(30)")]
        public string TYPE_UID
        {
            get
            {
                return this._TYPE_UID;
            }
            set
            {
                if ((this._TYPE_UID != value))
                {
                    this._TYPE_UID = value;
                }
            }
        }

        [Column(Storage = "_TYPE_NAME", DbType = "NVarChar(100)")]
        public string TYPE_NAME
        {
            get
            {
                return this._TYPE_NAME;
            }
            set
            {
                if ((this._TYPE_NAME != value))
                {
                    this._TYPE_NAME = value;
                }
            }
        }

        [Column(Storage = "_TYPE_NAME_ALIAS", DbType = "NVarChar(100)")]
        public string TYPE_NAME_ALIAS
        {
            get
            {
                return this._TYPE_NAME_ALIAS;
            }
            set
            {
                if ((this._TYPE_NAME_ALIAS != value))
                {
                    this._TYPE_NAME_ALIAS = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_UID", DbType = "NVarChar(50)")]
        public string MODALITY_UID
        {
            get
            {
                return this._MODALITY_UID;
            }
            set
            {
                if ((this._MODALITY_UID != value))
                {
                    this._MODALITY_UID = value;
                }
            }
        }

        [Column(Storage = "_MODALITY_NAME", DbType = "NVarChar(100)")]
        public string MODALITY_NAME
        {
            get
            {
                return this._MODALITY_NAME;
            }
            set
            {
                if ((this._MODALITY_NAME != value))
                {
                    this._MODALITY_NAME = value;
                }
            }
        }
    }
}
