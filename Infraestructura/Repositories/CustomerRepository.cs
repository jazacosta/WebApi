using Core.Entities;
using Core.Interfaces.Repositories;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static List<Customer> _customers = [
            new(){Id = 1, Name = "Jose"},
            new(){Id = 2, Name = "Juan"},
            ];
        public List<Customer> List()
        {
            return _customers;
        }

        //Obtain by id
        public Customer GetById(int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new Exception("The id entered does not match any user.");
            }
        }

        //Add
        public Customer PostPerson(Customer newcustomer)
        {
            _customers.Add(newcustomer);
            return newcustomer;
        }

        //Update
        public Customer PutFromRoute(Customer updatecustomer, int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.Id = id;
                customer.Name = updatecustomer.Name;
                return (customer);
            }
            else
            {
                throw new Exception("The id entered does not match any user.");
            }
        }

        //Delete
        public Customer DeleteFromRoute(Customer deletecustomer, int id)
        {
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                customer.Id = id;
                customer.Name = deletecustomer.Name;
                return (customer);
            }
            else
            {
                throw new Exception("The id entered does not match any user.");
            }
        }

    }
}
