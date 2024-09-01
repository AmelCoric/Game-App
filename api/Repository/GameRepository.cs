using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDBCpntext _context;
        public GameRepository(ApplicationDBCpntext context)
        {
            _context = context;
        }

        public async Task<Game> CreateAsync(Game gameModel)
        {
            await _context.Game.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var gameModel = await _context.Game.FirstOrDefaultAsync(x => x.id == id);
            if(gameModel == null){
                return null;
            }
            _context.Game.Remove(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public Task<bool> GameExist(int id)
        {
            return _context.Game.AnyAsync(s => s.id == id);
        }

        public Task<List<Game>> GetAllAsync()
        {
            return  _context.Game.Include(c => c.Categories).ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Game.Include(c => c.Categories).FirstOrDefaultAsync(i => i.id == id);
        }

        public async Task<Game?> UpdateAsync(int id, UpdateGameRequestDto gameDto)
        { 
            var existingGame = await _context.Game.FirstOrDefaultAsync(x=> x.id == id);

            if(existingGame == null){
                return null;
            }
            
       
            return existingGame;
            
        }
    }
}