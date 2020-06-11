namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Objet")]
    public partial class Objet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Objet()
        {
            Inventaire = new HashSet<Inventaire>();
        }

        [Key]
        public int idobjet { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomobjet { get; set; }

        [StringLength(150)]
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

        public int? nbmalus1 { get; set; }

        [StringLength(50)]
        public string typemalus1 { get; set; }

        public int? nbmalus2 { get; set; }

        [StringLength(50)]
        public string typemalus2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventaire> Inventaire { get; set; }

        public virtual Jeux Jeux { get; set; }
    }
}
