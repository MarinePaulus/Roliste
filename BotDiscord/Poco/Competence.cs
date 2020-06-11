namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Competence")]
    public partial class Competence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Competence()
        {
            TabComp = new HashSet<TabComp>();
        }

        [Key]
        public int idcomp { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcomp { get; set; }

        [StringLength(150)]
        public string descripcomp { get; set; }

        [Required]
        [StringLength(50)]
        public string typecomp { get; set; }

        public virtual Jeux Jeux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TabComp> TabComp { get; set; }
    }
}
