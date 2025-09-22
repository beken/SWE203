namespace MeetingApp.Models{
    public class User{
        public string Name{get; set;} = string.Empty;

        public static User[] GetUsers(){
            User user1 = new User{Name = "Ali Ali"};
            User user2 = new User{Name = "Ayşe Ayşe"};
            User user3 = new User{Name = "Elif Elif"};

            return new User[] {user1, user2, user3};
        }
    }
}