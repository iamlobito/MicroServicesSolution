using CustomerWebApi.Models;

namespace CustomerWebApi.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task<Customer> Add(Customer customer);
    }
}
