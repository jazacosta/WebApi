using Core.DTOs;

namespace Core.Interfaces.Repositories;

public interface ICardRepository
{
    Task<CardDTO> Get(int CardId);
}
