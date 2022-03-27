using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using BookinistV1.Infrostructure.DebugServices;
using MathCore.WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace BookinistV1.ViewModels
{
    public class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> _BooksRepository;

        #region BooksFilter : string - искомое слово
        private string _BooksFilter;

        public string BooksFilter
        {
            get => _BooksFilter;
            set
            {
                if (Set(ref _BooksFilter, value))
                    _BooksViewSource.View.Refresh();
            }
        }
        #endregion

        private CollectionViewSource _BooksViewSource;

        public ICollectionView BooksView => _BooksViewSource.View;

        public IEnumerable<Book> Books => _BooksRepository.Items;



        public BooksViewModel()
            : this(new DebugBooksRepository())
        {
            if (!App.IsDesignTime)
                throw new InvalidOperationException("Данный корнструктор не предназначен для использования вне дизайнера студии");
        }

        public BooksViewModel(IRepository<Book> books)
        {
            _BooksRepository = books;

            _BooksViewSource = new CollectionViewSource
            {
                Source = _BooksRepository.Items.ToArray(),
                SortDescriptions =
                {
                    new SortDescription(nameof(Book.Name), ListSortDirection.Ascending)
                }
            };

            _BooksViewSource.Filter += OnBooksFilter;
        }

        private void OnBooksFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Book book) || string.IsNullOrEmpty(BooksFilter)) return;

            if (!book.Name.Contains(BooksFilter))
                e.Accepted = false;
        }
    }
}
