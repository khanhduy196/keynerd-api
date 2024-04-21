using AutoMapper;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using Microsoft.Extensions.Options;

namespace KeyNerd.Api.Resolvers
{

    public class OrderDetailPhotosResolver : IValueResolver<OrderDetail, object, List<string>>
    {
        private readonly StorageSettings _storageSettings;
        public OrderDetailPhotosResolver(IOptions<StorageSettings> storageSettingsOption)
        {
            _storageSettings = storageSettingsOption.Value;
        }

        public List<string> Resolve(OrderDetail source, object destination, List<string> destMember, ResolutionContext context)
        {
            return source.KeycapDetail.Keycap.Photos.Select(photo => $"{_storageSettings.KeycapPhotoStorageUrl}/{photo.Url}").ToList();

        }
    }
}
