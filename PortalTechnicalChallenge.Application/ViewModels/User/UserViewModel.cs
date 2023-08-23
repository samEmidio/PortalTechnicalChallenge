using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Application.ViewModels.User
{
    /// <summary>
    /// view model para retornar usuario
    /// </summary>

    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CreatedAt { get; set; }
    }
}
