using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotDiscord.Dal
{
    class DalJeux : IDisposable
    {
        private ModelRoliste bdd;

        public DalJeux()
        {
            bdd = new ModelRoliste();
        }
          
        public int AddJeu(Jeux jeu)
        {
            try {
                Jeux jeux = bdd.Jeux.FirstOrDefault(j => j.nomjeux == jeu.nomjeux && j.idmj == jeu.idmj);
                if (jeux == null) {
                    bdd.Jeux.Add(jeu);
                    bdd.SaveChanges();
                    Jeux jx = bdd.Jeux.FirstOrDefault(j => j.nomjeux == jeu.nomjeux && j.idmj == jeu.idmj);
                    return jx.idjeux;
                } else { Console.WriteLine("Le jeu existe déjà, impossible de le rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpJeu(Jeux jeu)
        {
            try {
                Jeux jeux = bdd.Jeux.FirstOrDefault(j => j.idjeux == jeu.idjeux);
                if (jeux != null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le jeu n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelJeu(Jeux jeu)
        {
            try {
                Jeux jeux = bdd.Jeux.FirstOrDefault(j => j.idjeux == jeu.idjeux);
                if (jeux != null) {
                    bdd.Jeux.Remove(jeux);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le jeu n'existe pas, impossible de le supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Jeux GetJeu(Jeux jeu) => bdd.Jeux.FirstOrDefault(j => j.nomjeux == jeu.nomjeux && j.idmj == jeu.idmj);
        public List<Jeux> GetAllJeuxMJ(Personne mj) => bdd.Jeux.ToList().FindAll(jeu => jeu.idmj == mj.idperso);
        public List<Jeux> GetAllJeux() => bdd.Jeux.ToList();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
