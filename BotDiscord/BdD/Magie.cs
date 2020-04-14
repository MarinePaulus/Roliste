namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("magie")]
    public partial class Magie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idmagie { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nommagie { get; set; }

        [StringLength(50)]
        public string descripmagie { get; set; }

        [StringLength(50)]
        public string effetmagie { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
