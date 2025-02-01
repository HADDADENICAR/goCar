using System.Collections.Generic;

namespace CarRenting.Entites
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public double Price { get; set; }
        public string ImageBase64 { get; set; }
        public virtual ICollection<Agency> agencies { get; set; }

    }
}