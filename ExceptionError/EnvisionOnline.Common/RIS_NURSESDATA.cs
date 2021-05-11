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
    [Table(Name = "dbo.RIS_NURSESDATA")]
    public partial class RIS_NURSESDATA : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _NURSE_DATA_UK_ID;

        private int _NURSE_ID;

        private string _ACCESSION_NO;

        private System.DateTime _INPUT_DT;

        private System.Nullable<int> _ANESTHESIA_TECHNIQUE;

        private System.Nullable<char> _PAST_ILL_DM;

        private System.Nullable<char> _PAST_ILL_HT;

        private System.Nullable<char> _PAST_ILL_HD;

        private System.Nullable<char> _PAST_ILL_ASTHMA;

        private System.Nullable<char> _PAST_ILL_OTHERS;

        private string _PROCEDURE;

        private string _DIAGNOSIS;

        private string _OTHER_DESCRIPTION;

        private System.Nullable<int> _ASSISTANT_ID;

        private System.Nullable<int> _OPERATOR_ID;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntitySet<RIS_NURSESDATADTL> _RIS_NURSESDATADTLs;

        private EntityRef<HR_EMP> _HR_EMP;

        private EntityRef<RIS_ORDERDTL> _RIS_ORDERDTL;


        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnNURSE_DATA_UK_IDChanging(int value);
        partial void OnNURSE_DATA_UK_IDChanged();
        partial void OnNURSE_IDChanging(int value);
        partial void OnNURSE_IDChanged();
        partial void OnACCESSION_NOChanging(string value);
        partial void OnACCESSION_NOChanged();
        partial void OnINPUT_DTChanging(System.DateTime value);
        partial void OnINPUT_DTChanged();
        partial void OnANESTHESIA_TECHNIQUEChanging(System.Nullable<int> value);
        partial void OnANESTHESIA_TECHNIQUEChanged();
        partial void OnPAST_ILL_DMChanging(System.Nullable<char> value);
        partial void OnPAST_ILL_DMChanged();
        partial void OnPAST_ILL_HTChanging(System.Nullable<char> value);
        partial void OnPAST_ILL_HTChanged();
        partial void OnPAST_ILL_HDChanging(System.Nullable<char> value);
        partial void OnPAST_ILL_HDChanged();
        partial void OnPAST_ILL_ASTHMAChanging(System.Nullable<char> value);
        partial void OnPAST_ILL_ASTHMAChanged();
        partial void OnPAST_ILL_OTHERSChanging(System.Nullable<char> value);
        partial void OnPAST_ILL_OTHERSChanged();
        partial void OnPROCEDUREChanging(string value);
        partial void OnPROCEDUREChanged();
        partial void OnDIAGNOSISChanging(string value);
        partial void OnDIAGNOSISChanged();
        partial void OnOTHER_DESCRIPTIONChanging(string value);
        partial void OnOTHER_DESCRIPTIONChanged();
        partial void OnASSISTANT_IDChanging(System.Nullable<int> value);
        partial void OnASSISTANT_IDChanged();
        partial void OnOPERATOR_IDChanging(System.Nullable<int> value);
        partial void OnOPERATOR_IDChanged();
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
        #endregion

        public RIS_NURSESDATA()
        {
            this._RIS_NURSESDATADTLs = new EntitySet<RIS_NURSESDATADTL>(new Action<RIS_NURSESDATADTL>(this.attach_RIS_NURSESDATADTLs), new Action<RIS_NURSESDATADTL>(this.detach_RIS_NURSESDATADTLs));
            this._HR_EMP = default(EntityRef<HR_EMP>);
            this._RIS_ORDERDTL = default(EntityRef<RIS_ORDERDTL>);
            OnCreated();
        }

        [Column(Storage = "_NURSE_DATA_UK_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int NURSE_DATA_UK_ID
        {
            get
            {
                return this._NURSE_DATA_UK_ID;
            }
            set
            {
                if ((this._NURSE_DATA_UK_ID != value))
                {
                    this.OnNURSE_DATA_UK_IDChanging(value);
                    this.SendPropertyChanging();
                    this._NURSE_DATA_UK_ID = value;
                    this.SendPropertyChanged("NURSE_DATA_UK_ID");
                    this.OnNURSE_DATA_UK_IDChanged();
                }
            }
        }

        [Column(Storage = "_NURSE_ID", DbType = "Int NOT NULL")]
        public int NURSE_ID
        {
            get
            {
                return this._NURSE_ID;
            }
            set
            {
                if ((this._NURSE_ID != value))
                {
                    if (this._HR_EMP.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnNURSE_IDChanging(value);
                    this.SendPropertyChanging();
                    this._NURSE_ID = value;
                    this.SendPropertyChanged("NURSE_ID");
                    this.OnNURSE_IDChanged();
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
                    if (this._RIS_ORDERDTL.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnACCESSION_NOChanging(value);
                    this.SendPropertyChanging();
                    this._ACCESSION_NO = value;
                    this.SendPropertyChanged("ACCESSION_NO");
                    this.OnACCESSION_NOChanged();
                }
            }
        }

        [Column(Storage = "_INPUT_DT", DbType = "DateTime NOT NULL")]
        public System.DateTime INPUT_DT
        {
            get
            {
                return this._INPUT_DT;
            }
            set
            {
                if ((this._INPUT_DT != value))
                {
                    this.OnINPUT_DTChanging(value);
                    this.SendPropertyChanging();
                    this._INPUT_DT = value;
                    this.SendPropertyChanged("INPUT_DT");
                    this.OnINPUT_DTChanged();
                }
            }
        }

        [Column(Storage = "_ANESTHESIA_TECHNIQUE", DbType = "Int")]
        public System.Nullable<int> ANESTHESIA_TECHNIQUE
        {
            get
            {
                return this._ANESTHESIA_TECHNIQUE;
            }
            set
            {
                if ((this._ANESTHESIA_TECHNIQUE != value))
                {
                    this.OnANESTHESIA_TECHNIQUEChanging(value);
                    this.SendPropertyChanging();
                    this._ANESTHESIA_TECHNIQUE = value;
                    this.SendPropertyChanged("ANESTHESIA_TECHNIQUE");
                    this.OnANESTHESIA_TECHNIQUEChanged();
                }
            }
        }

        [Column(Storage = "_PAST_ILL_DM", DbType = "NVarChar(1)")]
        public System.Nullable<char> PAST_ILL_DM
        {
            get
            {
                return this._PAST_ILL_DM;
            }
            set
            {
                if ((this._PAST_ILL_DM != value))
                {
                    this.OnPAST_ILL_DMChanging(value);
                    this.SendPropertyChanging();
                    this._PAST_ILL_DM = value;
                    this.SendPropertyChanged("PAST_ILL_DM");
                    this.OnPAST_ILL_DMChanged();
                }
            }
        }

        [Column(Storage = "_PAST_ILL_HT", DbType = "NVarChar(1)")]
        public System.Nullable<char> PAST_ILL_HT
        {
            get
            {
                return this._PAST_ILL_HT;
            }
            set
            {
                if ((this._PAST_ILL_HT != value))
                {
                    this.OnPAST_ILL_HTChanging(value);
                    this.SendPropertyChanging();
                    this._PAST_ILL_HT = value;
                    this.SendPropertyChanged("PAST_ILL_HT");
                    this.OnPAST_ILL_HTChanged();
                }
            }
        }

        [Column(Storage = "_PAST_ILL_HD", DbType = "NVarChar(1)")]
        public System.Nullable<char> PAST_ILL_HD
        {
            get
            {
                return this._PAST_ILL_HD;
            }
            set
            {
                if ((this._PAST_ILL_HD != value))
                {
                    this.OnPAST_ILL_HDChanging(value);
                    this.SendPropertyChanging();
                    this._PAST_ILL_HD = value;
                    this.SendPropertyChanged("PAST_ILL_HD");
                    this.OnPAST_ILL_HDChanged();
                }
            }
        }

        [Column(Storage = "_PAST_ILL_ASTHMA", DbType = "NVarChar(1)")]
        public System.Nullable<char> PAST_ILL_ASTHMA
        {
            get
            {
                return this._PAST_ILL_ASTHMA;
            }
            set
            {
                if ((this._PAST_ILL_ASTHMA != value))
                {
                    this.OnPAST_ILL_ASTHMAChanging(value);
                    this.SendPropertyChanging();
                    this._PAST_ILL_ASTHMA = value;
                    this.SendPropertyChanged("PAST_ILL_ASTHMA");
                    this.OnPAST_ILL_ASTHMAChanged();
                }
            }
        }

        [Column(Storage = "_PAST_ILL_OTHERS", DbType = "NVarChar(1)")]
        public System.Nullable<char> PAST_ILL_OTHERS
        {
            get
            {
                return this._PAST_ILL_OTHERS;
            }
            set
            {
                if ((this._PAST_ILL_OTHERS != value))
                {
                    this.OnPAST_ILL_OTHERSChanging(value);
                    this.SendPropertyChanging();
                    this._PAST_ILL_OTHERS = value;
                    this.SendPropertyChanged("PAST_ILL_OTHERS");
                    this.OnPAST_ILL_OTHERSChanged();
                }
            }
        }

        [Column(Name = "[PROCEDURE]", Storage = "_PROCEDURE", DbType = "NVarChar(400)")]
        public string PROCEDURE
        {
            get
            {
                return this._PROCEDURE;
            }
            set
            {
                if ((this._PROCEDURE != value))
                {
                    this.OnPROCEDUREChanging(value);
                    this.SendPropertyChanging();
                    this._PROCEDURE = value;
                    this.SendPropertyChanged("PROCEDURE");
                    this.OnPROCEDUREChanged();
                }
            }
        }

        [Column(Storage = "_DIAGNOSIS", DbType = "NVarChar(400)")]
        public string DIAGNOSIS
        {
            get
            {
                return this._DIAGNOSIS;
            }
            set
            {
                if ((this._DIAGNOSIS != value))
                {
                    this.OnDIAGNOSISChanging(value);
                    this.SendPropertyChanging();
                    this._DIAGNOSIS = value;
                    this.SendPropertyChanged("DIAGNOSIS");
                    this.OnDIAGNOSISChanged();
                }
            }
        }

        [Column(Storage = "_OTHER_DESCRIPTION", DbType = "NVarChar(500)")]
        public string OTHER_DESCRIPTION
        {
            get
            {
                return this._OTHER_DESCRIPTION;
            }
            set
            {
                if ((this._OTHER_DESCRIPTION != value))
                {
                    this.OnOTHER_DESCRIPTIONChanging(value);
                    this.SendPropertyChanging();
                    this._OTHER_DESCRIPTION = value;
                    this.SendPropertyChanged("OTHER_DESCRIPTION");
                    this.OnOTHER_DESCRIPTIONChanged();
                }
            }
        }

        [Column(Storage = "_ASSISTANT_ID", DbType = "Int")]
        public System.Nullable<int> ASSISTANT_ID
        {
            get
            {
                return this._ASSISTANT_ID;
            }
            set
            {
                if ((this._ASSISTANT_ID != value))
                {
                    this.OnASSISTANT_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ASSISTANT_ID = value;
                    this.SendPropertyChanged("ASSISTANT_ID");
                    this.OnASSISTANT_IDChanged();
                }
            }
        }

        [Column(Storage = "_OPERATOR_ID", DbType = "Int")]
        public System.Nullable<int> OPERATOR_ID
        {
            get
            {
                return this._OPERATOR_ID;
            }
            set
            {
                if ((this._OPERATOR_ID != value))
                {
                    this.OnOPERATOR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._OPERATOR_ID = value;
                    this.SendPropertyChanged("OPERATOR_ID");
                    this.OnOPERATOR_IDChanged();
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

        [Association(Name = "RIS_NURSESDATA_RIS_NURSESDATADTL", Storage = "_RIS_NURSESDATADTLs", ThisKey = "NURSE_DATA_UK_ID", OtherKey = "NURSE_DATA_UK_ID")]
        public EntitySet<RIS_NURSESDATADTL> RIS_NURSESDATADTLs
        {
            get
            {
                return this._RIS_NURSESDATADTLs;
            }
            set
            {
                this._RIS_NURSESDATADTLs.Assign(value);
            }
        }

        [Association(Name = "HR_EMP_RIS_NURSESDATA", Storage = "_HR_EMP", ThisKey = "NURSE_ID", OtherKey = "EMP_ID", IsForeignKey = true)]
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
                        previousValue.RIS_NURSESDATAs.Remove(this);
                    }
                    this._HR_EMP.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_NURSESDATAs.Add(this);
                        this._NURSE_ID = value.EMP_ID;
                    }
                    else
                    {
                        this._NURSE_ID = default(int);
                    }
                    this.SendPropertyChanged("HR_EMP");
                }
            }
        }

        [Association(Name = "RIS_ORDERDTL_RIS_NURSESDATA", Storage = "_RIS_ORDERDTL", ThisKey = "ACCESSION_NO", OtherKey = "ACCESSION_NO", IsForeignKey = true)]
        public RIS_ORDERDTL RIS_ORDERDTL
        {
            get
            {
                return this._RIS_ORDERDTL.Entity;
            }
            set
            {
                RIS_ORDERDTL previousValue = this._RIS_ORDERDTL.Entity;
                if (((previousValue != value)
                            || (this._RIS_ORDERDTL.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RIS_ORDERDTL.Entity = null;
                        previousValue.RIS_NURSESDATAs.Remove(this);
                    }
                    this._RIS_ORDERDTL.Entity = value;
                    if ((value != null))
                    {
                        value.RIS_NURSESDATAs.Add(this);
                        this._ACCESSION_NO = value.ACCESSION_NO;
                    }
                    else
                    {
                        this._ACCESSION_NO = default(string);
                    }
                    this.SendPropertyChanged("RIS_ORDERDTL");
                }
            }
        }
        public int SELECTCASE { get; set; }

        public string ACCESSIONPARAMETER { get; set; }

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

        private void attach_RIS_NURSESDATADTLs(RIS_NURSESDATADTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_NURSESDATA = this;
        }

        private void detach_RIS_NURSESDATADTLs(RIS_NURSESDATADTL entity)
        {
            this.SendPropertyChanging();
            entity.RIS_NURSESDATA = null;
        }

        private string hn;
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
    }
}
