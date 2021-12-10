using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService" à la fois dans le code et le fichier de configuration.
[ServiceContract]
public interface IService
{
    
	[OperationContract]
	List<Eleve> GetEleves();
	[OperationContract]
	int AddStudent(int id, string cne, string prenom, string nom, string email, byte[] photo, string tel);
	[OperationContract]
	int DeleteById(int Id);
	[OperationContract]
	int UpdateStudent(int id, string cne, string prenom, string nom, string email, byte[] photo, string tel);
	[OperationContract]
	Eleve GetStudentById(int e);
	[OperationContract]
	Eleve GetStudentByCNE(string cne);
	
}
