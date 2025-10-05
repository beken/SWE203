using System.Security.Cryptography.Xml;

namespace Homework1.Models{
    public static class Repository
    {
        private static List<Student> _students = new();

        static Repository()
        {
            _students.Add(new Student()
            {
                StudentID = "b261202001",
                Name = "Zeynep",
                Surname = "Yalçın",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 00, 20)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202002",
                Name = "Mehmet",
                Surname = "Yıldırım",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202003",
                Name = "İpek",
                Surname = "Yağmur",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202004",
                Name = "Onur",
                Surname = "Karaoğlu",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202005",
                Name = "Emir",
                Surname = "Kaya",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202006",
                Name = "Hacer",
                Surname = "Demirtaş",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 00, 40)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202007",
                Name = "Ezgi",
                Surname = "Yıldız",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202008",
                Name = "Gamze",
                Surname = "Polat",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 01, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202009",
                Name = "Emir",
                Surname = "Yılmaz",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202010",
                Name = "Berk",
                Surname = "Çetin",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 02, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202011",
                Name = "Melisa",
                Surname = "Arslan",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 10, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202012",
                Name = "Sude",
                Surname = "Uslu",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 15, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202013",
                Name = "Lina",
                Surname = "Collins",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202014",
                Name = "Maria",
                Surname = "Duret",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 22, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202015",
                Name = "Henrik",
                Surname = "Dahl",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202016",
                Name = "Freya",
                Surname = "Lindström",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 13, 50, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202017",
                Name = "Yousef",
                Surname = "Khalil",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202018",
                Name = "Murad",
                Surname = "Abbasov",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 14, 20, 00)
            });
            _students.Add(new Student()
            {
                StudentID = "b261202019",
                Name = "Elchin",
                Surname = "Rasulov",
                Signed = false,
                SignedAt = null
            });
            _students.Add(new Student()
            {
                StudentID = "b261202020",
                Name = "Layla",
                Surname = "Karim",
                Signed = true,
                SignedAt = new DateTime(2025, 10, 5, 14, 30, 00)
            });
        }
   }
}