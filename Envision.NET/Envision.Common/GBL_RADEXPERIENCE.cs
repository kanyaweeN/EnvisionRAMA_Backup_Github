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
    [Table(Name = "dbo.GBL_RADEXPERIENCE")]
    public partial class GBL_RADEXPERIENCE : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _RADIOLOGIST_ID;

        private System.Nullable<short> _AUTO_REFRESH_WL_SEC;

        private System.Nullable<char> _DASHBOARD_DEF_SEARCH;

        private System.Nullable<bool> _LOAD_FINALIZED_EXAMS;

        private System.Nullable<bool> _ALL_EXAM_VISIBLE;

        private System.Nullable<bool> _LOAD_ALL_EXAM;

        private System.Nullable<bool> _AUTO_START_ORDER_IMG;

        private System.Nullable<bool> _AUTO_START_PACS_IMG;

        private string _DEF_DATE_RANGE;

        private System.Nullable<bool> _REMEMBER_GRID_ORDER;

        private System.Nullable<char> _GRID_DBL_CLICK_TO;

        private System.Nullable<char> _FINISH_WRITING_REFER_TO;

        private System.Nullable<bool> _ALLOW_OTHERSTO_FINALIZE;

        private string _FONT_FACE;

        private System.Nullable<byte> _FONT_SIZE;

        private string _SIGNATURE_TEXT;

        private string _SIGNATURE_RTF;

        private string _SIGNATURE_HTML;

        private System.Data.Linq.Binary _SIGNATURE_SCAN;

        private System.Nullable<char> _USED_SIGNATURE;

        private System.Nullable<char> _WHEN_GROUP_SIGN_USE;

        private System.Nullable<int> _MINIMIZE_CHARACTER;

        private string _WORKLIST_GRID_ORDER;

        private string _HISTORY_GRID_ORDER;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private System.Nullable<char> _USED_MENUBAR;
        private System.Nullable<char> _USED_120DPI;
        private System.Nullable<char> _RECONFIRM_PASS_ON_SAVE;

        private EntityRef<HR_EMP> _HR_EMP;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnRADIOLOGIST_IDChanging(int value);
        partial void OnRADIOLOGIST_IDChanged();
        partial void OnAUTO_REFRESH_WL_SECChanging(System.Nullable<short> value);
        partial void OnAUTO_REFRESH_WL_SECChanged();
        partial void OnDASHBOARD_DEF_SEARCHChanging(System.Nullable<char> value);
        partial void OnDASHBOARD_DEF_SEARCHChanged();
        partial void OnLOAD_FINALIZED_EXAMSChanging(System.Nullable<bool> value);
        partial void OnLOAD_FINALIZED_EXAMSChanged();
        partial void OnALL_EXAM_VISIBLEChanging(System.Nullable<bool> value);
        partial void OnALL_EXAM_VISIBLEChanged();
        partial void OnLOAD_ALL_EXAMChanging(System.Nullable<bool> value);
        partial void OnLOAD_ALL_EXAMChanged();
        partial void OnAUTO_START_ORDER_IMGChanging(System.Nullable<bool> value);
        partial void OnAUTO_START_ORDER_IMGChanged();
        partial void OnAUTO_START_PACS_IMGChanging(System.Nullable<bool> value);
        partial void OnAUTO_START_PACS_IMGChanged();
        partial void OnDEF_DATE_RANGEChanging(string value);
        partial void OnDEF_DATE_RANGEChanged();
        partial void OnREMEMBER_GRID_ORDERChanging(System.Nullable<bool> value);
        partial void OnREMEMBER_GRID_ORDERChanged();
        partial void OnGRID_DBL_CLICK_TOChanging(System.Nullable<char> value);
        partial void OnGRID_DBL_CLICK_TOChanged();
        partial void OnFINISH_WRITING_REFER_TOChanging(System.Nullable<char> value);
        partial void OnFINISH_WRITING_REFER_TOChanged();
        partial void OnALLOW_OTHERSTO_FINALIZEChanging(System.Nullable<bool> value);
        partial void OnALLOW_OTHERSTO_FINALIZEChanged();
        partial void OnFONT_FACEChanging(string value);
        partial void OnFONT_FACEChanged();
        partial void OnFONT_SIZEChanging(System.Nullable<byte> value);
        partial void OnFONT_SIZEChanged();
        partial void OnSIGNATURE_TEXTChanging(string value);
        partial void OnSIGNATURE_TEXTChanged();
        partial void OnSIGNATURE_RTFChanging(string value);
        partial void OnSIGNATURE_RTFChanged();
        partial void OnSIGNATURE_HTMLChanging(string value);
        partial void OnSIGNATURE_HTMLChanged();
        partial void OnSIGNATURE_SCANChanging(System.Data.Linq.Binary value);
        partial void OnSIGNATURE_SCANChanged();
        partial void OnUSED_SIGNATUREChanging(System.Nullable<char> value);
        partial void OnUSED_SIGNATUREChanged();
        partial void OnWHEN_GROUP_SIGN_USEChanging(System.Nullable<char> value);
        partial void OnWHEN_GROUP_SIGN_USEChanged();
        partial void OnMINIMIZE_CHARACTERChanging(System.Nullable<int> value);
        partial void OnMINIMIZE_CHARACTERChanged();
        partial void OnWORKLIST_GRID_ORDERChanging(string value);
        partial void OnWORKLIST_GRID_ORDERChanged();
        partial void OnHISTORY_GRID_ORDERChanging(string value);
        partial void OnHISTORY_GRID_ORDERChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnUSED_MENUBARChanging(System.Nullable<char> value);
        partial void OnUSED_MENUBARChanged();
        partial void OnUSED_120DPIChanging(System.Nullable<char> value);
        partial void OnUSED_120DPIChanged();
        partial void OnRECONFIRM_PASS_ON_SAVEChanging(System.Nullable<char> value);
        partial void OnRECONFIRM_PASS_ON_SAVEChanged();
        #endregion

        public GBL_RADEXPERIENCE()
        {
            this._HR_EMP = default(EntityRef<HR_EMP>);
            OnCreated();
        }

        [Column(Storage = "_RADIOLOGIST_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int RADIOLOGIST_ID
        {
            get
            {
                return this._RADIOLOGIST_ID;
            }
            set
            {
                if ((this._RADIOLOGIST_ID != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRADIOLOGIST_IDChanging(value);
                    this.SendPropertyChanging();
                    this._RADIOLOGIST_ID = value;
                    this.SendPropertyChanged("RADIOLOGIST_ID");
                    this.OnRADIOLOGIST_IDChanged();
                }
            }
        }

        [Column(Storage = "_AUTO_REFRESH_WL_SEC", DbType = "SmallInt")]
        public System.Nullable<short> AUTO_REFRESH_WL_SEC
        {
            get
            {
                return this._AUTO_REFRESH_WL_SEC;
            }
            set
            {
                if ((this._AUTO_REFRESH_WL_SEC != value))
                {
                    this.OnAUTO_REFRESH_WL_SECChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_REFRESH_WL_SEC = value;
                    this.SendPropertyChanged("AUTO_REFRESH_WL_SEC");
                    this.OnAUTO_REFRESH_WL_SECChanged();
                }
            }
        }

        [Column(Storage = "_DASHBOARD_DEF_SEARCH", DbType = "NVarChar(1)")]
        public System.Nullable<char> DASHBOARD_DEF_SEARCH
        {
            get
            {
                return this._DASHBOARD_DEF_SEARCH;
            }
            set
            {
                if ((this._DASHBOARD_DEF_SEARCH != value))
                {
                    this.OnDASHBOARD_DEF_SEARCHChanging(value);
                    this.SendPropertyChanging();
                    this._DASHBOARD_DEF_SEARCH = value;
                    this.SendPropertyChanged("DASHBOARD_DEF_SEARCH");
                    this.OnDASHBOARD_DEF_SEARCHChanged();
                }
            }
        }

        [Column(Storage = "_LOAD_FINALIZED_EXAMS", DbType = "Bit")]
        public System.Nullable<bool> LOAD_FINALIZED_EXAMS
        {
            get
            {
                return this._LOAD_FINALIZED_EXAMS;
            }
            set
            {
                if ((this._LOAD_FINALIZED_EXAMS != value))
                {
                    this.OnLOAD_FINALIZED_EXAMSChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_FINALIZED_EXAMS = value;
                    this.SendPropertyChanged("LOAD_FINALIZED_EXAMS");
                    this.OnLOAD_FINALIZED_EXAMSChanged();
                }
            }
        }

        [Column(Storage = "_ALL_EXAM_VISIBLE", DbType = "Bit")]
        public System.Nullable<bool> ALL_EXAM_VISIBLE
        {
            get
            {
                return this._ALL_EXAM_VISIBLE;
            }
            set
            {
                if ((this._ALL_EXAM_VISIBLE != value))
                {
                    this.OnALL_EXAM_VISIBLEChanging(value);
                    this.SendPropertyChanging();
                    this._ALL_EXAM_VISIBLE = value;
                    this.SendPropertyChanged("ALL_EXAM_VISIBLE");
                    this.OnALL_EXAM_VISIBLEChanged();
                }
            }
        }

        [Column(Storage = "_LOAD_ALL_EXAM", DbType = "Bit")]
        public System.Nullable<bool> LOAD_ALL_EXAM
        {
            get
            {
                return this._LOAD_ALL_EXAM;
            }
            set
            {
                if ((this._LOAD_ALL_EXAM != value))
                {
                    this.OnLOAD_ALL_EXAMChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_ALL_EXAM = value;
                    this.SendPropertyChanged("LOAD_ALL_EXAM");
                    this.OnLOAD_ALL_EXAMChanged();
                }
            }
        }

        [Column(Storage = "_AUTO_START_ORDER_IMG", DbType = "Bit")]
        public System.Nullable<bool> AUTO_START_ORDER_IMG
        {
            get
            {
                return this._AUTO_START_ORDER_IMG;
            }
            set
            {
                if ((this._AUTO_START_ORDER_IMG != value))
                {
                    this.OnAUTO_START_ORDER_IMGChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_START_ORDER_IMG = value;
                    this.SendPropertyChanged("AUTO_START_ORDER_IMG");
                    this.OnAUTO_START_ORDER_IMGChanged();
                }
            }
        }

        [Column(Storage = "_AUTO_START_PACS_IMG", DbType = "Bit")]
        public System.Nullable<bool> AUTO_START_PACS_IMG
        {
            get
            {
                return this._AUTO_START_PACS_IMG;
            }
            set
            {
                if ((this._AUTO_START_PACS_IMG != value))
                {
                    this.OnAUTO_START_PACS_IMGChanging(value);
                    this.SendPropertyChanging();
                    this._AUTO_START_PACS_IMG = value;
                    this.SendPropertyChanged("AUTO_START_PACS_IMG");
                    this.OnAUTO_START_PACS_IMGChanged();
                }
            }
        }

        [Column(Storage = "_DEF_DATE_RANGE", DbType = "NVarChar(2)")]
        public string DEF_DATE_RANGE
        {
            get
            {
                return this._DEF_DATE_RANGE;
            }
            set
            {
                if ((this._DEF_DATE_RANGE != value))
                {
                    this.OnDEF_DATE_RANGEChanging(value);
                    this.SendPropertyChanging();
                    this._DEF_DATE_RANGE = value;
                    this.SendPropertyChanged("DEF_DATE_RANGE");
                    this.OnDEF_DATE_RANGEChanged();
                }
            }
        }

        [Column(Storage = "_REMEMBER_GRID_ORDER", DbType = "Bit")]
        public System.Nullable<bool> REMEMBER_GRID_ORDER
        {
            get
            {
                return this._REMEMBER_GRID_ORDER;
            }
            set
            {
                if ((this._REMEMBER_GRID_ORDER != value))
                {
                    this.OnREMEMBER_GRID_ORDERChanging(value);
                    this.SendPropertyChanging();
                    this._REMEMBER_GRID_ORDER = value;
                    this.SendPropertyChanged("REMEMBER_GRID_ORDER");
                    this.OnREMEMBER_GRID_ORDERChanged();
                }
            }
        }

        [Column(Storage = "_GRID_DBL_CLICK_TO", DbType = "NVarChar(1)")]
        public System.Nullable<char> GRID_DBL_CLICK_TO
        {
            get
            {
                return this._GRID_DBL_CLICK_TO;
            }
            set
            {
                if ((this._GRID_DBL_CLICK_TO != value))
                {
                    this.OnGRID_DBL_CLICK_TOChanging(value);
                    this.SendPropertyChanging();
                    this._GRID_DBL_CLICK_TO = value;
                    this.SendPropertyChanged("GRID_DBL_CLICK_TO");
                    this.OnGRID_DBL_CLICK_TOChanged();
                }
            }
        }

        [Column(Storage = "_FINISH_WRITING_REFER_TO", DbType = "NVarChar(1)")]
        public System.Nullable<char> FINISH_WRITING_REFER_TO
        {
            get
            {
                return this._FINISH_WRITING_REFER_TO;
            }
            set
            {
                if ((this._FINISH_WRITING_REFER_TO != value))
                {
                    this.OnFINISH_WRITING_REFER_TOChanging(value);
                    this.SendPropertyChanging();
                    this._FINISH_WRITING_REFER_TO = value;
                    this.SendPropertyChanged("FINISH_WRITING_REFER_TO");
                    this.OnFINISH_WRITING_REFER_TOChanged();
                }
            }
        }

        [Column(Storage = "_ALLOW_OTHERSTO_FINALIZE", DbType = "Bit")]
        public System.Nullable<bool> ALLOW_OTHERSTO_FINALIZE
        {
            get
            {
                return this._ALLOW_OTHERSTO_FINALIZE;
            }
            set
            {
                if ((this._ALLOW_OTHERSTO_FINALIZE != value))
                {
                    this.OnALLOW_OTHERSTO_FINALIZEChanging(value);
                    this.SendPropertyChanging();
                    this._ALLOW_OTHERSTO_FINALIZE = value;
                    this.SendPropertyChanged("ALLOW_OTHERSTO_FINALIZE");
                    this.OnALLOW_OTHERSTO_FINALIZEChanged();
                }
            }
        }

        [Column(Storage = "_FONT_FACE", DbType = "NVarChar(50)")]
        public string FONT_FACE
        {
            get
            {
                return this._FONT_FACE;
            }
            set
            {
                if ((this._FONT_FACE != value))
                {
                    this.OnFONT_FACEChanging(value);
                    this.SendPropertyChanging();
                    this._FONT_FACE = value;
                    this.SendPropertyChanged("FONT_FACE");
                    this.OnFONT_FACEChanged();
                }
            }
        }

        [Column(Storage = "_FONT_SIZE", DbType = "TinyInt")]
        public System.Nullable<byte> FONT_SIZE
        {
            get
            {
                return this._FONT_SIZE;
            }
            set
            {
                if ((this._FONT_SIZE != value))
                {
                    this.OnFONT_SIZEChanging(value);
                    this.SendPropertyChanging();
                    this._FONT_SIZE = value;
                    this.SendPropertyChanged("FONT_SIZE");
                    this.OnFONT_SIZEChanged();
                }
            }
        }

        [Column(Storage = "_SIGNATURE_TEXT", DbType = "NVarChar(MAX)")]
        public string SIGNATURE_TEXT
        {
            get
            {
                return this._SIGNATURE_TEXT;
            }
            set
            {
                if ((this._SIGNATURE_TEXT != value))
                {
                    this.OnSIGNATURE_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._SIGNATURE_TEXT = value;
                    this.SendPropertyChanged("SIGNATURE_TEXT");
                    this.OnSIGNATURE_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_SIGNATURE_RTF", DbType = "NVarChar(MAX)")]
        public string SIGNATURE_RTF
        {
            get
            {
                return this._SIGNATURE_RTF;
            }
            set
            {
                if ((this._SIGNATURE_RTF != value))
                {
                    this.OnSIGNATURE_RTFChanging(value);
                    this.SendPropertyChanging();
                    this._SIGNATURE_RTF = value;
                    this.SendPropertyChanged("SIGNATURE_RTF");
                    this.OnSIGNATURE_RTFChanged();
                }
            }
        }

        [Column(Storage = "_SIGNATURE_HTML", DbType = "NVarChar(MAX)")]
        public string SIGNATURE_HTML
        {
            get
            {
                return this._SIGNATURE_HTML;
            }
            set
            {
                if ((this._SIGNATURE_HTML != value))
                {
                    this.OnSIGNATURE_HTMLChanging(value);
                    this.SendPropertyChanging();
                    this._SIGNATURE_HTML = value;
                    this.SendPropertyChanged("SIGNATURE_HTML");
                    this.OnSIGNATURE_HTMLChanged();
                }
            }
        }

        [Column(Storage = "_SIGNATURE_SCAN", DbType = "Image", UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary SIGNATURE_SCAN
        {
            get
            {
                return this._SIGNATURE_SCAN;
            }
            set
            {
                if ((this._SIGNATURE_SCAN != value))
                {
                    this.OnSIGNATURE_SCANChanging(value);
                    this.SendPropertyChanging();
                    this._SIGNATURE_SCAN = value;
                    this.SendPropertyChanged("SIGNATURE_SCAN");
                    this.OnSIGNATURE_SCANChanged();
                }
            }
        }
        public Byte[] Picture_Forsave { get; set; }

        [Column(Storage = "_USED_SIGNATURE", DbType = "NVarChar(1)")]
        public System.Nullable<char> USED_SIGNATURE
        {
            get
            {
                return this._USED_SIGNATURE;
            }
            set
            {
                if ((this._USED_SIGNATURE != value))
                {
                    this.OnUSED_SIGNATUREChanging(value);
                    this.SendPropertyChanging();
                    this._USED_SIGNATURE = value;
                    this.SendPropertyChanged("USED_SIGNATURE");
                    this.OnUSED_SIGNATUREChanged();
                }
            }
        }

        [Column(Storage = "_WHEN_GROUP_SIGN_USE", DbType = "NVarChar(1)")]
        public System.Nullable<char> WHEN_GROUP_SIGN_USE
        {
            get
            {
                return this._WHEN_GROUP_SIGN_USE;
            }
            set
            {
                if ((this._WHEN_GROUP_SIGN_USE != value))
                {
                    this.OnWHEN_GROUP_SIGN_USEChanging(value);
                    this.SendPropertyChanging();
                    this._WHEN_GROUP_SIGN_USE = value;
                    this.SendPropertyChanged("WHEN_GROUP_SIGN_USE");
                    this.OnWHEN_GROUP_SIGN_USEChanged();
                }
            }
        }

        [Column(Storage = "_MINIMIZE_CHARACTER", DbType = "Int")]
        public System.Nullable<int> MINIMIZE_CHARACTER
        {
            get
            {
                return this._MINIMIZE_CHARACTER;
            }
            set
            {
                if ((this._MINIMIZE_CHARACTER != value))
                {
                    this.OnMINIMIZE_CHARACTERChanging(value);
                    this.SendPropertyChanging();
                    this._MINIMIZE_CHARACTER = value;
                    this.SendPropertyChanged("MINIMIZE_CHARACTER");
                    this.OnMINIMIZE_CHARACTERChanged();
                }
            }
        }

        [Column(Storage = "_WORKLIST_GRID_ORDER", DbType = "NVarChar(MAX)")]
        public string WORKLIST_GRID_ORDER
        {
            get
            {
                return this._WORKLIST_GRID_ORDER;
            }
            set
            {
                if ((this._WORKLIST_GRID_ORDER != value))
                {
                    this.OnWORKLIST_GRID_ORDERChanging(value);
                    this.SendPropertyChanging();
                    this._WORKLIST_GRID_ORDER = value;
                    this.SendPropertyChanged("WORKLIST_GRID_ORDER");
                    this.OnWORKLIST_GRID_ORDERChanged();
                }
            }
        }

        [Column(Storage = "_HISTORY_GRID_ORDER", DbType = "NVarChar(MAX)")]
        public string HISTORY_GRID_ORDER
        {
            get
            {
                return this._HISTORY_GRID_ORDER;
            }
            set
            {
                if ((this._HISTORY_GRID_ORDER != value))
                {
                    this.OnHISTORY_GRID_ORDERChanging(value);
                    this.SendPropertyChanging();
                    this._HISTORY_GRID_ORDER = value;
                    this.SendPropertyChanged("HISTORY_GRID_ORDER");
                    this.OnHISTORY_GRID_ORDERChanged();
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


        [Column(Storage = "_USED_MENUBAR", DbType = "NVarChar(1)")]
        public System.Nullable<char> USED_MENUBAR
        {
            get
            {
                return this._USED_MENUBAR;
            }
            set
            {
                if ((this._USED_MENUBAR != value))
                {
                    this.OnUSED_MENUBARChanging(value);
                    this.SendPropertyChanging();
                    this._USED_MENUBAR = value;
                    this.SendPropertyChanged("USED_MENUBAR");
                    this.OnUSED_MENUBARChanged();
                }
            }
        }

        [Column(Storage = "_USED_120DPI", DbType = "NVarChar(1)")]
        public System.Nullable<char> USED_120DPI
        {
            get
            {
                return this._USED_120DPI;
            }
            set
            {
                if ((this._USED_120DPI != value))
                {
                    this.OnUSED_120DPIChanging(value);
                    this.SendPropertyChanging();
                    this._USED_120DPI = value;
                    this.SendPropertyChanged("USED_120DPI");
                    this.OnUSED_120DPIChanged();
                }
            }
        }
        [Column(Storage = "_RECONFIRM_PASS_ON_SAVE", DbType = "NVarChar(1)")]
        public System.Nullable<char> RECONFIRM_PASS_ON_SAVE
        {
            get
            {
                return this._RECONFIRM_PASS_ON_SAVE;
            }
            set
            {
                if ((this._RECONFIRM_PASS_ON_SAVE != value))
                {
                    this.OnRECONFIRM_PASS_ON_SAVEChanging(value);
                    this.SendPropertyChanging();
                    this._RECONFIRM_PASS_ON_SAVE = value;
                    this.SendPropertyChanged("RECONFIRM_PASS_ON_SAVE");
                    this.OnRECONFIRM_PASS_ON_SAVEChanged();
                }
            }
        }


        [Association(Name = "HR_EMP_GBL_RADEXPERIENCE", Storage = "_HR_EMP", ThisKey = "RADIOLOGIST_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
        public HR_EMP HR_EMP
        {
            get
            {
                return this._HR_EMP.Entity;
            }
            set
            {
                HR_EMP previousValue = this._HR_EMP.Entity;
                if (((previousValue != value)
                            || (this._HR_EMP.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_EMP.Entity = null;
                        previousValue.GBL_RADEXPERIENCE = null;
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.GBL_RADEXPERIENCE = this;
                        this._RADIOLOGIST_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._RADIOLOGIST_ID = default(int);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        public string IS_ADDENDUM { get; set; }
        public int ZOOM_SETTING { get; set; }
        public string AUTO_EXAMNAME { get; set; }
        public string AUTO_CLINICALINDICATION { get; set; }
        public string OPEN_PACS_WHEN_MERGE { get; set; }
        public int MAXIMUM_SHORTPRELIM_CHARECTORS { get; set; }

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
