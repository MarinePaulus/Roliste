using BotDiscord.BdD;
using BotDiscord.Dal;
using Discord;
using Discord.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    class RolisteModule : ModuleBase<SocketCommandContext>
    {
        [Command("add")]
        public async Task AddPerso([Remainder] IUser user = null)
        {
            DalPersonne perso = new DalPersonne();
            bool ok = (user == null) ? perso.AddPerso(Context.User.Id) : perso.AddPerso(user.Id);

            if (ok)
                await Context.Channel.SendMessageAsync("Utilisateur enregistré avec succès.");
            else
                await Context.Channel.SendMessageAsync("Utilisateur non enregistré, une erreur s'est produite.");
        }

        [Command("del")]
        public async Task DelPerso([Remainder] IUser user)
        {
            DalPersonne perso = new DalPersonne();
            bool ok = perso.DelPerso(user.Id);

            if (ok)
                await Context.Channel.SendMessageAsync("Utilisateur supprimé avec succès.");
            else
                await Context.Channel.SendMessageAsync("Utilisateur non supprimé, une erreur s'est produite.");
        }

        [Command("one")]
        public async Task GetPerso([Remainder] IUser user)
        {
            DalPersonne perso = new DalPersonne();
            Personne p = null;
            IEnumerable emu = await Context.Channel.GetUsersAsync().FlattenAsync();

            foreach (Object o in emu)
                if (o.ToString().Contains(user.ToString())) p = perso.GetPerso(user.Id);
            
            if (p != null)
                await Context.Channel.SendMessageAsync(Context.Channel.GetUserAsync((ulong)p.idperso).Result.ToString());
            else
                await Context.Channel.SendMessageAsync("Cet utilisateur n'est pas un rôliste.");
        }

        [Command("list")]
        public async Task ListPerso()
        {
            DalPersonne perso = new DalPersonne();
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
