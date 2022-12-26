using RestarauntMenu.Models;
using System;
using System.Collections.Generic;

namespace RestarauntMenu
{
    public class Program
    {
        static void Main()
        {
            DishService dishService = new DishService();

            dishService.AddDish(new Dish
            {
                Id = 1,
                Name = "Salad1",
                Cuisine = new CuisineType { Name = "American1" },
                DishType = new DishType { Name = "Salad1" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 1000,
                Votes = 0
            });

            dishService.UpdateVotesForDish(1, -6);

            var res = dishService.DishesInOrder;

            Console.WriteLine();
        }
    }
}
