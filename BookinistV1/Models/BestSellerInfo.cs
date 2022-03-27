using Bookinist.DAL.Entityes;

namespace BookinistV1.Models
{
    public class BestSellerInfo
    {
        public Book Book { get; set; }
        public int SellCount { get; set; }
        public decimal SummCost { get; set; }
    }
}
