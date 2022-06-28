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
    [Table(Name = "dbo.RIS_SEARCH_AUDIT")]
    public partial class RIS_SEARCH_AUDIT
    {

        private int _SEARCH_AUDIT_ID;

        private System.DateTime _SEARCH_START;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        public RIS_SEARCH_AUDIT()
        {
        }

        [Column(Storage = "_SEARCH_AUDIT_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
        public int SEARCH_AUDIT_ID
        {
            get
            {
                return this._SEARCH_AUDIT_ID;
            }
            set
            {
                if ((this._SEARCH_AUDIT_ID != value))
                {
                    this._SEARCH_AUDIT_ID = value;
                }
            }
        }

        [Column(Storage = "_SEARCH_START", DbType = "DateTime NOT NULL")]
        public System.DateTime SEARCH_START
        {
            get
            {
                return this._SEARCH_START;
            }
            set
            {
                if ((this._SEARCH_START != value))
                {
                    this._SEARCH_START = value;
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
    }
}
