using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipes.Data.Models
{
    public class  Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public List<InADish> InADish { get; set; }
    }
}
