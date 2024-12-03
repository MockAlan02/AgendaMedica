using AgendaMedica.Core.Application.ViewModels.User;
using AgendaMedica.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using AgendaMedica.Core.Application;

namespace Agencita.Presentation.Middlewares
{
    public class ValidateUserSession : IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly Dictionary<RoleEnum, List<string>> _rolePermissions;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            _rolePermissions = new Dictionary<RoleEnum, List<string>>()
        {
            {
                RoleEnum.Administrador, new List<string>
                {
                    "Admin",
                    "Doctor",
                    "Laboratorytest",
                    "User"
                }
            },
            {
                RoleEnum.Asistente, new List<string>
                {
                    "Patient",
                    "LaboratoryResult",
                    "Appointments",
                    "User"
                }
            }
        };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var action = context.ActionDescriptor.RouteValues["action"];
            var controller = context.ActionDescriptor.RouteValues["controller"];


            UserViewModel userViewModel = _contextAccessor.HttpContext!.Session.Get<UserViewModel>("user");


            if (userViewModel == null)
            {
                if (controller == "User" && (action == "Login" || action == "Register"))
                {
                    return;
                }
                else
                {
                    context.Result = new RedirectResult("/User/Login");
                }
            }
          
            else
            {
                if (userViewModel.RoleId != 0 && _rolePermissions.TryGetValue((RoleEnum)userViewModel.RoleId, out var allowedControllers))
                {
                    if (allowedControllers.Contains(controller!))
                    {
                        return;
                    }
                    else
                    {
                        var firstAllowedController = allowedControllers[0];
                        context.Result = new RedirectResult($"/{firstAllowedController}");
                        return;
                    }
                }
                context.Result = new RedirectResult("/Home/Index"); // Usuario no autorizado
            }




        }
    }
}
