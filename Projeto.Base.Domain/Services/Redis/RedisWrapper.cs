using Projeto.Base.CrossCutting.Configuration;
using Projeto.Base.CrossCutting.Configuration.Exceptions;
using StackExchange.Redis;
using System;
using System.ComponentModel;

namespace Projeto.Base.Domain.Services.Redis
{
    public class RedisWrapper
    {
        private readonly IDatabase _database;
        public RedisWrapper(IDatabase database) => _database = database;

        public virtual bool Set<T>(string key, T value) =>
            _database.StringSet(key, value.ToString(), new TimeSpan(0,  AppSettings.Settings.Redis.CacheExpirationMinutes, 0));

        public virtual T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ApiHttpCustomException("O parâmetro da chave de buscar no redis não deve ser nula", System.Net.HttpStatusCode.BadRequest);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            var result = _database.StringGet(key);

            if (string.IsNullOrEmpty(result))
                return default(T);

            return (T)converter.ConvertFromString(result);
        }
    }
}