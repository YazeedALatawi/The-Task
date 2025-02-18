
namespace The_Task.Models.DataRepository
{
    public class PersonRepo : IPersonRepo
    {
        private readonly List<Person> _persons = new List<Person>();
        public void Add(Person item)
        {
            item.Id = (item.Id == 0 && !_persons.Any()) ? 1 : _persons.Max(a => a.Id) + 1;
            _persons.Add(item);
        }

        public void Delete(int id)
        {
            var item = GetByID(id);
            if(item != null)
            {
                _persons.Remove(item);
            }
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public Person GetByID(int id)
        {
            return _persons.FirstOrDefault(a => a.Id == id);
        }

        public void Update(int id, Person item)
        {
            var existingItem = GetByID(id);
            if(existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Age = item.Age;
            }
        }
    }
}
