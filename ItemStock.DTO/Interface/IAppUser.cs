using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.DTO.Interface
{
    public interface IAppUser
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }
    }
}
