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
    [Table(Name = "dbo.GBLV_SETROLE")]
    public partial class GBLV_SETROLE
    {

        private int _ROLE_ID;

        private string _ROLE_UID;

        private string _ROLE_NAME;

        private System.Nullable<char> _IS_ACTIVE;

        private string _DESCR;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<int> _ROLEDTL_ID;

        private string _ROLEDTL_UID;

        private System.Nullable<int> _Expr1;

        private System.Nullable<int> _SUBMENU_ID;

        private System.Nullable<char> _CAN_VIEW;

        private System.Nullable<char> _CAN_MODIFY;

        private System.Nullable<char> _CAN_REMOVE;

        private System.Nullable<char> _IS_UPDATED;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<char> _CAN_CREATE;

        private System.Nullable<int> _Expr4;

        private System.Nullable<int> _Expr5;

        private System.Nullable<System.DateTime> _Expr6;

        private System.Nullable<int> _Expr7;

        private System.Nullable<System.DateTime> _Expr8;

        private System.Nullable<int> _Expr9;

        private string _ORG_UID;

        private string _ORG_NAME;

        private string _ORG_ALIAS;

        private string _ORG_SLOGAN1;

        private string _ORG_SLOGAN2;

        private string _ORG_ADDR1;

        private string _ORG_ADDR2;

        private string _ORG_ADDR3;

        private string _ORG_ADDR4;

        private string _ORG_TEL1;

        private string _ORG_TEL2;

        private string _ORG_TEL3;

        private string _ORG_FAX;

        private string _ORG_EMAIL1;

        private string _ORG_EMAIL2;

        private string _ORG_EMAIL3;

        private string _ORG_WEBSITE;

        private string _WELCOME_DIALOG1;

        private string _WELCOME_DIALOG2;

        private string _REP_SERVER;

        private string _REP_FORMAT;

        private string _REP_FOOTER1;

        private string _REP_FOOTER2;

        private string _EMP_IMG_TYPE;

        private string _EMP_IMG_MAX_SIZE;

        private System.Nullable<int> _OTHER_MAX_FILE_SIZE;

        private string _DT_FMT;

        private string _TIME_FMT;

        private string _LOCAL_CURRENCY_NAME;

        private string _LOCAL_CURRENCY_SYMBOL;

        private string _CURRENCY_FMT;

        private string _RESOURCE_IMAGE_PATH;

        private string _SCANNED_IMAGE_PATH;

        private string _DOCUMENT_PATH;

        private string _BACKUP_PATH;

        private string _OTHER_FILE_PATH;

        private string _EMP_IMG_PATH;

        private string _LAB_DATA_PATH;

        private string _USER_DISPLAY_FMT;

        private string _VENDOR_H1;

        private string _VENDOR_H2;

        private string _VENDOR_LOGO_PATH;

        private string _PARTNER1_H1;

        private string _PARTNER1_H2;

        private string _PARTNER1_LOGO_PATH;

        private string _PARTNER2_H1;

        private string _PARTNER2_H2;

        private string _PARTNER2_LOGO_PATH;

        private string _RIS_IP;

        private string _RIS_PORT;

        private string _RIS_USER;

        private string _RIS_PASS;

        private string _RIS_URL;

        private string _PACS_IP;

        private string _PACS_PORT;

        private string _PACS_URL1;

        private string _PACS_URL2;

        private string _PACS_DOMAIN;

        private string _HIS_IP;

        private string _HIS_PORT;

        private string _HIS_DB_NAME;

        private string _HIS_USER_NAME;

        private string _HIS_USER_PASS;

        private string _HIS_FIN_FLAG;

        private string _WS_IP;

        private string _WS_VERSION;

        private System.Nullable<int> _Expr10;

        private System.Nullable<System.DateTime> _Expr11;

        private System.Nullable<int> _Expr12;

        private System.Nullable<System.DateTime> _Expr13;

        public GBLV_SETROLE()
        {
        }

        [Column(Storage = "_ROLE_ID", DbType = "Int NOT NULL")]
        public int ROLE_ID
        {
            get
            {
                return this._ROLE_ID;
            }
            set
            {
                if ((this._ROLE_ID != value))
                {
                    this._ROLE_ID = value;
                }
            }
        }

        [Column(Storage = "_ROLE_UID", DbType = "NVarChar(50)")]
        public string ROLE_UID
        {
            get
            {
                return this._ROLE_UID;
            }
            set
            {
                if ((this._ROLE_UID != value))
                {
                    this._ROLE_UID = value;
                }
            }
        }

        [Column(Storage = "_ROLE_NAME", DbType = "NVarChar(50)")]
        public string ROLE_NAME
        {
            get
            {
                return this._ROLE_NAME;
            }
            set
            {
                if ((this._ROLE_NAME != value))
                {
                    this._ROLE_NAME = value;
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

        [Column(Storage = "_ROLEDTL_ID", DbType = "Int")]
        public System.Nullable<int> ROLEDTL_ID
        {
            get
            {
                return this._ROLEDTL_ID;
            }
            set
            {
                if ((this._ROLEDTL_ID != value))
                {
                    this._ROLEDTL_ID = value;
                }
            }
        }

        [Column(Storage = "_ROLEDTL_UID", DbType = "NVarChar(30)")]
        public string ROLEDTL_UID
        {
            get
            {
                return this._ROLEDTL_UID;
            }
            set
            {
                if ((this._ROLEDTL_UID != value))
                {
                    this._ROLEDTL_UID = value;
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

        [Column(Storage = "_SUBMENU_ID", DbType = "Int")]
        public System.Nullable<int> SUBMENU_ID
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

        [Column(Storage = "_Expr4", DbType = "Int")]
        public System.Nullable<int> Expr4
        {
            get
            {
                return this._Expr4;
            }
            set
            {
                if ((this._Expr4 != value))
                {
                    this._Expr4 = value;
                }
            }
        }

        [Column(Storage = "_Expr5", DbType = "Int")]
        public System.Nullable<int> Expr5
        {
            get
            {
                return this._Expr5;
            }
            set
            {
                if ((this._Expr5 != value))
                {
                    this._Expr5 = value;
                }
            }
        }

        [Column(Storage = "_Expr6", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Expr6
        {
            get
            {
                return this._Expr6;
            }
            set
            {
                if ((this._Expr6 != value))
                {
                    this._Expr6 = value;
                }
            }
        }

        [Column(Storage = "_Expr7", DbType = "Int")]
        public System.Nullable<int> Expr7
        {
            get
            {
                return this._Expr7;
            }
            set
            {
                if ((this._Expr7 != value))
                {
                    this._Expr7 = value;
                }
            }
        }

        [Column(Storage = "_Expr8", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Expr8
        {
            get
            {
                return this._Expr8;
            }
            set
            {
                if ((this._Expr8 != value))
                {
                    this._Expr8 = value;
                }
            }
        }

        [Column(Storage = "_Expr9", DbType = "Int")]
        public System.Nullable<int> Expr9
        {
            get
            {
                return this._Expr9;
            }
            set
            {
                if ((this._Expr9 != value))
                {
                    this._Expr9 = value;
                }
            }
        }

        [Column(Storage = "_ORG_UID", DbType = "NVarChar(30)")]
        public string ORG_UID
        {
            get
            {
                return this._ORG_UID;
            }
            set
            {
                if ((this._ORG_UID != value))
                {
                    this._ORG_UID = value;
                }
            }
        }

        [Column(Storage = "_ORG_NAME", DbType = "NVarChar(100)")]
        public string ORG_NAME
        {
            get
            {
                return this._ORG_NAME;
            }
            set
            {
                if ((this._ORG_NAME != value))
                {
                    this._ORG_NAME = value;
                }
            }
        }

        [Column(Storage = "_ORG_ALIAS", DbType = "NVarChar(30)")]
        public string ORG_ALIAS
        {
            get
            {
                return this._ORG_ALIAS;
            }
            set
            {
                if ((this._ORG_ALIAS != value))
                {
                    this._ORG_ALIAS = value;
                }
            }
        }

        [Column(Storage = "_ORG_SLOGAN1", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN1
        {
            get
            {
                return this._ORG_SLOGAN1;
            }
            set
            {
                if ((this._ORG_SLOGAN1 != value))
                {
                    this._ORG_SLOGAN1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_SLOGAN2", DbType = "NVarChar(100)")]
        public string ORG_SLOGAN2
        {
            get
            {
                return this._ORG_SLOGAN2;
            }
            set
            {
                if ((this._ORG_SLOGAN2 != value))
                {
                    this._ORG_SLOGAN2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR1", DbType = "NVarChar(100)")]
        public string ORG_ADDR1
        {
            get
            {
                return this._ORG_ADDR1;
            }
            set
            {
                if ((this._ORG_ADDR1 != value))
                {
                    this._ORG_ADDR1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR2", DbType = "NVarChar(100)")]
        public string ORG_ADDR2
        {
            get
            {
                return this._ORG_ADDR2;
            }
            set
            {
                if ((this._ORG_ADDR2 != value))
                {
                    this._ORG_ADDR2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR3", DbType = "NVarChar(100)")]
        public string ORG_ADDR3
        {
            get
            {
                return this._ORG_ADDR3;
            }
            set
            {
                if ((this._ORG_ADDR3 != value))
                {
                    this._ORG_ADDR3 = value;
                }
            }
        }

        [Column(Storage = "_ORG_ADDR4", DbType = "NVarChar(100)")]
        public string ORG_ADDR4
        {
            get
            {
                return this._ORG_ADDR4;
            }
            set
            {
                if ((this._ORG_ADDR4 != value))
                {
                    this._ORG_ADDR4 = value;
                }
            }
        }

        [Column(Storage = "_ORG_TEL1", DbType = "NVarChar(100)")]
        public string ORG_TEL1
        {
            get
            {
                return this._ORG_TEL1;
            }
            set
            {
                if ((this._ORG_TEL1 != value))
                {
                    this._ORG_TEL1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_TEL2", DbType = "NVarChar(100)")]
        public string ORG_TEL2
        {
            get
            {
                return this._ORG_TEL2;
            }
            set
            {
                if ((this._ORG_TEL2 != value))
                {
                    this._ORG_TEL2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_TEL3", DbType = "NVarChar(100)")]
        public string ORG_TEL3
        {
            get
            {
                return this._ORG_TEL3;
            }
            set
            {
                if ((this._ORG_TEL3 != value))
                {
                    this._ORG_TEL3 = value;
                }
            }
        }

        [Column(Storage = "_ORG_FAX", DbType = "NVarChar(100)")]
        public string ORG_FAX
        {
            get
            {
                return this._ORG_FAX;
            }
            set
            {
                if ((this._ORG_FAX != value))
                {
                    this._ORG_FAX = value;
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL1", DbType = "NVarChar(100)")]
        public string ORG_EMAIL1
        {
            get
            {
                return this._ORG_EMAIL1;
            }
            set
            {
                if ((this._ORG_EMAIL1 != value))
                {
                    this._ORG_EMAIL1 = value;
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL2", DbType = "NVarChar(100)")]
        public string ORG_EMAIL2
        {
            get
            {
                return this._ORG_EMAIL2;
            }
            set
            {
                if ((this._ORG_EMAIL2 != value))
                {
                    this._ORG_EMAIL2 = value;
                }
            }
        }

        [Column(Storage = "_ORG_EMAIL3", DbType = "NVarChar(100)")]
        public string ORG_EMAIL3
        {
            get
            {
                return this._ORG_EMAIL3;
            }
            set
            {
                if ((this._ORG_EMAIL3 != value))
                {
                    this._ORG_EMAIL3 = value;
                }
            }
        }

        [Column(Storage = "_ORG_WEBSITE", DbType = "NVarChar(100)")]
        public string ORG_WEBSITE
        {
            get
            {
                return this._ORG_WEBSITE;
            }
            set
            {
                if ((this._ORG_WEBSITE != value))
                {
                    this._ORG_WEBSITE = value;
                }
            }
        }

        [Column(Storage = "_WELCOME_DIALOG1", DbType = "NVarChar(500)")]
        public string WELCOME_DIALOG1
        {
            get
            {
                return this._WELCOME_DIALOG1;
            }
            set
            {
                if ((this._WELCOME_DIALOG1 != value))
                {
                    this._WELCOME_DIALOG1 = value;
                }
            }
        }

        [Column(Storage = "_WELCOME_DIALOG2", DbType = "NVarChar(500)")]
        public string WELCOME_DIALOG2
        {
            get
            {
                return this._WELCOME_DIALOG2;
            }
            set
            {
                if ((this._WELCOME_DIALOG2 != value))
                {
                    this._WELCOME_DIALOG2 = value;
                }
            }
        }

        [Column(Storage = "_REP_SERVER", DbType = "NVarChar(50)")]
        public string REP_SERVER
        {
            get
            {
                return this._REP_SERVER;
            }
            set
            {
                if ((this._REP_SERVER != value))
                {
                    this._REP_SERVER = value;
                }
            }
        }

        [Column(Storage = "_REP_FORMAT", DbType = "NVarChar(30)")]
        public string REP_FORMAT
        {
            get
            {
                return this._REP_FORMAT;
            }
            set
            {
                if ((this._REP_FORMAT != value))
                {
                    this._REP_FORMAT = value;
                }
            }
        }

        [Column(Storage = "_REP_FOOTER1", DbType = "NVarChar(500)")]
        public string REP_FOOTER1
        {
            get
            {
                return this._REP_FOOTER1;
            }
            set
            {
                if ((this._REP_FOOTER1 != value))
                {
                    this._REP_FOOTER1 = value;
                }
            }
        }

        [Column(Storage = "_REP_FOOTER2", DbType = "NVarChar(500)")]
        public string REP_FOOTER2
        {
            get
            {
                return this._REP_FOOTER2;
            }
            set
            {
                if ((this._REP_FOOTER2 != value))
                {
                    this._REP_FOOTER2 = value;
                }
            }
        }

        [Column(Storage = "_EMP_IMG_TYPE", DbType = "NVarChar(4)")]
        public string EMP_IMG_TYPE
        {
            get
            {
                return this._EMP_IMG_TYPE;
            }
            set
            {
                if ((this._EMP_IMG_TYPE != value))
                {
                    this._EMP_IMG_TYPE = value;
                }
            }
        }

        [Column(Storage = "_EMP_IMG_MAX_SIZE", DbType = "NVarChar(4)")]
        public string EMP_IMG_MAX_SIZE
        {
            get
            {
                return this._EMP_IMG_MAX_SIZE;
            }
            set
            {
                if ((this._EMP_IMG_MAX_SIZE != value))
                {
                    this._EMP_IMG_MAX_SIZE = value;
                }
            }
        }

        [Column(Storage = "_OTHER_MAX_FILE_SIZE", DbType = "Int")]
        public System.Nullable<int> OTHER_MAX_FILE_SIZE
        {
            get
            {
                return this._OTHER_MAX_FILE_SIZE;
            }
            set
            {
                if ((this._OTHER_MAX_FILE_SIZE != value))
                {
                    this._OTHER_MAX_FILE_SIZE = value;
                }
            }
        }

        [Column(Storage = "_DT_FMT", DbType = "NVarChar(30)")]
        public string DT_FMT
        {
            get
            {
                return this._DT_FMT;
            }
            set
            {
                if ((this._DT_FMT != value))
                {
                    this._DT_FMT = value;
                }
            }
        }

        [Column(Storage = "_TIME_FMT", DbType = "NVarChar(30)")]
        public string TIME_FMT
        {
            get
            {
                return this._TIME_FMT;
            }
            set
            {
                if ((this._TIME_FMT != value))
                {
                    this._TIME_FMT = value;
                }
            }
        }

        [Column(Storage = "_LOCAL_CURRENCY_NAME", DbType = "NVarChar(15)")]
        public string LOCAL_CURRENCY_NAME
        {
            get
            {
                return this._LOCAL_CURRENCY_NAME;
            }
            set
            {
                if ((this._LOCAL_CURRENCY_NAME != value))
                {
                    this._LOCAL_CURRENCY_NAME = value;
                }
            }
        }

        [Column(Storage = "_LOCAL_CURRENCY_SYMBOL", DbType = "NVarChar(2)")]
        public string LOCAL_CURRENCY_SYMBOL
        {
            get
            {
                return this._LOCAL_CURRENCY_SYMBOL;
            }
            set
            {
                if ((this._LOCAL_CURRENCY_SYMBOL != value))
                {
                    this._LOCAL_CURRENCY_SYMBOL = value;
                }
            }
        }

        [Column(Storage = "_CURRENCY_FMT", DbType = "NVarChar(30)")]
        public string CURRENCY_FMT
        {
            get
            {
                return this._CURRENCY_FMT;
            }
            set
            {
                if ((this._CURRENCY_FMT != value))
                {
                    this._CURRENCY_FMT = value;
                }
            }
        }

        [Column(Storage = "_RESOURCE_IMAGE_PATH", DbType = "NVarChar(300)")]
        public string RESOURCE_IMAGE_PATH
        {
            get
            {
                return this._RESOURCE_IMAGE_PATH;
            }
            set
            {
                if ((this._RESOURCE_IMAGE_PATH != value))
                {
                    this._RESOURCE_IMAGE_PATH = value;
                }
            }
        }

        [Column(Storage = "_SCANNED_IMAGE_PATH", DbType = "NVarChar(300)")]
        public string SCANNED_IMAGE_PATH
        {
            get
            {
                return this._SCANNED_IMAGE_PATH;
            }
            set
            {
                if ((this._SCANNED_IMAGE_PATH != value))
                {
                    this._SCANNED_IMAGE_PATH = value;
                }
            }
        }

        [Column(Storage = "_DOCUMENT_PATH", DbType = "NVarChar(500)")]
        public string DOCUMENT_PATH
        {
            get
            {
                return this._DOCUMENT_PATH;
            }
            set
            {
                if ((this._DOCUMENT_PATH != value))
                {
                    this._DOCUMENT_PATH = value;
                }
            }
        }

        [Column(Storage = "_BACKUP_PATH", DbType = "NVarChar(500)")]
        public string BACKUP_PATH
        {
            get
            {
                return this._BACKUP_PATH;
            }
            set
            {
                if ((this._BACKUP_PATH != value))
                {
                    this._BACKUP_PATH = value;
                }
            }
        }

        [Column(Storage = "_OTHER_FILE_PATH", DbType = "NVarChar(300)")]
        public string OTHER_FILE_PATH
        {
            get
            {
                return this._OTHER_FILE_PATH;
            }
            set
            {
                if ((this._OTHER_FILE_PATH != value))
                {
                    this._OTHER_FILE_PATH = value;
                }
            }
        }

        [Column(Storage = "_EMP_IMG_PATH", DbType = "NVarChar(300)")]
        public string EMP_IMG_PATH
        {
            get
            {
                return this._EMP_IMG_PATH;
            }
            set
            {
                if ((this._EMP_IMG_PATH != value))
                {
                    this._EMP_IMG_PATH = value;
                }
            }
        }

        [Column(Storage = "_LAB_DATA_PATH", DbType = "NVarChar(300)")]
        public string LAB_DATA_PATH
        {
            get
            {
                return this._LAB_DATA_PATH;
            }
            set
            {
                if ((this._LAB_DATA_PATH != value))
                {
                    this._LAB_DATA_PATH = value;
                }
            }
        }

        [Column(Storage = "_USER_DISPLAY_FMT", DbType = "NVarChar(10)")]
        public string USER_DISPLAY_FMT
        {
            get
            {
                return this._USER_DISPLAY_FMT;
            }
            set
            {
                if ((this._USER_DISPLAY_FMT != value))
                {
                    this._USER_DISPLAY_FMT = value;
                }
            }
        }

        [Column(Storage = "_VENDOR_H1", DbType = "NVarChar(300)")]
        public string VENDOR_H1
        {
            get
            {
                return this._VENDOR_H1;
            }
            set
            {
                if ((this._VENDOR_H1 != value))
                {
                    this._VENDOR_H1 = value;
                }
            }
        }

        [Column(Storage = "_VENDOR_H2", DbType = "NVarChar(300)")]
        public string VENDOR_H2
        {
            get
            {
                return this._VENDOR_H2;
            }
            set
            {
                if ((this._VENDOR_H2 != value))
                {
                    this._VENDOR_H2 = value;
                }
            }
        }

        [Column(Storage = "_VENDOR_LOGO_PATH", DbType = "NVarChar(300)")]
        public string VENDOR_LOGO_PATH
        {
            get
            {
                return this._VENDOR_LOGO_PATH;
            }
            set
            {
                if ((this._VENDOR_LOGO_PATH != value))
                {
                    this._VENDOR_LOGO_PATH = value;
                }
            }
        }

        [Column(Storage = "_PARTNER1_H1", DbType = "NVarChar(300)")]
        public string PARTNER1_H1
        {
            get
            {
                return this._PARTNER1_H1;
            }
            set
            {
                if ((this._PARTNER1_H1 != value))
                {
                    this._PARTNER1_H1 = value;
                }
            }
        }

        [Column(Storage = "_PARTNER1_H2", DbType = "NVarChar(300)")]
        public string PARTNER1_H2
        {
            get
            {
                return this._PARTNER1_H2;
            }
            set
            {
                if ((this._PARTNER1_H2 != value))
                {
                    this._PARTNER1_H2 = value;
                }
            }
        }

        [Column(Storage = "_PARTNER1_LOGO_PATH", DbType = "NVarChar(300)")]
        public string PARTNER1_LOGO_PATH
        {
            get
            {
                return this._PARTNER1_LOGO_PATH;
            }
            set
            {
                if ((this._PARTNER1_LOGO_PATH != value))
                {
                    this._PARTNER1_LOGO_PATH = value;
                }
            }
        }

        [Column(Storage = "_PARTNER2_H1", DbType = "NVarChar(300)")]
        public string PARTNER2_H1
        {
            get
            {
                return this._PARTNER2_H1;
            }
            set
            {
                if ((this._PARTNER2_H1 != value))
                {
                    this._PARTNER2_H1 = value;
                }
            }
        }

        [Column(Storage = "_PARTNER2_H2", DbType = "NVarChar(300)")]
        public string PARTNER2_H2
        {
            get
            {
                return this._PARTNER2_H2;
            }
            set
            {
                if ((this._PARTNER2_H2 != value))
                {
                    this._PARTNER2_H2 = value;
                }
            }
        }

        [Column(Storage = "_PARTNER2_LOGO_PATH", DbType = "NVarChar(300)")]
        public string PARTNER2_LOGO_PATH
        {
            get
            {
                return this._PARTNER2_LOGO_PATH;
            }
            set
            {
                if ((this._PARTNER2_LOGO_PATH != value))
                {
                    this._PARTNER2_LOGO_PATH = value;
                }
            }
        }

        [Column(Storage = "_RIS_IP", DbType = "NVarChar(300)")]
        public string RIS_IP
        {
            get
            {
                return this._RIS_IP;
            }
            set
            {
                if ((this._RIS_IP != value))
                {
                    this._RIS_IP = value;
                }
            }
        }

        [Column(Storage = "_RIS_PORT", DbType = "NVarChar(300)")]
        public string RIS_PORT
        {
            get
            {
                return this._RIS_PORT;
            }
            set
            {
                if ((this._RIS_PORT != value))
                {
                    this._RIS_PORT = value;
                }
            }
        }

        [Column(Storage = "_RIS_USER", DbType = "NVarChar(300)")]
        public string RIS_USER
        {
            get
            {
                return this._RIS_USER;
            }
            set
            {
                if ((this._RIS_USER != value))
                {
                    this._RIS_USER = value;
                }
            }
        }

        [Column(Storage = "_RIS_PASS", DbType = "NVarChar(300)")]
        public string RIS_PASS
        {
            get
            {
                return this._RIS_PASS;
            }
            set
            {
                if ((this._RIS_PASS != value))
                {
                    this._RIS_PASS = value;
                }
            }
        }

        [Column(Storage = "_RIS_URL", DbType = "NVarChar(300)")]
        public string RIS_URL
        {
            get
            {
                return this._RIS_URL;
            }
            set
            {
                if ((this._RIS_URL != value))
                {
                    this._RIS_URL = value;
                }
            }
        }

        [Column(Storage = "_PACS_IP", DbType = "NVarChar(300)")]
        public string PACS_IP
        {
            get
            {
                return this._PACS_IP;
            }
            set
            {
                if ((this._PACS_IP != value))
                {
                    this._PACS_IP = value;
                }
            }
        }

        [Column(Storage = "_PACS_PORT", DbType = "NVarChar(300)")]
        public string PACS_PORT
        {
            get
            {
                return this._PACS_PORT;
            }
            set
            {
                if ((this._PACS_PORT != value))
                {
                    this._PACS_PORT = value;
                }
            }
        }

        [Column(Storage = "_PACS_URL1", DbType = "NVarChar(300)")]
        public string PACS_URL1
        {
            get
            {
                return this._PACS_URL1;
            }
            set
            {
                if ((this._PACS_URL1 != value))
                {
                    this._PACS_URL1 = value;
                }
            }
        }

        [Column(Storage = "_PACS_URL2", DbType = "NVarChar(300)")]
        public string PACS_URL2
        {
            get
            {
                return this._PACS_URL2;
            }
            set
            {
                if ((this._PACS_URL2 != value))
                {
                    this._PACS_URL2 = value;
                }
            }
        }

        [Column(Storage = "_PACS_DOMAIN", DbType = "NVarChar(300)")]
        public string PACS_DOMAIN
        {
            get
            {
                return this._PACS_DOMAIN;
            }
            set
            {
                if ((this._PACS_DOMAIN != value))
                {
                    this._PACS_DOMAIN = value;
                }
            }
        }

        [Column(Storage = "_HIS_IP", DbType = "NVarChar(300)")]
        public string HIS_IP
        {
            get
            {
                return this._HIS_IP;
            }
            set
            {
                if ((this._HIS_IP != value))
                {
                    this._HIS_IP = value;
                }
            }
        }

        [Column(Storage = "_HIS_PORT", DbType = "NVarChar(300)")]
        public string HIS_PORT
        {
            get
            {
                return this._HIS_PORT;
            }
            set
            {
                if ((this._HIS_PORT != value))
                {
                    this._HIS_PORT = value;
                }
            }
        }

        [Column(Storage = "_HIS_DB_NAME", DbType = "NVarChar(300)")]
        public string HIS_DB_NAME
        {
            get
            {
                return this._HIS_DB_NAME;
            }
            set
            {
                if ((this._HIS_DB_NAME != value))
                {
                    this._HIS_DB_NAME = value;
                }
            }
        }

        [Column(Storage = "_HIS_USER_NAME", DbType = "NVarChar(300)")]
        public string HIS_USER_NAME
        {
            get
            {
                return this._HIS_USER_NAME;
            }
            set
            {
                if ((this._HIS_USER_NAME != value))
                {
                    this._HIS_USER_NAME = value;
                }
            }
        }

        [Column(Storage = "_HIS_USER_PASS", DbType = "NVarChar(300)")]
        public string HIS_USER_PASS
        {
            get
            {
                return this._HIS_USER_PASS;
            }
            set
            {
                if ((this._HIS_USER_PASS != value))
                {
                    this._HIS_USER_PASS = value;
                }
            }
        }

        [Column(Storage = "_HIS_FIN_FLAG", DbType = "NVarChar(300)")]
        public string HIS_FIN_FLAG
        {
            get
            {
                return this._HIS_FIN_FLAG;
            }
            set
            {
                if ((this._HIS_FIN_FLAG != value))
                {
                    this._HIS_FIN_FLAG = value;
                }
            }
        }

        [Column(Storage = "_WS_IP", DbType = "NVarChar(300)")]
        public string WS_IP
        {
            get
            {
                return this._WS_IP;
            }
            set
            {
                if ((this._WS_IP != value))
                {
                    this._WS_IP = value;
                }
            }
        }

        [Column(Storage = "_WS_VERSION", DbType = "NVarChar(300)")]
        public string WS_VERSION
        {
            get
            {
                return this._WS_VERSION;
            }
            set
            {
                if ((this._WS_VERSION != value))
                {
                    this._WS_VERSION = value;
                }
            }
        }

        [Column(Storage = "_Expr10", DbType = "Int")]
        public System.Nullable<int> Expr10
        {
            get
            {
                return this._Expr10;
            }
            set
            {
                if ((this._Expr10 != value))
                {
                    this._Expr10 = value;
                }
            }
        }

        [Column(Storage = "_Expr11", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Expr11
        {
            get
            {
                return this._Expr11;
            }
            set
            {
                if ((this._Expr11 != value))
                {
                    this._Expr11 = value;
                }
            }
        }

        [Column(Storage = "_Expr12", DbType = "Int")]
        public System.Nullable<int> Expr12
        {
            get
            {
                return this._Expr12;
            }
            set
            {
                if ((this._Expr12 != value))
                {
                    this._Expr12 = value;
                }
            }
        }

        [Column(Storage = "_Expr13", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Expr13
        {
            get
            {
                return this._Expr13;
            }
            set
            {
                if ((this._Expr13 != value))
                {
                    this._Expr13 = value;
                }
            }
        }
    }
}
