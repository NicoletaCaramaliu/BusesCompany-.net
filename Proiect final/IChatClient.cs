namespace Proiect_final
{
    public interface IChatClient
    {
        Task ReceiveMessage(string message);
    }
}
