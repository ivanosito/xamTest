using System;
using System.Collections.Generic;
using System.Text;

namespace xamTest.Models
{
    class Token
    {
        #region "Properties"

        public int id { get; set; }
        public string AccessToken { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }

        #endregion "Properties"

        #region "Constructors"

        public Token() { }

        #endregion "Cosntructors"
    }
}
