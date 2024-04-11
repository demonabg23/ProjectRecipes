using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipes.Data.Models
{
    public class TypeDish
    {
        public int TypeDishId { get; set; }
        public string Name { get; set; }
        public List<Dish> Dish { get; set; }
    }
}
