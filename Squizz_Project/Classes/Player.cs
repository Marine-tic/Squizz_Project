using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squizz_Project
{
    public class Player
    {
        #region PROPERTIES
        private int id;
        private string username;
        private string password;
        private string mail;

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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }
        #endregion

        public Player(int id, string username, string password, string mail)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.mail = mail;
        }
    }
}
