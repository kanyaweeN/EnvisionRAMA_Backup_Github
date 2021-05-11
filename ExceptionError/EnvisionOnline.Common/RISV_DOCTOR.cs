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
    [Table(Name = "dbo.RISV_DOCTOR")]
    public partial class RISV_DOCTOR
    {

        private int _EMP_ID;

        private string _EMP_UID;

        private string _USER_NAME;

        private string _UNIT_UID;

        private string _UNIT_NAME;

        private string _SALUTATION;

        private string _FNAME;

        private string _MNAME;

        private string _LNAME;

        private string _TITLE_ENG;

        private string _FNAME_ENG;

        private string _MNAME_ENG;

        private string _LNAME_ENG;

        private System.Nullable<char> _GENDER;

        private string _PHONE_NO;

        private string _FULLNAME;

        private string _FULLNAME_ENG;

        private string _AGE_ENG;

        private string _AGE;

        private System.Nullable<int> _AUTH_LEVEL_ID;

        private System.Nullable<char> _SUPPORT_USER;

        public RISV_DOCTOR()
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

        [Column(Storage = "_UNIT_UID", DbType = "NVarChar(30)")]
        public string UNIT_UID
        {
            get
            {
                return this._UNIT_UID;
            }
            set
            {
                if ((this._UNIT_UID != value))
                {
                    this._UNIT_UID = value;
                }
            }
        }

        [Column(Storage = "_UNIT_NAME", DbType = "NVarChar(100)")]
        public string UNIT_NAME
        {
            get
            {
                return this._UNIT_NAME;
            }
            set
            {
                if ((this._UNIT_NAME != value))
                {
                    this._UNIT_NAME = value;
                }
            }
        }

        [Column(Storage = "_SALUTATION", DbType = "NVarChar(20)")]
        public string SALUTATION
        {
            get
            {
                return this._SALUTATION;
            }
            set
            {
                if ((this._SALUTATION != value))
                {
                    this._SALUTATION = value;
                }
            }
        }

        [Column(Storage = "_FNAME", DbType = "NVarChar(50)")]
        public string FNAME
        {
            get
            {
                return this._FNAME;
            }
            set
            {
                if ((this._FNAME != value))
                {
                    this._FNAME = value;
                }
            }
        }

        [Column(Storage = "_MNAME", DbType = "NVarChar(50)")]
        public string MNAME
        {
            get
            {
                return this._MNAME;
            }
            set
            {
                if ((this._MNAME != value))
                {
                    this._MNAME = value;
                }
            }
        }

        [Column(Storage = "_LNAME", DbType = "NVarChar(50)")]
        public string LNAME
        {
            get
            {
                return this._LNAME;
            }
            set
            {
                if ((this._LNAME != value))
                {
                    this._LNAME = value;
                }
            }
        }

        [Column(Storage = "_TITLE_ENG", DbType = "NVarChar(20)")]
        public string TITLE_ENG
        {
            get
            {
                return this._TITLE_ENG;
            }
            set
            {
                if ((this._TITLE_ENG != value))
                {
                    this._TITLE_ENG = value;
                }
            }
        }

        [Column(Storage = "_FNAME_ENG", DbType = "NVarChar(50)")]
        public string FNAME_ENG
        {
            get
            {
                return this._FNAME_ENG;
            }
            set
            {
                if ((this._FNAME_ENG != value))
                {
                    this._FNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_MNAME_ENG", DbType = "NVarChar(50)")]
        public string MNAME_ENG
        {
            get
            {
                return this._MNAME_ENG;
            }
            set
            {
                if ((this._MNAME_ENG != value))
                {
                    this._MNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_LNAME_ENG", DbType = "NVarChar(50)")]
        public string LNAME_ENG
        {
            get
            {
                return this._LNAME_ENG;
            }
            set
            {
                if ((this._LNAME_ENG != value))
                {
                    this._LNAME_ENG = value;
                }
            }
        }

        [Column(Storage = "_GENDER", DbType = "NVarChar(1)")]
        public System.Nullable<char> GENDER
        {
            get
            {
                return this._GENDER;
            }
            set
            {
                if ((this._GENDER != value))
                {
                    this._GENDER = value;
                }
            }
        }

        [Column(Storage = "_PHONE_NO", DbType = "NVarChar(50)")]
        public string PHONE_NO
        {
            get
            {
                return this._PHONE_NO;
            }
            set
            {
                if ((this._PHONE_NO != value))
                {
                    this._PHONE_NO = value;
                }
            }
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

        [Column(Storage = "_AGE_ENG", DbType = "NVarChar(MAX)")]
        public string AGE_ENG
        {
            get
            {
                return this._AGE_ENG;
            }
            set
            {
                if ((this._AGE_ENG != value))
                {
                    this._AGE_ENG = value;
                }
            }
        }

        [Column(Storage = "_AGE", DbType = "NVarChar(MAX)")]
        public string AGE
        {
            get
            {
                return this._AGE;
            }
            set
            {
                if ((this._AGE != value))
                {
                    this._AGE = value;
                }
            }
        }

        [Column(Storage = "_AUTH_LEVEL_ID", DbType = "Int")]
        public System.Nullable<int> AUTH_LEVEL_ID
        {
            get
            {
                return this._AUTH_LEVEL_ID;
            }
            set
            {
                if ((this._AUTH_LEVEL_ID != value))
                {
                    this._AUTH_LEVEL_ID = value;
                }
            }
        }

        [Column(Storage = "_SUPPORT_USER", DbType = "NVarChar(1)")]
        public System.Nullable<char> SUPPORT_USER
        {
            get
            {
                return this._SUPPORT_USER;
            }
            set
            {
                if ((this._SUPPORT_USER != value))
                {
                    this._SUPPORT_USER = value;
                }
            }
        }
    }
}
