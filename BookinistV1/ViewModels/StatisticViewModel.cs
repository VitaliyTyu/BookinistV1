using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace BookinistV1.ViewModels
{
    public class StatisticViewModel : ViewModel
    {
        private IRepository<Book> _Bbooks;
        private IRepository<Buyer> _Buyers;
        private IRepository<Seller> _Sellers;

        public StatisticViewModel(IRepository<Book> books, IRepository<Buyer> buyers, IRepository<Seller> sellers)
        {
            _Bbooks = books;
            _Buyers = buyers;
            _Sellers = sellers;
        }
    }
}
