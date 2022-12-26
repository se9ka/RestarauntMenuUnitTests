using System;
using System.Collections.Generic;
using System.Linq;

namespace RestarauntMenu.Models
{
    public sealed class Dish : IEquatable<Dish>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DishType DishType { get; set; }

        public CuisineType Cuisine { get; set; }

        public List<DishIngredient> Ingredients { get; set; }

        public int Votes { get; set; }

        public bool Equals(Dish other)
        {
            return Id == other.Id &&
                   Name == other.Name &&
                   Price == other.Price &&
                   DishType.Equals(other.DishType) &&
                   Cuisine.Equals(other.Cuisine) &&
                   Ingredients.All(other.Ingredients.Contains);
        }
    }
}
