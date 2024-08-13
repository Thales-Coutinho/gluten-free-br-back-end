using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gluten_free_br.Model;

namespace gluten_free_br.Repository
{
    public interface IRecipeRepository
    {
        Recipe FinfById(long id);
        List<Recipe> FindAll();
        Recipe Create(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Delete(long id);
        bool Exists(long id);
    }
}