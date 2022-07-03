using AutoMapper;
using cineweb_movies_api.DTO;
using cineweb_movies_api.Entities;
using cineweb_movies_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineweb_movies_api.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController : Controller
    {
        private IBaseRepository<Movie> _moviesRepository;
        private IMapper _mapper;
        
        public MoviesController(IBaseRepository<Movie> repo, IMapper mapper)
        {
            _moviesRepository = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("home")]
        public ActionResult GetHomeMovies()
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();

            var currentMovies = _moviesRepository.ListItems().Where(x => x.HomeMovie).ToList();

            currentMovies.ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpGet]
        [Route("current")]
        public ActionResult GetCurrentMovies()
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();

            var currentMovies = _moviesRepository.ListItems().Where(x => x.Date < DateTime.Now && !x.HomeMovie).ToList();

            currentMovies.ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpGet]
        [Route("current/by-date")]
        public ActionResult GetCurrentMoviesByDate(DateTime date)
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();

            var currentMovies = _moviesRepository.ListItems().Where(x => x.Date < date && !x.HomeMovie).ToList();

            currentMovies.ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpGet]
        [Route("coming-soon")]
        public ActionResult GetComingSoonMovies()
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();

            var comingSoonMovies = _moviesRepository.ListItems().Where(x => x.Date > DateTime.Now && !x.HomeMovie).ToList();

            comingSoonMovies.ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpGet]
        [Route("coming-soon/by-date")]
        public ActionResult GetComingSoonMoviesByDate(DateTime date)
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();

            var comingSoonMovies = _moviesRepository.ListItems().Where(x => x.Date > date && !x.HomeMovie).ToList();

            comingSoonMovies.ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpGet]
        [Route("by-parameter")]
        public ActionResult GetMoviesByParameter(string parameter, string parameterType)
        {
            List<UserMovieDTO> userMovies = new List<UserMovieDTO>();
            var dictionaryMovies = new Dictionary<string, List<Movie>>();
            dictionaryMovies.Add("title", _moviesRepository.ListItems().Where(x => x.Title == parameter).ToList());
            dictionaryMovies.Add("genre", _moviesRepository.ListItems().Where(x => x.Genre == parameter).ToList());

            dictionaryMovies[parameterType].ForEach((item) =>
            {
                userMovies.Add(_mapper.Map<UserMovieDTO>(item));
            });

            return Json(userMovies);
        }

        [HttpPost]
        [Route("admin/save-movie")]
        public ActionResult SaveMovie(CreateMovieDTO movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieEntity = _mapper.Map<Movie>(movie);
            movieEntity.Id = Guid.NewGuid();
            _moviesRepository.AddItem(movieEntity);
            return Ok();
        }

        [HttpPost]
        [Route("admin/update-movie")]
        public ActionResult UpdateMovie(MovieDTO movie)
        {
            var movieEntity = _mapper.Map<Movie>(movie);
            _moviesRepository.Update(movieEntity);
            return Ok();
        }

        [HttpPost]
        [Route("admin/delete-movie")]
        public ActionResult DeleteMovieById(Guid id)
        {
            _moviesRepository.RemoveById(id);
            return Ok();
        }

        [HttpGet]
        [Route("admin/find-by-movie-genre")]
        public ActionResult FindByMovieGenre(string genre)
        {
            var adminMovies = new List<MovieDTO>();
            var moviesByGenre = _moviesRepository.FindByGenre(genre);

            moviesByGenre.ForEach((item) =>
            {
                adminMovies.Add(_mapper.Map<MovieDTO>(item));
            });
            return Json(adminMovies);
        }

        [HttpGet]
        [Route("admin/find-by-movie-title")]
        public ActionResult FindByMovieTitle(string title)
        {
            return Json(_mapper.Map<MovieDTO>(_moviesRepository.FindByTitle(title)));
        }
    }
}
