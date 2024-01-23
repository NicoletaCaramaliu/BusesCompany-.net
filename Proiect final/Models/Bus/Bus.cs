using Proiect_final.Models.Base;

namespace Proiect_final.Models.Bus
{
    // add number, capacity, route, etc.
    public class Bus : BaseEntity
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public string Route { get; set; }
        
    }
}
