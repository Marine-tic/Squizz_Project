using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squizz_Project
{
    public class Question
    {
        private int id;
        private string questionName; //on vire
        private string urlImage;
        private int idProposalAnswer;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string QuestionName
        {
            get
            {
                return questionName;
            }

            set
            {
                questionName = value;
            }
        }

        public string UrlImage
        {
            get
            {
                return urlImage;
            }

            set
            {
                urlImage = value;
            }
        }

        public int IdProposalAnswer //permet d'avoir un reférence, on peut s'en passer
        {
            get
            {
                return idProposalAnswer;
            }

            set
            {
                idProposalAnswer = value;
            }
        }

        public Question(int id, string question, string urlImage, int idProposalAnswer)
        {
            this.id = id;
            this.questionName = question;
            this.urlImage = urlImage;
            this.idProposalAnswer = idProposalAnswer;
        }
    }
}
