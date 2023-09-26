using System.Linq.Expressions;

namespace RailwayStation.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

        List<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
        T GetByID(int id);
    }
}
