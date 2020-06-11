namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Creature")]
    public partial class Creature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Creature()
        {
            Grimoire = new HashSet<Grimoire>();
            Inventaire = new HashSet<Inventaire>();
            Caracteristiques = new HashSet<TabCarac>();
            Competences = new HashSet<TabComp>();
        }

        [Key]
        public int idcrea { get; set; }

        public int idjeu { get; set; }

        public long idjoueur { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcrea { get; set; }

        [Required]
        [StringLength(50)]
        public string sexe { get; set; }

        public int? age { get; set; }

        public int? poids { get; set; }

        public int? taille { get; set; }

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

        [StringLength(150)]
        public string descripcrea { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual Jeux Jeux { get; set; }

        public virtual Personne Personne { get; set; }

        public virtual Race Race { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grimoire> Grimoire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventaire> Inventaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabCarac> Caracteristiques { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabComp> Competences { get; set; }
    }
}
