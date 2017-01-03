using System.Collections.Generic;
using System.ServiceModel;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IDataManagement" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IDataManagement
    {

        [OperationContract]
        Question GetQuestionById(int idQuestion);

        // Connexion
        [OperationContract]
        string ConnectionCheckPlayer(string username, string password);

        // Password oublié
        [OperationContract]
        string UpdateRandomPassword(string mail);

        // Send mail with new password
        string SendMail(string mail, int idPlayer);

        // Deconnexion?

        // Récupérer les scores
        [OperationContract]
        IList<Player> GetPlayerScoreList();

        [OperationContract]
        Player GetPlayerById(int idPlayer);

        // Mot de passe oublié pour un joueur
        [OperationContract]
        string ForgotPassword(string mail, int idPlayer);

        // Update score
        [OperationContract]
        string IncrementScorePlayer(int idPlayer);

        // Inscription joueur
        [OperationContract]
        string SignupPlayer(string username, string password, string mail);

    }
}
