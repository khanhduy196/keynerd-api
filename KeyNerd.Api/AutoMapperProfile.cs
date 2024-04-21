using KeyNerd.Api.Resolvers;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.DataTransfer.Responses;
using KeyNerd.DataTransfer.Settings;
using KeyNerd.Domain.Entities;
using KeyNerd.Service.Helpers;
using Microsoft.Extensions.Options;

namespace KeyNerd.Api
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMapForCreateRequest();
            CreateMapForUpdateRequest();
            CreateMapForResponse();

        }

        private void CreateMapForCreateRequest()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<CreateKeycapRequest, Keycap>().ForMember(m => m.Photos, act => act.Ignore());
            CreateMap<CreateKeycapDetailRequest, KeycapDetail>().ForMember(m => m.FileUrl, act => act.Ignore());
            CreateMap<UpdateKeycapDetailRequest, KeycapDetail>().ForMember(m => m.FileUrl, act => act.Ignore());
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<CreateOrderDetailRequest, OrderDetail>();
        }

        private void CreateMapForResponse()
        {
            CreateMap<Keycap, GetKeycapByIdResponse>()
                .ForMember(m => m.Photos, act => act.MapFrom<KeycapPhotosResolver>());
            CreateMap<Keycap, GetPaginatedKeycapListResponse>()
                .ForMember(m => m.Photos, act => act.MapFrom<KeycapPhotosResolver>());
            CreateMap<KeycapDetail, GetKeycapDetailByIdResponse>()
                .ForMember(m => m.FileUrl, act => act.MapFrom<KeycapDetailFileResolver>());
            CreateMap<KeycapDetail, GetPaginatedKeycapDetailListResponse>()
                .ForMember(m => m.FileUrl, act => act.MapFrom<KeycapDetailFileResolver>());
            CreateMap<Order, GetPaginatedOrderListResponse>();
            CreateMap<OrderDetail, GetPaginatedOrderDetailListResponse>()
                .ForMember(m => m.Id, act => act.MapFrom(mf => mf.KeycapDetail.Id))
                .ForMember(m => m.KeycapId, act => act.MapFrom(mf => mf.KeycapDetail.KeycapId))
                .ForMember(m => m.Profile, act => act.MapFrom(mf => mf.KeycapDetail.Profile))
                .ForMember(m => m.Size, act => act.MapFrom(mf => mf.KeycapDetail.Size))
                .ForMember(m => m.Name, act => act.MapFrom(mf => mf.KeycapDetail.Keycap.Name))
                .ForMember(m => m.Photos, act => act.MapFrom<OrderDetailPhotosResolver>())
                .ForMember(m => m.FileUrl, act => act.MapFrom<OrderDetailFileResolver>());
            CreateMap(typeof(PaginatedList<>), typeof(GetPaginatedListResponse<>));
        }

        private void CreateMapForUpdateRequest()
        {
            CreateMap<UpdateKeycapRequest, Keycap>();
        }
    }
}
