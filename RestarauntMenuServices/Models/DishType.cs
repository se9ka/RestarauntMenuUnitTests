using System;

namespace RestarauntMenu.Models
{
    public sealed class DishType : IEquatable<DishType>
    {
        public string Name { get; set; }

        public bool Equals(DishType other)
        {
            return Name == other.Name;
        }
    }
}
