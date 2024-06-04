using System.Threading.Tasks;

namespace KeyNerd.Infrastructure.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {

        #region Properties

        #endregion

        #region Methods

        void Delete(List<TEntity> entity);
        void Delete(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entityToUpdate);

        ValueTask<TEntity> GetByIdAsync(params object[] keyValues);

        Task<IList<TEntity>> GetAllAsync();

        IQueryable<TEntity> AsQueryable();

        #endregion

        #region Events

        #endregion
    }
}
