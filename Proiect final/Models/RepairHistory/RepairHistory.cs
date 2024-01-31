using Proiect_final.Models.Base;

namespace Proiect_final.Models.RepairHistory
{
    public class RepairHistory : BaseEntity
    {
        public Guid BusId { get; set; }
        public Guid DefectionId { get; set;}
        public DateTime RepairDate { get; set; }
        public int Price { get; set; }

        public Bus.Bus Bus { get; set; }
        public Defection.Defection Defection { get; set; }
    }
}
