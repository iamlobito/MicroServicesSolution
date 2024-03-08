using CustomerWebApi.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CustomerWebApi.Repository
{
    public class CachedCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerRepository _decorator;
        private readonly IMemoryCache _memoryCache;

        public CachedCustomerRepository(ICustomerRepository decorated, IMemoryCache memoryCache)
        {
            _decorator = decorated;
            _memoryCache = memoryCache;
        }

        public Task<Customer> Add(Customer customer) => _decorator.Add(customer);

        public Task<List<Customer>> GetAll() => _decorator.GetAll();

        public Task<Customer> GetById(int id)
        {
            string key = $"customer-{id}";

            return _memoryCache.GetOrCreateAsync(key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                    return _decorator.GetById(id);
                });

        }
    }
}
