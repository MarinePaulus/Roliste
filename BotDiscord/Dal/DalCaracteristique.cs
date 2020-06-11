using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BotDiscord.Dal
{
    class DalCaracteristique : IDisposable
    {
        private ModelRoliste bdd;

        public DalCaracteristique()
        {
            bdd = new ModelRoliste();
        }

        public int AddCaract(Caracteristique caracteristique)
        {
            try {
                Caracteristique caracs = bdd.Caracteristique.FirstOrDefault(caract => caract.nomcaract == caracteristique.nomcaract && caract.idjeu == caracteristique.idjeu);
                if(caracs == null) {
                    bdd.Caracteristique.Add(caracteristique);
                    bdd.SaveChanges();
                    Caracteristique cas = bdd.Caracteristique.FirstOrDefault(caract => caract.nomcaract == caracteristique.nomcaract && caract.idjeu == caracteristique.idjeu);
                    return cas.idcaract;
                } else { Console.WriteLine("la caracteristique existe deja, impossible de la rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }

        }
        public bool UpCaract(Caracteristique caracteristique)
        {
            try {
                Caracteristique caracs = bdd.Caracteristique.FirstOrDefault(caract => caract.idcaract == caracteristique.idcaract);
                if (caracs != null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La caracteristique n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelCaract(Caracteristique caracteristique)
        {
            try {
                Caracteristique caracs = bdd.Caracteristique.FirstOrDefault(caract => caract.idcaract == caracteristique.idcaract);
                if (caracs != null) {
                    bdd.Caracteristique.Remove(caracs);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("La caracteristique n'existe pas, impossible de la supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public Caracteristique GetCaract(Caracteristique caracteristique) => bdd.Caracteristique.FirstOrDefault(caract => caract.nomcaract == caracteristique.nomcaract && caract.idjeu == caracteristique.idjeu);
        public List<Caracteristique> GetAllCaractJeu(Jeux jeu) => bdd.Caracteristique.ToList().FindAll(caract => caract.idjeu == jeu.idjeux);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
