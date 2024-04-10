using AutoMapper;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Service.Contracts;
using KeyNerd.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KeyNerd.Service
{
    public class KeycapService : IKeycapService
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Keycap> _repository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly StorageSettings _storageSettings;
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public KeycapService(IUnitOfWork unitOfWork, IRepository<Keycap> repository, IStorageService storageService, IMapper mapper, IOptions<StorageSettings> storageSettingsOption)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _storageService = storageService;
            _mapper = mapper;
            _storageSettings = storageSettingsOption.Value;
        }

        #endregion

        #region Methods

        public async Task<Keycap> Create(CreateKeycapRequest request)
        {
            var keycap = _mapper.Map<Keycap>(request);

            var photoUrls = await _storageService.UploadFiles(_storageSettings.KeycapPhotoStorageName, request.Photos);
            keycap.Photos = photoUrls.Select(photoUrl => new KeycapPhoto { Url = photoUrl }).ToList();

            int keycapDetaislLength = keycap.Details.Count();
            for (int i = 0; i < keycapDetaislLength; i++)
            {
                if (request.Details[i].File != null)
                {
                    keycap.Details[i].FileUrl = await _storageService.UploadFile(_storageSettings.KeycapDetailFileStorageName, request.Details[i].File);
                }
            }

            _repository.Add(keycap);
            await _unitOfWork.CommitAsync();

            return keycap;
        }



        public async Task Delete(long id)
        {
            var keycap = await _repository.GetByIdAsync(id);
            if (keycap != null)
            {
                _repository.Delete(keycap);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<Keycap> GetById(long id)
        {
            var keycap = await _repository.AsQueryable()
                .Include(n => n.Photos)
                .Include(n => n.Details).SingleOrDefaultAsync(x => x.Id == id);

            if (keycap == null)
                throw new Exception();

            return keycap;
        }

        public PaginatedList<Keycap> GetList(int itemsPerPage, int currentPage, string? searchQuery)
        {
            var data = _repository.AsQueryable().Include(n => n.Details).AsQueryable();

            if(!string.IsNullOrEmpty(searchQuery))
            {
                data = data.Where(n => n.Name.ToLower().Contains(searchQuery.ToLower()));
            }

            var list = new PaginatedList<Keycap>(itemsPerPage, currentPage, data);

            return list;
        }

        public async Task Update(UpdateKeycapRequest request)
        {
            var updated = _mapper.Map<Keycap>(request);

            var keycap = await _repository.AsQueryable().Include(n => n.Details).FirstOrDefaultAsync(n => n.Id == updated.Id);

            if(keycap is null)
            {
                throw new Exception();
            }

            int keycapDetaislLength = request.Details.Count();
            for (int i = 0; i < keycapDetaislLength; i++)
            {
                if (request.Details[i].File != null)
                {
                    updated.Details[i].FileUrl = await _storageService.UploadFile(_storageSettings.KeycapDetailFileStorageName, request.Details[i].File);
                }
            }

            keycap.Name = updated.Name;
            keycap.Details.AddRange(updated.Details);

            await _unitOfWork.CommitAsync();
        }

        #endregion

        #region Events


        #endregion
    }
}
