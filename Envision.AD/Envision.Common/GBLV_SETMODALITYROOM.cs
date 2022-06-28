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
    [Table(Name = "dbo.GBLV_SETMODALITYROOM")]
    public partial class GBLV_SETMODALITYROOM
    {

        private string _MODALITY_NAME;

        private string _ROOM_UID;

        private System.Nullable<int> _ORG_ID;

        private System.Data.Linq.Binary _AllProperties;

        private System.Nullable<bool> _Visible;

        private int _MODALITY_ID;

        public GBLV_SETMODALITYROOM()
        {
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

        [Column(Storage = "_ROOM_UID", DbType = "NVarChar(30)")]
        public string ROOM_UID
        {
            get
            {
                return this._ROOM_UID;
            }
            set
            {
                if ((this._ROOM_UID != value))
                {
                    this._ROOM_UID = value;
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

        [Column(Storage = "_AllProperties", DbType = "VarBinary(256)", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary AllProperties
        {
            get
            {
                return this._AllProperties;
            }
            set
            {
                if ((this._AllProperties != value))
                {
                    this._AllProperties = value;
                }
            }
        }

        [Column(Storage = "_Visible", DbType = "Bit")]
        public System.Nullable<bool> Visible
        {
            get
            {
                return this._Visible;
            }
            set
            {
                if ((this._Visible != value))
                {
                    this._Visible = value;
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
    }
}
