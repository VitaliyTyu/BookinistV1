using Bookinist.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.DAL.Entityes
{
    public class Category : NamedEntity
    {
        //virtual нужен для ленивой загрузеки из базы данных только тех категорий, которе нам понадобились
        // virtual может как ускорить работу прилодения, так и замедлить (нужно разобраться)
        //Books - внешний ключ, но ef создаст его сам
        //в категории много книг
        public virtual ICollection<Book> Books { get; set; }
        public override string ToString() => $"Категория {Name}";

    }
}
