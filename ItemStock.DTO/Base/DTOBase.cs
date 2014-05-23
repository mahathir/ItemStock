using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Base
{
    public class DTOBase
    {
        public Guid Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? LastModifiedDateTime { get; set; }

        public IAppUser CreatedUser { get; set; }

        public IAppUser LastModifiedUser { get; set; }
    }
}
