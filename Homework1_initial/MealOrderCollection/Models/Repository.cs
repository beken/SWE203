public static class Repository
{
    private static List<MealOrder> _mealOrders = new();

    static Repository()
    {
        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O001",
            StudentName = "Zeynep Yalçın",
            MealName = "Chicken Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 10, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O002",
            StudentName = "Mehmet Yıldırım",
            MealName = "Pasta Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O003",
            StudentName = "İpek Yağmur",
            MealName = "Vegetarian Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O004",
            StudentName = "Onur Karaoğlu",
            MealName = "Meatball Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O005",
            StudentName = "Emir Kaya",
            MealName = "Chicken Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 20, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O006",
            StudentName = "Hacer Demirtaş",
            MealName = "Soup Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O007",
            StudentName = "Ezgi Yıldız",
            MealName = "Pasta Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 25, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O008",
            StudentName = "Gamze Polat",
            MealName = "Vegetarian Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O009",
            StudentName = "Emir Yılmaz",
            MealName = "Meatball Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O010",
            StudentName = "Berk Çetin",
            MealName = "Chicken Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 35, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O011",
            StudentName = "Melisa Arslan",
            MealName = "Pasta Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 40, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O012",
            StudentName = "Sude Uslu",
            MealName = "Soup Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O013",
            StudentName = "Lina Collins",
            MealName = "Vegetarian Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O014",
            StudentName = "Maria Duret",
            MealName = "Chicken Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 12, 50, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O015",
            StudentName = "Henrik Dahl",
            MealName = "Meatball Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O016",
            StudentName = "Freya Lindström",
            MealName = "Pasta Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 13, 0, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O017",
            StudentName = "Yousef Khalil",
            MealName = "Soup Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O018",
            StudentName = "Murad Abbasov",
            MealName = "Chicken Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 13, 10, 0)
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O019",
            StudentName = "Elchin Rasulov",
            MealName = "Vegetarian Menu",
            Collected = false,
            CollectedAt = null
        });

        _mealOrders.Add(new MealOrder()
        {
            OrderID = "O020",
            StudentName = "Layla Karim",
            MealName = "Meatball Menu",
            Collected = true,
            CollectedAt = new DateTime(2026, 10, 5, 13, 20, 0)
        });
    }

    
}
