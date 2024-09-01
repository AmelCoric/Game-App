using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>>GetAllAsync(QueryObject query);
        Task<Category?>GetByIdAsync(int id);
        Task<Category>CreateAsync(Category categoryModel);
        Task<Category?>UpdateAsync(int id, Category categoryModel);
        Task<Category?>DeleteAsync(int id);
    }
}