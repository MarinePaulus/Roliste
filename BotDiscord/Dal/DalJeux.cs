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
          
        public bool AddJeu(string nom, Personne mj)
        {
            try
            {
                Jeux jeux = bdd.Jeux.FirstOrDefault(jeu => jeu.nomjeux == nom && jeu.idmj == mj.idperso);
                if (jeux == null) {
                    bdd.Jeux.Add(new Jeux { nomjeux=nom, idmj=mj.idperso});
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le Jeu existe déjà, impossible de la rajouter."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool UpJeu(string nom, Personne mj, string newnom, Personne newmj)
        {
            try
            {
                Jeux jeux = bdd.Jeux.FirstOrDefault(jeu => jeu.nomjeux == nom && jeu.idmj == mj.idperso);
                if (jeux != null) {
                    if(newnom != null)  jeux.nomjeux = newnom;
                    if(newmj != null) jeux.idmj = newmj.idperso;
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le Jeu n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelJeu(string nom, Personne mj)
        {
            try
            {
                Jeux jeux = bdd.Jeux.FirstOrDefault(jeu => jeu.nomjeux == nom && jeu.idmj == mj.idperso);
                if (jeux != null) {
                    bdd.Jeux.Remove(jeux);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("Le Jeu n'existe pas, impossible de la supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Jeux GetJeu(string nom, Personne mj) => bdd.Jeux.FirstOrDefault(jeu => jeu.nomjeux == nom && jeu.idmj == mj.idperso);
        public List<Jeux> GetAllJeuxMJ(Personne mj) => bdd.Jeux.ToList().FindAll(jeu => jeu.idmj == mj.idperso);
        public List<Jeux> GetAllJeux() => bdd.Jeux.ToList();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
