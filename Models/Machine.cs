using System;

namespace MachineParkManagement.Models
{
    public class Machine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string LatestData { get; set; }
    }
}
