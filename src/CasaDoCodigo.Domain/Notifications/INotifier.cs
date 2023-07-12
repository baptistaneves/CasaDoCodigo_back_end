namespace CasaDoCodigo.Domain.Notifications;

public interface INotifier
{
    void Handle(Notification notification);
    bool HasNotifications();
    List<Notification> GetNotifications();
}
