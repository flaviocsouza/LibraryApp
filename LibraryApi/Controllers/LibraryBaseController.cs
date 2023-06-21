using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Notificator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public abstract class LibraryBaseController : ControllerBase
    {
        private INotificator _notificator;

        public LibraryBaseController(INotificator notificator)
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
    }
}
