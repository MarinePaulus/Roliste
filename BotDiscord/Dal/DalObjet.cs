using BotDiscord.BdD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotDiscord.Dal
{
    class DalObjet
    {
        private ModelRoliste bdd;

        public DalObjet()
        {
            bdd = new ModelRoliste();
        }


        public int AddObj(Objet objet)
        {
            try {
                Objet objets = bdd.Objet.FirstOrDefault(obj => obj.nomobjet == objet.nomobjet && obj.idjeu == objet.idjeu);
                if(objets == null) {
                    bdd.Objet.Add(objet);
                    bdd.SaveChanges();
                    Objet objs = bdd.Objet.FirstOrDefault(obj => obj.nomobjet == objet.nomobjet && obj.idjeu == objet.idjeu);
                    return objs.idobjet;
                } else { Console.WriteLine("L'objet existe déjà, impossible de le rajouter."); return 0; }
            } catch (Exception e) { Console.WriteLine(e.Message); return 0; }
        }
        public bool UpObj(Objet objet)
        {
            try {
                Objet objets = bdd.Objet.FirstOrDefault(obj => obj.idobjet == objet.idobjet);
                if(objets != null) {
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("L'objet n'existe pas, impossible de le modifier."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
        }
        public bool DelObj(Objet objet)
        {
            try {
                Objet objets = bdd.Objet.FirstOrDefault(obj => obj.idobjet == objet.idobjet);
                if (objet != null) {
                    bdd.Objet.Remove(objets);
                    bdd.SaveChanges();
                    return true;
                } else { Console.WriteLine("L'objet n'existe pas, impossible de le supprimer."); return false; }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }

        }
        public Objet GetObj(Objet objet) => bdd.Objet.FirstOrDefault(obj => obj.nomobjet == obj.nomobjet && obj.idjeu == obj.idjeu);
        public List<Objet> GetAllObj(Jeux jeu) => bdd.Objet.ToList().FindAll(obj => obj.idjeu == jeu.idjeux);

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
