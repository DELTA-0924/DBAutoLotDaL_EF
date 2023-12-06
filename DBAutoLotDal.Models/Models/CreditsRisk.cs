namespace DBAutoLotDaL.models
{
    using DBAutoLotDaL.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CreditsRisk: EntityBase
    {


        [Required]
        [StringLength(50)]
        [Index("IDX_CreditsRisks_Name",IsUnique =true,Order =2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IDX_CreditsRisks_Name", IsUnique = true, Order = 1)]
        public string LastName { get; set; }
    }
}
