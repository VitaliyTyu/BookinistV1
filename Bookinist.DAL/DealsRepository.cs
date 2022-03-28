using Bookinist.DAL.Context;
using Bookinist.DAL.Entityes;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bookinist.DAL
{
    class DealsRepository : DbRepository<Deal>
    {
        //показываем EF'у, что при загрузке данных из бд, нужно включать все нижеперечисленное
        public override IQueryable<Deal> Items => base.Items
           .Include(item => item.Book)
           .Include(item => item.Seller)
           .Include(item => item.Buyer)
        ;

        public DealsRepository(BookinistDB db) : base(db) { }
    }
}
