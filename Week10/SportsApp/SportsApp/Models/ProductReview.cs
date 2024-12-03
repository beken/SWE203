using Microsoft.EntityFrameworkCore;

namespace SportsApp.Models{
    public class ProductReview{

        //Properties of the entity:
        public long ProductReviewID {get; set;}
        
        public string ReviewerName {get; set;} = String.Empty;
        
        public string Title {get; set;} = String.Empty;
        
        public string Comment {get; set;} = String.Empty;
        
        public int Rating {get; set;} 

        //Relationships with other entities:
        public long ProductID {get; set;}

    }
}

