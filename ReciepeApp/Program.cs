using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeApp
{
    internal class Program
    {
        static void Main(string[] args)



        {
            ///there should be an option to 
            ///-add a reciepe,
            ///     -enter name of reciepe
            ///     -enter the number of ingredients
            ///     -enter the ingredients
            ///     -enter the quantities of the ingredients
            ///     -enter number of steps
            ///     -wnter detailed steps for the reciepe
            ///-display the reciepe, 
            ///-allow the user to scale the reciepe up or down 
            ///-allow the user to reset the quantities to their original values, 
            ///-allow the user to clear data so that they can add a new reciepe
            ///

            Recipe recipe = new Recipe();
            bool AppRunnin = true;
            Console.WriteLine("-----WELCOME TO THE RECIEPE APPLICATION-----\n");
            while (AppRunnin)
            {

                Console.WriteLine("1. Add reciepe");
                Console.WriteLine("2. Display reciepe");
                Console.WriteLine("3. Scale Reciepe Up/Down");
                Console.WriteLine("4. Reset quantities to original values");
                Console.WriteLine("5. Clear Reciepe");
                Console.WriteLine("6. End Session");

                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        recipe.AddRecipe();
                        break;
                    case "2":
                        recipe.DisplayRecipe();

                        break;
                    case "3":
                        recipe.ScaleRecipe();

                        break;
                    case "4":
                        recipe.ResetQuantities();

                        break;
                    case "5":
                        recipe.ClearRecipe();

                        break;
                    case "6":
                        AppRunnin = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }



            

        }
        class Recipe
        {
            private string recipeName;
            private string[] ingredients;
            private double[] originalQuantities;
            private double[] quantities;
            private string[] units;
            private string[] steps;

            public Recipe()
            {
                // Initialize arrays
            }

            public void AddRecipe()
            {
                Console.WriteLine("Enter recipe name:");
                recipeName = Console.ReadLine();

                Console.WriteLine("Enter the number of ingredients:");
                int numIngredients = int.Parse(Console.ReadLine());

                ingredients = new string[numIngredients];
                quantities = new double[numIngredients];
                originalQuantities = new double[numIngredients]; // Initialize originalQuantities array
                units = new string[numIngredients];

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter ingredient #{i + 1}:");
                    ingredients[i] = Console.ReadLine();

                    Console.WriteLine($"Enter quantity of {ingredients[i]}:");
                    quantities[i] = double.Parse(Console.ReadLine());
                    originalQuantities[i] = quantities[i]; // Store original quantity

                    Console.WriteLine($"Enter unit of measurement for {ingredients[i]}:");
                    units[i] = Console.ReadLine();
                }

                Console.WriteLine("Enter the number of steps:");
                int numSteps = int.Parse(Console.ReadLine());

                steps = new string[numSteps];

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step #{i + 1}:");
                    steps[i] = Console.ReadLine();
                }

                Console.WriteLine("Recipe details entered successfully!");
            }

            public void DisplayRecipe()
            {
                Console.WriteLine($"Recipe: {recipeName}");

                Console.WriteLine("\nIngredients:");
                for (int i = 0; i < ingredients.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {quantities[i]} {units[i]} of {ingredients[i]}");
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {steps[i]}");
                }
            }

            public void ScaleRecipe()
            {
                bool scaling = true;
                Console.WriteLine("Select by what value you would like to scale your recipe:\n" +
                    "1. 0.5\n" +
                    "2. 2\n" +
                    "3. 3\n" +
                    "4. close\n");
                string scale = Console.ReadLine();

                while (scaling)
                {
                    switch (scale)
                    {
                        case "1":
                            for (int i = 0; i < quantities.Length; i++)
                            {
                                quantities[i] *= 0.5;
                            }
                            scaling = false;
                            break;

                        case "2":
                            for (int i = 0; i < quantities.Length; i++)
                            {
                                quantities[i] *= 2;
                            }
                            scaling = false;
                            break;

                        case "3":
                            for (int i = 0; i < quantities.Length; i++)
                            {
                                quantities[i] *= 3;
                            }
                            scaling = false;
                            break;

                        case "4":
                            Console.WriteLine("You are now closing the scaling option");
                            scaling = false;
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                /*Console.WriteLine("Enter scale factor (0.5, 2, or 3):");
                double scaleFactor = double.Parse(Console.ReadLine());

                // Scaling the quantities of ingredients
                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] *= scaleFactor;
                }

                Console.WriteLine($"Recipe scaled up by a factor of {scaleFactor}!");*/
            }

            public void ResetQuantities()
            {
                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] = originalQuantities[i];
                }

                Console.WriteLine("Quantities reset to original values.");
            }

            public void ClearRecipe()
            {

                recipeName= null;
                ingredients = null;
                quantities = null;
                units = null;
                steps = null;

                Console.WriteLine("All recipe data cleared. Start afresh.");
            }


        }
    }
}
