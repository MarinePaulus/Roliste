using BotDiscord.BdD;
using BotDiscord.Dal;
using Discord;
using Discord.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    class JeuModule : ModuleBase<SocketCommandContext>
    {
        [Command("addjeu")]
        public async Task AddJeu([Remainder] string nom)
        {
            DalJeux jeu = new DalJeux();
            DalPersonne perso = new DalPersonne();
            Personne pe = perso.GetPerso(Context.User.Id);
            bool ok = false;

            if (pe == null) {
                perso.AddPerso(Context.User.Id);
                ok = jeu.AddJeu(nom, perso.GetPerso(Context.User.Id));
            } else
                ok = jeu.AddJeu(nom, pe);

            if (ok)
                await Context.Channel.SendMessageAsync("Jeu enregistré avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non enregistré, une erreur s'est produite.");
        }

        [Command("upjeu")]
        public async Task UpJeu([Remainder] string nom, [Remainder] string newnom, IUser newmj)
        {
            DalJeux jeu = new DalJeux();
            DalPersonne perso = new DalPersonne();
            Personne pe = perso.GetPerso(newmj.Id);
            bool ok = false;

            if (pe == null)
            {
                perso.AddPerso(Context.User.Id);
                ok = jeu.UpJeu(nom, perso.GetPerso(Context.User.Id), newnom, pe);
            }
            

            if (ok)
                await Context.Channel.SendMessageAsync("Jeu modifié avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non modifié, une erreur s'est produite.");
        }

        [Command("deljeu")]
        public async Task DelJeu([Remainder] string nom)
        {
            DalJeux jeu = new DalJeux();
            DalPersonne perso = new DalPersonne();
            bool ok = jeu.DelJeu(nom, perso.GetPerso(Context.User.Id));

            if (ok)
                await Context.Channel.SendMessageAsync("Jeu supprimé avec succès.");
            else
                await Context.Channel.SendMessageAsync("Jeu non supprimé, une erreur s'est produite.");
        }

        [Command("onejeu")]
        public async Task GetJeux([Remainder] string nom)
        {
            DalJeux jeu = new DalJeux();
            Jeux p = null;
            IEnumerable emu = await Context.Channel.GetUsersAsync().FlattenAsync();

            foreach (Object o in emu)
                if (o.ToString().Contains(jeu.ToString())) p = jeu.GetJeu(nom jeu.Id);

            if (p != null)
                await Context.Channel.SendMessageAsync(Context.Channel.GetUserAsync((ulong)p.idjeu).Result.ToString());
            else
                await Context.Channel.SendMessageAsync("Cet utilisateur n'est pas un rôliste.");
        }

        [Command("listjeu")]
        public async Task ListJeux()
        {
            DalJeux jeu = new DalJeux();
            List<Jeux> lstJeux = jeu.GetAllJeux();
            string str = null;

            foreach (Jeux p in lstJeux)
                str += p.nomjeux + "\n";

            if (str != null)
                await Context.Channel.SendMessageAsync(str);
            else
                await Context.Channel.SendMessageAsync("Il n'y a pas de rôlistes dans la liste...");
        }
    }
}
