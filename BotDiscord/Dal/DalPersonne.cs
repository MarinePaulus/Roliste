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

        public bool AddPerso(ulong id)
        {
            try
            {
                Personne perso = bdd.Personne.FirstOrDefault(pe => pe.idperso == (long)id);
                if (perso == null) {
                    bdd.Personne.Add(new Personne { idperso = (long)id });
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La Personne existe déjà, impossible de la rajouter."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelPerso(ulong id)
        {
            try
            {
                Personne perso = bdd.Personne.FirstOrDefault(pe => pe.idperso == (long)id);
                if (perso != null) {
                    bdd.Personne.Remove(perso);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La Personne n'existe pas, impossible de la supprimer."); return false; }
            }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Personne GetPerso(ulong id) => bdd.Personne.FirstOrDefault(pe => pe.idperso == (long)id);
        public List<Personne> GetAllPerso() => bdd.Personne.ToList();

        public void Dispose()
        {
            throw new NotImplementedException(); 
        }
    }
}
