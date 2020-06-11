namespace BotDiscord.BdD
{
    using BotDiscord.Dal;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Personne")]
    public partial class Personne
    {
        DalPersonne dal = new DalPersonne();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personne()
        {
            Creature = new HashSet<Creature>();
            Jeux = new HashSet<Jeux>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long idperso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creature> Creature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jeux> Jeux { get; set; }

        // Methodes
        public long AddPerso() => dal.AddPerso(this);
        public bool DelPerso() => dal.DelPerso(this);
        public Personne GetPerso() => dal.GetPerso(this);
        public List<Personne> GetAllPerso() => dal.GetAllPerso();
    }
}
