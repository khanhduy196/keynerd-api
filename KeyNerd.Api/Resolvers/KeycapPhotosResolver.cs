using AutoMapper;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using Microsoft.Extensions.Options;

namespace KeyNerd.Api.Resolvers
{

    public class KeycapPhotosResolver : IValueResolver<Keycap, object, List<string>>
    {
        private readonly StorageSettings _storageSettings;
        public KeycapPhotosResolver(IOptions<StorageSettings> storageSettingsOption)
        {
            _storageSettings = storageSettingsOption.Value;
        }

        public List<string> Resolve(Keycap source, object destination, List<string> destMember, ResolutionContext context)
        {
            return source.Photos.Select(photo => $"{_storageSettings.KeycapPhotoStorageUrl}/{photo.Url}").ToList();

        }
    }
}
