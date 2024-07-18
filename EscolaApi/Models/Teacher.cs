namespace EscolaApi.Models
{
    public class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(int id, string name, int age, string address, string subject) : base(id, name, age, address)
        {
            Subject = subject;
        }
    }
}
