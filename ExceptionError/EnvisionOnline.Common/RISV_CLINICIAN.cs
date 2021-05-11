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
    [Table(Name = "dbo.RISV_CLINICIAN")]
    public partial class RISV_CLINICIAN
    {

        private string _FULLNAME;

        private string _FULLNAME_ENG;

        private int _EMP_ID;

        private string _EMP_UID;

        public RISV_CLINICIAN()
        {
        }

        [Column(Storage = "_FULLNAME", DbType = "NVarChar(172) NOT NULL", CanBeNull = false)]
        public string FULLNAME
        {
            get
            {
                return this._FULLNAME;
            }
            set
            {
                if ((this._FULLNAME != value))
                {
                    this._FULLNAME = value;
                }
            }
        }

        [Column(Storage = "_FULLNAME_ENG", DbType = "NVarChar(152) NOT NULL", CanBeNull = false)]
        public string FULLNAME_ENG
        {
            get
            {
                return this._FULLNAME_ENG;
            }
            set
            {
                if ((this._FULLNAME_ENG != value))
                {
                    this._FULLNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_EMP_ID", AutoSync = AutoSync.Always, DbType = "Int NOT NULL IDENTITY", IsDbGenerated = true)]
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
    }
}
