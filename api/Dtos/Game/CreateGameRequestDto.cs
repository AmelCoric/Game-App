using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Game
{
    public class CreateGameRequestDto
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Ne moze biti duze od 100")]
        public string Naslov{get;set;} = string.Empty;
        [Required]
        [MaxLength(250,ErrorMessage ="Ne moze biti duze od 250")]
        public string Opis{get;set;} = string.Empty;
        [MaxLength(250,ErrorMessage ="Ne moze biti duze od 250")]
        public string imageUrl{get;set;} = string.Empty;
    }
}