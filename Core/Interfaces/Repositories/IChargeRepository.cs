using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> Add(CreateChargeDTO createChargeDTO);
}
