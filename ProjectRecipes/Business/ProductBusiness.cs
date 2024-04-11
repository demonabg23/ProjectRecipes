using System;
using System.Collections.Generic;
using System.Linq;
using ProjectRecipes.Data;
using ProjectRecipes.Data.Models;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipes.Business
{
    public class ProductBusiness
    {
        private ProductContext productContext;
        public List<Product> GetAllProducts()
        {
            using (productContext = new ProductContext())
            {
                return productContext.Products.ToList();
            }
        }
        public List<Dish> GetAllDishes()
        {
            using (productContext = new ProductContext())
            {
                return productContext.Dishes.ToList();
            }
        }
        public string FindTypeNameUsingTypeId(int id)
        {
            using (productContext = new ProductContext())
            {
                TypeDish typedish = productContext.Typesdishes.Find(id);
                return typedish.Name;
            }
        }
        public List<TypeDish> GetAllTypesOfDishes()
        {
            using (productContext = new ProductContext())
            {
                return productContext.Typesdishes.ToList();
            }
        }
        public void AddProduct(Product product)
        {
            using (productContext = new ProductContext())
            {
                productContext.Products.Add(product);
                productContext.SaveChanges();
            }
        }
        public void AddDish(Dish dish)
        {
            using (productContext = new ProductContext())
            {
                productContext.Dishes.Add(dish);
                productContext.SaveChanges();
            }

        }
        public void AddInADish(InADish inadish)
        {
            using (productContext = new ProductContext())
            {
                productContext.InTheDishes.Add(inadish);
                productContext.SaveChanges();
            }
        }
        public void AddTypeDish(TypeDish type)
        {
            using (productContext = new ProductContext())
            {
                productContext.Typesdishes.Add(type);
                productContext.SaveChanges();
            }
        }
        public Dish FindDishUsingId(int id)
        {
            using (productContext = new ProductContext())
            {
                return productContext.Dishes.Find(id);
            }
        }
        public List<InADish> GetAllInADish()
        {
            using (productContext = new ProductContext())
            {
                return productContext.InTheDishes.ToList();
            }
        }
        public string FindProductNameUsingId(int id)
        {
            using (productContext = new ProductContext())
            {
                Product product = productContext.Products.Find(id);
                return product.Name;
            }
        }
        public Product GetProduct(int id)
        {
            using (productContext = new ProductContext())
            {
                return productContext.Products.Find(id);
            }
        }
        public void UpdateProduct(Product product)
        {
            using (productContext = new ProductContext())
            {
                var item = productContext.Products.Find(product.ProductId);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(product);
                    productContext.SaveChanges();
                }
            }
        }
        public void UpdateDish(Dish dish)
        {
            using (productContext = new ProductContext())
            {
                var item = productContext.Products.Find(dish.DishId);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(dish);
                    productContext.SaveChanges();
                }
            }
        }
        public void DeleteInADishUsingId(int id)
        {
            using (productContext = new ProductContext())
            {
                var InADishForDeleting = productContext.InTheDishes.Find(id);
                if (InADishForDeleting != null)
                {
                    productContext.InTheDishes.Remove(InADishForDeleting);
                    productContext.SaveChanges();
                }
            }
        }
        public TypeDish FindTypeUsingId(int id)
        {
            using (productContext = new ProductContext())
            {
                return productContext.Typesdishes.Find(id);
            }
        }
        public void UpdateTypeDish(TypeDish typedish)
        {
            using (productContext = new ProductContext())
            {
                var item = productContext.Typesdishes.Find(typedish.TypeDishId);
                if (item != null)
                {
                    productContext.Entry(item).CurrentValues.SetValues(typedish);
                    productContext.SaveChanges();
                }
            }
        }

    }
}
