using System;

namespace RestarauntMenu.Models
{
    public sealed class DishIngredient : IEquatable<DishIngredient>
    {
        public string Name { get; set; }

        public bool Equals(DishIngredient other)
        {
            return Name == other.Name;
        }
    }
}
