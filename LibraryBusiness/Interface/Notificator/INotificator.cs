using LibraryBusiness.Notificator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Interface.Notificator
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void HandleNotification(Notification notification);
    }
}
