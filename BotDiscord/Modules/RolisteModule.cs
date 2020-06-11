using BotDiscord.BdD;
using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    class RolisteModule : ModuleBase<SocketCommandContext>
    {
        [Command("add")]
        public async Task AddPerso([Remainder] IUser user = null)
        {
            Personne perso = new Personne();
            if (user == null)
                perso.idperso = (long)Context.User.Id;
            else
                perso.idperso = (long)user.Id;

            long ok = perso.AddPerso();

            if (ok != 0)
                await Context.Channel.SendMessageAsync("Utilisateur enregistré avec succès.");
            else
                await Context.Channel.SendMessageAsync("Utilisateur non enregistré, une erreur s'est produite.");
        }

        [Command("del")]
        public async Task DelPerso([Remainder] IUser user)
        {
            Personne perso = new Personne() { idperso = (long)user.Id };
            bool ok = perso.DelPerso();

            if (ok)
                await Context.Channel.SendMessageAsync("Utilisateur supprimé avec succès.");
            else
                await Context.Channel.SendMessageAsync("Utilisateur non supprimé, une erreur s'est produite.");
        }

        [Command("get")]
        public async Task GetPerso([Remainder] IUser user)
        {
            Personne perso = new Personne() { idperso = (long)user.Id };
            perso = perso.GetPerso();
            Jeux jeu = new Jeux() { Maitre = perso};
            List<Jeux> jeux = jeu.GetAllJeuxMJ();
            
            if (perso != null)
                if (jeux != null)
                    await Context.Channel.SendMessageAsync(
                        Context.Channel.GetUserAsync((ulong)perso.idperso).Result.ToString()
                        + " est Maître de Jeu. Faites !lstjeux @" 
                        + Context.Channel.GetUserAsync((ulong)perso.idperso).Result.Username 
                        + " pour voir la liste de ses jeux.");
                else
                    await Context.Channel.SendMessageAsync(Context.Channel.GetUserAsync((ulong)perso.idperso).Result.ToString() + "n'est pas Maître de Jeu.");
            else
                await Context.Channel.SendMessageAsync("Cet utilisateur n'est pas un rôliste.");
        }

        [Command("list")]
        public async Task ListPerso()
        {
            Personne perso = new Personne();
            List<Personne> lstPerso = perso.GetAllPerso();
            string str = null;

            foreach (Personne p in lstPerso)
                str += Context.Channel.GetUserAsync((ulong)p.idperso).Result.ToString() + "\n";
            
            if (str != null)
                await Context.Channel.SendMessageAsync(str);
            else
                await Context.Channel.SendMessageAsync("Il n'y a pas de rôlistes dans la liste...");
        }
    }
}
