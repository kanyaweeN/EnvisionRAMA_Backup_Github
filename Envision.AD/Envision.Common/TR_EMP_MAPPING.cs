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
    [Table(Name = "dbo.TR_EMP_MAPPING")]
    public partial class TR_EMP_MAPPING
    {

        private string _personalno;

        private string _pid;

        private string _first_name;

        private string _last_name;

        private string _position;

        private System.Nullable<int> _ris_emp_id;

        public TR_EMP_MAPPING()
        {
        }

        [Column(Storage = "_personalno", DbType = "NVarChar(255)")]
        public string personalno
        {
            get
            {
                return this._personalno;
            }
            set
            {
                if ((this._personalno != value))
                {
                    this._personalno = value;
                }
            }
        }

        [Column(Storage = "_pid", DbType = "NVarChar(255)")]
        public string pid
        {
            get
            {
                return this._pid;
            }
            set
            {
                if ((this._pid != value))
                {
                    this._pid = value;
                }
            }
        }

        [Column(Storage = "_first_name", DbType = "NVarChar(255)")]
        public string first_name
        {
            get
            {
                return this._first_name;
            }
            set
            {
                if ((this._first_name != value))
                {
                    this._first_name = value;
                }
            }
        }

        [Column(Storage = "_last_name", DbType = "NVarChar(255)")]
        public string last_name
        {
            get
            {
                return this._last_name;
            }
            set
            {
                if ((this._last_name != value))
                {
                    this._last_name = value;
                }
            }
        }

        [Column(Storage = "_position", DbType = "NVarChar(255)")]
        public string position
        {
            get
            {
                return this._position;
            }
            set
            {
                if ((this._position != value))
                {
                    this._position = value;
                }
            }
        }

        [Column(Storage = "_ris_emp_id", DbType = "Int")]
        public System.Nullable<int> ris_emp_id
        {
            get
            {
                return this._ris_emp_id;
            }
            set
            {
                if ((this._ris_emp_id != value))
                {
                    this._ris_emp_id = value;
                }
            }
        }
    }
}
