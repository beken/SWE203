using SportsApp.Models;

namespace SportsApp.ViewModels
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<ProductCategory> Categories { get; set; }
    }
}
