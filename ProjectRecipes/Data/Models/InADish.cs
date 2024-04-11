using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipes.Data.Models
{
    public class InADish
    {
        public int InADishId { get; set; }
        public string Quantity { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public List<Dish> Dish { get; set; }
        public Product Product { get; set; }
    }
}
