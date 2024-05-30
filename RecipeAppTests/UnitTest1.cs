
using NUnit.Framework;

namespace RecipeAppTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestTotalCalories()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.AddIngredient(new Ingredient { Name = "Sugar", Quantity = 100, Unit = "g", Calories = 400, FoodGroup = "Carbohydrates" });
            recipe.AddIngredient(new Ingredient { Name = "Butter", Quantity = 50, Unit = "g", Calories = 360, FoodGroup = "Fats" });

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(760, totalCalories, "The total calories calculation is incorrect.");
        }
    }
}