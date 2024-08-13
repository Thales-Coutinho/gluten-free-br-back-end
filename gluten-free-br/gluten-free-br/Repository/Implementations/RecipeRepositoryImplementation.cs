using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gluten_free_br.Model;
using gluten_free_br.Model.Context;

namespace gluten_free_br.Repository.Implementation
{
    public class RecipeRepositoryImplementation : IRecipeRepository
    {
        private MySQLContext _context;
        public RecipeRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Recipe FinfById(long id)
        {
            return _context.Recipes.SingleOrDefault(r => r.Id.Equals(id));

        }
        public List<Recipe> FindAll()
        {
            return _context.Recipes.ToList();
        }
        public Recipe Create(Recipe recipe)
        {
            try
            {
                _context.Add(recipe);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return recipe;
        }
        public Recipe Update(Recipe recipe)
        {
            if (!Exists(recipe.Id)) return new Recipe();

            var result = _context.Recipes.SingleOrDefault(r => r.Id.Equals(recipe.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(recipe);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return recipe;
        }
        public void Delete(long id){
            var result = _context.Recipes.SingleOrDefault(r => r.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Recipes.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return _context.Recipes.Any(r => r.Id.Equals(id));
        }

    }
}