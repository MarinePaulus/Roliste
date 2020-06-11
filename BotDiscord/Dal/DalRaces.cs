using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Dal
{
    class DalRaces
    {
        private ModelRoliste bdd;

        public DalRaces()
        {
            bdd = new ModelRoliste();
        }

        public int AddRaces(Race race)
        {
            try {
                Race races = bdd.Race.FirstOrDefault(ra => ra.nomrace == race.nomrace && ra.idjeu == race.idjeu);
                if (races == null)
                {
                    bdd.Race.Add(races);
                    bdd.SaveChanges();
                    Race rs = bdd.Race.FirstOrDefault(ra => ra.nomrace == race.nomrace && ra.idjeu == race.idjeu);
                    return rs.idrace;
                } else { Console.WriteLine("La race existe déjà, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpRaces(Race race)
        {
            try {
                Race races = bdd.Race.FirstOrDefault(ra => ra.idrace == race.idrace);
                if (races == null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La race n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelRaces(Race race)
        {
            try {
                Race races = bdd.Race.FirstOrDefault(ra => ra.idrace == race.idrace);
                if (races != null) {
                    bdd.Race.Remove(races);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La race n'existe pas, impossible de la supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Race GetRace(Race race) => bdd.Race.FirstOrDefault(ra => ra.nomrace == ra.nomrace && ra.idjeu == race.idjeu);
        public List<Race> GetAllRace(Jeux jeu) => bdd.Race.ToList().FindAll(ra => ra.idjeu == jeu.idjeux);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
