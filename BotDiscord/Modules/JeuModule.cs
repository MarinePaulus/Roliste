using BotDiscord.BdD;
using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    class JeuModule : ModuleBase<SocketCommandContext>
    {
        [Command("addjeu")]
        public async Task AddJeu(string nom)
        {
            Jeux jeu = new Jeux() { nomjeux = nom};
            int ok = jeu.AddJeu(Context.User.Id);
            if (ok != 0)
                await Context.Channel.SendMessageAsync("Jeu enregistré avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non enregistré, une erreur s'est produite.");
        }

        [Command("upjeu")]
        public async Task UpJeu(string nom, string newnom, IUser newmj = null)
        {
            // Info pour récup le jeu
            Jeux jeu = new Jeux() { nomjeux = nom, idmj = (long)Context.User.Id };
            jeu = jeu.GetJeu();

            // Modification des infos
            if (newmj != null) jeu.idmj = (long)newmj.Id;
            jeu.nomjeux = newnom;
            bool ok = jeu.UpJeu();

            if (ok)
                await Context.Channel.SendMessageAsync("Jeu modifié avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non modifié, une erreur s'est produite.");
        }

        [Command("deljeu")]
        public async Task DelJeu(string nom)
        {
            Jeux jeu = new Jeux { nomjeux = nom, idmj = (long)Context.User.Id };
            jeu = jeu.GetJeu();
            bool ok = jeu.DelJeu();

            if (ok)
                await Context.Channel.SendMessageAsync("Jeu supprimé avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non supprimé, une erreur s'est produite.");
        }

        [Command("getjeu")]
        public async Task GetJeux(string nom)
        {
            Personne perso = new Personne() { idperso = (long)Context.User.Id };
            perso = perso.GetPerso();
            Jeux jeu = new Jeux() { nomjeux = nom, Maitre = perso, idmj = perso.idperso };
            jeu = jeu.GetJeu();

            if (jeu != null)
                await Context.Channel.SendMessageAsync("Nom du jeu : " + jeu.nomjeux + ", Maitre du Jeu : " + Context.User.Username);
            else
                await Context.Channel.SendMessageAsync("Le Jeu n'existe pas pour ce MJ.");
        }

        [Command("lstjeux")]
        public async Task ListJeuxMJ(IUser user = null)
        {
            Personne perso = new Personne();
            if (user == null)
                perso.idperso = (long)Context.User.Id;
            else
                perso.idperso = (long)user.Id;

            string str = "Le MJ " + Context.Channel.GetUserAsync((ulong)perso.idperso).Result.Username + " possède les jeux suivants:\n";
            Jeux jeu = new Jeux() { Maitre = perso.GetPerso() };
            List<Jeux> lstJeux = jeu.GetAllJeuxMJ();

            foreach (Jeux p in lstJeux)
                str += p.nomjeux + "\n";

            if (str != null)
                await Context.Channel.SendMessageAsync(str);
            else
                await Context.Channel.SendMessageAsync("Il n'y a pas de Jeux dans la liste de ce rôliste...");
        }

        [Command("lstalljeux")]
        public async Task ListAllJeux()
        {
            Jeux jeu = new Jeux();
            List<Jeux> lstJeux = jeu.GetAllJeux();
            string str = null;

            foreach (Jeux p in lstJeux)
                str += p.nomjeux + "\n" + "\t" + "Le MJ est " + Context.Channel.GetUserAsync((ulong)p.Maitre.idperso).Result.Username + "\n";

            if (str != null)
                await Context.Channel.SendMessageAsync(str);
            else
                await Context.Channel.SendMessageAsync("Il n'y a pas de Jeux dans la liste...");
        }
    }
}
