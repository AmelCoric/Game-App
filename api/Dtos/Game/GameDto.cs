using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;

namespace api.Dtos.Game
{
    public class GameDto
    {
        public int id { get;set;}
        public string Naslov{get;set;} = string.Empty;
        public string Opis{get;set;} = string.Empty;
        
        public string imageUrl{get;set;} = string.Empty;
        public List<CategoryDto>Categories{get; set;}
    }
}