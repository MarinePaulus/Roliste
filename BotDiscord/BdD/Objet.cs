namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("objet")]
    public partial class Objet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idobjet { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomobjet { get; set; }

        [Required]
        [StringLength(50)]
        public string descripobjet { get; set; }

        [StringLength(50)]
        public string effetobjet { get; set; }

        public int rareteobjet { get; set; }

        [StringLength(50)]
        public string typebonus1 { get; set; }

        public int? nbbonus1 { get; set; }

        [StringLength(50)]
        public string typebonus2 { get; set; }

        public int? nbbonus2 { get; set; }

        public int nbmalus1 { get; set; }

        public int typemalus1 { get; set; }

        public int nbmalus2 { get; set; }

        public int typemalus2 { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
