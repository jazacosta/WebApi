using Core.DTOs.Account;
using Core.Entities;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task<DetailedAccountDTO> GetById(int id);
}
