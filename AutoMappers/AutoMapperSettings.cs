using AutoMapper;
using DailyAPP.WebAPI.DataModel;
using DailyAPP.WebAPI.DTOs;

namespace DailyAPP.WebAPI.AutoMappers
{
    public class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            CreateMap<AccountInfoDTO, AccountInfo>().ReverseMap();
            CreateMap<MenuInfo, MenuInfoDTO>().ReverseMap();
            CreateMap<WaitInfoDTO, WaitInfo>().ReverseMap();
            CreateMap<MemoInfo, MemoInfoDTO>().ReverseMap();
        }
    }
}
