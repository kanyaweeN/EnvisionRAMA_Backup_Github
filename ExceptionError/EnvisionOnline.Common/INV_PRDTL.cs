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
    [Table(Name = "dbo.INV_PRDTL")]
    public partial class INV_PRDTL : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _PR_ID;

        private int _ITEM_ID;

        private System.Nullable<decimal> _QTY;

        private System.Nullable<int> _ORG_ID;

        private System.Nullable<int> _CREATED_BY;

        private System.Nullable<System.DateTime> _CREATED_ON;

        private System.Nullable<int> _LAST_MODIFIED_BY;

        private System.Nullable<System.DateTime> _LAST_MODIFIED_ON;

        private EntityRef<INV_PRDTL> _INV_PRDTL2;

        private EntityRef<INV_PR> _INV_PR;

        private EntityRef<INV_PRDTL> _INV_PRDTL1;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnPR_IDChanging(int value);
        partial void OnPR_IDChanged();
        partial void OnITEM_IDChanging(int value);
        partial void OnITEM_IDChanged();
        partial void OnQTYChanging(System.Nullable<decimal> value);
        partial void OnQTYChanged();
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

        public INV_PRDTL()
        {
            this._INV_PRDTL2 = default(EntityRef<INV_PRDTL>);
            this._INV_PR = default(EntityRef<INV_PR>);
            this._INV_PRDTL1 = default(EntityRef<INV_PRDTL>);
            OnCreated();
        }

        [Column(Storage = "_PR_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int PR_ID
        {
            get
            {
                return this._PR_ID;
            }
            set
            {
                if ((this._PR_ID != value))
                {
                    if (this._INV_PR.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPR_IDChanging(value);
                    this.SendPropertyChanging();
                    this._PR_ID = value;
                    this.SendPropertyChanged("PR_ID");
                    this.OnPR_IDChanged();
                }
            }
        }

        [Column(Storage = "_ITEM_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int ITEM_ID
        {
            get
            {
                return this._ITEM_ID;
            }
            set
            {
                if ((this._ITEM_ID != value))
                {
                    if (this._INV_PRDTL1.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnITEM_IDChanging(value);
                    this.SendPropertyChanging();
                    this._ITEM_ID = value;
                    this.SendPropertyChanged("ITEM_ID");
                    this.OnITEM_IDChanged();
                }
            }
        }

        [Column(Storage = "_QTY", DbType = "Decimal(9,2)")]
        public System.Nullable<decimal> QTY
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

        [Association(Name = "INV_PRDTL_INV_PRDTL", Storage = "_INV_PRDTL2", ThisKey = "PR_ID,ITEM_ID", OtherKey = "PR_ID,ITEM_ID", IsUnique = true, IsForeignKey = false)]
        public INV_PRDTL INV_PRDTL2
        {
            get
            {
                return this._INV_PRDTL2.Entity;
            }
            set
            {
                INV_PRDTL previousValue = this._INV_PRDTL2.Entity;
                if (((previousValue != value)
                            || (this._INV_PRDTL2.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_PRDTL2.Entity = null;
                        previousValue.INV_PRDTL1 = null;
                    }
                    this._INV_PRDTL2.Entity = value;
                    if ((value != null))
                    {
                        value.INV_PRDTL1 = this;
                    }
                    this.SendPropertyChanged("INV_PRDTL2");
                }
            }
        }

        [Association(Name = "INV_PR_INV_PRDTL", Storage = "_INV_PR", ThisKey = "PR_ID", OtherKey = "PR_ID", IsForeignKey = true)]
        public INV_PR INV_PR
        {
            get
            {
                return this._INV_PR.Entity;
            }
            set
            {
                INV_PR previousValue = this._INV_PR.Entity;
                if (((previousValue != value)
                            || (this._INV_PR.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_PR.Entity = null;
                        previousValue.INV_PRDTLs.Remove(this);
                    }
                    this._INV_PR.Entity = value;
                    if ((value != null))
                    {
                        value.INV_PRDTLs.Add(this);
                        this._PR_ID = value.PR_ID;
                    }
                    else
                    {
                        this._PR_ID = default(int);
                    }
                    this.SendPropertyChanged("INV_PR");
                }
            }
        }

        [Association(Name = "INV_PRDTL_INV_PRDTL", Storage = "_INV_PRDTL1", ThisKey = "PR_ID,ITEM_ID", OtherKey = "PR_ID,ITEM_ID", IsForeignKey = true)]
        public INV_PRDTL INV_PRDTL1
        {
            get
            {
                return this._INV_PRDTL1.Entity;
            }
            set
            {
                INV_PRDTL previousValue = this._INV_PRDTL1.Entity;
                if (((previousValue != value)
                            || (this._INV_PRDTL1.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._INV_PRDTL1.Entity = null;
                        previousValue.INV_PRDTL2 = null;
                    }
                    this._INV_PRDTL1.Entity = value;
                    if ((value != null))
                    {
                        value.INV_PRDTL2 = this;
                        this._PR_ID = value.PR_ID;
                        this._ITEM_ID = value.ITEM_ID;
                    }
                    else
                    {
                        this._PR_ID = default(int);
                        this._ITEM_ID = default(int);
                    }
                    this.SendPropertyChanged("INV_PRDTL1");
                }
            }
        }
        public string REMARK { get; set; }

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
