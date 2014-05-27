using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Implementation;
using ItemStock.DTO.Interface;

namespace ItemStock.Persistence
{
    public class ItemStockContext :DbContext
    {
        public DbSet<Good> Goods { get; set; }

        public DbSet<StockTransaction> StockTransactions { get; set; }

        public DbSet<StockTransactionItem> StockTransactionItems { get; set; }

        public DbSet<AppUser> Users { get; set; }
    }
}
