using AgendaMedica.Core.Application.ViewModels.ConsultingRoom;
using AgendaMedica.Core.Domain.Entities;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IConsultingRoomService : IGenericService<SaveConsultingRoomViewModel, ConsultingRoomViewModel>
    { 
        Task<ConsultingRoom> AddAsync(SaveConsultingRoomViewModel vm);
    }
}