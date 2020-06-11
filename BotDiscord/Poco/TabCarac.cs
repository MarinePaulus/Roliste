namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabCarac")]
    public partial class TabCarac
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcrea { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcarac { get; set; }

        public int? scorecarac { get; set; }

        public virtual Caracteristique Caracteristique { get; set; }

        public virtual Creature Creature { get; set; }
    }
}
