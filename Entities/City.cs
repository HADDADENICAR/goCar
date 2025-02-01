using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRenting.Entites
{

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Agency> Agencies { get; set; }
    }
}