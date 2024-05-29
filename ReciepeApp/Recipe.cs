using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeApp
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
            Console.WriteLine("Enter recipe name:");
            Name = Console.ReadLine();

            int numIngredients = GetValidNumber("Enter the number of ingredients (number only):");

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"\nEnter ingredient #{i + 1} (name of the ingredient):");
                string ingredientName = Console.ReadLine();

                double quantity = GetValidDouble($"Enter quantity of {ingredientName} (number only):");

                Console.WriteLine($"Enter unit of measurement for {ingredientName}:");
                string unit = Console.ReadLine();

                double calories = GetValidDouble($"Enter the number of calories for {ingredientName} (number only):");

                Console.WriteLine($"Enter the food group for {ingredientName}:");
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

            int numSteps = GetValidNumber("Enter the number of steps (number only):");

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"\nEnter step #{i + 1}:");
                steps.Add(Console.ReadLine());
            }

            Console.WriteLine("Your recipe has been added!");
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke("Warning: The total calories of this recipe exceed 300.");
            }
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("===============================================================");

            Console.WriteLine("\nIngredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }
            Console.WriteLine($"Total Calories: {totalCalories}");
            Console.WriteLine("===============================================================");
            Console.WriteLine("===============================================================");

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.WriteLine("===============================================================");
        }

        public void ScaleRecipe()
        {
            Console.WriteLine(
                "Select by what value you would like to scale your recipe:\n" +
                "1. 0.5\n" +
                "2. 2\n" +
                "3. 3\n" +
                "4. Close\n");
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
                        Console.WriteLine("You are now closing the scaling option");
                        scaling = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter 1, 2, 3, or 4.");
                        scale = Console.ReadLine();
                        break;
                }
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }

            Console.WriteLine("Quantities reset to original values.");
        }

        private void ScaleQuantities(double factor)
        {
            totalCalories = 0; // Reset total calories before recalculating
            foreach (var ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
                totalCalories += ingredient.Calories;
            }

            Console.WriteLine($"Recipe scaled by a factor of {factor}.");
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke("Warning: The total calories of this recipe exceed 300.");
            }
        }

        private int GetValidNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
            return number;
        }

        private double GetValidDouble(string prompt)
        {
            double number;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
            return number;
        }
    }
}
