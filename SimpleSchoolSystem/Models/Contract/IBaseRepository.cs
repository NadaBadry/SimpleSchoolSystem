namespace SimpleSchoolSystem.Models.Contract
{
    public interface IBaseRepository<T>where T : class
    {
        IEnumerable<T>? GetAll();
        T? GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
       void save();
    }
}
