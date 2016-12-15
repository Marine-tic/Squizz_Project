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
        private string questionName;
        private string urlImage;
        private int idProposal;

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

        public int IdProposal
        {
            get
            {
                return idProposal;
            }

            set
            {
                idProposal = value;
            }
        }

        public Question(int id, string question, string urlImage, int idProposal)
        {
            this.id = id;
            this.questionName = question;
            this.urlImage = urlImage;
            this.idProposal = idProposal;
        }
    }
}
