using Bookinist.DAL.Context;
using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using BookinistV1.Models;
using BookinistV1.Services.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookinistV1.ViewModels
{
    public class StatisticViewModel : ViewModel
    {
        private readonly IRepository<Book> _Books;
        private readonly IRepository<Buyer> _Buyers;
        private readonly IRepository<Seller> _Sellers;
        private readonly IRepository<Deal> _Deals;
        private readonly ISalesService _SalesService;

        public ObservableCollection<BestSellerInfo> Bestsellers { get; } = new ObservableCollection<BestSellerInfo>();

        //#region BooksCount : int - количество книг
        //private int _BooksCount;

        //public int BooksCount
        //{
        //    get => _BooksCount;
        //    set => Set(ref _BooksCount, value);
        //}
        //#endregion


        #region ComputeStatisticCommand : Command - Вычислить статистические данные
        private ICommand _ComputeStatisticCommand;

        public ICommand ComputeStatisticCommand => _ComputeStatisticCommand ??= new LambdaCommandAsync(OnComputeStatisticCommandExecuted);

        private async Task OnComputeStatisticCommandExecuted()
        {
            await ComputeDealsStatisticAsync();
        }

        private async Task ComputeDealsStatisticAsync()
        {
            var bestsellers_query = _Deals.Items
                .GroupBy(b => b.Book.Id)
                .Select(deals => new { BookId = deals.Key, Count = deals.Count(), Sum = deals.Sum(d => d.Price) })
                .OrderByDescending(deals => deals.Count)
                .Take(5)
                .Join(_Books.Items,
                      deals => deals.BookId,
                      book => book.Id,
                      (deals, book) => new BestSellerInfo 
                      { 
                          Book = book, 
                          SellCount = deals.Count, 
                          SummCost = deals.Sum 
                      });

            Bestsellers.AddClear(await bestsellers_query.ToArrayAsync());


            //foreach (var bestseller in await bestsellers_query.ToArrayAsync())
            //    Bestsellers.Add(bestseller);
        }

        #endregion

        public StatisticViewModel(
            IRepository<Book> books, 
            IRepository<Buyer> buyers, 
            IRepository<Seller> sellers,
            IRepository<Deal> deals,
            ISalesService salesService)
        {
            _Books = books;
            _Buyers = buyers;
            _Sellers = sellers;
            _Deals = deals;
            _SalesService = salesService;
        }
    }
}