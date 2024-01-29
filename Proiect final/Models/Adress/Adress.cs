using Proiect_final.Models.Base;

namespace Proiect_final.Models.Adress
{
    public class Adress : BaseEntity
    {
        // add street, number, city, etc.
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        //has one driver
        public Guid DriverId { get; set; }
        public Driver.Driver Driver { get; set; }

    }
}
