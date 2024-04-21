using AutoMapper;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using Microsoft.Extensions.Options;

namespace KeyNerd.Api.Resolvers
{

    public class KeycapDetailFileResolver : IValueResolver<KeycapDetail, object, string>
    {
        private readonly StorageSettings _storageSettings;
        public KeycapDetailFileResolver(IOptions<StorageSettings> storageSettingsOption)
        {
            _storageSettings = storageSettingsOption.Value;
        }

        public string Resolve(KeycapDetail source, object destination, string destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.FileUrl) ? string.Empty : $"{_storageSettings.KeycapDetailFileStorageUrl}/{source.FileUrl}";
        }
    }
}
