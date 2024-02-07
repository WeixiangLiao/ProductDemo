using ProductDemo.Server.Application.Abstract.Infrastructure;
using System.Diagnostics;

namespace ProductDemo.Server.Infrastructure.Notification
{
    public class NotifyImplementation : INotify
    {
        public void Notify(string userId, string message)
        {
             Debug.WriteLine($"Sending message...{userId} - {message}");
        }

    }
}
