using LibraryBusiness.Interface.Notificator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Notificator
{
    public class Notificator : INotificator
    {
        public Notificator()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications;
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void HandleNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
