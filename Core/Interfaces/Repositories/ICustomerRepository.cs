using Core.DTOs;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDTO>> List();
        public CustomerDTO Get(int id);
        public CustomerDTO Add(string name);
        public CustomerDTO Update(int id, string name);
        public CustomerDTO Delete(int id);


    }
}
