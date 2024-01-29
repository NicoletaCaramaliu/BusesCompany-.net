namespace Proiect_final.Models.Driver.DTO
{
    public class DriverRequestDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }

        public Guid? BusId { get; set; }
    }
}
