namespace BotDiscord.BdD
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("caracteristique")]
    public partial class Caracteristique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idcaract { get; set; }

        public int idjeu { get; set; }

        [Required]
        [StringLength(50)]
        public string nomcaract { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcaract { get; set; }

        public virtual Jeux jeux { get; set; }
    }
}
