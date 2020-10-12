using AutoMapper;

namespace Api.UnitTests.MockData
{
    public class Mapper
    {
        private readonly MapperConfiguration _configuration;
        public IMapper Object { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper"/> class.
        /// </summary>
        public Mapper()
        {
            var profile = new MappingProfile();
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            Object = new AutoMapper.Mapper(_configuration);
        }
    }
}
