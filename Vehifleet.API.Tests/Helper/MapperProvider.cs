using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Vehifleet.API.Tests.Helper
{
    public static class MapperProvider
    {
        public static IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }

    }
}
