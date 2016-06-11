using System;
using AutoMapper;
using Google.Apis.Books.v1.Data;
using RL.RemoteData.Contract.RemoteModels;

namespace RL.RemoteData.Contract.Configuration
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Volume.VolumeInfoData.ImageLinksData, ImageLinksDto>();

            Mapper.CreateMap<Volume, BookDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.VolumeInfo.Authors))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.VolumeInfo.Categories))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.VolumeInfo.Description))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.VolumeInfo.ImageLinks))
                .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.VolumeInfo.Publisher))
                .ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => src.VolumeInfo.Subtitle))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.VolumeInfo.Title))
                .ForMember(dest => dest.PublishDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow)); //DateTime.Parse(src.VolumeInfo.PublishedDate)));
        }
    }
}
