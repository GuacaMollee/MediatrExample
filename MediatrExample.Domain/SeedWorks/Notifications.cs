namespace Example.Ordering.Domain.SeedWorks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MediatR;

    public class Notifications
    {
        private readonly List<INotification> _myNotifications;

        private Notifications(params INotification[] notifications) =>
            _myNotifications = notifications.ToList();

        public void AddNotification(INotification notification) =>
            _myNotifications.Add(notification);

        public IEnumerable<Task> Select(Func<INotification, Task> action) =>
            _myNotifications.Select(action);

        public static Notifications CreateFrom(params INotification[] notifications) =>
            new Notifications(notifications);
    }
}
