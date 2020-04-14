namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("race")]
    public partial class Race
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idrace { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomrace { get; set; }

        [Required]
        [StringLength(50)]
        public string descriprace { get; set; }

        [StringLength(50)]
        public string avantagesrace { get; set; }

        [StringLength(50)]
        public string inconvenientrace { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
