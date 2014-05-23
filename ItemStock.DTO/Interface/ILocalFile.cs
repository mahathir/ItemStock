using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.DTO.Interface
{
    public interface ILocalFile
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Location { get; set; }
    }
}
