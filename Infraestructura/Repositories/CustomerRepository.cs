using Core.DTOs;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Contexts;
using Mapster;
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
            var entity = await VerifyExists(id);
            return entity.Adapt<CustomerDTO>();

            /*    .Include(x => x.Accounts)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (entities == null)
            {
                throw new Exception("The id entered does not match any user.");
            }

            return new CustomerDTO()
            {
                //Id = entities.Id,
                FullName = $"{entities.FirstName} {entities.LastName}",
                Email = entities.Email,
                Phone = entities.Phone,
                BirthDate = entities.BirthDate,
                Accounts = entities.Accounts.Select(x => new DetailedCustoemrDTO)
                {
                    Id = entities.Accounts.Id,
                    Number = entities.Accounts.Number,
                    Balance = entities.Balance,
                    OpeningDate = entities.OpeningDate
                }
            };*/

        }

        public async Task<List<CustomerDTO>> List(PaginationRequest request, CancellationToken cancellationToken)
        {
            var entities = await _context.Customers.ToListAsync();
            return entities.Adapt<List<CustomerDTO>>();
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

            //return AddTo(entity);
            return entity.Adapt<CustomerDTO>();

        }

        public async Task<CustomerDTO> Delete(int id)
        {
            var entity = await VerifyExists(id);

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return entity.Adapt<CustomerDTO>();
        }

        public async Task<CustomerDTO> Update(UpdateCustomerDTO updateCustomerDTO)
        {
            var entities = await VerifyExists(updateCustomerDTO.Id);

            entities.Id = updateCustomerDTO.Id;
            entities.FirstName = updateCustomerDTO.FirstName;
            entities.LastName = updateCustomerDTO.LastName;
            entities.Email = updateCustomerDTO.Email;
            entities.Phone = updateCustomerDTO.Phone;
            entities.BirthDate = updateCustomerDTO.BirthDate;

            await _context.SaveChangesAsync();
            return entities.Adapt<CustomerDTO>();
        }

        /*public CustomerDTO AddTo(Customer customer) => new()
        {
            Id = customer.Id,
            FullName = $"{customer.FirstName} {customer.LastName}",
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate
        };*/

        private async Task<Customer> VerifyExists(int id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity == null) throw new Exception("The id entered does not match any user.");
            return entity;
        }
    }
}
