using System;

namespace Test.Entities
{
    public class WeekDay
    {
        public int Id { get; set; }
        public int WeekId { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}