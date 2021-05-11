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
    [Table(Name = "dbo.RIS_LOADMEDIADTL")]
    public partial class RIS_LOADMEDIADTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _LOAD_ID;

        private int _EXAM_ID;

        private string _ACCESSION_NO;

        private System.Nullable<System.DateTime> _EXAM_DT;

        private byte _QTY;

        private string _HL7_TEXT;

        private System.Nullable<char> _HL7_SENT;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<RIS_EXAM> _RIS_EXAM;

        private EntityRef<RIS_LOADMEDIA> _RIS_LOADMEDIA;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnLOAD_IDChanging(int value);
        partial void OnLOAD_IDChanged();
        partial void OnEXAM_IDChanging(int value);
        partial void OnEXAM_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnEXAM_DTChanging(System.Nullable<System.DateTime> value);
        partial void OnEXAM_DTChanged();
        partial void OnQTYChanging(byte value);
        partial void OnQTYChanged();
        partial void OnHL7_TEXTChanging(string value);
        partial void OnHL7_TEXTChanged();
        partial void OnHL7_SENTChanging(System.Nullable<char> value);
        partial void OnHL7_SENTChanged();
        partial void OnCREATED_BYChanging(System.Nullable<int> value);
        partial void OnCREATED_BYChanged();
        partial void OnCREATED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnCREATED_ONChanged();
        partial void OnLAST_MODIFIED_BYChanging(System.Nullable<int> value);
        partial void OnLAST_MODIFIED_BYChanged();
        partial void OnLAST_MODIFIED_ONChanging(System.Nullable<System.DateTime> value);
        partial void OnLAST_MODIFIED_ONChanged();
        #endregion

        public RIS_LOADMEDIADTL()
        {
            this._RIS_EXAM = default(EntityRef<RIS_EXAM>);
            this._RIS_LOADMEDIA = default(EntityRef<RIS_LOADMEDIA>);
            OnCreated();
        }

        [Column(Storage = "_LOAD_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int LOAD_ID
        {
            get
            {
                return this._LOAD_ID;
            }
            set
            {
                if ((this._LOAD_ID != value))
                {
                    if (this._RIS_LOADMEDIA.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnLOAD_IDChanging(value);
                    this.SendPropertyChanging();
                    this._LOAD_ID = value;
                    this.SendPropertyChanged("LOAD_ID");
                    this.OnLOAD_IDChanged();
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

        [Association(Name = "RIS_EXAM_RIS_LOADMEDIADTL", Storage = "_RIS_EXAM", ThisKey = "EXAM_ID", OtherKey = "EXAM_ID", IsForeignKey = true)]
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
                        previousValue.RIS_LOADMEDIADTLs.Remove(this);
                    }
                    this._RIS_EXAM.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_LOADMEDIADTLs.Add(this);
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

        [Association(Name = "RIS_LOADMEDIA_RIS_LOADMEDIADTL", Storage = "_RIS_LOADMEDIA", ThisKey = "LOAD_ID", OtherKey = "LOAD_ID", IsForeignKey = true)]
        public RIS_LOADMEDIA RIS_LOADMEDIA
        {
            get
            {
                return this._RIS_LOADMEDIA.Entity;
            }
            set
            {
                RIS_LOADMEDIA previousValue = this._RIS_LOADMEDIA.Entity;
                if (((previousValue != value)
                            || (this._RIS_LOADMEDIA.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_LOADMEDIA.Entity = null;
                        previousValue.RIS_LOADMEDIADTLs.Remove(this);
                    }
                    this._RIS_LOADMEDIA.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_LOADMEDIADTLs.Add(this);
                        this._LOAD_ID = value.LOAD_ID;
                    }
                    else
                    {
                        this._LOAD_ID = default(int);
                    }
                    this.SendPropertyChanged("RIS_LOADMEDIA");
                }
            }
        }
        public int SELECTCASE { get; set; }

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
