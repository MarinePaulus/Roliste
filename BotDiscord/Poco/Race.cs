namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Race")]
    public partial class Race
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Race()
        {
            Creature = new HashSet<Creature>();
        }

        [Key]
        public int idrace { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomrace { get; set; }

        [StringLength(150)]
        public string descriprace { get; set; }

        [StringLength(50)]
        public string avantagesrace { get; set; }

        [StringLength(50)]
        public string inconvenientrace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creature> Creature { get; set; }

        public virtual Jeux Jeux { get; set; }
    }
}
