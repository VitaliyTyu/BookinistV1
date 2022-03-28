using Bookinist.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookinistV1.Services.Interfaces
{
    public interface IUserDialog
    {
        bool Edit(Book book);

        bool ConfirmInformation(string Information, string Caption);
        bool ConfirmWarning(string Warning, string Caption);
        bool ConfirmError(string Error, string Caption);
    }
}
