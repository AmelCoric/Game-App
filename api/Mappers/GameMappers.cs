using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Game;
using api.Models;

namespace api.Mappers
{
    public static class GameMappers
    {
        public static GameDto ToGameDto(this Game gamemodel){
            return new GameDto{
                id=gamemodel.id,
                Naslov=gamemodel.Naslov,
                Opis=gamemodel.Opis,
                Categories = gamemodel.Categories.Select(c => c.ToCategoryDto()).ToList()
            };
        }

        public static Game ToGameFromCreateDTO(this CreateGameRequestDto gameDto){
            return new Game{
                Naslov=gameDto.Naslov,
                Opis=gameDto.Opis,
                imageUrl=gameDto.imageUrl
                


            };
        }
    }
}