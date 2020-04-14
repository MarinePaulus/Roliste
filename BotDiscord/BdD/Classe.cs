namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("classe")]
    public partial class Classe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idclasse { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomclasse { get; set; }

        [Required]
        [StringLength(50)]
        public string descripclasse { get; set; }

        [StringLength(50)]
        public string avantagesclasse { get; set; }

        [StringLength(50)]
        public string inconvenientclasse { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
