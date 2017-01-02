using System.Runtime.Serialization;

namespace SquizzWebService
{
    [DataContract]
    public class Proposal
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public bool IsAnswer { get; set; }

        [DataMember]
        public int IdQuestion { get; set; }
        public Proposal(int id, string value, bool isAnswer, int idQuestion)
        {
            Id = id;
            Value = value;
            IsAnswer = isAnswer;
            IdQuestion = idQuestion;
        }

    }
}