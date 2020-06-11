namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Magie")]
    public partial class Magie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Magie()
        {
            Grimoire = new HashSet<Grimoire>();
        }

        [Key]
        public int idmagie { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nommagie { get; set; }

        [StringLength(150)]
        public string descripmagie { get; set; }

        [StringLength(50)]
        public string effetmagie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grimoire> Grimoire { get; set; }

        public virtual Jeux Jeux { get; set; }
    }
}
