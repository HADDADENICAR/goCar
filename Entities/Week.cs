using System.Collections.Generic;

namespace Test.Entities
{
    public class Week
    {
        public int Id { get; set; }
        public string WeekName { get; set; }

        public ICollection<WeekDay> WeekDays { get; set; }
    }
}