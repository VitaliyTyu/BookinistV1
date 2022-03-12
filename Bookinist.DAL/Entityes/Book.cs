using Bookinist.DAL.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.DAL.Entityes
{
    public class Book : NamedEntity
    {
        //virtual нужен для ленивой загрузеки из базы данных только тех книг, которе нам понадобились
        // virtual может как ускорить работу прилодения, так и замедлить (нужно разобраться)
        //у книги 1 катекория
        //Category - внешний ключ, но ef создаст его сам
        public virtual Category Category { get; set; }
    }
}
