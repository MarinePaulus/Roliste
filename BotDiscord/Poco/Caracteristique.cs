namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Caracteristique")]
    public partial class Caracteristique
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caracteristique()
        {
            TabCarac = new HashSet<TabCarac>();
        }

        [Key]
        public int idcaract { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcaract { get; set; }

        [StringLength(150)]
        public string descripcaract { get; set; }

        public virtual Jeux Jeux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabCarac> TabCarac { get; set; }
    }
}
