using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("say")]
        public Task Say([Remainder] string echo)
            => ReplyAsync(echo);

        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("pong!");
        }

        [Command("pong")]
        public async Task Pong()
        {
            await Context.Channel.SendMessageAsync("ping!");
        }

        [Command("roll")]
		[Alias("r")]
        public async Task RollAsync([Remainder] string roll)
        { // xdx // xdx+x // xdx+xdx 
            string retour = "";
            string[] dices = roll.Split('+'); // Récup les =/= types de dés
            int sol = 0;
            foreach (string dice in dices)
            {
                if (dice.Contains("d"))
                {
                    string[] data = dice.Split('d'); // Séparer nb dés et type dés
                    int nbDes = Int32.Parse(data[0]); // Récup nb dés
                    int typeDes = Int32.Parse(data[1]); // Récup type dés
                    Random rand = new Random();
                    for (int i = 0; i < nbDes; i++) // pour chaque dés à lancer
                    {
                        int nb = rand.Next(0, typeDes) + 1; // Roll le dés
                        sol += nb; // Ajoute à la somme
                        retour += nb + " + "; // Ajoute à l'opération
                    }
                } else {
                    sol += Int32.Parse(dice); // Ajoute à la somme
                    retour += Int32.Parse(dice) + " + "; // Ajoute à l'opération
                }
            }
            retour = retour.Remove(retour.Length - 3); // Retire le + parasite
            retour += " = " + sol; // Ajoute la somme
            if (roll.Equals("12d8+34")){ retour += "... *T'es fait!*"; }
            await Context.Channel.SendMessageAsync(retour);
        }

        [Command("whoiam")]
        public async Task WhoIam()
        {
//            ulong id = X;
//            IUser user = await Context.Channel.GetUserAsync(id);
//            String str = " ID : " + user.Id + ", pseudo : " + user.ToString();
            String str = "Pseudo : " + Context.User.ToString();
            
            await Context.Channel.SendMessageAsync(str);
        }
    }
}
