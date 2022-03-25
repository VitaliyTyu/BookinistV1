using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using BookinistV1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookinistV1.Services
{
    public class SalesService : ISalesService
    {
        private readonly IRepository<Book> _Books;
        private readonly IRepository<Deal> _Deals;

        public IEnumerable<Deal> Deals => _Deals.Items;

        public SalesService(IRepository<Book> Books,
            IRepository<Seller> Sellers, 
            IRepository<Buyer> Buyers,
            IRepository<Deal> Deals)
        {
            _Books = Books;
            _Deals = Deals;
        }

        public async Task<Deal> MakeADeal(string BookName, Seller Seller, Buyer Buyer, decimal Price)
        {
            var book = await _Books.Items.FirstOrDefaultAsync(b => b.Name == BookName).ConfigureAwait(false);
            if (book is null) return null;

            var deal = new Deal
            {
                Price = Price,
                Book = book,
                Seller = Seller,
                Buyer = Buyer
            };

            return await _Deals.AddAsync(deal);

        }
    }
}
