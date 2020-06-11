using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotDiscord.Dal
{
    class DalClasse
    {
        private ModelRoliste bdd;

        public DalClasse()
        {
            bdd = new ModelRoliste();
        }

        public int AddClasse(Classe classe)
        {
            try {
                Classe classse = bdd.Classe.FirstOrDefault(cla => cla.nomclasse == classe.nomclasse && cla.idjeu == classe.idjeu);
                if (classse == null) {
                    bdd.Classe.Add(classe);
                    bdd.SaveChanges();
                    Classe cl = bdd.Classe.FirstOrDefault(cla => cla.nomclasse == classe.nomclasse && cla.idjeu == classe.idjeu);
                    return cl.idclasse;
                } else { Console.WriteLine("La classe existe déjà, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpClasse(Classe classe)
        {
            try {
                Classe classse = bdd.Classe.FirstOrDefault(cla => cla.idclasse == classe.idclasse);
                if (classse != null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La classe n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelClasse(Classe classe)
        {
            try {
                Classe classse = bdd.Classe.FirstOrDefault(cla => cla.idclasse == classe.idclasse);
                if (classse != null) {
                    bdd.Classe.Remove(classse);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La classe n'existe pas, impossible de la supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Classe GetClasse(Classe classe) => bdd.Classe.FirstOrDefault(cla => cla.nomclasse == classe.nomclasse && cla.idjeu == classe.idjeu);
        public List<Classe> GetAllClasseJeu(Jeux jeu) => bdd.Classe.ToList().FindAll(cla => cla.idjeu == jeu.idjeux);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
