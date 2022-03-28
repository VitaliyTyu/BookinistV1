using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using BookinistV1.Services;
using BookinistV1.Services.Interfaces;
using System.Windows.Input;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Bookinist.DAL.Context;

namespace BookinistV1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IUserDialog _UserDialog;
        private readonly IRepository<Book> _Books;
        private readonly ISalesService _Sales;
        private readonly IRepository<Buyer> _Buyers;
        private readonly IRepository<Deal> _Deals;
        private readonly IRepository<Seller> _Sellers;
        private readonly ISalesService _SalesService;



        #region Title : string - Заголовок
        /// <summary> Заголовок </summary>
        private string _Title = "Главное окно программы";

        /// <summary> Заголовок </summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region CurrentModel : ViewModel - Текущая VM
        /// <summary> Текущая дочерняя VM </summary>
        private ViewModel _CurrentModel;

        /// <summary> Текущая дочерняя VM </summary>
        public ViewModel CurrentModel
        {
            get => _CurrentModel;
            set => Set(ref _CurrentModel, value);
        }
        #endregion



        #region ShowBooksViewCommand : Command - Отобразить представление книг
        private ICommand _ShowBooksViewCommand;

        public ICommand ShowBooksViewCommand => _ShowBooksViewCommand ??= new LambdaCommand(OnShowBooksViewCommandExecuted, CanShowBooksViewCommandExecute);

        private bool CanShowBooksViewCommandExecute() => true;

        private void OnShowBooksViewCommandExecuted()
        {
            CurrentModel = new BooksViewModel(_Books, _UserDialog);
        }
        #endregion

        #region ShowBuyersViewCommand : Command - Отобразить представление покупателей
        private ICommand _ShowBuyersViewCommand;

        public ICommand ShowBuyersViewCommand => _ShowBuyersViewCommand ??= new LambdaCommand(OnShowBuyersViewCommandExecuted, CanShowBuyersViewCommandExecute);

        private bool CanShowBuyersViewCommandExecute() => true;

        private void OnShowBuyersViewCommandExecuted()
        {
            CurrentModel = new BuyersViewModel(_Buyers);
        }
        #endregion

        #region ShowStatisticViewCommand : Command - Отобразить представление статистики
        private ICommand _ShowStatisticViewCommand;

        public ICommand ShowStatisticViewCommand => _ShowStatisticViewCommand ??= new LambdaCommand(OnShowStatisticViewCommandExecuted, CanShowStatisticViewCommandExecute);

        private bool CanShowStatisticViewCommandExecute() => true;

        private void OnShowStatisticViewCommandExecuted()
        {
            CurrentModel = new StatisticViewModel(_Books, _Buyers, _Sellers, _Deals, _SalesService);
        }
        #endregion



        public MainWindowViewModel(
            IUserDialog UserDialog,
            IRepository<Book> Books, 
            ISalesService SalesService,
            IRepository<Buyer> Buyers,
            IRepository<Deal> Deals,
            IRepository<Seller> Sellers)
        {
            _UserDialog = UserDialog;
            _Books = Books;
            _Buyers = Buyers;
            _Deals = Deals;
            _Sellers = Sellers;
            _SalesService = SalesService;

            //Не будет колонки Categories, т.к. она virtual, и нужно создать специальный репозиторий для книг, чтобы заработало (Создан BooksRepository)
            //var books = BooksRepository.Items.Take(10).ToArray();


        }

        //public async void Test()
        //{
        //    var deals_count1 = _SalesService.Deals.Count();

        //    var book = await _BooksRepository.GetAsync(5);
        //    var buyer = await _Buyers.GetAsync(3);
        //    var seller = await _Sellers.GetAsync(7);

        //    var deal = _SalesService.MakeADeal(book.Name, seller, buyer, 100m);

        //    var deals_count2 = _SalesService.Deals.Count();

        //}

    }
}
