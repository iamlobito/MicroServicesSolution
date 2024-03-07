using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerWebApi.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<Customer> Add(Customer customer)
        {

            var result = _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync();
            return result.Entity;    
        }

        public async Task<Customer> GetById(int id)
        {
            return await _customerDbContext.Customers.FirstOrDefaultAsync(a => a.CustomerId == id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerDbContext.Customers.ToListAsync();
        }
    }
}
