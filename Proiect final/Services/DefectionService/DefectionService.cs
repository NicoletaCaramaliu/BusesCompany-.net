using Proiect_final.Models.Defection;
using Proiect_final.Repositories.DefectionRepository;

namespace Proiect_final.Services.DefectionService
{
    public class DefectionService : IDefectionService
    {
        private readonly IDefectionRepository _defectionRepository;
        public DefectionService(IDefectionRepository defectionRepository)
        {
            _defectionRepository = defectionRepository;
        }

        //get all defections
        public async Task<IEnumerable<Defection>> GetAllDefections()
        {
            return await _defectionRepository.GetAllAsync();
        }

        //create defection
        public async Task CreateDefection(Defection defection)
        {
            await _defectionRepository.CreateAsync(defection);
            await _defectionRepository.SaveAsync();
        }

        //get defection by id
        public async Task<Defection> GetDefectionById(Guid id)
        {
            return await _defectionRepository.FindByIdAsync(id);
        }

        //update defection
        public async Task UpdateDefection(Defection defection)
        {
            _defectionRepository.Update(defection);
            await _defectionRepository.SaveAsync();
        }

        //delete defection
        public async Task DeleteDefection(Defection defection)
        {
            _defectionRepository.Delete(defection);
            await _defectionRepository.SaveAsync();
        }
    }
}
