using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotDiscord.Dal
{
    class DalCompetence
    {
        private ModelRoliste bdd;

        public DalCompetence()
        {
            bdd = new ModelRoliste();
        }

        public int AddCompetence(Competence competence)
        {
            try {
                Competence comps = bdd.Competence.FirstOrDefault(comp => comp.nomcomp == competence.nomcomp && comp.idjeu == comp.idjeu);
                if(comps == null) {
                    bdd.Competence.Add(competence);
                    bdd.SaveChanges();
                    Competence cp = bdd.Competence.FirstOrDefault(comp => comp.nomcomp == competence.nomcomp && comp.idjeu == comp.idjeu);
                    return cp.idcomp;
                } else { Console.WriteLine("La compétence existe déjà, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpCompetence(Competence competence)
        {
            try {
                Competence comps = bdd.Competence.FirstOrDefault(comp => comp.idcomp == competence.idcomp);
                if (comps == null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La compétence n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelCompetence(Competence competence)
        {
            try {
                Competence comps = bdd.Competence.FirstOrDefault(comp => comp.idcomp == competence.idcomp);
                if (comps == null)
                {
                    bdd.Competence.Remove(comps);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La compétence n'existe pas, impossible de la supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Competence GetCompetence(Competence competence) => bdd.Competence.FirstOrDefault(comp => comp.nomcomp == competence.nomcomp && comp.idjeu == comp.idjeu);
        public List<Competence> GetAllCompetenceJeu(Jeux jeu) => bdd.Competence.ToList().FindAll(comp => comp.idjeu == jeu.idjeux);
    }
}
