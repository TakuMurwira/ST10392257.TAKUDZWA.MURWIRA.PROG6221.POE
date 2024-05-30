using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    /// <summary>
    /// Represents an ingredient with details such as name, quantity, unit, calories, and food group.
    /// </summary>
    public class Ingredient
    {
        private double _quantity;
        private double _originalQuantity;
        private double _originalCalories;

        public string Name { get; set; }
        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                if (_originalQuantity == 0) // Set original quantity only once
                {
                    _originalQuantity = value;
                }
            }
        }
        public string Unit { get; set; }
        public double Calories
        {
            get => _calories;
            set
            {
                _calories = value;
                if (_originalCalories == 0) // Set original calories only once
                {
                    _originalCalories = value;
                }
            }
        }
        private double _calories;
        public string FoodGroup { get; set; }

        public Ingredient()
        {
            // Default constructor
        }

        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
            Calories *= factor;
        }

        public void ResetQuantity()
        {
            Quantity = _originalQuantity;
            Calories = _originalCalories;
        }
    }
}

