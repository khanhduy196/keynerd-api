using KeyNerd.DataTransfer.Requests;
using KeyNerd.DataTransfer.Responses;
using KeyNerd.Domain.Entities;
using KeyNerd.Service.Helpers;

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
                .ForMember(m => m.Photos, act => act.MapFrom(mf => mf.Photos.Select(photo => $"https://keynerd-keycap-photos.s3.ap-southeast-1.amazonaws.com/{photo.Url}")));
            CreateMap<Keycap, GetPaginatedKeycapListResponse>();
            CreateMap<KeycapDetail, GetKeycapDetailByIdResponse>()
                .ForMember(m => m.FileUrl, act => act.MapFrom(mf => string.IsNullOrEmpty(mf.FileUrl) ? string.Empty : $"https://keynerd-keycap-details-file.s3.ap-southeast-1.amazonaws.com/{mf.FileUrl}"));
            CreateMap<KeycapDetail, GetPaginatedKeycapDetailListResponse>();

            CreateMap<Order, GetPaginatedOrderListResponse>();
            CreateMap<OrderDetail, GetPaginatedOrderDetailListResponse>()
                .ForMember(m => m.Id, act => act.MapFrom(mf => mf.KeycapDetail.Id))
                .ForMember(m => m.KeycapId, act => act.MapFrom(mf => mf.KeycapDetail.KeycapId))
                .ForMember(m => m.Profile, act => act.MapFrom(mf => mf.KeycapDetail.Profile))
                .ForMember(m => m.Size, act => act.MapFrom(mf => mf.KeycapDetail.Size))
                .ForMember(m => m.Name, act => act.MapFrom(mf => mf.KeycapDetail.Keycap.Name))
                .ForMember(m => m.Photos, act => act.MapFrom(mf => mf.KeycapDetail.Keycap.Photos.Select(n => $"https://keynerd-keycap-photos.s3.ap-southeast-1.amazonaws.com/{n.Url}")));
            CreateMap(typeof(PaginatedList<>), typeof(GetPaginatedListResponse<>));
        }

        private void CreateMapForUpdateRequest()
        {
            CreateMap<UpdateKeycapRequest, Keycap>();
        }
    }
}
