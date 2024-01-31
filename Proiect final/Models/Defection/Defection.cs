using Proiect_final.Models.Base;

namespace Proiect_final.Models.Defection
{
    public class Defection : BaseEntity
    {
        // add defection name, repair date, price, etc.
        public string DefectionName { get; set; }

        //a defection can be in many repair histories
        public ICollection<RepairHistory.RepairHistory> RepairHistories { get; set; }
    }
}
