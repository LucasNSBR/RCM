using AutoMapper;

namespace RCM.Application.Mappers
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                cfg.AddProfile(new ViewModelToCommandMappingProfile());
            });
        }
    }
}
