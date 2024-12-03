using AgendaMedica.Core.Application.ViewModels.Laboratorytest;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface ILaboratoryTestService : IGenericService<SaveLaboratorySaveViewModel, LaboratoryTestViewModel>
    {
        Task<IEnumerable<LaboratoryTestViewModel>> GetTestsByConsultingRoomId(int id);
    }
}