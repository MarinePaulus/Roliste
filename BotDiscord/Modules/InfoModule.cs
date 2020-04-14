using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace BotDiscord.Modules
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        // !say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task Say([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);

        [Command("ping")]
        [Summary("Ping pong !")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("pong!");
        }

        [Command("roll")]
		[Alias("r")]
        [Summary("Rolling dices")]
        public async Task RollAsync([Remainder] [Summary("Type of dices to roll")] string roll)
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
        [Summary("Who I am?")]
        public async Task WhoIam()
        {
            ulong id = 595719586062532638;
            IUser user = await Context.Channel.GetUserAsync(id);
            //String str = " ID : " + Context.User.Id + ", pseudo : " + Context.User.ToString();
            String str = " ID : " + user.Id + ", pseudo : " + user.ToString();
            await Context.Channel.SendMessageAsync(str);
        }
    }
}
