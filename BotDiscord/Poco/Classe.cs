namespace BotDiscord.BdD
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classe")]
    public partial class Classe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classe()
        {
            Creature = new HashSet<Creature>();
        }

        [Key]
        public int idclasse { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomclasse { get; set; }

        [StringLength(150)]
        public string descripclasse { get; set; }

        [StringLength(150)]
        public string avantagesclasse { get; set; }

        [StringLength(150)]
        public string inconvenientclasse { get; set; }

        public virtual Jeux Jeux { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creature> Creature { get; set; }
    }
}
