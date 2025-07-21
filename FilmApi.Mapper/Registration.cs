using Microsoft.Extensions.DependencyInjection;
using FilmApi.Application.Interfaces.AutoMapper;

namespace FilmApi.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
