using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace BookinistV1.ViewModels
{
    public class BooksViewModel : ViewModel
    {
        private readonly IRepository<Book> _Books;

        public BooksViewModel(IRepository<Book> books)
        {
            _Books = books;
        }
    }
}
