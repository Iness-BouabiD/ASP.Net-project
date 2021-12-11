using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
public class Service : IService
{
    GINF3Entities db = new GINF3Entities();
    public List<Eleve> GetEleves()
    {
        List<Eleve> eleves = new List<Eleve>();

        var x = from n in db.Eleve select n;
        foreach (var item in x)
        {
            Eleve e = new Eleve();
            e.ID_Eleve = item.ID_Eleve;
            e.CNE = item.CNE;
            e.Prenom = item.Prenom;
            e.Nom = item.Nom;
            e.Email = item.Email;
            e.Photo = item.Photo;
            e.Tel = item.Tel;

            eleves.Add(e);
        }
        return eleves;
    }

    public int AddStudent(int id, string cne, string prenom, string nom, string email, byte[] photo, string tel)
    {
        Eleve e = new Eleve();
        e.ID_Eleve = id;
        e.CNE = cne;
        e.Prenom = prenom;
        e.Nom = nom;
        e.Email = email;
        e.Photo = photo;
        e.Tel = tel;
        db.Eleve.Add(e);

        int res = db.SaveChanges();
        return res;
    }
    public int DeleteById(int id)
    {
        Eleve e = new Eleve();
        e.ID_Eleve = id;
        db.Entry(e).State = System.Data.Entity.EntityState.Deleted;
        int res = db.SaveChanges();
        return res;
    }

    public int UpdateStudent(int id, string cne, string prenom, string nom, string email, byte[] photo, string tel)
    {
        Eleve e = new Eleve();
        e.ID_Eleve = id;
        e.CNE = cne;
        e.Prenom = prenom;
        e.Nom = nom;
        e.Email = email;
        e.Photo = photo;
        e.Tel = tel;
        db.Entry(e).State = System.Data.Entity.EntityState.Modified;
        int res = db.SaveChanges();
        return res;
    }

    public Eleve GetStudentById(int i)
    {
        var list = from k in db.Eleve where k.ID_Eleve == i select k;
        Eleve e = new Eleve();
        foreach (var item in list)
        {
            e.ID_Eleve = item.ID_Eleve;
            e.CNE = item.CNE;
            e.Prenom = item.Prenom;
            e.Nom = item.Nom;
            e.Email = item.Email;
            e.Photo = item.Photo;
            e.Tel = item.Tel;
        }
        return e;
    }
    public Eleve GetStudentByCNE(string cne)
    {
        var list = from k in db.Eleve where k.CNE == cne select k;
        Eleve e = new Eleve();
        foreach (var item in list)
        {
            e.ID_Eleve = item.ID_Eleve;
            e.CNE = item.CNE;
            e.Prenom = item.Prenom;
            e.Nom = item.Nom;
            e.Email = item.Email;
            e.Photo = item.Photo;
            e.Tel = item.Tel;

        }
        return e;
    }


}
