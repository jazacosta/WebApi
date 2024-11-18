﻿using Core.DTOs.Customer;
using Core.Entities;
using Core.Requests;

namespace Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken);
    Task<CustomerDTO> Get(int id);
    Task<CustomerDTO> Add(CreateCustomerDTO createCustomerDTO);
    Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO);
    Task<CustomerDTO> Delete(int id);
}
