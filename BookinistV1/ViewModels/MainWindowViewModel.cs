using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinistV1.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Book> _BooksRepository;


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

        public MainWindowViewModel(IRepository<Book> BooksRepository)
        {
            _BooksRepository = BooksRepository;

            //Не будет колонки Categories, т.к. она virtual, и нужно создать специальный репозиторий для книг, чтобы заработало (Создан BooksRepository)
            var books = BooksRepository.Items.Take(10).ToArray();
        }
    }
}
