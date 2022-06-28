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
    [Table(Name = "dbo.RIS_ORDERDTL")]
    public partial class RIS_ORDERDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ORDER_ID;

        private int _EXAM_ID;

        private string _ACCESSION_NO;

        private System.Nullable<byte> _Q_NO;

        private int _MODALITY_ID;

        private System.Nullable<System.DateTime> _EXAM_DT;

        private System.Nullable<int> _SERVICE_TYPE;

        private byte _QTY;

        private System.Nullable<System.DateTime> _EST_START_TIME;

        private System.Nullable<int> _ASSIGNED_TO;

        private string _HL7_TEXT;

        private System.Nullable<char> _HL7_SENT;

        private System.Nullable<decimal> _RATE;

        private string _COMMENTS;

        private System.Nullable<char> _SPECIAL_CLINIC;

        private System.Nullable<char> _SELF_ARRIVAL;

        private System.Nullable<int> _IMAGE_CAPTURED_BY;

        private System.Nullable<System.DateTime> _IMAGE_CAPTURED_ON;

        private System.Nullable<int> _QA_BY;

        private System.Nullable<System.DateTime> _QA_ON;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<char> _PRIORITY;

        private System.Nullable<char> _STATUS;

        private System.Nullable<char> _IS_DELETED;

        private System.Nullable<int> _ASSIGNED_BY;

        private System.Nullable<System.DateTime> _ASSIGNED_TIMESTAMP;

        private System.Nullable<int> _CLINIC_TYPE;

        private System.Nullable<int> _BPVIEW_ID;

        private string _MERGE;

        private string _MERGE_WITH;

        private System.Nullable<char> _HIS_SYNC;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private string _HIS_ACK;

        private System.Nullable<int> _PREPARATION_ID;

        private EntitySet<RIS_EXAMTRANSFERLOG> _RIS_EXAMTRANSFERLOGs;

        private EntitySet<RIS_NURSESDATA> _RIS_NURSESDATAs;

        private EntitySet<RIS_RADSTUDYGROUP> _RIS_RADSTUDYGROUPs;

        private EntitySet<RIS_TECHCONSUMPTION> _RIS_TECHCONSUMPTIONs;

        private EntityRef<RIS_CLINICTYPE> _RIS_CLINICTYPE;

        private EntityRef<GBL_ENV> _GBL_ENV;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_MODALITY> _RIS_MODALITY;

        private EntityRef<RIS_ORDER> _RIS_ORDER;

        public int PAT_DEST_ID { get; set; }

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnORDER_IDChanging(int value);
        partial void OnORDER_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnQ_NOChanging(System.Nullable<byte> value);
        partial void OnQ_NOChanged();
        partial void OnMODALITY_IDChanging(int value);
        partial void OnMODALITY_IDChanged();
        partial void OnEXAM_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnEXAM_DTChanged();
        partial void OnSERVICE_TYPEChanging(System.Nullable<int> value);
        partial void OnSERVICE_TYPEChanged();
        partial void OnQTYChanging(byte value);
        partial void OnQTYChanged();
        partial void OnEST_START_TIMEChanging(System.Nullable<System.DateTime> value);
        partial void OnEST_START_TIMEChanged();
        partial void OnASSIGNED_TOChanging(System.Nullable<int> value);
        partial void OnASSIGNED_TOChanged();
        partial void OnHL7_TEXTChanging(string value);
        partial void OnHL7_TEXTChanged();
        partial void OnHL7_SENTChanging(System.Nullable<char> value);
        partial void OnHL7_SENTChanged();
        partial void OnRATEChanging(System.Nullable<decimal> value);
        partial void OnRATEChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnSPECIAL_CLINICChanging(System.Nullable<char> value);
        partial void OnSPECIAL_CLINICChanged();
        partial void OnSELF_ARRIVALChanging(System.Nullable<char> value);
        partial void OnSELF_ARRIVALChanged();
        partial void OnIMAGE_CAPTURED_BYChanging(System.Nullable<int> value);
        partial void OnIMAGE_CAPTURED_BYChanged();
        partial void OnIMAGE_CAPTURED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnIMAGE_CAPTURED_ONChanged();
        partial void OnQA_BYChanging(System.Nullable<int> value);
        partial void OnQA_BYChanged();
        partial void OnQA_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnQA_ONChanged();
        partial void OnORG_IDChanging(System.Nullable<int> value);
        partial void OnORG_IDChanged();
        partial void OnPRIORITYChanging(System.Nullable<char> value);
        partial void OnPRIORITYChanged();
        partial void OnSTATUSChanging(System.Nullable<char> value);
        partial void OnSTATUSChanged();
        partial void OnIS_DELETEDChanging(System.Nullable<char> value);
        partial void OnIS_DELETEDChanged();
        partial void OnASSIGNED_BYChanging(System.Nullable<int> value);
        partial void OnASSIGNED_BYChanged();
        partial void OnASSIGNED_TIMESTAMPChanging(System.Nullable<System.DateTime> value);
        partial void OnASSIGNED_TIMESTAMPChanged();
        partial void OnCLINIC_TYPEChanging(System.Nullable<int> value);
        partial void OnCLINIC_TYPEChanged();
        partial void OnBPVIEW_IDChanging(System.Nullable<int> value);
        partial void OnBPVIEW_IDChanged();
        partial void OnMERGEChanging(string value);
        partial void OnMERGEChanged();
        partial void OnMERGE_WITHChanging(string value);
        partial void OnMERGE_WITHChanged();
        partial void OnHIS_SYNCChanging(System.Nullable<char> value);
        partial void OnHIS_SYNCChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        partial void OnHIS_ACKChanging(string value);
        partial void OnHIS_ACKChanged();
        partial void OnPREPARATION_IDChanging(System.Nullable<int> value);
        partial void OnPREPARATION_IDChanged();
        #endregion

        public RIS_ORDERDTL()
        {
            this._RIS_EXAMTRANSFERLOGs = new EntitySet<RIS_EXAMTRANSFERLOG>(new Action<RIS_EXAMTRANSFERLOG>(this.attach_RIS_EXAMTRANSFERLOGs), new Action<RIS_EXAMTRANSFERLOG>(this.detach_RIS_EXAMTRANSFERLOGs));
            this._RIS_NURSESDATAs = new EntitySet<RIS_NURSESDATA>(new Action<RIS_NURSESDATA>(this.attach_RIS_NURSESDATAs), new Action<RIS_NURSESDATA>(this.detach_RIS_NURSESDATAs));
            this._RIS_RADSTUDYGROUPs = new EntitySet<RIS_RADSTUDYGROUP>(new Action<RIS_RADSTUDYGROUP>(this.attach_RIS_RADSTUDYGROUPs), new Action<RIS_RADSTUDYGROUP>(this.detach_RIS_RADSTUDYGROUPs));
            this._RIS_TECHCONSUMPTIONs = new EntitySet<RIS_TECHCONSUMPTION>(new Action<RIS_TECHCONSUMPTION>(this.attach_RIS_TECHCONSUMPTIONs), new Action<RIS_TECHCONSUMPTION>(this.detach_RIS_TECHCONSUMPTIONs));
            this._RIS_CLINICTYPE = default(EntityRef<RIS_CLINICTYPE>);
            this._GBL_ENV = default(EntityRef<GBL_ENV>);
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_MODALITY = default(EntityRef<RIS_MODALITY>);
            this._RIS_ORDER = default(EntityRef<RIS_ORDER>);
            OnCreated();
        }

        [Column(Storage = "_ORDER_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ORDER_ID
        {
            get
            {
                return this._ORDER_ID;
            }
            set
            {
                if ((this._ORDER_ID != value))
                {
                    if (this._RIS_ORDER.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnORDER_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ORDER_ID = value;
                    this.SendPropertyChanged("ORDER_ID");
                    this.OnORDER_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int EXAM_ID
        {
            get
            {
                return this._EXAM_ID;
            }
            set
            {
                if ((this._EXAM_ID != value))
                {
                    if (this._RIS_EXAM.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30) NOT NULL", CanBeNull = false)]
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

        [Column(Storage = "_Q_NO", DbType = "TinyInt")]
        public System.Nullable<byte> Q_NO
        {
            get
            {
                return this._Q_NO;
            }
            set
            {
                if ((this._Q_NO != value))
                {
                    this.OnQ_NOChanging(value);
                    this.SendPropertyChanging();
                    this._Q_NO = value;
                    this.SendPropertyChanged("Q_NO");
                    this.OnQ_NOChanged();
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
                    if (this._RIS_MODALITY.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMODALITY_IDChanging(value);
                    this.SendPropertyChanging();
                    this._MODALITY_ID = value;
                    this.SendPropertyChanged("MODALITY_ID");
                    this.OnMODALITY_IDChanged();
                }
            }
        }

        [Column(Storage = "_EXAM_DT", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EXAM_DT
        {
            get
            {
                return this._EXAM_DT;
            }
            set
            {
                if ((this._EXAM_DT != value))
                {
                    this.OnEXAM_DTChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_DT = value;
                    this.SendPropertyChanged("EXAM_DT");
                    this.OnEXAM_DTChanged();
                }
            }
        }

        [Column(Storage = "_SERVICE_TYPE", DbType = "Int")]
        public System.Nullable<int> SERVICE_TYPE
        {
            get
            {
                return this._SERVICE_TYPE;
            }
            set
            {
                if ((this._SERVICE_TYPE != value))
                {
                    this.OnSERVICE_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._SERVICE_TYPE = value;
                    this.SendPropertyChanged("SERVICE_TYPE");
                    this.OnSERVICE_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_QTY", DbType = "TinyInt NOT NULL")]
        public byte QTY
        {
            get
            {
                return this._QTY;
            }
            set
            {
                if ((this._QTY != value))
                {
                    this.OnQTYChanging(value);
                    this.SendPropertyChanging();
                    this._QTY = value;
                    this.SendPropertyChanged("QTY");
                    this.OnQTYChanged();
                }
            }
        }

        [Column(Storage = "_EST_START_TIME", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EST_START_TIME
        {
            get
            {
                return this._EST_START_TIME;
            }
            set
            {
                if ((this._EST_START_TIME != value))
                {
                    this.OnEST_START_TIMEChanging(value);
                    this.SendPropertyChanging();
                    this._EST_START_TIME = value;
                    this.SendPropertyChanged("EST_START_TIME");
                    this.OnEST_START_TIMEChanged();
                }
            }
        }

        [Column(Storage = "_ASSIGNED_TO", DbType = "Int")]
        public System.Nullable<int> ASSIGNED_TO
        {
            get
            {
                return this._ASSIGNED_TO;
            }
            set
            {
                if ((this._ASSIGNED_TO != value))
                {
                    this.OnASSIGNED_TOChanging(value);
                    this.SendPropertyChanging();
                    this._ASSIGNED_TO = value;
                    this.SendPropertyChanged("ASSIGNED_TO");
                    this.OnASSIGNED_TOChanged();
                }
            }
        }

        [Column(Storage = "_HL7_TEXT", DbType = "NVarChar(1000)")]
        public string HL7_TEXT
        {
            get
            {
                return this._HL7_TEXT;
            }
            set
            {
                if ((this._HL7_TEXT != value))
                {
                    this.OnHL7_TEXTChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_TEXT = value;
                    this.SendPropertyChanged("HL7_TEXT");
                    this.OnHL7_TEXTChanged();
                }
            }
        }

        [Column(Storage = "_HL7_SENT", DbType = "NVarChar(1)")]
        public System.Nullable<char> HL7_SENT
        {
            get
            {
                return this._HL7_SENT;
            }
            set
            {
                if ((this._HL7_SENT != value))
                {
                    this.OnHL7_SENTChanging(value);
                    this.SendPropertyChanging();
                    this._HL7_SENT = value;
                    this.SendPropertyChanged("HL7_SENT");
                    this.OnHL7_SENTChanged();
                }
            }
        }

        [Column(Storage = "_RATE", DbType = "Decimal(7,2)")]
        public System.Nullable<decimal> RATE
        {
            get
            {
                return this._RATE;
            }
            set
            {
                if ((this._RATE != value))
                {
                    this.OnRATEChanging(value);
                    this.SendPropertyChanging();
                    this._RATE = value;
                    this.SendPropertyChanged("RATE");
                    this.OnRATEChanged();
                }
            }
        }

        [Column(Storage = "_COMMENTS", DbType = "NVarChar(200)")]
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

        [Column(Storage = "_SPECIAL_CLINIC", DbType = "NVarChar(1)")]
        public System.Nullable<char> SPECIAL_CLINIC
        {
            get
            {
                return this._SPECIAL_CLINIC;
            }
            set
            {
                if ((this._SPECIAL_CLINIC != value))
                {
                    this.OnSPECIAL_CLINICChanging(value);
                    this.SendPropertyChanging();
                    this._SPECIAL_CLINIC = value;
                    this.SendPropertyChanged("SPECIAL_CLINIC");
                    this.OnSPECIAL_CLINICChanged();
                }
            }
        }

        [Column(Storage = "_SELF_ARRIVAL", DbType = "NVarChar(1)")]
        public System.Nullable<char> SELF_ARRIVAL
        {
            get
            {
                return this._SELF_ARRIVAL;
            }
            set
            {
                if ((this._SELF_ARRIVAL != value))
                {
                    this.OnSELF_ARRIVALChanging(value);
                    this.SendPropertyChanging();
                    this._SELF_ARRIVAL = value;
                    this.SendPropertyChanged("SELF_ARRIVAL");
                    this.OnSELF_ARRIVALChanged();
                }
            }
        }

        [Column(Storage = "_IMAGE_CAPTURED_BY", DbType = "Int")]
        public System.Nullable<int> IMAGE_CAPTURED_BY
        {
            get
            {
                return this._IMAGE_CAPTURED_BY;
            }
            set
            {
                if ((this._IMAGE_CAPTURED_BY != value))
                {
                    this.OnIMAGE_CAPTURED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._IMAGE_CAPTURED_BY = value;
                    this.SendPropertyChanged("IMAGE_CAPTURED_BY");
                    this.OnIMAGE_CAPTURED_BYChanged();
                }
            }
        }

        [Column(Storage = "_IMAGE_CAPTURED_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> IMAGE_CAPTURED_ON
        {
            get
            {
                return this._IMAGE_CAPTURED_ON;
            }
            set
            {
                if ((this._IMAGE_CAPTURED_ON != value))
                {
                    this.OnIMAGE_CAPTURED_ONChanging(value);
                    this.SendPropertyChanging();
                    this._IMAGE_CAPTURED_ON = value;
                    this.SendPropertyChanged("IMAGE_CAPTURED_ON");
                    this.OnIMAGE_CAPTURED_ONChanged();
                }
            }
        }

        [Column(Storage = "_QA_BY", DbType = "Int")]
        public System.Nullable<int> QA_BY
        {
            get
            {
                return this._QA_BY;
            }
            set
            {
                if ((this._QA_BY != value))
                {
                    this.OnQA_BYChanging(value);
                    this.SendPropertyChanging();
                    this._QA_BY = value;
                    this.SendPropertyChanged("QA_BY");
                    this.OnQA_BYChanged();
                }
            }
        }

        [Column(Storage = "_QA_ON", DbType = "DateTime")]
        public System.Nullable<System.DateTime> QA_ON
        {
            get
            {
                return this._QA_ON;
            }
            set
            {
                if ((this._QA_ON != value))
                {
                    this.OnQA_ONChanging(value);
                    this.SendPropertyChanging();
                    this._QA_ON = value;
                    this.SendPropertyChanged("QA_ON");
                    this.OnQA_ONChanged();
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

        [Column(Storage = "_PRIORITY", DbType = "NVarChar(1)")]
        public System.Nullable<char> PRIORITY
        {
            get
            {
                return this._PRIORITY;
            }
            set
            {
                if ((this._PRIORITY != value))
                {
                    this.OnPRIORITYChanging(value);
                    this.SendPropertyChanging();
                    this._PRIORITY = value;
                    this.SendPropertyChanged("PRIORITY");
                    this.OnPRIORITYChanged();
                }
            }
        }

        [Column(Storage = "_STATUS", DbType = "NVarChar(1)")]
        public System.Nullable<char> STATUS
        {
            get
            {
                return this._STATUS;
            }
            set
            {
                if ((this._STATUS != value))
                {
                    this.OnSTATUSChanging(value);
                    this.SendPropertyChanging();
                    this._STATUS = value;
                    this.SendPropertyChanged("STATUS");
                    this.OnSTATUSChanged();
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
                    this.OnIS_DELETEDChanging(value);
                    this.SendPropertyChanging();
                    this._IS_DELETED = value;
                    this.SendPropertyChanged("IS_DELETED");
                    this.OnIS_DELETEDChanged();
                }
            }
        }

        [Column(Storage = "_ASSIGNED_BY", DbType = "Int")]
        public System.Nullable<int> ASSIGNED_BY
        {
            get
            {
                return this._ASSIGNED_BY;
            }
            set
            {
                if ((this._ASSIGNED_BY != value))
                {
                    this.OnASSIGNED_BYChanging(value);
                    this.SendPropertyChanging();
                    this._ASSIGNED_BY = value;
                    this.SendPropertyChanged("ASSIGNED_BY");
                    this.OnASSIGNED_BYChanged();
                }
            }
        }

        [Column(Storage = "_ASSIGNED_TIMESTAMP", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ASSIGNED_TIMESTAMP
        {
            get
            {
                return this._ASSIGNED_TIMESTAMP;
            }
            set
            {
                if ((this._ASSIGNED_TIMESTAMP != value))
                {
                    this.OnASSIGNED_TIMESTAMPChanging(value);
                    this.SendPropertyChanging();
                    this._ASSIGNED_TIMESTAMP = value;
                    this.SendPropertyChanged("ASSIGNED_TIMESTAMP");
                    this.OnASSIGNED_TIMESTAMPChanged();
                }
            }
        }

        [Column(Storage = "_CLINIC_TYPE", DbType = "Int")]
        public System.Nullable<int> CLINIC_TYPE
        {
            get
            {
                return this._CLINIC_TYPE;
            }
            set
            {
                if ((this._CLINIC_TYPE != value))
                {
                    if (this._RIS_CLINICTYPE.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCLINIC_TYPEChanging(value);
                    this.SendPropertyChanging();
                    this._CLINIC_TYPE = value;
                    this.SendPropertyChanged("CLINIC_TYPE");
                    this.OnCLINIC_TYPEChanged();
                }
            }
        }

        [Column(Storage = "_BPVIEW_ID", DbType = "Int")]
        public System.Nullable<int> BPVIEW_ID
        {
            get
            {
                return this._BPVIEW_ID;
            }
            set
            {
                if ((this._BPVIEW_ID != value))
                {
                    this.OnBPVIEW_IDChanging(value);
                    this.SendPropertyChanging();
                    this._BPVIEW_ID = value;
                    this.SendPropertyChanged("BPVIEW_ID");
                    this.OnBPVIEW_IDChanged();
                }
            }
        }

        [Column(Storage = "_MERGE", DbType = "NVarChar(3)")]
        public string MERGE
        {
            get
            {
                return this._MERGE;
            }
            set
            {
                if ((this._MERGE != value))
                {
                    this.OnMERGEChanging(value);
                    this.SendPropertyChanging();
                    this._MERGE = value;
                    this.SendPropertyChanged("MERGE");
                    this.OnMERGEChanged();
                }
            }
        }

        [Column(Storage = "_MERGE_WITH", DbType = "NVarChar(30)")]
        public string MERGE_WITH
        {
            get
            {
                return this._MERGE_WITH;
            }
            set
            {
                if ((this._MERGE_WITH != value))
                {
                    this.OnMERGE_WITHChanging(value);
                    this.SendPropertyChanging();
                    this._MERGE_WITH = value;
                    this.SendPropertyChanged("MERGE_WITH");
                    this.OnMERGE_WITHChanged();
                }
            }
        }

        [Column(Storage = "_HIS_SYNC", DbType = "NVarChar(1)")]
        public System.Nullable<char> HIS_SYNC
        {
            get
            {
                return this._HIS_SYNC;
            }
            set
            {
                if ((this._HIS_SYNC != value))
                {
                    this.OnHIS_SYNCChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_SYNC = value;
                    this.SendPropertyChanged("HIS_SYNC");
                    this.OnHIS_SYNCChanged();
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

        [Column(Storage = "_HIS_ACK", DbType = "NVarChar(300)")]
        public string HIS_ACK
        {
            get
            {
                return this._HIS_ACK;
            }
            set
            {
                if ((this._HIS_ACK != value))
                {
                    this.OnHIS_ACKChanging(value);
                    this.SendPropertyChanging();
                    this._HIS_ACK = value;
                    this.SendPropertyChanged("HIS_ACK");
                    this.OnHIS_ACKChanged();
                }
            }
        }

        [Column(Storage = "_PREPARATION_ID", DbType = "Int")]
        public System.Nullable<int> PREPARATION_ID
        {
            get
            {
                return this._PREPARATION_ID;
            }
            set
            {
                if ((this._PREPARATION_ID != value))
                {
                    this.OnPREPARATION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_ID = value;
                    this.SendPropertyChanged("PREPARATION_ID");
                    this.OnPREPARATION_IDChanged();
                }
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_EXAMTRANSFERLOG", Storage = "_RIS_EXAMTRANSFERLOGs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_EXAMTRANSFERLOG> RIS_EXAMTRANSFERLOGs
        {
            get
            {
                return this._RIS_EXAMTRANSFERLOGs;
            }
            set
            {
                this._RIS_EXAMTRANSFERLOGs.Assign(value);
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_NURSESDATA", Storage = "_RIS_NURSESDATAs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_NURSESDATA> RIS_NURSESDATAs
        {
            get
            {
                return this._RIS_NURSESDATAs;
            }
            set
            {
                this._RIS_NURSESDATAs.Assign(value);
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_RADSTUDYGROUP", Storage = "_RIS_RADSTUDYGROUPs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_RADSTUDYGROUP> RIS_RADSTUDYGROUPs
        {
            get
            {
                return this._RIS_RADSTUDYGROUPs;
            }
            set
            {
                this._RIS_RADSTUDYGROUPs.Assign(value);
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_TECHCONSUMPTION", Storage = "_RIS_TECHCONSUMPTIONs", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO")]
        public EntitySet<RIS_TECHCONSUMPTION> RIS_TECHCONSUMPTIONs
        {
            get
            {
                return this._RIS_TECHCONSUMPTIONs;
            }
            set
            {
                this._RIS_TECHCONSUMPTIONs.Assign(value);
            }
        }

        [Association(Name = "RIS_CLINICTYPE_RIS_ORDERDTL", Storage = "_RIS_CLINICTYPE", ThisKey = "CLINIC_TYPE", OtherKey = "CLINIC_TYPE_ID", IsForeignKey = true)]
        public RIS_CLINICTYPE RIS_CLINICTYPE
        {
            get
            {
                return this._RIS_CLINICTYPE.Entity;
            }
            set
            {
                RIS_CLINICTYPE previousValue = this._RIS_CLINICTYPE.Entity;
                if (((previousValue != value)
                            || (this._RIS_CLINICTYPE.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_CLINICTYPE.Entity = null;
                        previousValue.RIS_ORDERDTLs.Remove(this);
                    }
                    this._RIS_CLINICTYPE.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERDTLs.Add(this);
                        this._CLINIC_TYPE = value.CLINIC_TYPE_ID;
                    }
                    else
                    {
                        this._CLINIC_TYPE = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RIS_CLINICTYPE");
                }
            }
        }

        [Association(Name = "GBL_ENV_RIS_ORDERDTL", Storage = "_GBL_ENV", ThisKey = "ORG_ID", OtherKey = "ORG_ID", IsForeignKey = true)]
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
                        previousValue.RIS_ORDERDTLs.Remove(this);
                    }
                    this._GBL_ENV.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERDTLs.Add(this);
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

        [Association(Name = "RIS_EXAM_RIS_ORDERDTL", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
        public RIS_EXAM RIS_EXAM
        {
            get
            {
                return this._RIS_EXAM.Entity;
            }
            set
            {
                RIS_EXAM previousValue = this._RIS_EXAM.Entity;
                if (((previousValue != value)
                            || (this._RIS_EXAM.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_EXAM.Entity = null;
                        previousValue.RIS_ORDERDTLs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERDTLs.Add(this);
                        this._EXAM_ID = value.EXAM_ID;
                    }
                    else
                    {
                        this._EXAM_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_EXAM");
                }
            }
        }

        [Association(Name = "RIS_MODALITY_RIS_ORDERDTL", Storage = "_RIS_MODALITY", ThisKey = "MODALITY_ID", OtherKey = "MODALITY_ID", IsForeignKey = true)]
        public RIS_MODALITY RIS_MODALITY
        {
            get
            {
                return this._RIS_MODALITY.Entity;
            }
            set
            {
                RIS_MODALITY previousValue = this._RIS_MODALITY.Entity;
                if (((previousValue != value)
                            || (this._RIS_MODALITY.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_MODALITY.Entity = null;
                        previousValue.RIS_ORDERDTLs.Remove(this);
                    }
                    this._RIS_MODALITY.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERDTLs.Add(this);
                        this._MODALITY_ID = value.MODALITY_ID;
                    }
                    else
                    {
                        this._MODALITY_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_MODALITY");
                }
            }
        }

        [Association(Name = "RIS_ORDER_RIS_ORDERDTL", Storage = "_RIS_ORDER", ThisKey = "ORDER_ID", OtherKey = "ORDER_ID", IsForeignKey = true)]
        public RIS_ORDER RIS_ORDER
        {
            get
            {
                return this._RIS_ORDER.Entity;
            }
            set
            {
                RIS_ORDER previousValue = this._RIS_ORDER.Entity;
                if (((previousValue != value)
                            || (this._RIS_ORDER.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_ORDER.Entity = null;
                        previousValue.RIS_ORDERDTLs.Remove(this);
                    }
                    this._RIS_ORDER.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_ORDERDTLs.Add(this);
                        this._ORDER_ID = value.ORDER_ID;
                    }
                    else
                    {
                        this._ORDER_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_ORDER");
                }
            }
        }

        public int OLD_EXAM_ID { get; set; }
        public int BV_VIEW { get; set; }
        public int PREPARATION { get; set; }
        public string COMMENTS_ONLINE { get; set; } 

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

        private void attach_RIS_EXAMTRANSFERLOGs(RIS_EXAMTRANSFERLOG entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = this;
        }

        private void detach_RIS_EXAMTRANSFERLOGs(RIS_EXAMTRANSFERLOG entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = null;
        }

        private void attach_RIS_NURSESDATAs(RIS_NURSESDATA entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = this;
        }

        private void detach_RIS_NURSESDATAs(RIS_NURSESDATA entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = null;
        }

        private void attach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = this;
        }

        private void detach_RIS_RADSTUDYGROUPs(RIS_RADSTUDYGROUP entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = null;
        }

        private void attach_RIS_TECHCONSUMPTIONs(RIS_TECHCONSUMPTION entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = this;
        }

        private void detach_RIS_TECHCONSUMPTIONs(RIS_TECHCONSUMPTION entity)
        {
            this.SendPropertyChanging();
            entity.RIS_ORDERDTL = null;
        }
    }
}
