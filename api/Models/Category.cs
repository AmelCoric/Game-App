using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Category
    {
        public int id {get;set;}
        public string ime{get;set;} = string.Empty;
        public int? Gameid {get;set;}
        public Game? Game {get;set;}
        
    }
}
