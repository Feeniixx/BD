namespace CW_3.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IndexNumber { get; set; }
        public string DateOFBirth { get; set; }
        public string Studies { get; set; }
        public string Form { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {IndexNumber} {DateOFBirth} {Studies} {Form} {Email} {FatherName} {MotherName}\n";
        }
    }
}