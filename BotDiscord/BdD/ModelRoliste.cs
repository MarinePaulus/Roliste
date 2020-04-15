namespace BotDiscord.BdD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelRoliste : DbContext
    {
        public ModelRoliste()
            : base("name=ModelRoliste")
        {
        }

        public virtual DbSet<Caracteristique> Caracteristique { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Competence> Competence { get; set; }
        public virtual DbSet<Creature> Creature { get; set; }
        public virtual DbSet<Grimoire> Grimoire { get; set; }
        public virtual DbSet<Inventaire> Inventaire { get; set; }
        public virtual DbSet<Jeux> Jeux { get; set; }
        public virtual DbSet<Magie> Magie { get; set; }
        public virtual DbSet<Objet> Objet { get; set; }
        public virtual DbSet<Personne> Personne { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Tabcarac> Tabcarac { get; set; }
        public virtual DbSet<Tabcomp> Tabcomp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caracteristique>()
                .Property(e => e.nomcaract)
                .IsUnicode(false);

            modelBuilder.Entity<Caracteristique>()
                .Property(e => e.descripcaract)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.nomclasse)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.descripclasse)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.avantagesclasse)
                .IsUnicode(false);

            modelBuilder.Entity<Classe>()
                .Property(e => e.inconvenientclasse)
                .IsUnicode(false);

            modelBuilder.Entity<Competence>()
                .Property(e => e.nomcomp)
                .IsUnicode(false);

            modelBuilder.Entity<Competence>()
                .Property(e => e.descripcomp)
                .IsUnicode(false);

            modelBuilder.Entity<Competence>()
                .Property(e => e.typecomp)
                .IsUnicode(false);

            modelBuilder.Entity<Creature>()
                .Property(e => e.nomcrea)
                .IsUnicode(false);

            modelBuilder.Entity<Creature>()
                .Property(e => e.sexe)
                .IsUnicode(false);

            modelBuilder.Entity<Creature>()
                .Property(e => e.descripcrea)
                .IsUnicode(false);

            modelBuilder.Entity<Jeux>()
                .Property(e => e.nomjeux)
                .IsUnicode(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.caracteristique)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.classe)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.competence)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.creature)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.objet)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.race)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jeux>()
                .HasMany(e => e.magie)
                .WithRequired(e => e.jeux)
                .HasForeignKey(e => e.idjeu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Magie>()
                .Property(e => e.nommagie)
                .IsUnicode(false);

            modelBuilder.Entity<Magie>()
                .Property(e => e.descripmagie)
                .IsUnicode(false);

            modelBuilder.Entity<Magie>()
                .Property(e => e.effetmagie)
                .IsUnicode(false);

            modelBuilder.Entity<Objet>()
                .Property(e => e.nomobjet)
                .IsUnicode(false);

            modelBuilder.Entity<Objet>()
                .Property(e => e.descripobjet)
                .IsUnicode(false);

            modelBuilder.Entity<Objet>()
                .Property(e => e.effetobjet)
                .IsUnicode(false);

            modelBuilder.Entity<Objet>()
                .Property(e => e.typebonus1)
                .IsUnicode(false);

            modelBuilder.Entity<Objet>()
                .Property(e => e.typebonus2)
                .IsUnicode(false);

            modelBuilder.Entity<Personne>()
                .HasMany(e => e.creature)
                .WithRequired(e => e.personne)
                .HasForeignKey(e => e.idjoueur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personne>()
                .HasMany(e => e.jeux)
                .WithRequired(e => e.personne)
                .HasForeignKey(e => e.idmj)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.nomrace)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.descriprace)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.avantagesrace)
                .IsUnicode(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.inconvenientrace)
                .IsUnicode(false);
        }
    }
}
