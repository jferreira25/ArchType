﻿using AutoMapper;
using Projeto.Base.Domain.MappersProfile;

namespace Projeto.Base.Tests.Shared.Mock.Injection.Mappers
{
    public static class MappersMock
    {
        public static IMapper GetMock()
        {
            var configuration = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<lessonsProfile>();
                    cfg.AddProfile<UsersProfile>();
                });

            return new Mapper(configuration);
        }
    }
}
