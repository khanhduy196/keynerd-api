using AutoMapper;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using Microsoft.Extensions.Options;

namespace KeyNerd.Api.Resolvers
{

    public class OrderDetailFileResolver : IValueResolver<OrderDetail, object, string>
    {
        private readonly StorageSettings _storageSettings;
        public OrderDetailFileResolver(IOptions<StorageSettings> storageSettingsOption)
        {
            _storageSettings = storageSettingsOption.Value;
        }

        public string Resolve(OrderDetail source, object destination, string destMember, ResolutionContext context)
        {
            return string.IsNullOrEmpty(source.KeycapDetail.FileUrl) ? string.Empty : $"{_storageSettings.KeycapDetailFileStorageUrl}/{source.KeycapDetail.FileUrl}";
        }
    }
}
