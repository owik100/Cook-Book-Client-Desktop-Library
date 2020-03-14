using Cook_Book_Client_Desktop_Library.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cook_Book_Client_Desktop_Library.Models
{
   public class LoggedUser : ILoggedUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }

        public void LogOffUser()
        {
            Id = "";
            Email = "";
            UserName = "";
            Token = "";
        }
    }
}
