namespace Client.Stream
{
    public interface IClientChannel
    {
        Task AddStreamEvent();
        Task InitStream();
    }
}