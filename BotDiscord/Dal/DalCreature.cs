using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Dal
{
    class DalCreature : IDisposable
    {
        private ModelRoliste bdd;

        public DalCreature()
        {
            bdd = new ModelRoliste();
        }

        public int AddCrea(Creature creature)
        {
            try {
                Creature creas = bdd.Creature.FirstOrDefault(crea => crea.idjeu == creature.idjeu && crea.idjoueur == creature.idjoueur && crea.nomcrea == creature.nomcrea);
                if (creas == null) {
                    bdd.Creature.Add(creature);
                    bdd.SaveChanges();
                    Creature cr = bdd.Creature.FirstOrDefault(crea => crea.idjeu == creature.idjeu && crea.idjoueur == creature.idjoueur && crea.nomcrea == creature.nomcrea);
                    return cr.idcrea;
                } else { Console.WriteLine("Le personnage existe déjà, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpCrea(Creature creature)
        {
            try
            {
                Creature creas = bdd.Creature.FirstOrDefault(crea => crea.idcrea == creature.idcrea);
                if (creas != null)
                {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le personnage n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelCrea(Creature creature)
        {
            try {
                Creature creas = bdd.Creature.FirstOrDefault(crea => crea.idcrea == creature.idcrea);
                if (creas != null) {
                    bdd.Creature.Remove(creas);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le personnage n'existe pas, impossible de le supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Creature GetCrea(Creature creature) => bdd.Creature.FirstOrDefault(crea => crea.idjeu == creature.idjeu && crea.idjoueur == creature.idjoueur && crea.nomcrea == creature.nomcrea);
        public List<Creature> GetAllCreaPJ(Personne joueur) => bdd.Creature.ToList().FindAll(crea => crea.idjoueur == joueur.idperso);
        public List<Creature> GetCreaJeuPJ(Jeux jeu, Personne joueur) => bdd.Creature.ToList().FindAll(crea => crea.idjeu == jeu.idjeux && crea.idjoueur == joueur.idperso);
        public List<Creature> GetCreaJeuPNJ(Jeux jeu, Personne mj) => bdd.Creature.ToList().FindAll(crea => crea.idjeu == jeu.idjeux && crea.idjoueur == mj.idperso);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
