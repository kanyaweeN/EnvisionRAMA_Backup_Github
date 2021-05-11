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
    [Table(Name = "dbo.RIS_SCHEDULEDTL")]
    public partial class RIS_SCHEDULEDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _SCHEDULE_ID;

        private int _EXAM_ID;

        private int _QTY;

        private decimal _RATE;

        private System.Nullable<int> _GEN_DTL_ID;

        private System.Nullable<int> _RAD_ID;

        private System.Nullable<int> _PREPARATION_ID;

        private System.Nullable<int> _BPVIEW_ID;

        private System.Nullable<int> _AVG_REQ_MIN;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;
        private EntityRef<RIS_PATIENTPREPARATION> _RIS_PATIENTPREPARATION;
        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnSCHEDULE_IDChanging(int value);
        partial void OnSCHEDULE_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnMODALITY_IDChanging(int value);
        partial void OnMODALITY_IDChanged();
        partial void OnAPPOINT_DTChanging(System.DateTime value);
        partial void OnAPPOINT_DTChanged();
        partial void OnQTYChanging(byte value);
        partial void OnQTYChanged();
        partial void OnCOMMENTSChanging(string value);
        partial void OnCOMMENTSChanged();
        partial void OnSPECIAL_CLINICChanging(System.Nullable<char> value);
        partial void OnSPECIAL_CLINICChanged();
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
        partial void OnQTYChanging(int value);
        partial void OnRATEChanging(decimal value);
        partial void OnRATEChanged();
        partial void OnRAD_IDChanging(System.Nullable<int> value);
        partial void OnRAD_IDChanged();
        partial void OnGEN_DTL_IDChanging(System.Nullable<int> value);
        partial void OnGEN_DTL_IDChanged();
        partial void OnPREPARATION_IDChanging(System.Nullable<int> value);
        partial void OnPREPARATION_IDChanged();
        partial void OnBPVIEW_IDChanging(System.Nullable<int> value);
        partial void OnBPVIEW_IDChanged();
        partial void OnAVG_REQ_MINChanging(System.Nullable<int> value);
        partial void OnAVG_REQ_MINChanged();
        #endregion

        public RIS_SCHEDULEDTL()
        {
            OnCreated();
        }

        [Column(Storage = "_SCHEDULE_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int SCHEDULE_ID
        {
            get
            {
                return this._SCHEDULE_ID;
            }
            set
            {
                if ((this._SCHEDULE_ID != value))
                {
                    this.OnSCHEDULE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._SCHEDULE_ID = value;
                    this.SendPropertyChanged("SCHEDULE_ID");
                    this.OnSCHEDULE_IDChanged();
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
                    this.OnEXAM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._EXAM_ID = value;
                    this.SendPropertyChanged("EXAM_ID");
                    this.OnEXAM_IDChanged();
                }
            }
        }

        [Column(Storage = "_QTY", DbType = "Int NOT NULL")]
        public int QTY
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

        [Column(Storage = "_RATE", DbType = "Decimal(7,2) NOT NULL")]
        public decimal RATE
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

        [Column(Storage = "_GEN_DTL_ID", DbType = "Int")]
        public System.Nullable<int> GEN_DTL_ID
        {
            get
            {
                return this._GEN_DTL_ID;
            }
            set
            {
                if ((this._GEN_DTL_ID != value))
                {
                    this.OnGEN_DTL_IDChanging(value);
                    this.SendPropertyChanging();
                    this._GEN_DTL_ID = value;
                    this.SendPropertyChanged("GEN_DTL_ID");
                    this.OnGEN_DTL_IDChanged();
                }
            }
        }

        [Column(Storage = "_RAD_ID", DbType = "Int")]
        public System.Nullable<int> RAD_ID
        {
            get
            {
                return this._RAD_ID;
            }
            set
            {
                if ((this._RAD_ID != value))
                {
                    this.OnRAD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._RAD_ID = value;
                    this.SendPropertyChanged("RAD_ID");
                    this.OnRAD_IDChanged();
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
                    if (this._RIS_PATIENTPREPARATION.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPREPARATION_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PREPARATION_ID = value;
                    this.SendPropertyChanged("PREPARATION_ID");
                    this.OnPREPARATION_IDChanged();
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

        [Column(Storage = "_AVG_REQ_MIN", DbType = "Int")]
        public System.Nullable<int> AVG_REQ_MIN
        {
            get
            {
                return this._AVG_REQ_MIN;
            }
            set
            {
                if ((this._AVG_REQ_MIN != value))
                {
                    this.OnAVG_REQ_MINChanging(value);
                    this.SendPropertyChanging();
                    this._AVG_REQ_MIN = value;
                    this.SendPropertyChanged("AVG_REQ_MIN");
                    this.OnAVG_REQ_MINChanged();
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


        public int PAT_STATUS { get; set; }

        public int SELECTCASE { get; set; }

        public int MODALITY_ID { get; set; }

        public string REASON { get; set; }

        public int OLD_EXAM_ID { get; set; }

        public int PAT_DEST_ID { get; set; }

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
