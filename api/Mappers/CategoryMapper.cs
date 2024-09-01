using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel){
            return new CategoryDto{
                id = categoryModel.id,
                ime = categoryModel.ime,
                Gameid = categoryModel.Gameid
                
            };
        }
        public static Category ToCategoryFromCreate(this CreateCategoryDto categoryDto,int gameid){
            return new Category{
                
                ime = categoryDto.ime,
                Gameid = gameid
                
            };
        }

          public static Category ToCategoryFromUpdate(this UpdateCategoryRequestDto categoryDto){
            return new Category{
                
                ime = categoryDto.ime,
                
                
            };
        }
    }
}