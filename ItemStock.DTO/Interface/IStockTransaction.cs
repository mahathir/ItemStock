using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.DTO.Interface
{
    public interface IStockTransaction
    {
        Guid Id { get; set; }

        ICollection<IStockTransactionItem> TransactionItem { get; set; }

        DateTime TransactionDate { get; set; }

        IAppUser PersonInCharge { get; set; }

        IAppUser Customer { get; set; }

        decimal TotalPrice { get; set; }
    }
}
