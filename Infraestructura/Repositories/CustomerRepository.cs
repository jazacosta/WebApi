using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //obtain by id
        public async Task<CustomerDTO> Get(int id)
        {
            var entities = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entities == null)
            {
                throw new Exception("The id entered does not match any user.");
            }

            return AddTo(entities);

        }

        public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
        {
            var dtos = await _context.Customers
                .Skip((request.Page.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value)
                .Select(customer => new CustomerDTO
                {
                    Id = customer.Id,
                    FullName = $"{customer.FirstName} {customer.LastName}",
                    Email = customer.Email,
                    Phone = customer.Phone,
                    BirthDate = customer.BirthDate
                }).OrderBy(c => c.Id).ToListAsync();

            return dtos;
        } 

        public async Task<CustomerDTO> Add(CreateCustomerDTO createCustomerDTO)
        {
            var entity = new Customer
            {
                FirstName = createCustomerDTO.FirstName,
                LastName = createCustomerDTO?.LastName,
                Email = createCustomerDTO.Email,
                Phone = createCustomerDTO.Phone,
                BirthDate = createCustomerDTO.BirthDate
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync(); //this impacts the database

            return AddTo(entity);
        }

        public async Task<CustomerDTO> Delete(int id)
        {
            var entities = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entities == null)
            {
                throw new Exception("The id entered does not match any user.");
            }

            _context.Customers.Remove(entities);
            await _context.SaveChangesAsync();

            return AddTo(entities);
        }

        public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
        {
            var entities = await _context.Customers.FirstOrDefaultAsync(x => x.Id == updateCustomerDTO.Id);
            if (entities == null)
            {
                throw new Exception("The id entered does not match any user.");
            }

            entities.Id = updateCustomerDTO.Id;
            entities.FirstName = updateCustomerDTO.FirstName;
            entities.LastName = updateCustomerDTO.LastName;
            entities.Email = updateCustomerDTO.Email;
            entities.Phone = updateCustomerDTO.Phone;
            entities.BirthDate = updateCustomerDTO.BirthDate;

            await _context.SaveChangesAsync();
            return AddTo(entities);
        }

        public CustomerDTO AddTo(Customer customer) => new()
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate
        };
    }
}
