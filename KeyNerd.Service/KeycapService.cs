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
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly StorageSettings _storageSettings;
        #endregion

        #region Properties

        #endregion

        #region Constructors

        public KeycapService(IUnitOfWork unitOfWork, IRepository<Keycap> repository, IStorageService storageService, IMapper mapper, IOptions<StorageSettings> storageSettingsOption, IRepository<OrderDetail> orderDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _storageService = storageService;
            _mapper = mapper;
            _storageSettings = storageSettingsOption.Value;
            _orderDetailRepository = orderDetailRepository;
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
            var data = _repository.AsQueryable().Include(n => n.Details).Include(n => n.Photos).AsQueryable();

            if(!string.IsNullOrEmpty(searchQuery))
            {
                data = data.Where(n => n.Name.ToLower().Contains(searchQuery.ToLower()));
            }

            data = data.OrderBy(n => n.Name);

            var list = new PaginatedList<Keycap>(itemsPerPage, currentPage, data);

            return list;
        }

        public async Task Update(UpdateKeycapRequest request)
        {
            var keycap = await _repository.AsQueryable().Include(n => n.Details).FirstOrDefaultAsync(n => n.Id == request.Id);

            if(keycap is null)
            {
                throw new Exception();
            }

            var existingDetailIds = request.Details.Where(n => n.Id != 0).Select(n =>  n.Id).ToList();
            var deletedDetailIds = keycap.Details.Where(n => !existingDetailIds.Contains(n.Id)).Select(n => n.Id).ToList();

            if(_orderDetailRepository.AsQueryable().Any(n => deletedDetailIds.Contains(n.KeycapDetailId)))
            {
                throw new Exception("Cannot delete used detail id");
            }

            var updatedKeycap = _mapper.Map<Keycap>(request);

            int keycapDetaislLength = request.Details.Count();
            for (int i = 0; i < keycapDetaislLength; i++)
            {
                if (request.Details[i].File != null)
                {
                    updatedKeycap.Details[i].FileUrl = await _storageService.UploadFile(_storageSettings.KeycapDetailFileStorageName, request.Details[i].File);
                }
            }

            keycap.Name = updatedKeycap.Name;

            // remove deleted details from the list
            keycap.Details = keycap.Details.Where(n => existingDetailIds.Contains(n.Id)).ToList();
            // update existing details
            var updatedDetails = updatedKeycap.Details.Where(n => n.Id != 0);
            foreach (var detail in keycap.Details)
            {
                var updatedDetai = updatedDetails.FirstOrDefault(n => n.Id == detail.Id);
                if (updatedDetai is not null)
                {
                    detail.Profile = updatedDetai.Profile;
                    detail.Size = updatedDetai.Size;
                    if (!string.IsNullOrEmpty(updatedDetai.FileUrl))
                    {
                        detail.FileUrl = updatedDetai.FileUrl;
                    }
                }
            }
            // add newly added details
            var newlyAddedDetais = updatedKeycap.Details.Where(n => n.Id == 0);
            keycap.Details.AddRange(newlyAddedDetais);

            await _unitOfWork.CommitAsync();
        }

        public async Task<List<KeycapDetail>> GetUsedDetailsOfKeycap(long id)
        {
            var keycap = await _repository.AsQueryable().Include(n => n.Details).SingleOrDefaultAsync(x => x.Id == id);

            if (keycap is null)
                return new List<KeycapDetail>() { };

            var existingDetailIds = keycap.Details.Select(n => n.Id).ToList();
            var usedDetailIds = _orderDetailRepository.AsQueryable().Where(n => existingDetailIds.Contains(n.KeycapDetailId))
                .Select(n => n.KeycapDetailId)
                .Distinct().ToList();
            return keycap.Details.Where(n => usedDetailIds.Contains(n.Id)).ToList();

        }

        #endregion

        #region Events


        #endregion
    }
}
