using CustomerWebApi.Models;
using CustomerWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _customerRepository.GetAll().Result;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Customer> GetCustomers(int id)
        {
            return _customerRepository.GetById(id).Result;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Customer> Create([FromBody]Customer customer)
        {
            var newCustomer =   _customerRepository.Add(customer).Result;
            return Ok(newCustomer);
        }
    }
}
