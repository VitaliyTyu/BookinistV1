using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookinist.DAL.Entityes;

namespace BookinistV1.Services.Interfaces
{
    public interface ISalesService
    {
        IEnumerable<Deal> Deals { get; }
        Task<Deal> MakeADeal(string BookName, Seller Seller, Buyer Buyer, decimal Price);
    }
}
