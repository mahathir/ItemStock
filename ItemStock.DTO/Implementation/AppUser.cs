using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Base;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Implementation
{
    public class AppUser : DTOBase, IAppUser
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
