using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [MinLength(2,ErrorMessage ="Mora biti minimalno 2 karaktera")]
        [MaxLength(100,ErrorMessage ="Ne moze biti duze od 100")]
         public string ime{get;set;} = string.Empty;
    }
}