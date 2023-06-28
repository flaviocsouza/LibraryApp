using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Notificator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
