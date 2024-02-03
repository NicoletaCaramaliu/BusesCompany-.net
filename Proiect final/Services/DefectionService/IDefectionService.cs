using Proiect_final.Models.Defection;

namespace Proiect_final.Services.DefectionService
{
    public interface IDefectionService
    {
        //get all defections
        Task<IEnumerable<Defection>> GetAllDefections();

        //create defection
        Task CreateDefection(Defection defection);

        //get defection by id
        Task<Defection> GetDefectionById(Guid id);

        //update defection
        Task UpdateDefection(Defection defection);

        //delete defection
        Task DeleteDefection(Defection defection);
    }
}
