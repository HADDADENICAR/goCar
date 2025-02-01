using System.Collections.Generic;
using Test.Entities;

namespace CarRenting.Entites
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public City City { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public int  WeekId { get; set; }
        public Week Week { get; set; }

    }
}