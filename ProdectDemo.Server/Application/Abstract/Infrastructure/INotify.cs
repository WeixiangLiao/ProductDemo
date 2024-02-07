namespace ProductDemo.Server.Application.Abstract.Infrastructure
{
    public interface INotify
    {
        public void Notify(string userId, string message);
    }
}
