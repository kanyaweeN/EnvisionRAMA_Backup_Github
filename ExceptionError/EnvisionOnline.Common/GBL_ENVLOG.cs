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
    [Table(Name = "dbo.GBL_ENVLOG")]
    public partial class GBL_ENVLOG : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOG_ID;

        private System.DateTime _EFFECTIVE_DT;

        private System.Data.Linq.Binary _START_LSN;

        private System.Data.Linq.Binary _SEQVAL;

        private int _OPERATION;

        private System.Data.Linq.Binary _UPDATE_MASK;

        private System.Nullable<int> _ORG_ID;

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

        private System.Data.Linq.Binary _ORG_IMG;

        private string _WELCOME_DIALOG1;

        private string _WELCOME_DIALOG2;

        private string _DEFAULT_FONT_FACE;

        private System.Nullable<byte> _DEFAULT_FONT_SIZE;

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

        private string _PACS_URL3;

        private string _PACS_DOMAIN;

        private string _HIS_IP;

        private string _HIS_PORT;

        private string _HIS_DB_NAME;

        private string _HIS_USER_NAME;

        private string _HIS_USER_PASS;

        private string _HIS_FIN_FLAG;

        private string _WS_IP;

        private string _WS_IP_PICTURE;

        private string _WS_VERSION;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLOG_IDChanging(int value);
        partial void OnLOG_IDChanged();
        partial void OnEFFECTIVE_DTChanging(System.DateTime value);
        partial void OnEFFECTIVE_DTChanged();
        partial void OnSTART_LSNChanging(System.Data.Linq.Binary value);
        partial void OnSTART_LSNChanged();
        partial void OnSEQVALChanging(System.Data.Linq.Binary value);
        partial void OnSEQVALChanged();
        partial void OnOPERATIONChanging(int value);
        partial void OnOPERATIONChanged();
        partial void OnUPDATE_MASKChanging(System.Data.Linq.Binary value);
        partial void OnUPDATE_MASKChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnORG_UIDChanging(string value);
        partial void OnORG_UIDChanged();
        partial void OnORG_NAMEChanging(string value);
        partial void OnORG_NAMEChanged();
        partial void OnORG_ALIASChanging(string value);
        partial void OnORG_ALIASChanged();
        partial void OnORG_SLOGAN1Changing(string value);
        partial void OnORG_SLOGAN1Changed();
        partial void OnORG_SLOGAN2Changing(string value);
        partial void OnORG_SLOGAN2Changed();
        partial void OnORG_ADDR1Changing(string value);
        partial void OnORG_ADDR1Changed();
        partial void OnORG_ADDR2Changing(string value);
        partial void OnORG_ADDR2Changed();
        partial void OnORG_ADDR3Changing(string value);
        partial void OnORG_ADDR3Changed();
        partial void OnORG_ADDR4Changing(string value);
        partial void OnORG_ADDR4Changed();
        partial void OnORG_TEL1Changing(string value);
        partial void OnORG_TEL1Changed();
        partial void OnORG_TEL2Changing(string value);
        partial void OnORG_TEL2Changed();
        partial void OnORG_TEL3Changing(string value);
        partial void OnORG_TEL3Changed();
        partial void OnORG_FAXChanging(string value);
        partial void OnORG_FAXChanged();
        partial void OnORG_EMAIL1Changing(string value);
        partial void OnORG_EMAIL1Changed();
        partial void OnORG_EMAIL2Changing(string value);
        partial void OnORG_EMAIL2Changed();
        partial void OnORG_EMAIL3Changing(string value);
        partial void OnORG_EMAIL3Changed();
        partial void OnORG_WEBSITEChanging(string value);
        partial void OnORG_WEBSITEChanged();
        partial void OnORG_IMGChanging(System.Data.Linq.Binary value);
        partial void OnORG_IMGChanged();
        partial void OnWELCOME_DIALOG1Changing(string value);
        partial void OnWELCOME_DIALOG1Changed();
        partial void OnWELCOME_DIALOG2Changing(string value);
        partial void OnWELCOME_DIALOG2Changed();
        partial void OnDEFAULT_FONT_FACEChanging(string value);
        partial void OnDEFAULT_FONT_FACEChanged();
        partial void OnDEFAULT_FONT_SIZEChanging(System.Nullable<byte> value);
        partial void OnDEFAULT_FONT_SIZEChanged();
        partial void OnREP_SERVERChanging(string value);
        partial void OnREP_SERVERChanged();
        partial void OnREP_FORMATChanging(string value);
        partial void OnREP_FORMATChanged();
        partial void OnREP_FOOTER1Changing(string value);
        partial void OnREP_FOOTER1Changed();
        partial void OnREP_FOOTER2Changing(string value);
        partial void OnREP_FOOTER2Changed();
        partial void OnEMP_IMG_TYPEChanging(string value);
        partial void OnEMP_IMG_TYPEChanged();
        partial void OnEMP_IMG_MAX_SIZEChanging(string value);
        partial void OnEMP_IMG_MAX_SIZEChanged();
        partial void OnOTHER_MAX_FILE_SIZEChanging(System.Nullable<int> value);
        partial void OnOTHER_MAX_FILE_SIZEChanged();
        partial void OnDT_FMTChanging(string value);
        partial void OnDT_FMTChanged();
        partial void OnTIME_FMTChanging(string value);
        partial void OnTIME_FMTChanged();
        partial void OnLOCAL_CURRENCY_NAMEChanging(string value);
        partial void OnLOCAL_CURRENCY_NAMEChanged();
        partial void OnLOCAL_CURRENCY_SYMBOLChanging(string value);
        partial void OnLOCAL_CURRENCY_SYMBOLChanged();
        partial void OnCURRENCY_FMTChanging(string value);
        partial void OnCURRENCY_FMTChanged();
        partial void OnRESOURCE_IMAGE_PATHChanging(string value);
        partial void OnRESOURCE_IMAGE_PATHChanged();
        partial void OnSCANNED_IMAGE_PATHChanging(string value);
        partial void OnSCANNED_IMAGE_PATHChanged();
        partial void OnDOCUMENT_PATHChanging(string value);
        partial void OnDOCUMENT_PATHChanged();
        partial void OnBACKUP_PATHChanging(string value);
        partial void OnBACKUP_PATHChanged();
        partial void OnOTHER_FILE_PATHChanging(string value);
        partial void OnOTHER_FILE_PATHChanged();
        partial void OnEMP_IMG_PATHChanging(string value);
        partial void OnEMP_IMG_PATHChanged();
        partial void OnLAB_DATA_PATHChanging(string value);
        partial void OnLAB_DATA_PATHChanged();
        partial void OnUSER_DISPLAY_FMTChanging(string value);
        partial void OnUSER_DISPLAY_FMTChanged();
        partial void OnVENDOR_H1Changing(string value);
        partial void OnVENDOR_H1Changed();
        partial void OnVENDOR_H2Changing(string value);
        partial void OnVENDOR_H2Changed();
        partial void OnVENDOR_LOGO_PATHChanging(string value);
        partial void OnVENDOR_LOGO_PATHChanged();
        partial void OnPARTNER1_H1Changing(string value);
        partial void OnPARTNER1_H1Changed();
        partial void OnPARTNER1_H2Changing(string value);
        partial void OnPARTNER1_H2Changed();
        partial void OnPARTNER1_LOGO_PATHChanging(string value);
        partial void OnPARTNER1_LOGO_PATHChanged();
        partial void OnPARTNER2_H1Changing(string value);
        partial void OnPARTNER2_H1Changed();
        partial void OnPARTNER2_H2Changing(string value);
        partial void OnPARTNER2_H2Changed();
        partial void OnPARTNER2_LOGO_PATHChanging(string value);
        partial void OnPARTNER2_LOGO_PATHChanged();
        partial void OnRIS_IPChanging(string value);
        partial void OnRIS_IPChanged();
        partial void OnRIS_PORTChanging(string value);
        partial void OnRIS_PORTChanged();
        partial void OnRIS_USERChanging(string value);
        partial void OnRIS_USERChanged();
        partial void OnRIS_PASSChanging(string value);
        partial void OnRIS_PASSChanged();
        partial void OnRIS_URLChanging(string value);
        partial void OnRIS_URLChanged();
        partial void OnPACS_IPChanging(string value);
        partial void OnPACS_IPChanged();
        partial void OnPACS_PORTChanging(string value);
        partial void OnPACS_PORTChanged();
        partial void OnPACS_URL1Changing(string value);
        partial void OnPACS_URL1Changed();
        partial void OnPACS_URL2Changing(string value);
        partial void OnPACS_URL2Changed();
        partial void OnPACS_URL3Changing(string value);
        partial void OnPACS_URL3Changed();
        partial void OnPACS_DOMAINChanging(string value);
        partial void OnPACS_DOMAINChanged();
        partial void OnHIS_IPChanging(string value);
        partial void OnHIS_IPChanged();
        partial void OnHIS_PORTChanging(string value);
        partial void OnHIS_PORTChanged();
        partial void OnHIS_DB_NAMEChanging(string value);
        partial void OnHIS_DB_NAMEChanged();
        partial void OnHIS_USER_NAMEChanging(string value);
        partial void OnHIS_USER_NAMEChanged();
        partial void OnHIS_USER_PASSChanging(string value);
        partial void OnHIS_USER_PASSChanged();
        partial void OnHIS_FIN_FLAGChanging(string value);
        partial void OnHIS_FIN_FLAGChanged();
        partial void OnWS_IPChanging(string value);
        partial void OnWS_IPChanged();
        partial void OnWS_IP_PICTUREChanging(string value);
        partial void OnWS_IP_PICTUREChanged();
        partial void OnWS_VERSIONChanging(string value);
        partial void OnWS_VERSIONChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public GBL_ENVLOG()
        {
            OnCreated();
        }

        [Column(Storage = "_LOG_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int LOG_ID
        {
            get
            {
                return this._LOG_ID;
            }
            set
            {
                if ((this._LOG_ID != value))
                {
                    this.OnLOG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LOG_ID = value;
                    this.SendPropertyChanged("LOG_ID");
                    this.OnLOG_IDChanged();
                }
            }
        }

        [Column(Storage = "_EFFECTIVE_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime EFFECTIVE_DT
        {
            get
            {
                return this._EFFECTIVE_DT;
            }
            set
            {
                if ((this._EFFECTIVE_DT != value))
                {
                    this.OnEFFECTIVE_DTChanging(value);
                    this.SendPropertyChanging();
                    this._EFFECTIVE_DT = value;
                    this.SendPropertyChanged("EFFECTIVE_DT");
                    this.OnEFFECTIVE_DTChanged();
                }
            }
        }

        [Column(Storage = "_START_LSN", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary START_LSN
        {
            get
            {
                return this._START_LSN;
            }
            set
            {
                if ((this._START_LSN != value))
                {
                    this.OnSTART_LSNChanging(value);
                    this.SendPropertyChanging();
                    this._START_LSN = value;
                    this.SendPropertyChanged("START_LSN");
                    this.OnSTART_LSNChanged();
                }
            }
        }

        [Column(Storage = "_SEQVAL", DbType = "Binary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary SEQVAL
        {
            get
            {
                return this._SEQVAL;
            }
            set
            {
                if ((this._SEQVAL != value))
                {
                    this.OnSEQVALChanging(value);
                    this.SendPropertyChanging();
                    this._SEQVAL = value;
                    this.SendPropertyChanged("SEQVAL");
                    this.OnSEQVALChanged();
                }
            }
        }

        [Column(Storage = "_OPERATION", DbType = "Int NOT NULL")]
        public int OPERATION
        {
            get
            {
                return this._OPERATION;
            }
            set
            {
                if ((this._OPERATION != value))
                {
                    this.OnOPERATIONChanging(value);
                    this.SendPropertyChanging();
                    this._OPERATION = value;
                    this.SendPropertyChanged("OPERATION");
                    this.OnOPERATIONChanged();
                }
            }
        }

        [Column(Storage = "_UPDATE_MASK", DbType = "VarBinary(10) NOT NULL", CanBeNull = false, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary UPDATE_MASK
        {
            get
            {
                return this._UPDATE_MASK;
            }
            set
            {
                if ((this._UPDATE_MASK != value))
                {
                    this.OnUPDATE_MASKChanging(value);
                    this.SendPropertyChanging();
                    this._UPDATE_MASK = value;
                    this.SendPropertyChanged("UPDATE_MASK");
                    this.OnUPDATE_MASKChanged();
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
                    this.OnORG_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ID = value;
                    this.SendPropertyChanged("ORG_ID");
                    this.OnORG_IDChanged();
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
                    this.OnORG_UIDChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_UID = value;
                    this.SendPropertyChanged("ORG_UID");
                    this.OnORG_UIDChanged();
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
                    this.OnORG_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_NAME = value;
                    this.SendPropertyChanged("ORG_NAME");
                    this.OnORG_NAMEChanged();
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
                    this.OnORG_ALIASChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_ALIAS = value;
                    this.SendPropertyChanged("ORG_ALIAS");
                    this.OnORG_ALIASChanged();
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
                    this.OnORG_SLOGAN1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_SLOGAN1 = value;
                    this.SendPropertyChanged("ORG_SLOGAN1");
                    this.OnORG_SLOGAN1Changed();
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
                    this.OnORG_SLOGAN2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_SLOGAN2 = value;
                    this.SendPropertyChanged("ORG_SLOGAN2");
                    this.OnORG_SLOGAN2Changed();
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
                    this.OnORG_ADDR1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR1 = value;
                    this.SendPropertyChanged("ORG_ADDR1");
                    this.OnORG_ADDR1Changed();
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
                    this.OnORG_ADDR2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR2 = value;
                    this.SendPropertyChanged("ORG_ADDR2");
                    this.OnORG_ADDR2Changed();
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
                    this.OnORG_ADDR3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR3 = value;
                    this.SendPropertyChanged("ORG_ADDR3");
                    this.OnORG_ADDR3Changed();
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
                    this.OnORG_ADDR4Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_ADDR4 = value;
                    this.SendPropertyChanged("ORG_ADDR4");
                    this.OnORG_ADDR4Changed();
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
                    this.OnORG_TEL1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL1 = value;
                    this.SendPropertyChanged("ORG_TEL1");
                    this.OnORG_TEL1Changed();
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
                    this.OnORG_TEL2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL2 = value;
                    this.SendPropertyChanged("ORG_TEL2");
                    this.OnORG_TEL2Changed();
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
                    this.OnORG_TEL3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_TEL3 = value;
                    this.SendPropertyChanged("ORG_TEL3");
                    this.OnORG_TEL3Changed();
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
                    this.OnORG_FAXChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_FAX = value;
                    this.SendPropertyChanged("ORG_FAX");
                    this.OnORG_FAXChanged();
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
                    this.OnORG_EMAIL1Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL1 = value;
                    this.SendPropertyChanged("ORG_EMAIL1");
                    this.OnORG_EMAIL1Changed();
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
                    this.OnORG_EMAIL2Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL2 = value;
                    this.SendPropertyChanged("ORG_EMAIL2");
                    this.OnORG_EMAIL2Changed();
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
                    this.OnORG_EMAIL3Changing(value);
                    this.SendPropertyChanging();
                    this._ORG_EMAIL3 = value;
                    this.SendPropertyChanged("ORG_EMAIL3");
                    this.OnORG_EMAIL3Changed();
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
                    this.OnORG_WEBSITEChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_WEBSITE = value;
                    this.SendPropertyChanged("ORG_WEBSITE");
                    this.OnORG_WEBSITEChanged();
                }
            }
        }

        [Column(Storage = "_ORG_IMG", DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary ORG_IMG
        {
            get
            {
                return this._ORG_IMG;
            }
            set
            {
                if ((this._ORG_IMG != value))
                {
                    this.OnORG_IMGChanging(value);
                    this.SendPropertyChanging();
                    this._ORG_IMG = value;
                    this.SendPropertyChanged("ORG_IMG");
                    this.OnORG_IMGChanged();
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
                    this.OnWELCOME_DIALOG1Changing(value);
                    this.SendPropertyChanging();
                    this._WELCOME_DIALOG1 = value;
                    this.SendPropertyChanged("WELCOME_DIALOG1");
                    this.OnWELCOME_DIALOG1Changed();
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
                    this.OnWELCOME_DIALOG2Changing(value);
                    this.SendPropertyChanging();
                    this._WELCOME_DIALOG2 = value;
                    this.SendPropertyChanged("WELCOME_DIALOG2");
                    this.OnWELCOME_DIALOG2Changed();
                }
            }
        }

        [Column(Storage = "_DEFAULT_FONT_FACE", DbType = "NVarChar(200)")]
        public string DEFAULT_FONT_FACE
        {
            get
            {
                return this._DEFAULT_FONT_FACE;
            }
            set
            {
                if ((this._DEFAULT_FONT_FACE != value))
                {
                    this.OnDEFAULT_FONT_FACEChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_FONT_FACE = value;
                    this.SendPropertyChanged("DEFAULT_FONT_FACE");
                    this.OnDEFAULT_FONT_FACEChanged();
                }
            }
        }

        [Column(Storage = "_DEFAULT_FONT_SIZE", DbType = "TinyInt")]
        public System.Nullable<byte> DEFAULT_FONT_SIZE
        {
            get
            {
                return this._DEFAULT_FONT_SIZE;
            }
            set
            {
                if ((this._DEFAULT_FONT_SIZE != value))
                {
                    this.OnDEFAULT_FONT_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._DEFAULT_FONT_SIZE = value;
                    this.SendPropertyChanged("DEFAULT_FONT_SIZE");
                    this.OnDEFAULT_FONT_SIZEChanged();
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
                    this.OnREP_SERVERChanging(value);
                    this.SendPropertyChanging();
                    this._REP_SERVER = value;
                    this.SendPropertyChanged("REP_SERVER");
                    this.OnREP_SERVERChanged();
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
                    this.OnREP_FORMATChanging(value);
                    this.SendPropertyChanging();
                    this._REP_FORMAT = value;
                    this.SendPropertyChanged("REP_FORMAT");
                    this.OnREP_FORMATChanged();
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
                    this.OnREP_FOOTER1Changing(value);
                    this.SendPropertyChanging();
                    this._REP_FOOTER1 = value;
                    this.SendPropertyChanged("REP_FOOTER1");
                    this.OnREP_FOOTER1Changed();
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
                    this.OnREP_FOOTER2Changing(value);
                    this.SendPropertyChanging();
                    this._REP_FOOTER2 = value;
                    this.SendPropertyChanged("REP_FOOTER2");
                    this.OnREP_FOOTER2Changed();
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
                    this.OnEMP_IMG_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_TYPE = value;
                    this.SendPropertyChanged("EMP_IMG_TYPE");
                    this.OnEMP_IMG_TYPEChanged();
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
                    this.OnEMP_IMG_MAX_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_MAX_SIZE = value;
                    this.SendPropertyChanged("EMP_IMG_MAX_SIZE");
                    this.OnEMP_IMG_MAX_SIZEChanged();
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
                    this.OnOTHER_MAX_FILE_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._OTHER_MAX_FILE_SIZE = value;
                    this.SendPropertyChanged("OTHER_MAX_FILE_SIZE");
                    this.OnOTHER_MAX_FILE_SIZEChanged();
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
                    this.OnDT_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._DT_FMT = value;
                    this.SendPropertyChanged("DT_FMT");
                    this.OnDT_FMTChanged();
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
                    this.OnTIME_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._TIME_FMT = value;
                    this.SendPropertyChanged("TIME_FMT");
                    this.OnTIME_FMTChanged();
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
                    this.OnLOCAL_CURRENCY_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._LOCAL_CURRENCY_NAME = value;
                    this.SendPropertyChanged("LOCAL_CURRENCY_NAME");
                    this.OnLOCAL_CURRENCY_NAMEChanged();
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
                    this.OnLOCAL_CURRENCY_SYMBOLChanging(value);
                    this.SendPropertyChanging();
                    this._LOCAL_CURRENCY_SYMBOL = value;
                    this.SendPropertyChanged("LOCAL_CURRENCY_SYMBOL");
                    this.OnLOCAL_CURRENCY_SYMBOLChanged();
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
                    this.OnCURRENCY_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._CURRENCY_FMT = value;
                    this.SendPropertyChanged("CURRENCY_FMT");
                    this.OnCURRENCY_FMTChanged();
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
                    this.OnRESOURCE_IMAGE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._RESOURCE_IMAGE_PATH = value;
                    this.SendPropertyChanged("RESOURCE_IMAGE_PATH");
                    this.OnRESOURCE_IMAGE_PATHChanged();
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
                    this.OnSCANNED_IMAGE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._SCANNED_IMAGE_PATH = value;
                    this.SendPropertyChanged("SCANNED_IMAGE_PATH");
                    this.OnSCANNED_IMAGE_PATHChanged();
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
                    this.OnDOCUMENT_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._DOCUMENT_PATH = value;
                    this.SendPropertyChanged("DOCUMENT_PATH");
                    this.OnDOCUMENT_PATHChanged();
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
                    this.OnBACKUP_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._BACKUP_PATH = value;
                    this.SendPropertyChanged("BACKUP_PATH");
                    this.OnBACKUP_PATHChanged();
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
                    this.OnOTHER_FILE_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._OTHER_FILE_PATH = value;
                    this.SendPropertyChanged("OTHER_FILE_PATH");
                    this.OnOTHER_FILE_PATHChanged();
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
                    this.OnEMP_IMG_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._EMP_IMG_PATH = value;
                    this.SendPropertyChanged("EMP_IMG_PATH");
                    this.OnEMP_IMG_PATHChanged();
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
                    this.OnLAB_DATA_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._LAB_DATA_PATH = value;
                    this.SendPropertyChanged("LAB_DATA_PATH");
                    this.OnLAB_DATA_PATHChanged();
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
                    this.OnUSER_DISPLAY_FMTChanging(value);
                    this.SendPropertyChanging();
                    this._USER_DISPLAY_FMT = value;
                    this.SendPropertyChanged("USER_DISPLAY_FMT");
                    this.OnUSER_DISPLAY_FMTChanged();
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
                    this.OnVENDOR_H1Changing(value);
                    this.SendPropertyChanging();
                    this._VENDOR_H1 = value;
                    this.SendPropertyChanged("VENDOR_H1");
                    this.OnVENDOR_H1Changed();
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
                    this.OnVENDOR_H2Changing(value);
                    this.SendPropertyChanging();
                    this._VENDOR_H2 = value;
                    this.SendPropertyChanged("VENDOR_H2");
                    this.OnVENDOR_H2Changed();
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
                    this.OnVENDOR_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._VENDOR_LOGO_PATH = value;
                    this.SendPropertyChanged("VENDOR_LOGO_PATH");
                    this.OnVENDOR_LOGO_PATHChanged();
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
                    this.OnPARTNER1_H1Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_H1 = value;
                    this.SendPropertyChanged("PARTNER1_H1");
                    this.OnPARTNER1_H1Changed();
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
                    this.OnPARTNER1_H2Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_H2 = value;
                    this.SendPropertyChanged("PARTNER1_H2");
                    this.OnPARTNER1_H2Changed();
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
                    this.OnPARTNER1_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._PARTNER1_LOGO_PATH = value;
                    this.SendPropertyChanged("PARTNER1_LOGO_PATH");
                    this.OnPARTNER1_LOGO_PATHChanged();
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
                    this.OnPARTNER2_H1Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_H1 = value;
                    this.SendPropertyChanged("PARTNER2_H1");
                    this.OnPARTNER2_H1Changed();
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
                    this.OnPARTNER2_H2Changing(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_H2 = value;
                    this.SendPropertyChanged("PARTNER2_H2");
                    this.OnPARTNER2_H2Changed();
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
                    this.OnPARTNER2_LOGO_PATHChanging(value);
                    this.SendPropertyChanging();
                    this._PARTNER2_LOGO_PATH = value;
                    this.SendPropertyChanged("PARTNER2_LOGO_PATH");
                    this.OnPARTNER2_LOGO_PATHChanged();
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
                    this.OnRIS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_IP = value;
                    this.SendPropertyChanged("RIS_IP");
                    this.OnRIS_IPChanged();
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
                    this.OnRIS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_PORT = value;
                    this.SendPropertyChanged("RIS_PORT");
                    this.OnRIS_PORTChanged();
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
                    this.OnRIS_USERChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_USER = value;
                    this.SendPropertyChanged("RIS_USER");
                    this.OnRIS_USERChanged();
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
                    this.OnRIS_PASSChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_PASS = value;
                    this.SendPropertyChanged("RIS_PASS");
                    this.OnRIS_PASSChanged();
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
                    this.OnRIS_URLChanging(value);
                    this.SendPropertyChanging();
                    this._RIS_URL = value;
                    this.SendPropertyChanged("RIS_URL");
                    this.OnRIS_URLChanged();
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
                    this.OnPACS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_IP = value;
                    this.SendPropertyChanged("PACS_IP");
                    this.OnPACS_IPChanged();
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
                    this.OnPACS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_PORT = value;
                    this.SendPropertyChanged("PACS_PORT");
                    this.OnPACS_PORTChanged();
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
                    this.OnPACS_URL1Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL1 = value;
                    this.SendPropertyChanged("PACS_URL1");
                    this.OnPACS_URL1Changed();
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
                    this.OnPACS_URL2Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL2 = value;
                    this.SendPropertyChanged("PACS_URL2");
                    this.OnPACS_URL2Changed();
                }
            }
        }

        [Column(Storage = "_PACS_URL3", DbType = "NVarChar(300)")]
        public string PACS_URL3
        {
            get
            {
                return this._PACS_URL3;
            }
            set
            {
                if ((this._PACS_URL3 != value))
                {
                    this.OnPACS_URL3Changing(value);
                    this.SendPropertyChanging();
                    this._PACS_URL3 = value;
                    this.SendPropertyChanged("PACS_URL3");
                    this.OnPACS_URL3Changed();
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
                    this.OnPACS_DOMAINChanging(value);
                    this.SendPropertyChanging();
                    this._PACS_DOMAIN = value;
                    this.SendPropertyChanged("PACS_DOMAIN");
                    this.OnPACS_DOMAINChanged();
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
                    this.OnHIS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_IP = value;
                    this.SendPropertyChanged("HIS_IP");
                    this.OnHIS_IPChanged();
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
                    this.OnHIS_PORTChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_PORT = value;
                    this.SendPropertyChanged("HIS_PORT");
                    this.OnHIS_PORTChanged();
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
                    this.OnHIS_DB_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_DB_NAME = value;
                    this.SendPropertyChanged("HIS_DB_NAME");
                    this.OnHIS_DB_NAMEChanged();
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
                    this.OnHIS_USER_NAMEChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_USER_NAME = value;
                    this.SendPropertyChanged("HIS_USER_NAME");
                    this.OnHIS_USER_NAMEChanged();
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
                    this.OnHIS_USER_PASSChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_USER_PASS = value;
                    this.SendPropertyChanged("HIS_USER_PASS");
                    this.OnHIS_USER_PASSChanged();
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
                    this.OnHIS_FIN_FLAGChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_FIN_FLAG = value;
                    this.SendPropertyChanged("HIS_FIN_FLAG");
                    this.OnHIS_FIN_FLAGChanged();
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
                    this.OnWS_IPChanging(value);
                    this.SendPropertyChanging();
                    this._WS_IP = value;
                    this.SendPropertyChanged("WS_IP");
                    this.OnWS_IPChanged();
                }
            }
        }

        [Column(Storage = "_WS_IP_PICTURE", DbType = "NVarChar(300)")]
        public string WS_IP_PICTURE
        {
            get
            {
                return this._WS_IP_PICTURE;
            }
            set
            {
                if ((this._WS_IP_PICTURE != value))
                {
                    this.OnWS_IP_PICTUREChanging(value);
                    this.SendPropertyChanging();
                    this._WS_IP_PICTURE = value;
                    this.SendPropertyChanged("WS_IP_PICTURE");
                    this.OnWS_IP_PICTUREChanged();
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
                    this.OnWS_VERSIONChanging(value);
                    this.SendPropertyChanging();
                    this._WS_VERSION = value;
                    this.SendPropertyChanged("WS_VERSION");
                    this.OnWS_VERSIONChanged();
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
                    this.OnCREATED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_BY = value;
                    this.SendPropertyChanged("CREATED_BY");
                    this.OnCREATED_BYChanged();
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
                    this.OnCREATED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._CREATED_ON = value;
                    this.SendPropertyChanged("CREATED_ON");
                    this.OnCREATED_ONChanged();
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
                    this.OnLAST_MODIFIED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_BY = value;
                    this.SendPropertyChanged("LAST_MODIFIED_BY");
                    this.OnLAST_MODIFIED_BYChanged();
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
                    this.OnLAST_MODIFIED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._LAST_MODIFIED_ON = value;
                    this.SendPropertyChanged("LAST_MODIFIED_ON");
                    this.OnLAST_MODIFIED_ONChanged();
                }
            }
        }

        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
