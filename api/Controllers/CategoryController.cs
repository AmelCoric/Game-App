using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route ("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IGameRepository _gameRepo;
        public CategoryController(ICategoryRepository categoryRepo, IGameRepository gameRepo)
        {
            _categoryRepo = categoryRepo;
            _gameRepo = gameRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var categories = await _categoryRepo.GetAllAsync(query);
            var categoryDto = categories.Select(s=> s.ToCategoryDto());
            return Ok(categoryDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult>GetById([FromRoute]int id){
             if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null){
                return NotFound();

            }
             return Ok(category.ToCategoryDto());
        }
        [HttpPost("{gameid:int}")]
        public async Task<IActionResult> Create([FromRoute]int gameid, CreateCategoryDto categoryDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _gameRepo.GameExist(gameid)){
                return BadRequest("Igra ne postoji");
            }

            var categoryModel = categoryDto.ToCategoryFromCreate(gameid);
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById),new {id = categoryModel.id},categoryModel.ToCategoryDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdateCategoryRequestDto updateDto)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.UpdateAsync(id,updateDto.ToCategoryFromUpdate());
            
            if(category == null){
                return NotFound("Kategorija ne postoji");
            }
            return Ok(category.ToCategoryDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult>Delete([FromRoute]int id)
        {
             if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.DeleteAsync(id);
            if(categoryModel == null){
                return NotFound("Kategorija ne postoji");
            }
            return Ok(categoryModel);
        }
    }
}