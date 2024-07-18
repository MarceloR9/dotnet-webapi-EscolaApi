namespace EscolaApi.Models
{
    public class AdminStaff : Person
    {
        public string Department { get; set; }
        public AdminStaff(int id, string name, int age, string address, string department) : base(id, name, age, address)
        {
            Department = department;
        }
    }
}
