namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("creature")]
    public partial class Creature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcrea { get; set; }

        public int idjeu { get; set; }

        public long idjoueur { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcrea { get; set; }

        [Required]
        [StringLength(50)]
        public string sexe { get; set; }

        public int age { get; set; }

        public int poids { get; set; }

        public int taille { get; set; }

        public int idrace { get; set; }

        public int idclasse { get; set; }

        public int? niveau { get; set; }

        public int pvmax { get; set; }

        public int? mvactuel { get; set; }

        public int pmmax { get; set; }

        public int? pmactuel { get; set; }

        public int? armure { get; set; }

        public int? emcombrement { get; set; }

        public int? bourse { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcrea { get; set; }

        public virtual Jeux jeux { get; set; }

        public virtual Personne personne { get; set; }
    }
}
