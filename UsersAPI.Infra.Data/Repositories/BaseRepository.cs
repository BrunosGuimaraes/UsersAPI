using UsersAPI.Domain.Interfaces.Repositories;
using UsersAPI.Infra.Data.Contexts;

namespace UsersAPI.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DataContext dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Add(TEntity entity)
        {
            dataContext?.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
           dataContext?.Remove(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return dataContext?.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return dataContext?.Set<TEntity>().Where(where).ToList();
        }

        public  virtual TEntity? GetById(TKey id)
        {
            return dataContext?.Set<TEntity>().Find(id);
        }

        public virtual TEntity? GetById(Func<TEntity, bool> where)
        {
            return dataContext?.Set<TEntity>().FirstOrDefault(where);
        }

        public virtual void Update(TEntity entity)
        {
            dataContext?.Update(entity);
        }
        public virtual void Dispose()
        {
            dataContext?.Dispose();
        }
    }
}
