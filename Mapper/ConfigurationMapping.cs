using AutoMapper;
using cineweb_movies_api.DTO;
using cineweb_movies_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cineweb_movies_api.Mapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<UserMovieDTO, Filme>().ForMember(x => x.Poster, opt => opt.Ignore());
            CreateMap<CreateMovieDTO, Filme>().ForMember(x => x.Poster, opt => opt.Ignore());

            CreateMap<Filme, UserMovieDTO>().ForMember(x => x.Poster, opt => opt.MapFrom(y => "data:image/webp;base64," + Convert.ToBase64String(y.Poster)));
            CreateMap<Filme, CreateMovieDTO>().ForMember(x => x.Poster, opt => opt.MapFrom(y => "data:image/webp;base64," + Convert.ToBase64String(y.Poster)));

            CreateMap<UpdateMovieDTO, Filme>().ForMember(x => x.Poster, opt => opt.Ignore());

            CreateMap<MovieDTO, Filme>()
            .ForMember(dest => dest.Id, src => src.MapFrom(x => Guid.Parse(x.Id)));

            CreateMap<Filme, MovieDTO>()
           .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id.ToString()))
           .ForMember(x => x.Poster, opt => opt.MapFrom(y => "data:image/webp;base64," + Convert.ToBase64String(y.Poster)));
        }
    }
}
