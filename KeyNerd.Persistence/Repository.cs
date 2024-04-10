using KeyNerd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace KeyNerd.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Members

        protected AppDbContext context;
        protected DbSet<TEntity> dbSet;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        #endregion

        #region Methods

        public virtual ValueTask<TEntity> GetByIdAsync(params object[] keyValues)
        {
            return dbSet.FindAsync(keyValues);
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(params object[] keyValues)
        {
            TEntity entityToDelete = dbSet.Find(keyValues);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return dbSet.AsQueryable();
        }

        #endregion

        #region Events

        #endregion

    }
}
