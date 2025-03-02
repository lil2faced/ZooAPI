using AutoMapper;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using ZooAPI.Application;
using ZooAPI.Application.Entities;
using ZooAPI.DTO.AnimalDTO;
using ZooAPI.Services.Interfaces;

namespace ZooAPI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        public AnimalService(IMapper mapper)
        {
               _mapper = mapper;
        }
        public void Create(CreateAnimalViewModel viewModel)
        {
            using (DatabaseContext db = new())
            {
                var temp = db.Animals.Where(p => p.Name == viewModel.Name).FirstOrDefault();
                if (temp != null)
                {
                    throw new Exception("Такое животное уже существует");
                }
                var res = _mapper.Map<Animal>(viewModel);
                db.Animals.Update(res);
                db.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using (DatabaseContext db = new())
            {
                var res = db.Animals.Find(id);
                if (res == null)
                {
                    throw new Exception("Not found");
                }
                db.Animals.Remove(res);
                db.SaveChanges();
            }
        }
        public void EditById(EditAnimalViewModel viewModel, int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var res = db.Animals.Find(id);
                if (res == null)
                    throw new Exception("Not Found");
                var temp = db.Animals.Where(p => p.Name == viewModel.Name).FirstOrDefault();
                if (temp != null)
                    throw new Exception("Животное с таким именем уже существует");
                res.Name = viewModel.Name;
                res.Energy = viewModel.Energy;
                db.Animals.Update(res);
                db.SaveChanges();
            }
        }
        public IndexAnimalViewModel GetById(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var res = db.Animals.Find(id);
                if (res == null)
                {
                    throw new Exception("Not Found");
                }
                return _mapper.Map<IndexAnimalViewModel>(res);
            }
        }


    }
}
