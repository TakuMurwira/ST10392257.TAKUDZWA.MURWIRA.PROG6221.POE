using ReciepeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool appRunning = true;
            Console.WriteLine("===============================================================");
            Console.WriteLine("------------WELCOME TO THE RECIPE APPLICATION------------------");
            Console.WriteLine("===============================================================");


            while (appRunning)
            {
                Console.WriteLine("\n1. Add recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. List all recipes");
                Console.WriteLine("4. Scale recipe up/down");
                Console.WriteLine("5. Reset quantities to original values");
                Console.WriteLine("6. Clear recipe");
                Console.WriteLine("7. End session\n");
                Console.WriteLine("===============================================================\n");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        recipeManager.AddRecipe();
                        break;
                    case "2":
                        recipeManager.DisplayRecipe();
                        break;
                    case "3":
                        recipeManager.ListRecipes();
                        break;
                    case "4":
                        recipeManager.ScaleRecipe();
                        break;
                    case "5":
                        recipeManager.ResetQuantities();
                        break;
                    case "6":
                        recipeManager.ClearRecipe();
                        break;
                    case "7":
                        appRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }

   
}




