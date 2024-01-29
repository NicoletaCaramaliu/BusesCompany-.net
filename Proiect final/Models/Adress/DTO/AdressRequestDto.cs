namespace Proiect_final.Models.Adress.DTO
{
    public class AdressRequestDto
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Guid DriverId { get; set; }

    }
}
