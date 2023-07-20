namespace EsportFTW_DAL.Interface
{
    internal interface IRepository<T, out TReturn>
    {
        IEnumerable<T> Get();
        T Get(int id);
        TReturn Add(T entity);
        TReturn Update(T entity);
        TReturn Delete(int id);
    }
}
