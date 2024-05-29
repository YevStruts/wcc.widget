using AutoMapper;
using wcc.widget.Infrastructure;
using wcc.widget.kernel.Models;

namespace wcc.widget.kernel.Helpers
{
    public sealed class MapperHelper
    {
        private static IMapper? instance = null;

        private MapperHelper()
        {
        }

        public static IMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        // cfg.CreateMap<Game, GameModel>().ReverseMap();
                    });

                    instance = new Mapper(config);
                }
                return instance;
            }
        }
    }
}
