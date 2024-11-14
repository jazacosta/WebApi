using Core.DTOs;

namespace Core.Interfaces.Services;

public interface ICardService
{
    Task<CardDTO> Create(CreateCardDTO request);
    Task<ChargeDTO> CreateCharge(CreateChargeDTO request);
}
