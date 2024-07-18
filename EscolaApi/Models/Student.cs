namespace EscolaApi.Models
{
    public class Student : Person
    {
        public string Grade { get; set; }
        public Student(int id, string name, int age, string address, string grade) : base(id, name, age, address)
        {
            Grade = grade;
        }
    }
}
