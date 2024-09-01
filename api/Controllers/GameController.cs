using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Game;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDBCpntext _context;
        private readonly IGameRepository _gameRepo;
        public GameController(ApplicationDBCpntext context,IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var games = await _gameRepo.GetAllAsync();
            var gameDto= games.Select(g =>g.ToGameDto());
            return Ok(games);   
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id){
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var game = await _gameRepo.GetByIdAsync(id);
            if(game == null){
                return NotFound();
            }
            return Ok(game.ToGameDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateGameRequestDto gameDto){
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameModel = gameDto.ToGameFromCreateDTO();
           await _gameRepo.CreateAsync(gameModel);
            return CreatedAtAction(nameof (GetById), new { id=gameModel.id},gameModel.ToGameDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdateGameRequestDto updateDto){
           

            var gameModel = await _gameRepo.UpdateAsync(id,updateDto);

            if(gameModel == null){
                return NotFound();
            }
         
            return Ok(gameModel.ToGameDto());

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id){
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var gameModel = await _gameRepo.DeleteAsync(id);

            if(gameModel == null){
                return NotFound();
            }
          
            return NoContent();
        }
    }
}