
namespace DataAccess.Repository.IReq
{
    public interface IUserRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}
