using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gluten_free_br.Model;

namespace gluten_free_br.Services.Implementation
{
    public class RecipeServiceImplementation : IRecipeService
    {
        public Recipe FinfById(long id)
        {
            return new Recipe
            {
                Id = id,
                Name = "Bolo de cenoura",
                Text = " faz isso, depois aquilo, depois aquilo outro"
            };

        }
        public List<Recipe> FindAll()
        {
            List<Recipe> Recipes = new List<Recipe>();
            for (int i = 0; i < 5; i++)
            {
                Recipe Recipe = new Recipe
                {
                    Id = i,
                    Name = "Bolo de cenoura",
                    Text = " faz isso, depois aquilo, depois aquilo outro"
                };

                Recipes.Add(Recipe);
            }
            return Recipes;
        }

    }
}