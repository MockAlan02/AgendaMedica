using AgendaMedica.Core.Application.Interface.Repository;
using AgendaMedica.Core.Application.Interface.Service;
using AgendaMedica.Core.Application.ViewModels.ConsultingRoom;
using AgendaMedica.Core.Domain.Entities;


namespace AgendaMedica.Core.Application.Service
{
    public class ConsultingRoomService : IGenericService<SaveConsultingRoomViewModel, ConsultingRoomViewModel>, IConsultingRoomService
    {
        private readonly IGenericRepository<ConsultingRoom> _repository;
        public ConsultingRoomService(IGenericRepository<ConsultingRoom> repository)
        {
            _repository = repository;
        }
        public async Task Add(SaveConsultingRoomViewModel vm)
        {
            var consulting = new ConsultingRoom
            {
                Id = vm.Id,
                Name = vm.Name,
            };
            await _repository.AddAsync(consulting);
        }

        public async Task<ConsultingRoom> AddAsync(SaveConsultingRoomViewModel vm)
        {
            var consulting = new ConsultingRoom
            {
                Name = vm.Name,
            };
            return await _repository.AddAsync(consulting);
        }

        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<ConsultingRoomViewModel>> GetAllViewModel()
        {
            var consultingRooms = await _repository.GetAllAsync();
            return consultingRooms.Select(x => new ConsultingRoomViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task<SaveConsultingRoomViewModel> GetByIdSaveViewModel(int id)
        {
            var consultingRoom = await _repository.GetByIdAsync(id);
            return new SaveConsultingRoomViewModel
            {
                Id = consultingRoom.Id,
                Name = consultingRoom.Name,
            };
        }

        public async Task Update(SaveConsultingRoomViewModel vm)
        {
            var consultingRoomUpdate = new ConsultingRoom
            {
                Name = vm.Name,
            };
            await _repository.UpdateAsync(consultingRoomUpdate);
        }
    }
}
