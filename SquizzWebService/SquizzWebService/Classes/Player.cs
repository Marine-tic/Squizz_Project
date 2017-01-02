using System.Runtime.Serialization;

namespace SquizzWebService
{
    //
    [DataContract]
    public class Player
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Mail { get; set; }

        [DataMember]
        public int Score { get; set; }

        public Player(int id, string username, string password, string mail, int score=0)
        {
            Id = id;
            Username = username;
            Password = password;
            Mail = mail;
            Score = score;
        }
    }
}