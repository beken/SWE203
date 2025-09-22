using Microsoft.EntityFrameworkCore;


namespace SportsApp.Models{
    public class ProductCategory{

        public long ProductCategoryID {get; set;}

        public string Name {get; set;} = String.Empty;

        public string Description {get; set;} = String.Empty;

    }
}
