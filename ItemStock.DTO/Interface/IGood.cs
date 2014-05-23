using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.DTO.Interface
{
    public interface IGood
    {
        Guid Id { get; set; }

        string Code { get; set; }

        string Name { get; set; }

        ILocalFile Picture { get; set; }

        int Stock { get; set; }

        decimal BuyPrice { get; set; }

        decimal MinimalSellPrice { get; set; }
    }
}
