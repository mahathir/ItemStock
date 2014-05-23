using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.DTO.Interface
{
    public interface IStockTransactionItem
    {
        Guid Id { get; set; }

        IGood Item { get; set; }

        int Count { get; set; }

        decimal TotalPrice { get; set; }
    }
}
