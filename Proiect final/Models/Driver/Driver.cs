using Proiect_final.Models.Base;

namespace Proiect_final.Models.Driver
{
    public class Driver : BaseEntity
    {
        // add name, age, list of buses, etc.
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }

        //one driver can drive only one bus
        public Guid? BusId { get; set; }

        public Bus.Bus? Bus { get; set; }
        public Adress.Adress? Adress { get; set; }

    }
}
