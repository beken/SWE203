 public class MealOrder
    {
        public string OrderID { get; set; }
        public string StudentName { get; set; }
        public string MealName { get; set; }
        public bool Collected { get; set; }
        public DateTime? CollectedAt { get; set; }
    }