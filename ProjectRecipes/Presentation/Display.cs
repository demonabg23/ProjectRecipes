using ProjectRecipes.Business;
using ProjectRecipes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectRecipes.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        private ProductBusiness productBusiness = new ProductBusiness();
        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine();
            Console.WriteLine("1. Виж всички продукти/ ястия/ типове ястия");
            Console.WriteLine("2. Добави нов продукт/ ястие/ тип ястие");
            Console.WriteLine("3. Виж рецепта според номера й");
            Console.WriteLine("4. Редактирай");
            Console.WriteLine("5. Изтрий");
            Console.WriteLine();
            Console.Write("Изберете номер от менюто: ");
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        LookingForDish();
                        break;
                    case 4:
                        Update();
                        break;/*
                    case 5:
                        AddTypesOfDishesInfo();
                        break;
                    case 6:
                        ListAllTypesOfDishes();
                        break;
                    case 7:
                        FindType();
                        break;*/
                }
            } while (operation != closeOperationId);
        }
        private void ListAll()
        {
            Console.WriteLine("Изберете списък от какво да ви се изведе: ");
            Console.WriteLine("1. продуктите");
            Console.WriteLine("2. ястията");
            Console.WriteLine("3. типовете ястия");
            Console.WriteLine();
            Console.Write("Изберете номер от дадените: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ListAllProducts();
                    break;
                case 2:
                    ListAllDishes();
                    break;
                case 3:
                    ListAllTypesOfDishes();
                    break;
            }
            Console.WriteLine();
        }
        private void ListAllProducts()
        {
            Console.WriteLine();
            Console.WriteLine("Продуктите, изведени във формат");
            Console.WriteLine("номер | име");
            Console.WriteLine();
            var products = productBusiness.GetAllProducts();
            foreach (var item in products)
            {
                Console.WriteLine("{0} | {1}", item.ProductId, item.Name);
            }
            Console.WriteLine();
        }
        private void ListAllDishes()
        {
            Console.WriteLine();
            Console.WriteLine("Ястията, изведени във формат");
            Console.WriteLine("Номер | име | тип | количество | калории");
            Console.WriteLine();
            var dishes = productBusiness.GetAllDishes();
            foreach (var item in dishes)
            {
                string typedish = productBusiness.FindTypeNameUsingTypeId(item.TypeDishId);
                Console.WriteLine("{0} | {1} | {2} | {3} | {4}", item.DishId, item.Name, typedish, item.Quantity, item.Calories);
            }
            Console.WriteLine();
        }
        private void ListAllTypesOfDishes()
        {
            Console.WriteLine();
            Console.WriteLine("Типовете продукти, изведени във формат");
            Console.WriteLine("номер | име");
            Console.WriteLine();
            var type = productBusiness.GetAllTypesOfDishes();
            foreach (var item in type)
            {
                Console.WriteLine("{0} | {1}", item.TypeDishId, item.Name);
            }
            Console.WriteLine();
        }
        private void Add()
        {
            Console.WriteLine("Изберете какво ще добавите: ");
            Console.WriteLine("1. продукт");
            Console.WriteLine("2. ястие");
            Console.WriteLine("3. тип ястие");
            Console.WriteLine();
            Console.Write("Изберете номер от дадените: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    AddDish();
                    break;
                case 3:
                    AddTypeDish();
                    break;
            }
            Console.WriteLine();
        }
        private void AddProduct()
        {
            Console.WriteLine();
            Product product = new Product();
            Console.Write("Въведете име на продукта: ");
            product.Name = Console.ReadLine();
            productBusiness.AddProduct(product);
            Console.WriteLine();
        }
        private void AddDish()
        {
            Console.WriteLine();
            Dish dish = new Dish();
            Console.Write("Въведете име ястието: ");
            dish.Name = Console.ReadLine();
            Console.Write("Въведете рецептата му: ");
            dish.Recipe_details = Console.ReadLine();
            Console.Write("Въведете количеството му: ");
            dish.Quantity = Console.ReadLine();
            Console.Write("Въведете калории на ястието: ");
            dish.Calories = int.Parse(Console.ReadLine());
            Console.Write("Въведете номер на тип ястие: ");
            dish.TypeDishId = int.Parse(Console.ReadLine());
            productBusiness.AddDish(dish);
            var dishes = productBusiness.GetAllDishes();
            List<int> ides = new List<int>();
            foreach (var item in dishes)
            {
                ides.Add(item.DishId);
            }
            int NomerDish = ides.Last();
            int NomerProduct = 1;
            do {
                Console.Write("Въведете номер на продукт за {0}: ", dish.Name);
                NomerProduct = int.Parse(Console.ReadLine());
                if (NomerProduct != 0)
                {
                    InADish inadish = new InADish();
                    inadish.DishId = dish.DishId;
                    inadish.ProductId = NomerProduct;
                    Console.Write("Въведете количество: ");
                    inadish.Quantity = Console.ReadLine();
                    productBusiness.AddInADish(inadish);
                }
            } while (NomerProduct!=0);
            Console.WriteLine();
        }
        private void AddTypeDish()
        {
            Console.WriteLine();
            TypeDish type = new TypeDish();
            Console.Write("Въведете име на типа ястие: ");
            type.Name = Console.ReadLine();
            productBusiness.AddTypeDish(type);
            Console.WriteLine();
        }
        private void LookingForDish()
        {
            Console.Write("Въведете номер на ястие: ");
            int NomerDish = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Dish dish = productBusiness.FindDishUsingId(NomerDish);
            Console.Write(dish.Name);
            string typedish = productBusiness.FindTypeNameUsingTypeId(dish.TypeDishId);
            Console.WriteLine(" ({0})",typedish);
            Console.WriteLine();
            Console.WriteLine("   Количеството е {0} и съдържа {1} калории", dish.Quantity,dish.Calories);
            var ingredients = productBusiness.GetAllInADish();
            int br = 0;
            foreach (var item in ingredients)
            {
                if (item.DishId == NomerDish)
                {
                    br++;
                    if (br == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Необходими продукти");
                        Console.WriteLine();
                        Console.WriteLine("   Име съставка | количество");
                        Console.WriteLine();
                    }
                    string NameProduct = productBusiness.FindProductNameUsingId(item.ProductId);
                    Console.WriteLine("   {0} | {1}", NameProduct, item.Quantity);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Рецепта");
            Console.WriteLine();
            Console.WriteLine("   {0}",dish.Recipe_details);
            Console.WriteLine();
            Console.WriteLine();
        }
        private void Update()
        {
            Console.WriteLine("Изберете какво ще редактирате: ");
            Console.WriteLine("1. продукт");
            Console.WriteLine("2. ястие");
            Console.WriteLine("3. тип ястие");
            Console.WriteLine();
            Console.Write("Изберете номер от дадените: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    UpdateProduct();
                    break;
                case 2:
                    UpdateDish();
                    break;
                case 3:
                    UpdateTypeDish();
                    break;
            }
            Console.WriteLine();
        }
        private void UpdateProduct()
        {
            Console.Write("Въведете номер на продукта за редактиране: ");
            int id = int.Parse(Console.ReadLine());
            Product product = productBusiness.GetProduct(id);
            if (product != null)
            {
                Console.WriteLine();
                Console.Write("Въведете име на типа ястие: ");
                product.Name = Console.ReadLine();
                productBusiness.UpdateProduct(product);
            }
            else
            {
                Console.WriteLine("Продуктът не е намерен!");
            }
        }
        private void UpdateDish()
        {
            Console.Write("Въведете номер на ястието за редактиране: ");
            int id = int.Parse(Console.ReadLine());
            Dish dish = productBusiness.FindDishUsingId(id);
            if (dish != null)
            {
                Console.Write("Въведете име ястието: ");
                dish.Name = Console.ReadLine();
                Console.Write("Въведете рецептата му: ");
                dish.Recipe_details = Console.ReadLine();
                Console.Write("Въведете количеството му: ");
                dish.Quantity = Console.ReadLine();
                Console.Write("Въведете калории на ястието: ");
                dish.Calories = int.Parse(Console.ReadLine());
                Console.Write("Въведете номер на тип ястие: ");
                dish.TypeDishId = int.Parse(Console.ReadLine());
                productBusiness.UpdateDish(dish);
                var dishes = productBusiness.GetAllDishes();
                List<int> ides = new List<int>();
                foreach (var item in dishes)
                {
                    ides.Add(item.DishId);
                }
                int NomerDish = ides.Last();
                //InADish inadish1 = new InADish();
                var inadish1 = productBusiness.GetAllInADish();
                foreach (var item in inadish1)
                {
                    if (item.DishId == NomerDish)
                    {
                        productBusiness.DeleteInADishUsingId(item.InADishId);
                    }
                }
                int NomerProduct = 1;
                do
                {
                    Console.Write("Въведете номер на продукт за {0}: ", dish.Name);
                    NomerProduct = int.Parse(Console.ReadLine());
                    if (NomerProduct != 0)
                    {
                        InADish inadish = new InADish();
                        inadish.DishId = dish.DishId;
                        inadish.ProductId = NomerProduct;
                        Console.Write("Въведете количество: ");
                        inadish.Quantity = Console.ReadLine();
                        productBusiness.AddInADish(inadish);
                    }
                } while (NomerProduct != 0);
            }
            else
            {
                Console.WriteLine("Ястието не е намерено!");
            }
        }
        private void UpdateTypeDish()
        {
            Console.Write("Въведете номер на типа ястие за редактиране: ");
            int id = int.Parse(Console.ReadLine());
            TypeDish typedish = productBusiness.FindTypeUsingId(id);
            if (typedish != null)
            {
                Console.WriteLine();
                Console.Write("Въведете име на типа: ");
                typedish.Name = Console.ReadLine();
                productBusiness.UpdateTypeDish(typedish);
            }
            else
            {
                Console.WriteLine("Типът ястие не е намерен!");
            }
        }
    }
}
