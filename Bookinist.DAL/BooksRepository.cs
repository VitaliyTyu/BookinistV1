using Bookinist.DAL.Context;
using Bookinist.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookinist.DAL
{
    class BooksRepository : DbRepository<Book>
    {
        //показываем EF'у, что при загрузке данных из бд, нужно включать категории
        public override IQueryable<Book> Items => base.Items.Include(item => item.Category);

        public BooksRepository(BookinistDB db) : base(db) { }
    }
}
