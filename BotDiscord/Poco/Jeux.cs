namespace BotDiscord.BdD
{
    using BotDiscord.Dal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Jeux")]
    public partial class Jeux
    {
        DalJeux dal = new DalJeux();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jeux()
        {
            Caracteristique = new HashSet<Caracteristique>();
            Classe = new HashSet<Classe>();
            Competence = new HashSet<Competence>();
            Creature = new HashSet<Creature>();
            Objet = new HashSet<Objet>();
            Race = new HashSet<Race>();
            Magie = new HashSet<Magie>();
        }

        [Key]
        public int idjeux { get; set; }

        [Required]
        [StringLength(50)]
        public string nomjeux { get; set; }

        public long idmj { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristique> Caracteristique { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Classe> Classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competence> Competence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creature> Creature { get; set; }

        public virtual Personne Maitre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objet> Objet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Race> Race { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Magie> Magie { get; set; }

        // Méthodes

        public int AddJeu(ulong id) {
            Personne p = new Personne() { idperso = (long)id };
            if (p.GetPerso() != null) {
                idmj = (long)id;
                return dal.AddJeu(this);
            } else {
                p = new Personne() { idperso = (long)id };
                p.AddPerso();
                idmj = (long) id;
                return 0;
            }
        }
        public bool UpJeu() {
            Personne p = new Personne() { idperso = this.idmj };
            p.GetPerso();
            if (p.GetPerso() != null) {
                this.Maitre = p;
            } else {
                p = new Personne() { idperso = this.idmj };
                p.AddPerso();
                this.Maitre = p;
            }
            return dal.UpJeu(this);
        }
        public bool DelJeu() => dal.DelJeu(this);
        public Jeux GetJeu() => dal.GetJeu(this);
        public List<Jeux> GetAllJeuxMJ() => dal.GetAllJeuxMJ(this.Maitre);
        public List<Jeux> GetAllJeux() => dal.GetAllJeux();
    }
}
