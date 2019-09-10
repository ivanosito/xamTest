using System;
using System.Collections.Generic;
using System.Text;

using xamTest.Data;

namespace xamTest.Models
{
    public class User
    {
        #region "Properties"

        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion "Properties"

        #region "Constructors"

        public User() { }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        #endregion "Constructors"

        #region "Methods"

        public bool ValidarDatos() => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password));

        #endregion "Methods"
    }
}
