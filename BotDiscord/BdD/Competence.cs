namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("competence")]
    public partial class Competence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcomp { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcomp { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcomp { get; set; }

        [Required]
        [StringLength(50)]
        public string typecomp { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
