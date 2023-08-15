namespace EsportFTW_DAL.Interface
{
    public interface IRepository<T, out TReturn>
    {
        IEnumerable<T> Get();
        T Get(int id);
        TReturn Add(T entity);
        TReturn Update(T entity);
        TReturn Delete(int id);
    }
}
