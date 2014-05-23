using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Base;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Implementation
{
    public class StockTransactionItem : DTOBase, IStockTransactionItem
    {
        public IGood Item { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
