using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> CreateCharge(CreateChargeDTO createChargeDTO);

    Task<bool> VerifyChargeAmount(int CardId, int Amount);
}
