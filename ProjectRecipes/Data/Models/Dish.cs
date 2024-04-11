using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipes.Data.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Recipe_details { get; set; }
        public string Quantity { get; set; }
        public int Calories { get; set; }
        public int TypeDishId { get; set; }
        public TypeDish TypeDish { get; set; }
        public InADish InADish { get; set; }
    }
}
