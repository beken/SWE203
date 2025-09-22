
using MeetingApp.Models;

public static class Repository{
    private static List<UserInfo> _users = new();

    static Repository(){
        _users.Add(new UserInfo(){
            id = 1,
            Name = "Beyza",
            Phone = "1234",
            Email = "beken@sakarya.edu.tr",
            WillAttend = true 
            });

            _users.Add(new UserInfo(){
            id = 2,
            Name = "Elif",
            Phone = "4321",
            Email = "elif@sakarya.edu.tr",
            WillAttend = true 
            });

            _users.Add(new UserInfo(){
            id = 3,
            Name = "Mehmet",
            Phone = "5555",
            Email = "mehmet@sakarya.edu.tr",
            WillAttend = true 
            });
    }

    public static List<UserInfo> users(){
        return _users;
    }

    public static UserInfo? GetById(int id){
        return _users.FirstOrDefault(user => user.id == id);
    }

    public static void CreateUser(UserInfo user){
        user.id = _users.Count + 1;
        _users.Add(user);
    }
}