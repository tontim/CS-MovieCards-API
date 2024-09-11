using AutoMapper;

namespace CS_MovieCards_API.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieDto>();
        }
    }
}
