namespace StudentAttendanceApp.Models {
    public static class Repository {    
        private static List<Student> _students = new();
        public static List<Student> Students (){
            return _students;
        }
        static Repository(){
            _students.Add(new Student(){ StudentID = "b251202001", Name = "Elif", Signed = true });
            _students.Add(new Student(){ StudentID = "b251202002", Name = "Mehmet", Signed = false });
            _students.Add(new Student(){ StudentID = "b251202003", Name = "İpek", Signed = false });
            _students.Add(new Student(){ StudentID = "b251202004", Name = "Naci", Signed = false });
            _students.Add(new Student(){ StudentID = "b251202005", Name = "Hacer", Signed = true });           
        }

        //IMPLEMENT HERE:
        public static List<Student> students(){
            return _students;
        }
        //
    }
}