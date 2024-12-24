
namespace DataAccess.Repository
{
    public interface IProductRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}
