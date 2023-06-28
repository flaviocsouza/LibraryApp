using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Notificator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private INotificator _notificator;

        public MainController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool IsValid()
        {
            return !_notificator.HasNotification();
        }

        protected IEnumerable<Notification> GetNotifications()
        {
            return _notificator.GetNotifications();
        }

        protected ActionResult CustonResult(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificateModelStateErrors(modelState);
            return CustomResult();
        }

        private void NotificateModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(m => m.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception is null ? error.ErrorMessage: error.Exception.Message;
                Notificate(errorMessage);
            }
         
        }

        private void Notificate(string errorMessage)
        {
            _notificator.HandleNotification(new Notification(errorMessage));
        }

        protected ActionResult CustomResult(object dataReturn = null)
        {
            if (IsValid())
                return Ok(new
                {
                    success = true,
                    data = dataReturn
                });

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications()
            });
        }
    }
}
