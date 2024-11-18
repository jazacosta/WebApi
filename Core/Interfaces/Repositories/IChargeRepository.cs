using Core.DTOs.Charge;

namespace Core.Interfaces.Repositories;

public interface IChargeRepository
{
    Task<ChargeDTO> CreateCharge(int CardId, CreateChargeDTO createChargeDTO);

    Task<bool> VerifyChargeAmount(int CardId, int Amount);
}
