using KeyNerd.Domain.Entities;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Service.Contracts;

namespace KeyNerd.Service
{
    public class CategoryService : ICategoryService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Category> _repository;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion

        #region Methods

        public async Task Create(Category category)
        {
            _repository.Add(category);
            await _unitOfWork.CommitAsync();         
        }

        #endregion

        #region Events


        #endregion
    }
}
