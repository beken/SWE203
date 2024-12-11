using Microsoft.EntityFrameworkCore;


namespace SportsApp.Models{
    public class Product{
  
        // Properties of the entity (entity's own properties such as primary key):

        //  <TypeName>Id (in our case ProductID) will be configured as primary key --> this is the convention set by .net.
        //  Also, you can configure the primary key by putting [Key] property at the beginning of primary key variable.
        //  MORE: https://learn.microsoft.com/en-us/ef/core/modeling/keys?tabs=data-annotations
        public long ProductID {get; set;}

        public string Name {get; set;} = String.Empty;

        public string Description {get; set;} = String.Empty;

        public double Price {get; set;}



        //Navitagion properties (Relationships with other entities):
        //To define a foreign key, either use [ForeignKey("ProductCategory")] 
        //or use the .net naming convention <TypeName>Id (TypeName is the entity name)
        public long ProductCategoryID {get; set;} //ProductCategory foreign key 
        public ProductCategory ProductCategory { get; set; } //ProductCategory entity --> this is used to ease the navigation from Product to ProductCategory

        public ICollection<ProductReview> Reviews {get; set;} 

        public ICollection<Order> Orders {get; set;} 
    }
}

