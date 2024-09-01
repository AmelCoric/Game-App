using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBCpntext _context;
        public CategoryRepository(ApplicationDBCpntext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(x=>x.id == id);
            if(categoryModel == null){
                return null;
            }
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync(QueryObject query)
        {
            var categories = _context.Categories.AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(query.ime))
            {
                categories = categories.Where(s=>s.ime.Contains(query.ime));
            }
            return await categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> UpdateAsync(int id, Category categoryModel)
        {
            var existingCategory = await _context.Categories.FindAsync(id);
            if(existingCategory == null){
                return null;
            }
            existingCategory.ime=categoryModel.ime;
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}