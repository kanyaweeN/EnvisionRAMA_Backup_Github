namespace Envision.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RIS_INTEGRATIONSERVERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SERVER_ID { get; set; }

        [StringLength(50)]
        public string SERVER_UID { get; set; }

        [StringLength(1)]
        public string SERVER_TYPE { get; set; }
    }
}
