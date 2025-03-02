using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Application;
using ZooAPI.Application.Entities;
using ZooAPI.DTO.AnimalDTO;
using ZooAPI.Services.Interfaces;

namespace ZooAPI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly DatabaseContext _db;
        public AnimalService(IMapper mapper, DatabaseContext databaseContext)
        {
            _mapper = mapper;
            _db = databaseContext;
        }
        public async Task Create(CreateAnimalViewModel viewModel)
        {
            var temp = await _db.Animals.Where(p => p.Name == viewModel.Name).FirstOrDefaultAsync();
            if (temp != null)
            {
                throw new Exception("Такое животное уже существует");
            }
            var res = _mapper.Map<Animal>(viewModel);
            _db.Animals.Update(res);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var res = await _db.Animals.FindAsync(id);
            if (res == null)
            {
                throw new Exception("Not found");
            }
            _db.Animals.Remove(res);
            await _db.SaveChangesAsync();
        }
        public async Task EditById(EditAnimalViewModel viewModel, int id)
        {
            var res = await _db.Animals.FindAsync(id);
            if (res == null)
                throw new Exception("Not Found");
            var temp = await _db.Animals.Where(p => p.Name == viewModel.Name).FirstOrDefaultAsync();
            if (temp != null)
                throw new Exception("Животное с таким именем уже существует");
            res.Name = viewModel.Name;
            res.Energy = viewModel.Energy;
            _db.Animals.Update(res);
            await _db.SaveChangesAsync();
        }

        public async Task<List<IndexAnimalViewModel>> GetAll()
        {
            return await _db.Animals.Select(p => _mapper.Map<IndexAnimalViewModel>(p)).ToListAsync();
        }

        public async Task<IndexAnimalViewModel> GetById(int id)
        {
            var res = await _db.Animals.FindAsync(id);
            if (res == null)
            {
                throw new Exception("Not Found");
            }
            return _mapper.Map<IndexAnimalViewModel>(res);
        }
    }
}
