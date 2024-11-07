using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<CustomerDTO>> Add(string firstName, string? lastName)
        {
            var entity = new Customer
            {
                FirstName = firstName,
                LastName = lastName
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync(); //this impacts the database

            return await List();
        }

        public List<CustomerDTO> Delete(int id)
        {
            throw new NotImplementedException();
        }

        //obtain by id
        public CustomerDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDTO>> List()
        {
            var entities = await _context.Customers.ToListAsync();

            var dtos = entities.Select(customer => new CustomerDTO
            {
                Id = customer.Id,
                FullName = $"{customer.FirstName} {customer.LastName}"
            });

            return dtos.ToList();
        } 

        public List<CustomerDTO> Update(int id, string name)
        {
            throw new NotImplementedException();
        } 
    }
}
