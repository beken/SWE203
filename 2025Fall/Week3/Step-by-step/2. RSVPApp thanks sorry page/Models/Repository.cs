namespace RSVPApp.Models
{
    public static class Repository
    {
        private static List<Guest> guests = new();
        static Repository()
        {
            guests.Add(new Guest { Id = 1, Name = "Beyza", Email = "beken@sakarya.edu.tr", Phone = "1234", WillAttend = true });
            guests.Add(new Guest { Id = 2, Name = "Ayşe", Email = "ayse@xyz.com", Phone = "2345", WillAttend = true });
            guests.Add(new Guest { Id = 3, Name = "Ali", Email = "ali@xyz.com", Phone = "3446", WillAttend = false });
            guests.Add(new Guest { Id = 4, Name = "Hasan", Email = "hasan@xyz.com", Phone = "7642", WillAttend = true });
            guests.Add(new Guest { Id = 5, Name = "Gamze", Email = "gamze@xyz.com", Phone = "4436", WillAttend = false });
        }

        public static List<Guest> GetGuests()
        { return guests; }

        public static void CreateGuest(Guest guest)
        {
            guest.Id = guests.Count() + 1;
            guests.Add(guest);
        }
    }
}