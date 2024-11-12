using Microsoft.EntityFrameworkCore;


namespace SportsApp.Models{
    public class Product{
  
        //Properties of the entity:
        public long ProductID {get; set;}

        public string Name {get; set;} = String.Empty;

        public string Description {get; set;} = String.Empty;

        public double Price {get; set;}

        //public string Category {get; set;} = String.Empty;

        //Navitagion properties (Relationships with other entities):
        public long ProductCategoryID {get; set;} //can be only one category
        //public ICollection<ProductReview> Reviews {get; set;} //can be zero to many reviews
    }
}

