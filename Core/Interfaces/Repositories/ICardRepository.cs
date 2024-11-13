using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<CardDTO> Add(CreateCardDTO createCardDTO);
    Task<CardDTO> Get(int CardId);
    Task<List<DetailedCardDTO>> GetAll(int customerId);
}
