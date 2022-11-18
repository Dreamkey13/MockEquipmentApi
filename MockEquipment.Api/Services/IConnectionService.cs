namespace MockEquipment.Api.Services
{
    public interface IConnectionService
    {
        ConnectionService.Connection CreateConnection(string serialNo);
        ConnectionService.Connection? GetConnection(Guid connectionId);
        void RemoveConnection(Guid connectionId);
    }
}