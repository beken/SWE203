using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace SportsApp.Models{
    public class Product{
  
        //Properties of the entity:
        public long ProductID {get; set;}

        public string Name {get; set;} = String.Empty;

        public string Description {get; set;} = String.Empty;

        public double Price {get; set;}

        //Navitagion properties (Relationships with other entities):
    
        public long ProductCategoryID {get; set;} 
        public ProductCategory ProductCategory {get; set;} 
        
        public ICollection<ProductReview> Reviews {get; set;} 
    }
}

