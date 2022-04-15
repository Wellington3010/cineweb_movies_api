using AutoMapper;
using cineweb_movies_api.Context;
using cineweb_movies_api.DTO;
using cineweb_movies_api.Entities;
using cineweb_movies_api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.Swagger;
using Microsoft.EntityFrameworkCore;

namespace cineweb_movies_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo());
            });
            services.AddControllers();
            services.AddDbContext<MovieContext, MovieContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IBaseRepository<Movie>, MovieRepository>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserMovieDTO, Movie>().ReverseMap();

                cfg.CreateMap<CreateMovieDTO, Movie>().ReverseMap();

                cfg.CreateMap<MovieDTO, Movie>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => Guid.Parse(x.Id)));

                cfg.CreateMap<Movie, MovieDTO>()
               .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id.ToString()));
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c => c.AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
