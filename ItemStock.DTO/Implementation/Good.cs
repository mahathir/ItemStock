using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Base;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Implementation
{
    public class Good : DTOBase, IGood
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ILocalFile Picture { get; set; }

        public int Stock { get; set; }

        public decimal BuyPrice { get; set; }

        public decimal MinimalSellPrice { get; set; }
    }
}
