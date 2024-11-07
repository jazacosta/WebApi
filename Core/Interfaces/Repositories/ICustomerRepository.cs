using Core.DTOs;
using Core.Requests;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDTO>> List(PaginationRequest request);
        Task<CustomerDTO> Get(int id);
        Task<CustomerDTO> Add(string firstName, string? lastName);
        Task<CustomerDTO> Update(int id, string firstName, string? lastName);
        Task<CustomerDTO> Delete(int id);


    }
}
