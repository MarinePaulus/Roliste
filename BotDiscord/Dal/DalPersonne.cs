using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotDiscord.Dal
{
    class DalPersonne : IDisposable
    {
        private ModelRoliste bdd;
 
        public DalPersonne()
        {
            bdd = new ModelRoliste();
        }

        public long AddPerso(Personne personne)
        {
            try
            {
                Personne perso = bdd.Personne.FirstOrDefault(pe => pe.idperso == personne.idperso);
                if (perso == null) {
                    bdd.Personne.Add(personne);
                    bdd.SaveChanges();
                    return personne.idperso;
                } else { Console.WriteLine("La Personne existe déjà, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool DelPerso(Personne personne)
        {
            try
            {
                Personne perso = bdd.Personne.FirstOrDefault(pe => pe.idperso == personne.idperso);
                if (perso != null) {
                    bdd.Personne.Remove(perso);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La Personne n'existe pas, impossible de la supprimer."); return false; }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Personne GetPerso(Personne personne) => bdd.Personne.FirstOrDefault(pe => pe.idperso == personne.idperso);
        public List<Personne> GetAllPerso() => bdd.Personne.ToList();

        public void Dispose()
        {
            throw new NotImplementedException(); 
        }
    }
}
