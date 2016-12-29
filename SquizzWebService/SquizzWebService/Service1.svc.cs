using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SquizzWebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string AddNewQuestion(Question value)
        {
            string msg;
            SqlConnection connec = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename='D:\\Documents\\Visual Studio 2015\\Projects\\SquizzWebService\\SquizzWebService\\App_Data\\SquizzDatabase.mdf';Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO Question (Q_questionName, Q_urlImage)  VALUES (@QuestionName,@UrlImage)", connec);
            cmd.Parameters.AddWithValue("@QuestionName", value.QuestionName);
            cmd.Parameters.AddWithValue("@UrlImage", value.UrlImage);
            connec.Open();
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                msg = "Success";
            }
            else
            {
                msg = "Failure";
            }
            connec.Close();
            return msg;
        }

        public Question GetQuestionById(int value)
        {
            Question quest = new Question();

            SqlConnection connec = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename='D:\\Documents\\Visual Studio 2015\\Projects\\SquizzWebService\\SquizzWebService\\App_Data\\SquizzDatabase.mdf';Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Question WHERE Q_id=" + value, connec);
            connec.Open();
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (rd != null)
            {
                if (rd.Read())
                {
                    quest.Id = (int)rd[0];
                    quest.QuestionName = rd[1].ToString();
                    quest.UrlImage = rd[2].ToString();
                }
                else
                {
                    quest = null;
                }
            }


            return quest;
        }

    }
}
