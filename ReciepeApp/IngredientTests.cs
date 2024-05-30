using NUnit.Framework;
using RecipeApp;

namespace RecipeApp.Tests
{
    [TestFixture]
    public class IngredientTests
    {
        [Test]
        public void Calories_SetValidValue_ShouldSetCalories()
        {
            // Arrange
            var ingredient = new Ingredient();

            // Act
            ingredient.Calories = 100;

            // Assert
            Assert.AreEqual(100, ingredient.Calories);
        }

        [Test]
        public void Calories_SetNegativeValue_ShouldThrowArgumentException()
        {
            // Arrange
            var ingredient = new Ingredient();

            // Act & Assert
            Assert.That(() => ingredient.Calories = -50, Throws.ArgumentException);
        }

        [Test]
        public void Calories_SetZeroValue_ShouldNotThrowException()
        {
            // Arrange
            var ingredient = new Ingredient();

            // Act & Assert
            Assert.That(() => ingredient.Calories = 0, Throws.Nothing);
        }
    }
}
