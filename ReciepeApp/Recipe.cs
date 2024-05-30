using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// Represents a recipe with ingredients and steps.
    /// </summary>
    public class Recipe
    {
        public string Name { get; private set; }
        private List<Ingredient> ingredients;
        private List<string> steps;
        private double totalCalories;

        public delegate void CalorieNotificationHandler(string message);
        public event CalorieNotificationHandler CalorieNotification;

        public Recipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void AddRecipe()
        {
            Console.WriteLine("\n===============================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter recipe name:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Name = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            int numIngredients = GetValidNumber("\nEnter the number of ingredients (number only):");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nEnter ingredient #{i + 1} (name of the ingredient):");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string ingredientName = Console.ReadLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                double quantity = GetValidDouble($"\nEnter quantity of {ingredientName} (number only):");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nEnter unit of measurement for {ingredientName}:");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string unit = Console.ReadLine();
                Console.ResetColor();



                Console.ForegroundColor = ConsoleColor.Green;
                double calories = GetValidDouble($"\nEnter the number of calories for {ingredientName} (number only):");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nEnter the food group for {ingredientName}:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                string foodGroup = Console.ReadLine();

                ingredients.Add(new Ingredient
                {
                    Name = ingredientName,
                    Quantity = quantity,
                    Unit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                });

                totalCalories += calories;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            int numSteps = GetValidNumber("\nEnter the number of steps (number only):");
            Console.ResetColor();

            for (int i = 0; i < numSteps; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nEnter step #{i + 1}:");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                steps.Add(Console.ReadLine());
                Console.ResetColor();
            }

            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYour recipe has been added!");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------");

            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke("\nWarning: The total calories of this recipe exceed 300.");
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("===============================================================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Recipe: {Name}");
            Console.ResetColor();
            Console.WriteLine("===============================================================");

            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIngredients:\n");
            Console.ResetColor();

            foreach (var ingredient in ingredients)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
                Console.ResetColor();
            }
            Console.WriteLine("---------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Total Calories: {totalCalories}");
            Console.ResetColor();

            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSteps:\n");
            Console.ResetColor();
            for (int i = 0; i < steps.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{i + 1}. {steps[i]}");
                Console.ResetColor();
            }

            Console.WriteLine("===============================================================");
        }

        public void ScaleRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                "Select by what value you would like to scale your recipe:\n\n"); 
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. 0.5\n" +
                "2. 2\n" +
                "3. 3\n" +
                "4. Close\n");
            Console.ResetColor();
            string scale = Console.ReadLine();

            bool scaling = true;
            while (scaling)
            {
                switch (scale)
                {
                    case "1":
                        ScaleQuantities(0.5);
                        scaling = false;
                        break;
                    case "2":
                        ScaleQuantities(2);
                        scaling = false;
                        break;
                    case "3":
                        ScaleQuantities(3);
                        scaling = false;
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nYou are now closing the scaling option");
                        Console.ResetColor();
                        scaling = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option. Please enter 1, 2, 3, or 4.");
                        Console.ResetColor();
                        scale = Console.ReadLine();
                        break;
                }
            }
        }

        public void ResetQuantities()
        {
            totalCalories = 0; // Reset total calories before recalculating
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
                totalCalories += ingredient.Calories;
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nQuantities and calories reset to original values.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------------------------------------");
        }

        private void ScaleQuantities(double factor)
        {
            totalCalories = 0; // Reset total calories before recalculating
            foreach (var ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
                totalCalories += ingredient.Calories;
            }

            Console.WriteLine($"\nRecipe scaled by a factor of {factor}.");
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke("\nWarning: The total calories of this recipe exceed 300.\n");
            }
        }

        private int GetValidNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(prompt);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter a positive number.\n");
                    Console.ResetColor();
                }
            }
            return number;
        }

        private double GetValidDouble(string prompt)
        {
            double number;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(prompt);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (double.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter a positive number.\n");
                    Console.ResetColor();

                }
            }
            return number;
        }
    }
}