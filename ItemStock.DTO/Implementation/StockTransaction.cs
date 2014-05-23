using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Base;
using ItemStock.DTO.Interface;

namespace ItemStock.DTO.Implementation
{
    public class StockTransaction : DTOBase, IStockTransaction
    {
        public ICollection<IStockTransactionItem> TransactionItem { get; set; }

        public DateTime TransactionDate { get; set; }

        public IAppUser PersonInCharge { get; set; }

        public IAppUser Customer { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
