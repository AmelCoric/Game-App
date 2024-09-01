using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CategoryDto
    {
        public int id {get;set;}
        public string ime{get;set;} = string.Empty;
        public int? Gameid {get;set;}
        
    }
}