using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Implementation;

namespace ItemStock.Persistence.Data
{
    public class TestData
    {
        public static List<AppUser> AppUsers = new List<AppUser>
        {
            new AppUser
            {
                Id = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now,
                Name = "Admin",
                Password = "123456",
                Username = "admin"
            }
        };
    }
}
