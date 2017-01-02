using System.Runtime.Serialization;

namespace SquizzWebService
{
    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class Question
    {
        public Question(int id, string name, string urlImage)
        {
            Id = id;
            Name = name;
            UrlImage = urlImage;
        }

        public Question()
        {
            Id = 1;
            Name = "";
            UrlImage = "";
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string UrlImage { get; set; }


    }
}