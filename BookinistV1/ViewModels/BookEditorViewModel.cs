using Bookinist.DAL.Entityes;
using MathCore.WPF.ViewModels;
using System;

namespace BookinistV1.ViewModels
{
    internal class BookEditorViewModel : ViewModel
    {
        public int BookId { get; }


        #region Name : string - название книги
        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
        #endregion

        public BookEditorViewModel()
            :this(new Book { Id = 1, Name = "Букварь"})
        {
                if (!App.IsDesignTime)
                    throw new InvalidOperationException("Не для рантайма");
        }

        public BookEditorViewModel(Book book)
        {
            BookId = book.Id;
            Name = book.Name;
        }
    }
}
