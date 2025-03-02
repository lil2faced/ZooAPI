using ZooAPI.DTO.AnimalDTO;

namespace ZooAPI.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<IndexAnimalViewModel> GetById(int id);
        Task Create(CreateAnimalViewModel viewModel);
        Task EditById(EditAnimalViewModel viewModel, int id);
        Task DeleteById(int id);
        Task<List<IndexAnimalViewModel>> GetAll();
    }
}
