namespace Proiect_final.Models.RepairHistory.DTO
{
    public class RepairHistoryRequestDto
    {
        public Guid BusId { get; set; }
        public Guid DefectionId { get; set;}
        public DateTime RepairDate { get; set; }
        public int Price { get; set; }

    }
}
