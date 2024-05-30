using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp;
using System;

namespace RecipeAppTests1
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void TestScaleQuantity()
        {
            // Arrange
            Ingredient ingredient = new Ingredient
            {
                Quantity = 100,
                Calories = 200
            };

            // Act
            ingredient.ScaleQuantity(2);

            // Assert
            Assert.AreEqual(200, ingredient.Quantity);
            Assert.AreEqual(400, ingredient.Calories);
        }

        [TestMethod]
        public void TestResetQuantity()
        {
            // Arrange
            Ingredient ingredient = new Ingredient
            {
                Quantity = 100,
                Calories = 200
            };

            // Act
            ingredient.ResetQuantity();

            // Assert
            Assert.AreEqual(100, ingredient.Quantity);
            Assert.AreEqual(200, ingredient.Calories);
        }

        [TestMethod]
        public void TestInvalidScaleFactor()
        {
            // Arrange
            Ingredient ingredient = new Ingredient
            {
                Quantity = 100,
                Calories = 200
            };

            // Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() => ingredient.ScaleQuantity(0));
            Assert.ThrowsException<System.ArgumentException>(() => ingredient.ScaleQuantity(-1));
        }
    }
}
