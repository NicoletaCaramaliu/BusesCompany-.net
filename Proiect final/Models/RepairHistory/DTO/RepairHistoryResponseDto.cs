﻿namespace Proiect_final.Models.RepairHistory.DTO
{
    public class RepairHistoryResponseDto
    {
        public Guid Id { get; set; }

        public DateTime RepairDate { get; set; }
        public int Price { get; set; }
    }
}
