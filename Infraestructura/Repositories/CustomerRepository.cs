using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
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

        public async Task<List<CustomerDTO>> List()
        {
            var entities = await _context.Customers.ToListAsync();

            var dtos = entities.Select(customer => AddTo(customer));

            return dtos.OrderBy(c => c.Id).ToList();
        } 

        public async Task<CustomerDTO> Update(int id, string firstName, string? lastName)
        {
            var entities = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (entities == null)
            {
                throw new Exception("The id entered does not match any user.");
            }

            entities.FirstName = firstName;
            entities.LastName = lastName;
            await _context.SaveChangesAsync();
            return AddTo(entities);
        }

        public CustomerDTO AddTo(Customer customer) => new()
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}"
        };
    }
}
