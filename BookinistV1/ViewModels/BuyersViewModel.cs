using Bookinist.DAL.Entityes;
using Bookinist.Interfaces;
using MathCore.WPF.ViewModels;

namespace BookinistV1.ViewModels
{
    public class BuyersViewModel : ViewModel
    {
        private IRepository<Buyer> _Buyers;

        public BuyersViewModel(IRepository<Buyer> buyers)
        {
            _Buyers = buyers;
        }
    }
}
