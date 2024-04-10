using KeyNerd.Infrastructure.Persistence;

namespace KeyNerd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Members

        private readonly AppDbContext _appDbContext;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        #endregion

        #region Methods

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        #endregion

        #region Events


        #endregion

    }
}
