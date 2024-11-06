using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> List();
        public Customer GetById(int id);
        public Customer PostPerson(Customer newcustomer);
        public Customer PutFromRoute(Customer updatecustomer, int id);
        public Customer DeleteFromRoute(Customer deletecustomer, int id);


    }
}
