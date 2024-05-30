using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeApp
{
    /// <summary>
    /// Manages multiple recipes, allowing users to add, list, display, scale, reset, and clear recipes.
    /// </summary>
    public class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public delegate void CalorieNotificationHandler(string message);
        public event CalorieNotificationHandler CalorieNotification;

        public RecipeManager()
        {
            CalorieNotification += NotifyUser;
        }

        public void AddRecipe()
        {
            Recipe recipe = new Recipe();
            recipe.CalorieNotification += NotifyUser;
            recipe.AddRecipe();
            recipes.Add(recipe);
        }

        public void DisplayRecipe()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("No recipes available to display.");
                return;
            }

            ListRecipes();

            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void ListRecipes()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("\nNo recipes available.\n");
                return;
            }

            Console.WriteLine("===============================================================");
            Console.WriteLine("\nList of all recipes (alphabetical order):");
            Console.WriteLine("---------------------------------------------------------------");


            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.WriteLine("---------------------------------------------------------------");

        }

        public void ScaleRecipe()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("No recipes available to scale.");
                return;
            }

            ListRecipes();

            Console.WriteLine("Enter the name of the recipe to scale:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ScaleRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void ResetQuantities()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("No recipes available to reset.");
                return;
            }

            ListRecipes();

            Console.WriteLine("Enter the name of the recipe to reset quantities:");
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ResetQuantities();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void ClearRecipe()
        {
            if (!recipes.Any())
            {
                Console.WriteLine("No recipes available to clear.");
                return;
            }

            ListRecipes();

            string recipeName = SelectRecipe();
            if (!string.IsNullOrEmpty(recipeName))
            {
                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                if (recipe != null)
                {
                    Console.WriteLine($"Are you sure you want to clear recipe '{recipe.Name}'? Type:(y/n)");
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "y")
                    {
                        recipes.Remove(recipe);
                        Console.WriteLine("Recipe cleared.");
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }
        }

        private void NotifyUser(string message)
        {
            Console.WriteLine(message);
        }

        private string SelectRecipe()
        {
            Console.WriteLine("Enter the name of the recipe:");
            return Console.ReadLine();
        }
    }

        
    
}
