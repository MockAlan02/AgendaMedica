using AgendaMedica.Core.Application.ViewModels.Status;

namespace AgendaMedica.Core.Application.Interface.Service
{
    public interface IStatusService
    {
        Task Add(SaveStatuViewModel vm);
        Task Delete(int id);
        Task<List<StatusViewModel>> GetAllViewModel();
        Task<SaveStatuViewModel> GetByIdSaveViewModel(int id);
        Task Update(SaveStatuViewModel vm);
    }
}