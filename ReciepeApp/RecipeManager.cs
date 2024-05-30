using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available to display.");
                Console.ResetColor();
                return;
            }

            ListRecipes();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the recipe to display:");
            Console.ResetColor();
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found.");
                Console.ResetColor();
            }
        }

        public void ListRecipes()
        {
            if (!recipes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo recipes available.\n");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("===============================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nList of all recipes (alphabetical order):");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------");

            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            foreach (var recipe in sortedRecipes)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(recipe.Name);
                Console.ResetColor();
            }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void ScaleRecipe()
        {
            if (!recipes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available to scale.");
                Console.ResetColor();
                return;
            }

            ListRecipes();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the recipe to scale:");
            Console.ResetColor();
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ScaleRecipe();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found.");
                Console.ResetColor();
            }
        }

        public void ResetQuantities()
        {
            if (!recipes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available to reset.");
                Console.ResetColor();
                return;
            }

            ListRecipes();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the recipe to reset quantities:");
            Console.ResetColor();
            string recipeName = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ResetQuantities();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Recipe not found.");
                Console.ResetColor();
            }
        }

        public void ClearRecipe()
        {
            if (!recipes.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipes available to clear.");
                Console.ResetColor();
                return;
            }

            ListRecipes();

            string recipeName = SelectRecipe();
            if (!string.IsNullOrEmpty(recipeName))
            {
                Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                if (recipe != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Are you sure you want to clear recipe '{recipe.Name}'? Type:(y/n)");
                    Console.ResetColor();
                    string confirm = Console.ReadLine();
                    if (confirm.ToLower() == "y")
                    {
                        recipes.Remove(recipe);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Recipe cleared.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("Operation cancelled.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Recipe not found.");
                    Console.ResetColor();
                }
            }
        }

        private void NotifyUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private string SelectRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the name of the recipe:");
            Console.ResetColor();
            return

            Console.ReadLine();
        }
    }
}
