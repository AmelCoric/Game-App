

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Game
    {
        public int id { get;set;}
        public string Naslov{get;set;} = string.Empty;
        public string Opis{get;set;} = string.Empty;
        [MaxLength(200,ErrorMessage ="Ne moze biti duze od 200")]
        public string imageUrl{get;set;} = string.Empty;

        public List<Category>Categories{get;set;} =  new List<Category>();
    }
}