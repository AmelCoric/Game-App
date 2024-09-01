using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllAsync();
        Task<Game?>GetByIdAsync(int id);
        Task<Game>CreateAsync(Game gameModel);
        Task<Game?>UpdateAsync(int id,UpdateGameRequestDto gameDto);
        Task<Game?>DeleteAsync(int id);
        Task<bool> GameExist(int id);
    }
}