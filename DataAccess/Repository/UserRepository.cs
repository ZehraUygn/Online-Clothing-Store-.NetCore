using DataAccess.Database;
using DataAccess.Repository.IReq;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace DataAccess.Repository
{
    public class UserRepository<TEntity> : IUserRepository<TEntity> where TEntity : class
    {
        private readonly UserContext context;
        public UserRepository(UserContext context)
        {
            this.context = context;
        }
        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public TEntity Insert(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
        public bool Delete(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}




