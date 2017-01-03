using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceModel;
using System.Text;
using System.Net.Mail;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "DataManagement" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez DataManagement.svc ou DataManagement.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    [ServiceBehavior]
    public class DataManagement : IDataManagement
    {
        // REMARQUE : Penser à changer le path du fichier de database en conséquence du clonage du dépot un clic sur SquizzDatabase.mdf affichera le chemin complet à copier coller ci dessous et escape text.
        private readonly string _connectionString =
            "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Auna\\Documents\\Squizz_Project\\SquizzWebService\\SquizzWebService\\App_Data\\SquizzDatabase.mdf';Integrated Security=True";

        public Question GetQuestionById(int idQuestion)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    Question question = new Question();
                    SqlCommand getQuestionByIdSql = new SqlCommand("SELECT * FROM Question WHERE idQ= @idQuestion",
                        sqlConnection);
                    getQuestionByIdSql.Parameters.AddWithValue("@idQuestion", idQuestion);

                    SqlDataReader sqlDataReader = getQuestionByIdSql.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        question.Id = (int) sqlDataReader[0];
                        question.Name = sqlDataReader[1].ToString();
                        question.UrlImage = sqlDataReader[2].ToString();
                    }
                    else
                    {
                        question = null;
                    }

                    return question;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string ConnectionCheckPlayer(string username, string password)
        {
            // Récupérer le joueur en base de donnée
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    Player playerDatabase = new Player(1, "", "", "");
                    // Check existence joueur en database avant de vérifier login et pass
                    SqlCommand checkExistPlayerSql = new SqlCommand("SELECT * FROM PLAYER WHERE username = @username",
                        sqlConnection);
                    checkExistPlayerSql.Parameters.AddWithValue("@username", username);

                    SqlDataReader sqlDataReader = checkExistPlayerSql.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        playerDatabase.Id = (int) sqlDataReader[0];
                        playerDatabase.Username = sqlDataReader[1].ToString();
                        playerDatabase.Password = sqlDataReader[2].ToString();
                        playerDatabase.Mail = sqlDataReader[3].ToString();
                    }
                    else
                    {
                        playerDatabase = null;
                        return "Error: This user does not exist";
                    }

                    // Si le joueur existe bien en base de donnée
                    // Vérifier le login, le mot de passe pour voir s'il correspond avec ceux entré par le client
                    // Renvoyer Connection successful si c'est le cas sinon Connection failure
                    return (password.Equals(playerDatabase.Password) &&
                            username.Equals(playerDatabase.Username))
                        ? "Connection successful"
                        : "Connection failure";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        public string UpdateRandomPassword(string mail)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    // Met à jour le password du joueur en database et le remplace par un généré aléatoirement 
                    SqlCommand updatePlayerPasswordSql =
                        new SqlCommand("UPDATE PLAYER set password=@password WHERE mail = @mail",
                            sqlConnection);
                    // Générer un mot de passe aléatoire de 10 caractères et le mettre en base de donnée.
                    string randomPassword = CreateRandomPassword(10);
                    updatePlayerPasswordSql.Parameters.AddWithValue("@mail", mail);
                    updatePlayerPasswordSql.Parameters.AddWithValue("@password", randomPassword);
                    // Si le joueur n'existe pas inutile de vérifier son login et password
                    return updatePlayerPasswordSql.ExecuteNonQuery() == 1
                        ? "Update password successful"
                        : "Update password failure";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string ForgotPassword(string mail, int idPlayer)
        {
            // Si le mot de passe a bien été mis à jour, j'envoie le mail sinon fail
            if (UpdateRandomPassword(mail) == "Update password successful")
            {
                SendMail(mail, idPlayer);
            }
            else
            {
                return "Error during password update";
            }
            return "Password sucessfully reset";
        }

        public string SendMail(string mail, int idPlayer)
        {
            if (String.IsNullOrWhiteSpace(mail))
            {
                return "Error: invalid mail";
            }
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("teamsquizz@outlook.fr", "5Qu!zZ2016");

            // je récupère le joueur dans la bd pour être sur d'avoir le dernier mot de passe
            Player playerDatabase = GetPlayerById(idPlayer);

            // je prépare le mail
            MailMessage mailMessage = new MailMessage("teamsquizz@outlook.fr", playerDatabase.Mail, "Squizz : Your password",
                "Your password has been reset, Here is the new password " + playerDatabase.Password);
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            // j'envoie le mail
            client.Send(mailMessage);
            return "Mail sent hopefully :D";
        }

        public IList<Player> GetPlayerScoreList()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string sqlStr = "select username, score from Player";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlStr, sqlConnection);
                    sqlDa.Fill(dataSet);
                }
                catch
                {
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            List<Player> playerListScore = new List<Player>();
            DataTable dataTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var item = new Player(0,
                    dataRow["Username"] as string,
                    "",
                    "",
                    (int) dataRow["Score"]);
                playerListScore.Add(item);
            }

            return playerListScore;
        }

        public Player GetPlayerById(int idPlayer)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    Player playerDatabase;
                    sqlConnection.Open();
                    SqlCommand getScoreFromPlayerSql = new SqlCommand("SELECT * FROM Player WHERE idPl= @IdPlayer",
                        sqlConnection);
                    getScoreFromPlayerSql.Parameters.AddWithValue("@IdPlayer", idPlayer);

                    SqlDataReader sqlDataReader = getScoreFromPlayerSql.ExecuteReader();

                    if (sqlDataReader.Read())
                    {
                        playerDatabase = new Player((int) sqlDataReader[0], sqlDataReader[1].ToString(),
                            sqlDataReader[2].ToString(), sqlDataReader[3].ToString(), (int) sqlDataReader[4]);
                    }
                    else
                    {
                        playerDatabase = null;
                    }

                    return playerDatabase;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string IncrementScorePlayer(int idPlayer)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    // update score of the player in database  
                    SqlCommand updateScorePlayerSql =
                        new SqlCommand("UPDATE Player set score=@Score WHERE idPl = @idPlayer",
                            sqlConnection);
                    // Récupérer le score actuel du joueur et l'incrémenter de 1.
                    Player playerDatabase = GetPlayerById(idPlayer);
                    playerDatabase.Score += 1;

                    updateScorePlayerSql.Parameters.AddWithValue("@idPlayer", playerDatabase.Id);
                    updateScorePlayerSql.Parameters.AddWithValue("@Score", playerDatabase.Score);
                    // Vérifier si l'update est successful ou non
                    return updateScorePlayerSql.ExecuteNonQuery() == 1
                        ? "Score update successful"
                        : "Score update failure";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string SignupPlayer(string username, string password, string mail)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password) ||
                String.IsNullOrWhiteSpace(mail))
            {
                return "Error : Username, Password, Mail cannot be empty or null";
            }
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand registerPlayerSql =
                        new SqlCommand(
                            "INSERT INTO Player (username, password, mail)  VALUES (@Username,@Password,@Mail)",
                            sqlConnection);
                    registerPlayerSql.Parameters.AddWithValue("@Username", username);
                    registerPlayerSql.Parameters.AddWithValue("@Password", password);
                    registerPlayerSql.Parameters.AddWithValue("@Mail", mail);
                    return registerPlayerSql.ExecuteNonQuery() == 1 ? "Register sucessful" : "Register failure";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        private string CreateRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random random = new Random();
            while (0 < length--)
            {
                res.Append(valid[random.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
