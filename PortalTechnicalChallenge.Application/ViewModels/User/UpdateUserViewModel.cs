using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Application.ViewModels.User
{

    /// <summary>
    /// view model para atualizar usuario
    /// </summary>

    public class UpdateUserViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }
}
