using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddNewQuestion(Question value);

        [OperationContract]
        Question GetQuestionById(int value);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id
        {
            get; set;
        }
        [DataMember]
        public string QuestionName
        {
            get; set;
        }

        [DataMember]
        public string UrlImage
        {
            get; set;
        }
    }
    [DataContract]
    public class Proposal
    {
        [DataMember]
        public int Id
        {
            get; set;
        }

        [DataMember]
        public string ProposalName
        {
            get; set;
        }

        [DataMember]
        public bool IsAnswer
        {
            get; set;
        }
        [DataMember]
        public string Theme
        {
            get; set;
        }
        [DataMember]
        public int IdQuestion
        {
            get; set;
        }

    }
}
