namespace MeetingApp.Models
{
    public static class Repository{    

        private static List<UserInfo> _users = new();

        static Repository(){
            _users.Add(new UserInfo(){
                id=1, Name="Ahmet", Email="ahmet@gmail.com", Phone="1234", WillAttend=true
            });
              _users.Add(new UserInfo(){
                id=2, Name="Mehmet", Email="mehmet@gmail.com", Phone="1235", WillAttend=true
            });
              _users.Add(new UserInfo(){
                id=3, Name="Ayse", Email="ayse@gmail.com", Phone="1236", WillAttend=true
            });
        }
        
        public static List<UserInfo> users{
            get{
               return _users;
            }
        }

        public static void CreateUser(UserInfo user){
            user.id = users.Count + 1;
            _users.Add(user);
        }

        public static UserInfo? GetById(int Id){
            return _users.FirstOrDefault(user => user.id == Id);
        }
    }

}
