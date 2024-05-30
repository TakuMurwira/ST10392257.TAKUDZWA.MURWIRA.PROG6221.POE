using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciepeApp
{
    /// <summary>
    /// Represents an ingredient with details such as name, quantity, unit, calories, and food group.
    /// </summary>
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        private double originalQuantity;

        public Ingredient()
        {
            Quantity=originalQuantity ;
        }

        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
            Calories *= factor;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }
    }
}
