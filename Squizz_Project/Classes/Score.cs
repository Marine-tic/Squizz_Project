using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squizz_Project
{
    public class Score
    {
        #region PROPERTIES
        private int id;
        private int playerScore;
        private int idPlayer;

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

        public int PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }

        public int IdPlayer
        {
            get
            {
                return idPlayer;
            }

            set
            {
                idPlayer = value;
            }
        }
        #endregion

        public Score(int id, int playerScore, int idPlayer)
        {
            this.id = id;
            this.playerScore = playerScore;
            this.idPlayer = idPlayer;
        }
    }
}
