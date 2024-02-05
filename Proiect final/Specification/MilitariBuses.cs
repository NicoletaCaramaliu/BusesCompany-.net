using Proiect_final.Models.Bus;
using Proiect_final.Models.Bus.DTO;

namespace Proiect_final.Specification
{
    public class MilitariBuses : Specification<Bus>
    {
        public MilitariBuses() : base(r => r.Route == "Militari" && r.Capacity > 25)
        {

            AddInclude(r => r.RepairHistories);
            AddOrderBy(r => r.Number);

        }
    }
}
