using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Org.BouncyCastle.Asn1.Pkcs;

// #nullable disable

namespace MilitaryDistrictAPI.Models.scaffolded
{
    public class SoldierOccupation
    {
        // [Key]
        // public long Id { get; set; }
        public int SoldierId { get; set; }
        public int OccupationId { get; set; }

        public virtual Soldier Soldier { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
