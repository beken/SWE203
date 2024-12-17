using SportsApp.Models;

public class Order {
    public long OrderID {get; set;}
    //public DateTime OrderDate {get; set;}
    public List<Product> products {get; set;} = new List<Product>();

    //public long Customer {get; set;}, payment

}

public class ShippingOrder:Order {

    public string ShippingAddress {get; set;}
    public string ShippingFirm {get; set;}

}

public class SubscriptionOrder:Order {

    public string RenewalDate {get; set;}

    public string RenewalPeriod {get; set;} //monthly yearly

}