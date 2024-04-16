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

                Console.WriteLine("\n1. Add reciepe");
                Console.WriteLine("2. Display reciepe");
                Console.WriteLine("3. Scale Reciepe Up/Down");
                Console.WriteLine("4. Reset quantities to original values");
                Console.WriteLine("5. Clear Reciepe");
                Console.WriteLine("6. End Session\n");

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
                
            }
            /// <summary>
            /// this is the add recipe method and it has error handling to prevent the app from crashing and to guide the user when
            /// they make a mistake
            /// </summary>
            public void AddRecipe()
            {
                Console.WriteLine("Enter recipe name:");
                recipeName = Console.ReadLine();
                Console.WriteLine("\n");


                int numIngredients;
                while (true)
                {
                    Console.WriteLine("\nEnter the number of ingredients:(number only)");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numIngredients) && numIngredients > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry! You may only enter an number :(");

                    }
                }

                ingredients = new string[numIngredients];
                quantities = new double[numIngredients];
                originalQuantities = new double[numIngredients];
                units = new string[numIngredients];

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"\nEnter ingredient #{i + 1}:(name of the ingredient)");
                    ingredients[i] = Console.ReadLine();

                    double quantity;
                    while (true)
                    {
                        Console.WriteLine($"\nEnter quantity of {ingredients[i]}:(number only)");
                        string input = Console.ReadLine();
                        if (double.TryParse(input, out quantity) && quantity > 0)
                        {
                            quantities[i] = quantity;
                            originalQuantities[i] = quantity;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Sorry! You may only enter an number :(");

                        }
                    }

                    Console.WriteLine($"\nEnter unit of measurement for {ingredients[i]}:");
                    units[i] = Console.ReadLine();
                }

                int numSteps;
                while (true)
                {
                    Console.WriteLine("\nEnter the number of steps:(number only)");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out numSteps) && numSteps > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry! You may only enter an number :(");
                    }
                }

                steps = new string[numSteps];

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"\nEnter step #{i + 1}:");
                    steps[i] = Console.ReadLine();
                }

                Console.WriteLine("Your recipe has been added!");
            }
            /// <summary>
            /// this method is just there to display the arrays and there is some lines to separathe the content
            /// </summary>
            public void DisplayRecipe()
            {
                if (recipeName == null)
                {
                    Console.WriteLine("\nThere is currently no recipe to display :(\n"); return;
                }
                else
                {
                    Console.WriteLine("===============================================================");
                    Console.WriteLine($"Recipe: {recipeName}");
                    Console.WriteLine("===============================================================");

                    Console.WriteLine("\nIngredients:");
                    for (int i = 0; i < ingredients.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {quantities[i]} {units[i]} of {ingredients[i]}");
                    }
                    Console.WriteLine("===============================================================");
                    Console.WriteLine("===============================================================");


                    Console.WriteLine("\nSteps:");
                    for (int i = 0; i < steps.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {steps[i]}");
                    }
                    Console.WriteLine("===============================================================");

                }
            }
            /// <summary>
            /// for scaling up i used a switch case to avoid having the user make mistakes or enter whatever they want
            /// </summary>
            public void ScaleRecipe()
            {
                bool scaling = true;
                Console.WriteLine(
                    "Select by what value you would like to scale your recipe:\n" +
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

            }

            /// <summary>
            /// since the scale up alters the quantities we are able to rest them using the original quantities array
            /// </summary>
            public void ResetQuantities()
            {
                for (int i = 0; i < quantities.Length; i++)
                {
                    quantities[i] = originalQuantities[i];
                }

                Console.WriteLine("Quantities reset to original values.");
            }

            /// <summary>
            /// buy setting the array values to null we are able to start all over and can fill the array all over again
            /// after clearing the data you get a message confirming that the data is cleared
            /// </summary>
            public void ClearRecipe()
            {

                recipeName = null;
                ingredients = null;
                quantities = null;
                units = null;
                steps = null;

                Console.WriteLine("All recipe data cleared. Start afresh.");
            }


        }
    }
}
