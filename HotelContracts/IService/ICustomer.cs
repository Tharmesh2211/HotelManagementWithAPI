using HotelEntities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelContracts.IService
{
    public interface ICustomer
    {
        public Task<Customer> Add(Customer customer);
        public Task<IEnumerable<Customer>> Get();
        public Task<Customer> GetById(int id);
    }
}
