namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_BILLINGLOG
    {
        [Key]
        public int BILLING_LOG_ID { get; set; }

        public string BILLING_MSG { get; set; }

        [StringLength(100)]
        public string BILLING_ACK_MSG { get; set; }

        [StringLength(20)]
        public string BILLING_TYPE { get; set; }

        [StringLength(30)]
        public string RQID { get; set; }

        [StringLength(30)]
        public string HN { get; set; }

        [Required]
        [StringLength(50)]
        public string ACCESSION_NO { get; set; }

        [StringLength(50)]
        public string AN { get; set; }

        [StringLength(50)]
        public string ISEQ { get; set; }

        [StringLength(50)]
        public string Dept_Code { get; set; }

        [StringLength(50)]
        public string Date { get; set; }

        [StringLength(50)]
        public string Sem { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Exam_code { get; set; }

        [StringLength(50)]
        public string Qty { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [StringLength(50)]
        public string Amt { get; set; }

        [StringLength(50)]
        public string Ord_by { get; set; }

        [StringLength(50)]
        public string OPID1 { get; set; }

        [StringLength(50)]
        public string OPID2 { get; set; }

        [StringLength(50)]
        public string OPID3 { get; set; }

        [StringLength(50)]
        public string OPID4 { get; set; }

        [StringLength(50)]
        public string Ord_Date { get; set; }

        [StringLength(50)]
        public string Ord_Time { get; set; }

        [StringLength(50)]
        public string MSType { get; set; }

        [StringLength(50)]
        public string SacType { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [StringLength(50)]
        public string Policy_id { get; set; }

        [StringLength(50)]
        public string Sv_DeptCode { get; set; }

        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string RegisterBy { get; set; }

        [StringLength(50)]
        public string PriceType { get; set; }

        [StringLength(50)]
        public string Enc_type { get; set; }
    }
}
