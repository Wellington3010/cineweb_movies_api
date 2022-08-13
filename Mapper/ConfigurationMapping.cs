﻿using AutoMapper;
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
            CreateMap<UserMovieDTO, Movie>().ForMember(x => x.MoviePoster, opt => opt.MapFrom(y => Encoding.ASCII.GetBytes(y.MoviePoster)));
            CreateMap<Movie, UserMovieDTO>().ForMember(x => x.MoviePoster, opt => opt.MapFrom(y => Encoding.ASCII.GetString(y.MoviePoster)));

            CreateMap<CreateMovieDTO, Movie>().ForMember(x => x.MoviePoster, opt => opt.MapFrom(y => Encoding.ASCII.GetBytes(y.MoviePoster)));
            CreateMap<Movie, CreateMovieDTO>().ForMember(x => x.MoviePoster, opt => opt.MapFrom(y => Encoding.ASCII.GetString(y.MoviePoster)));

            CreateMap<MovieDTO, Movie>()
            .ForMember(dest => dest.Id, src => src.MapFrom(x => Guid.Parse(x.Id)));

            CreateMap<Movie, MovieDTO>()
           .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id.ToString()));
        }
    }
}