namespace The_Task.Models.DataRepository
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetAll();
        Person GetByID(int id);
        void Add(Person item);
        void Update(int id, Person item);
        void Delete(int id);
    }
}
