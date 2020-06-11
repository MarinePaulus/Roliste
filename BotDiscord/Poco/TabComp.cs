namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabComp")]
    public partial class TabComp
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcrea { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcomp { get; set; }

        public int? scorecomp { get; set; }

        public virtual Competence Competence { get; set; }

        public virtual Creature Creature { get; set; }
    }
}
