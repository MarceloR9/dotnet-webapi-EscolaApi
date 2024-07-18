using EscolaApi.Data;
using EscolaApi.Models;

namespace EscolaApi.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly EscolaContext _context;

        public PersonRepository(EscolaContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _context.Persons.Find(id);
        }

        public void Add(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges();
            }
        }
    }
}
