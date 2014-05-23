using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Base;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Implementation
{
    public class LocalFile : DTOBase, ILocalFile
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
