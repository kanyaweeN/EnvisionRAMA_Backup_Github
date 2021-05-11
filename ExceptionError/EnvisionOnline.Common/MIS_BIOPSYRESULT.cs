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
    [Table(Name = "dbo.MIS_BIOPSYRESULT")]
    public partial class MIS_BIOPSYRESULT : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ACCESSION_NO;

        private System.Nullable<System.DateTime> _RESULT_DT;

        private System.Nullable<int> _RADIOLOGIST_ID;

        private string _LOC_NO_R;

        private string _LOC_NO_L;

        private System.Nullable<char> _TISSUE_TYPE;

        private System.Nullable<char> _DEPTH_TYPE_R;

        private System.Nullable<char> _DEPTH_TYPE_L;

        private string _WIDTH;

        private string _LENGTH;

        private string _DEPTH;

        private System.Nullable<char> _PROCEDURE_TYPE;

        private System.Nullable<byte> _NO_OF_CORE;

        private System.Nullable<byte> _CALCIUM_PCS;

        private System.Nullable<char> _IS_SATISFACTORY;

        private System.Nullable<char> _IS_SURGERY;

        private string _COMMENTS;

        private System.Nullable<char> _IS_PALPABLE;

        private System.Nullable<int> _LESION_TYPE_ID;

        private System.Nullable<int> _ASESSMENT_TYPE_ID;

        private System.Nullable<int> _TECHNIQUE_TYPE_ID;

        private string _LAB_DATA;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private byte _BIOPSY_RESULT_ID;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<MIS_ASESSMENTTYPE> _MIS_ASESSMENTTYPE;

        private EntityRef<MIS_LESIONTYPE> _MIS_LESIONTYPE;

        private EntityRef<MIS_TECHNIQUETYPE> _MIS_TECHNIQUETYPE;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnRESULT_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnRESULT_DTChanged();
        partial void OnRADIOLOGIST_IDChanging(System.Nullable<int> value);
        partial void OnRADIOLOGIST_IDChanged();
        partial void OnLOC_NO_RChanging(string value);
        partial void OnLOC_NO_RChanged();
        partial void OnLOC_NO_LChanging(string value);
        partial void OnLOC_NO_LChanged();
        partial void OnTISSUE_TYPEChanging(System.Nullable<char> value);
        partial void OnTISSUE_TYPEChanged();
        partial void OnDEPTH_TYPE_RChanging(System.Nullable<char> value);
        partial void OnDEPTH_TYPE_RChanged();
        partial void OnDEPTH_TYPE_LChanging(System.Nullable<char> value);
        partial void OnDEPTH_TYPE_LChanged();
        partial void OnWIDTHChanging(string value);
        partial void OnWIDTHChanged();
        partial void OnLENGTHChanging(string value);
        partial void OnLENGTHChanged();
        partial void OnDEPTHChanging(string value);
        partial void OnDEPTHChanged();
        partial void OnPROCEDURE_TYPEChanging(System.Nullable<char> value);
        partial void OnPROCEDURE_TYPEChanged();
        partial void OnNO_OF_COREChanging(System.Nullable<byte> value);
        partial void OnNO_OF_COREChanged();
        partial void OnCALCIUM_PCSChanging(System.Nullable<byte> value);
        partial void OnCALCIUM_PCSChanged();
        partial void OnIS_SATISFACTORYChanging(System.Nullable<char> value);
        partial void OnIS_SATISFACTORYChanged();
        partial void OnIS_SURGERYChanging(System.Nullable<char> value);
        partial void OnIS_SURGERYChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnIS_PALPABLEChanging(System.Nullable<char> value);
        partial void OnIS_PALPABLEChanged();
        partial void OnLESION_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnLESION_TYPE_IDChanged();
        partial void OnASESSMENT_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnASESSMENT_TYPE_IDChanged();
        partial void OnTECHNIQUE_TYPE_IDChanging(System.Nullable<int> value);
        partial void OnTECHNIQUE_TYPE_IDChanged();
        partial void OnLAB_DATAChanging(string value);
        partial void OnLAB_DATAChanged();
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
        partial void OnBIOPSY_RESULT_IDChanging(byte value);
        partial void OnBIOPSY_RESULT_IDChanged();
        #endregion

        public MIS_BIOPSYRESULT()
        {
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._MIS_ASESSMENTTYPE = default(EntityRef<MIS_ASESSMENTTYPE>);
            this._MIS_LESIONTYPE = default(EntityRef<MIS_LESIONTYPE>);
            this._MIS_TECHNIQUETYPE = default(EntityRef<MIS_TECHNIQUETYPE>);
            OnCreated();
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false, IsPrimaryKey = true)]
        public string ACCESSION_NO
        {
            get
            {
                return this._ACCESSION_NO;
            }
            set
            {
                if ((this._ACCESSION_NO != value))
                {
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_RESULT_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RESULT_DT
        {
            get
            {
                return this._RESULT_DT;
            }
            set
            {
                if ((this._RESULT_DT != value))
                {
                    this.OnRESULT_DTChanging(value);
                    this.SendPropertyChanging();
                    this._RESULT_DT = value;
                    this.SendPropertyChanged("RESULT_DT");
                    this.OnRESULT_DTChanged();
                }
            }
        }

        [Column(Storage = "_RADIOLOGIST_ID", DbType = "Int")]
        public System.Nullable<int> RADIOLOGIST_ID
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

        [Column(Storage = "_LOC_NO_R", DbType = "NVarChar(3)")]
        public string LOC_NO_R
        {
            get
            {
                return this._LOC_NO_R;
            }
            set
            {
                if ((this._LOC_NO_R != value))
                {
                    this.OnLOC_NO_RChanging(value);
                    this.SendPropertyChanging();
                    this._LOC_NO_R = value;
                    this.SendPropertyChanged("LOC_NO_R");
                    this.OnLOC_NO_RChanged();
                }
            }
        }

        [Column(Storage = "_LOC_NO_L", DbType = "NVarChar(3)")]
        public string LOC_NO_L
        {
            get
            {
                return this._LOC_NO_L;
            }
            set
            {
                if ((this._LOC_NO_L != value))
                {
                    this.OnLOC_NO_LChanging(value);
                    this.SendPropertyChanging();
                    this._LOC_NO_L = value;
                    this.SendPropertyChanged("LOC_NO_L");
                    this.OnLOC_NO_LChanged();
                }
            }
        }

        [Column(Storage = "_TISSUE_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> TISSUE_TYPE
        {
            get
            {
                return this._TISSUE_TYPE;
            }
            set
            {
                if ((this._TISSUE_TYPE != value))
                {
                    this.OnTISSUE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._TISSUE_TYPE = value;
                    this.SendPropertyChanged("TISSUE_TYPE");
                    this.OnTISSUE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_DEPTH_TYPE_R", DbType = "NVarChar(1)")]
        public System.Nullable<char> DEPTH_TYPE_R
        {
            get
            {
                return this._DEPTH_TYPE_R;
            }
            set
            {
                if ((this._DEPTH_TYPE_R != value))
                {
                    this.OnDEPTH_TYPE_RChanging(value);
                    this.SendPropertyChanging();
                    this._DEPTH_TYPE_R = value;
                    this.SendPropertyChanged("DEPTH_TYPE_R");
                    this.OnDEPTH_TYPE_RChanged();
                }
            }
        }

        [Column(Storage = "_DEPTH_TYPE_L", DbType = "NVarChar(1)")]
        public System.Nullable<char> DEPTH_TYPE_L
        {
            get
            {
                return this._DEPTH_TYPE_L;
            }
            set
            {
                if ((this._DEPTH_TYPE_L != value))
                {
                    this.OnDEPTH_TYPE_LChanging(value);
                    this.SendPropertyChanging();
                    this._DEPTH_TYPE_L = value;
                    this.SendPropertyChanged("DEPTH_TYPE_L");
                    this.OnDEPTH_TYPE_LChanged();
                }
            }
        }

        [Column(Storage = "_WIDTH", DbType = "NVarChar(20)")]
        public string WIDTH
        {
            get
            {
                return this._WIDTH;
            }
            set
            {
                if ((this._WIDTH != value))
                {
                    this.OnWIDTHChanging(value);
                    this.SendPropertyChanging();
                    this._WIDTH = value;
                    this.SendPropertyChanged("WIDTH");
                    this.OnWIDTHChanged();
                }
            }
        }

        [Column(Storage = "_LENGTH", DbType = "NVarChar(20)")]
        public string LENGTH
        {
            get
            {
                return this._LENGTH;
            }
            set
            {
                if ((this._LENGTH != value))
                {
                    this.OnLENGTHChanging(value);
                    this.SendPropertyChanging();
                    this._LENGTH = value;
                    this.SendPropertyChanged("LENGTH");
                    this.OnLENGTHChanged();
                }
            }
        }

        [Column(Storage = "_DEPTH", DbType = "NVarChar(20)")]
        public string DEPTH
        {
            get
            {
                return this._DEPTH;
            }
            set
            {
                if ((this._DEPTH != value))
                {
                    this.OnDEPTHChanging(value);
                    this.SendPropertyChanging();
                    this._DEPTH = value;
                    this.SendPropertyChanged("DEPTH");
                    this.OnDEPTHChanged();
                }
            }
        }

        [Column(Storage = "_PROCEDURE_TYPE", DbType = "NVarChar(1)")]
        public System.Nullable<char> PROCEDURE_TYPE
        {
            get
            {
                return this._PROCEDURE_TYPE;
            }
            set
            {
                if ((this._PROCEDURE_TYPE != value))
                {
                    this.OnPROCEDURE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._PROCEDURE_TYPE = value;
                    this.SendPropertyChanged("PROCEDURE_TYPE");
                    this.OnPROCEDURE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_NO_OF_CORE", DbType = "TinyInt")]
        public System.Nullable<byte> NO_OF_CORE
        {
            get
            {
                return this._NO_OF_CORE;
            }
            set
            {
                if ((this._NO_OF_CORE != value))
                {
                    this.OnNO_OF_COREChanging(value);
                    this.SendPropertyChanging();
                    this._NO_OF_CORE = value;
                    this.SendPropertyChanged("NO_OF_CORE");
                    this.OnNO_OF_COREChanged();
                }
            }
        }

        [Column(Storage = "_CALCIUM_PCS", DbType = "TinyInt")]
        public System.Nullable<byte> CALCIUM_PCS
        {
            get
            {
                return this._CALCIUM_PCS;
            }
            set
            {
                if ((this._CALCIUM_PCS != value))
                {
                    this.OnCALCIUM_PCSChanging(value);
                    this.SendPropertyChanging();
                    this._CALCIUM_PCS = value;
                    this.SendPropertyChanged("CALCIUM_PCS");
                    this.OnCALCIUM_PCSChanged();
                }
            }
        }

        [Column(Storage = "_IS_SATISFACTORY", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_SATISFACTORY
        {
            get
            {
                return this._IS_SATISFACTORY;
            }
            set
            {
                if ((this._IS_SATISFACTORY != value))
                {
                    this.OnIS_SATISFACTORYChanging(value);
                    this.SendPropertyChanging();
                    this._IS_SATISFACTORY = value;
                    this.SendPropertyChanged("IS_SATISFACTORY");
                    this.OnIS_SATISFACTORYChanged();
                }
            }
        }

        [Column(Storage = "_IS_SURGERY", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_SURGERY
        {
            get
            {
                return this._IS_SURGERY;
            }
            set
            {
                if ((this._IS_SURGERY != value))
                {
                    this.OnIS_SURGERYChanging(value);
                    this.SendPropertyChanging();
                    this._IS_SURGERY = value;
                    this.SendPropertyChanged("IS_SURGERY");
                    this.OnIS_SURGERYChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(300)")]
        public string COMMENTS
        {
            get
            {
                return this._COMMENTS;
            }
            set
            {
                if ((this._COMMENTS != value))
                {
                    this.OnCOMMENTSChanging(value);
                    this.SendPropertyChanging();
                    this._COMMENTS = value;
                    this.SendPropertyChanged("COMMENTS");
                    this.OnCOMMENTSChanged();
                }
            }
        }

        [Column(Storage = "_IS_PALPABLE", DbType = "NVarChar(1)")]
        public System.Nullable<char> IS_PALPABLE
        {
            get
            {
                return this._IS_PALPABLE;
            }
            set
            {
                if ((this._IS_PALPABLE != value))
                {
                    this.OnIS_PALPABLEChanging(value);
                    this.SendPropertyChanging();
                    this._IS_PALPABLE = value;
                    this.SendPropertyChanged("IS_PALPABLE");
                    this.OnIS_PALPABLEChanged();
                }
            }
        }

        [Column(Storage = "_LESION_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> LESION_TYPE_ID
        {
            get
            {
                return this._LESION_TYPE_ID;
            }
            set
            {
                if ((this._LESION_TYPE_ID != value))
                {
                    if (this._MIS_LESIONTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnLESION_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LESION_TYPE_ID = value;
                    this.SendPropertyChanged("LESION_TYPE_ID");
                    this.OnLESION_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_ASESSMENT_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> ASESSMENT_TYPE_ID
        {
            get
            {
                return this._ASESSMENT_TYPE_ID;
            }
            set
            {
                if ((this._ASESSMENT_TYPE_ID != value))
                {
                    if (this._MIS_ASESSMENTTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnASESSMENT_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ASESSMENT_TYPE_ID = value;
                    this.SendPropertyChanged("ASESSMENT_TYPE_ID");
                    this.OnASESSMENT_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_TECHNIQUE_TYPE_ID", DbType = "Int")]
        public System.Nullable<int> TECHNIQUE_TYPE_ID
        {
            get
            {
                return this._TECHNIQUE_TYPE_ID;
            }
            set
            {
                if ((this._TECHNIQUE_TYPE_ID != value))
                {
                    if (this._MIS_TECHNIQUETYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTECHNIQUE_TYPE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._TECHNIQUE_TYPE_ID = value;
                    this.SendPropertyChanged("TECHNIQUE_TYPE_ID");
                    this.OnTECHNIQUE_TYPE_IDChanged();
                }
            }
        }

        [Column(Storage = "_LAB_DATA", DbType = "NVarChar(500)")]
        public string LAB_DATA
        {
            get
            {
                return this._LAB_DATA;
            }
            set
            {
                if ((this._LAB_DATA != value))
                {
                    this.OnLAB_DATAChanging(value);
                    this.SendPropertyChanging();
                    this._LAB_DATA = value;
                    this.SendPropertyChanged("LAB_DATA");
                    this.OnLAB_DATAChanged();
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
                    if (this._GBL_ENV.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
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

        [Column(Storage = "_BIOPSY_RESULT_ID", DbType = "TinyInt NOT NULL", IsPrimaryKey = true)]
        public byte BIOPSY_RESULT_ID
        {
            get
            {
                return this._BIOPSY_RESULT_ID;
            }
            set
            {
                if ((this._BIOPSY_RESULT_ID != value))
                {
                    this.OnBIOPSY_RESULT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._BIOPSY_RESULT_ID = value;
                    this.SendPropertyChanged("BIOPSY_RESULT_ID");
                    this.OnBIOPSY_RESULT_IDChanged();
                }
            }
        }

        [Association(Name = "GBL_ENV_MIS_BIOPSYRESULT", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
        public GBL_ENV GBL_ENV
        {
            get
            {
                return this._GBL_ENV.Entity;
            }
            set
            {
                GBL_ENV previousValue = this._GBL_ENV.Entity;
                if (((previousValue != value)
                            || (this._GBL_ENV.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._GBL_ENV.Entity = null;
                        previousValue.MIS_BIOPSYRESULTs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_BIOPSYRESULTs.Add(this);
                        this._ORG_ID = value.ORG_ID;
                    }
                    else
                    {
                        this._ORG_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("GBL_ENV");
                }
            }
        }

        [Association(Name = "HR_EMP_MIS_BIOPSYRESULT", Storage = "_HR_EMP", ThisKey = "RADIOLOGIST_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.MIS_BIOPSYRESULTs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_BIOPSYRESULTs.Add(this);
                        this._RADIOLOGIST_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._RADIOLOGIST_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "MIS_ASESSMENTTYPE_MIS_BIOPSYRESULT", Storage = "_MIS_ASESSMENTTYPE", ThisKey = "ASESSMENT_TYPE_ID", OtherKey = "ASESSMENT_TYPE_ID", IsForeignKey = true)]
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE
        {
            get
            {
                return this._MIS_ASESSMENTTYPE.Entity;
            }
            set
            {
                MIS_ASESSMENTTYPE previousValue = this._MIS_ASESSMENTTYPE.Entity;
                if (((previousValue != value)
                            || (this._MIS_ASESSMENTTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._MIS_ASESSMENTTYPE.Entity = null;
                        previousValue.MIS_BIOPSYRESULTs.Remove(this);
                    }
                    this._MIS_ASESSMENTTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_BIOPSYRESULTs.Add(this);
                        this._ASESSMENT_TYPE_ID = value.ASESSMENT_TYPE_ID;
                    }
                    else
                    {
                        this._ASESSMENT_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("MIS_ASESSMENTTYPE");
                }
            }
        }

        [Association(Name = "MIS_LESIONTYPE_MIS_BIOPSYRESULT", Storage = "_MIS_LESIONTYPE", ThisKey = "LESION_TYPE_ID", OtherKey = "LESION_TYPE_ID", IsForeignKey = true)]
        public MIS_LESIONTYPE MIS_LESIONTYPE
        {
            get
            {
                return this._MIS_LESIONTYPE.Entity;
            }
            set
            {
                MIS_LESIONTYPE previousValue = this._MIS_LESIONTYPE.Entity;
                if (((previousValue != value)
                            || (this._MIS_LESIONTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._MIS_LESIONTYPE.Entity = null;
                        previousValue.MIS_BIOPSYRESULTs.Remove(this);
                    }
                    this._MIS_LESIONTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_BIOPSYRESULTs.Add(this);
                        this._LESION_TYPE_ID = value.LESION_TYPE_ID;
                    }
                    else
                    {
                        this._LESION_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("MIS_LESIONTYPE");
                }
            }
        }

        [Association(Name = "MIS_TECHNIQUETYPE_MIS_BIOPSYRESULT", Storage = "_MIS_TECHNIQUETYPE", ThisKey = "TECHNIQUE_TYPE_ID", OtherKey = "TECHNIQUE_TYPE_ID", IsForeignKey = true)]
        public MIS_TECHNIQUETYPE MIS_TECHNIQUETYPE
        {
            get
            {
                return this._MIS_TECHNIQUETYPE.Entity;
            }
            set
            {
                MIS_TECHNIQUETYPE previousValue = this._MIS_TECHNIQUETYPE.Entity;
                if (((previousValue != value)
                            || (this._MIS_TECHNIQUETYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._MIS_TECHNIQUETYPE.Entity = null;
                        previousValue.MIS_BIOPSYRESULTs.Remove(this);
                    }
                    this._MIS_TECHNIQUETYPE.Entity = value;
                    if ((value != null))
                    {
                        value.MIS_BIOPSYRESULTs.Add(this);
                        this._TECHNIQUE_TYPE_ID = value.TECHNIQUE_TYPE_ID;
                    }
                    else
                    {
                        this._TECHNIQUE_TYPE_ID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("MIS_TECHNIQUETYPE");
                }
            }
        }

        public string STATUS { get; set; }
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
