using System;

namespace RestarauntMenu.Models
{
    public sealed class CuisineType : IEquatable<CuisineType>
    {
        public string Name { get; set; }

        public bool Equals(CuisineType other)
        {
            return Name == other.Name;
        }
    }
}
