using RestarauntMenu.Models;
using RestarauntMenu.Services;
using System.Collections.Generic;
using System.Linq;

namespace RestarauntMenu
{
    public sealed class DishService : IDishService
    {
        private readonly List<Dish> _dishesAvailable = new List<Dish> {
            new Dish
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
            },new Dish
            {
                Id = 2,
                Name = "Salad2",
                Cuisine = new CuisineType { Name = "American2" },
                DishType = new DishType { Name = "Salad2" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Egg" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 2000,
                Votes = 0
            },new Dish
            {
                Id = 3,
                Name = "Salad3",
                Cuisine = new CuisineType { Name = "American3" },
                DishType = new DishType { Name = "Salad3" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 3000,
                Votes = 0
            },
        };

        public List<Dish> DishesInOrder = new List<Dish>();


        public Dish AddDish(Dish dish)
        {
            if (!CheckDishAvailability(dish))
            {
                return null;
            }

            DishesInOrder.Add(dish);

            return FindDish(dish.Id);
        }

        public Dish RemoveDish(Dish dish)
        {
            if (!CheckDishAvailability(dish))
            {
                return null;
            }

            DishesInOrder.Remove(dish);

            return dish;
        }

        public Dish UpdateDish(int dishId, Dish dish)
        {
            var dishFromOrder = FindDish(dishId);

            if (dishFromOrder == null)
            {
                return null;
            }

            DishesInOrder[DishesInOrder.FindIndex(dishInOrder => dishInOrder.Id == dishId)] = dish;

            return dishFromOrder;
        }

        public Dish UpdateVotesForDish(int dishId, int votesAmmount)
        {
            var dishFromOrder = FindDish(dishId);

            dishFromOrder.Votes += votesAmmount;

            return dishFromOrder;
        }

        public List<Dish> GetListOfDishesByPopularity()
        {
            return DishesInOrder.OrderByDescending(dish => dish.Votes).ToList();
        }

        public List<Dish> GetDishesWithExcludedIngridients(List<DishIngredient> dishIngredients)
        {
            return DishesInOrder.Where(dish =>
                 !dish.Ingredients.Any(dishIngredients.Contains))
                .ToList();
        }

        public bool CheckDishAvailability(Dish dish)
        {
            return _dishesAvailable.Any(dishAvailable => dishAvailable.Equals(dish));
        }

        public Dish FindDish(int dishId)
        {
            return DishesInOrder.Find(dishInOrder => dishInOrder.Id == dishId);
        }
    }
}
