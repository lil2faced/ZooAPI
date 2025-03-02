using ZooAPI.DTO.AnimalDTO;

namespace ZooAPI.Services.Interfaces
{
    public interface IAnimalService
    {
        IndexAnimalViewModel GetById(int id);
        void Create(CreateAnimalViewModel viewModel);
        void EditById(EditAnimalViewModel viewModel, int id);
        void DeleteById(int id);
    }
}
