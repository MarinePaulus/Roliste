using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Dal
{
    class DalMagie
    {
        private ModelRoliste bdd;

        public DalMagie()
        {
            bdd = new ModelRoliste();
        }

        public bool AddMagie(Magie magie)
        {
            try {
                Magie magic = bdd.Magie.FirstOrDefault(mgc => mgc.nommagie == magie.nommagie && mgc.idjeu == magie.idjeu);
                if(magie == null) {
                    bdd.Magie.Add(magie);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le sort existe déjà, impossible de le rajouter."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool UpMagie(Magie magie)
        {
            try {
                Magie magic = bdd.Magie.FirstOrDefault(mgc => mgc.nommagie == magie.nommagie && mgc.idjeu == magie.idjeu);
                if(magie != null) {
                    if (newnom != null) magie.nommagie = newnom;
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le sort n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelMagie(Magie magie)
        {
            try {
                Magie magic = bdd.Magie.FirstOrDefault(mgc => mgc.nommagie == magie.nommagie && mgc.idjeu == magie.idjeu);
                if(magie != null) {
                    bdd.Magie.Remove(magie);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le sort n'existe pas, impossible de le supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Magie GetMagie(Magie magie) => bdd.Magie.FirstOrDefault(mgc => mgc.nommagie == magie.nommagie && mgc.idjeu == magie.idjeu);
        public List<Magie> GetAllMagieJeu(Jeux jeu) => bdd.Magie.ToList().FindAll(mgc => mgc.idjeu == jeu.idjeux);
    }
}
