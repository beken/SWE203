public static class Repository
{
    private static List<Guest> guests = new();
    static Repository() {
        guests.Add(new Guest { Id = 1, Name = "Beyza", Phone = "6567", Email = "beken@sakarya.edu.tr", WillAttend = true });
        guests.Add(new Guest { Id = 2, Name = "Ayşe", Phone = "2135", Email = "ayse@xyz.com", WillAttend = false });
        guests.Add(new Guest { Id = 3, Name = "Ali", Phone = "3312", Email = "ali@xyz.com", WillAttend = true });
        guests.Add(new Guest { Id = 4, Name = "Hasan", Phone = "7548", Email = "hasan@xyz.com", WillAttend = true });
        guests.Add(new Guest { Id = 5, Name = "Mehmet", Phone = "3642", Email = "mehmet@xyz.com", WillAttend = false });
    }

    public static List<Guest> GetGuests() {
        return guests;
    }

    public static void CreateGuest(Guest guest)
    {
        guest.Id = guests.Count + 1;
        guests.Add(guest);
    }


}