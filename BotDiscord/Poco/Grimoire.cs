namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grimoire")]
    public partial class Grimoire
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcrea { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idsort { get; set; }

        public int? niveausort { get; set; }

        public virtual Creature Creature { get; set; }

        public virtual Magie Magie { get; set; }
    }
}
