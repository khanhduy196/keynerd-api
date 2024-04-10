namespace KeyNerd.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        #region Properties

        #endregion

        #region Methods

        Task<int> CommitAsync();

        #endregion

        #region Events

        #endregion
    }
}
