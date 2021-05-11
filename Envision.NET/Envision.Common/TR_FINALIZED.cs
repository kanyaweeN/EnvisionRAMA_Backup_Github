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
    [Table(Name = "dbo.TR_FINALIZED")]
    public partial class TR_FINALIZED
    {

        private string _ACCESSION_NO;

        private string _TEST_NO;

        private string _REPORT_DONE;

        private string _REPORTED_BY;

        private System.Nullable<System.DateTime> _REPORT_TIMESTAMP;

        private string _ORDER_NO;

        private string _RADIOLOGICAL_FINDING;

        private string _REG_NO;

        public TR_FINALIZED()
        {
        }

        [Column(Storage = "_ACCESSION_NO", DbType = "NVarChar(30)")]
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
                    this._ACCESSION_NO = value;
                }
            }
        }

        [Column(Storage = "_TEST_NO", DbType = "NVarChar(30)")]
        public string TEST_NO
        {
            get
            {
                return this._TEST_NO;
            }
            set
            {
                if ((this._TEST_NO != value))
                {
                    this._TEST_NO = value;
                }
            }
        }

        [Column(Storage = "_REPORT_DONE", DbType = "NVarChar(255)")]
        public string REPORT_DONE
        {
            get
            {
                return this._REPORT_DONE;
            }
            set
            {
                if ((this._REPORT_DONE != value))
                {
                    this._REPORT_DONE = value;
                }
            }
        }

        [Column(Storage = "_REPORTED_BY", DbType = "NVarChar(255)")]
        public string REPORTED_BY
        {
            get
            {
                return this._REPORTED_BY;
            }
            set
            {
                if ((this._REPORTED_BY != value))
                {
                    this._REPORTED_BY = value;
                }
            }
        }

        [Column(Storage = "_REPORT_TIMESTAMP", DbType = "DateTime")]
        public System.Nullable<System.DateTime> REPORT_TIMESTAMP
        {
            get
            {
                return this._REPORT_TIMESTAMP;
            }
            set
            {
                if ((this._REPORT_TIMESTAMP != value))
                {
                    this._REPORT_TIMESTAMP = value;
                }
            }
        }

        [Column(Storage = "_ORDER_NO", DbType = "NVarChar(255)")]
        public string ORDER_NO
        {
            get
            {
                return this._ORDER_NO;
            }
            set
            {
                if ((this._ORDER_NO != value))
                {
                    this._ORDER_NO = value;
                }
            }
        }

        [Column(Storage = "_RADIOLOGICAL_FINDING", DbType = "NVarChar(MAX)")]
        public string RADIOLOGICAL_FINDING
        {
            get
            {
                return this._RADIOLOGICAL_FINDING;
            }
            set
            {
                if ((this._RADIOLOGICAL_FINDING != value))
                {
                    this._RADIOLOGICAL_FINDING = value;
                }
            }
        }

        [Column(Storage = "_REG_NO", DbType = "NVarChar(255)")]
        public string REG_NO
        {
            get
            {
                return this._REG_NO;
            }
            set
            {
                if ((this._REG_NO != value))
                {
                    this._REG_NO = value;
                }
            }
        }
    }
}
