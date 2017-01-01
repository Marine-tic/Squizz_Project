using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squizz_Project
{
    public class Proposal
    {
        #region PROPERTIES
        private int id;
        private string proposalName;
        private bool isAnswer;
        private string theme;
        private int idQuestion;

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

        public string ProposalName
        {
            get
            {
                return proposalName;
            }

            set
            {
                proposalName = value;
            }
        }

        public bool IsAnswer
        {
            get
            {
                return isAnswer;
            }

            set
            {
                isAnswer = value;
            }
        }

        public string Theme
        {
            get
            {
                return theme;
            }

            set
            {
                theme = value;
            }
        }

        public int IdQuestion
        {
            get
            {
                return idQuestion;
            }

            set
            {
                idQuestion = value;
            }
        }
        #endregion

        public Proposal(int id, string proposalName, bool isAnswer, int idQuestion)
        {
            this.id = id;
            this.proposalName = proposalName;
            this.isAnswer = isAnswer;
            this.idQuestion = idQuestion;
        }
    }
}
