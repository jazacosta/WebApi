﻿using Core.DTOs;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDTO>> List();
        CustomerDTO Get(int id);
        Task<List<CustomerDTO>> Add(string firstName, string? lastName);
        List<CustomerDTO> Update(int id, string name);
        List<CustomerDTO> Delete(int id);


    }
}
