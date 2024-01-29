namespace Proiect_final.Models.Bus.DTO
{
    public class BusResponseDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public string Route { get; set; }

        public IEnumerable<string> DriversNames { get; set; }
            
    }
}
