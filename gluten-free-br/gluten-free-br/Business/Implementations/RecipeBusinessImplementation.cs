using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gluten_free_br.Model;
using gluten_free_br.Model.Context;
using gluten_free_br.Repository;

namespace gluten_free_br.Business.Implementation
{
    public class RecipeBusinessImplementation : IRecipeBusiness
    {
        private readonly IRecipeRepository _repository;
        public RecipeBusinessImplementation(IRecipeRepository repository)
        {
            _repository = repository;
        }
        public Recipe FinfById(long id)
        {
            return _repository.FinfById(id);
        }
        public List<Recipe> FindAll()
        {
            return _repository.FindAll();
        }
        public Recipe Create(Recipe recipe)
        {
            return _repository.Create(recipe);
        }
        public Recipe Update(Recipe recipe)
        {
            return _repository.Update(recipe);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}