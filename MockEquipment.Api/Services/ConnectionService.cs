using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockEquipment.Api.Services
{
    public class ConnectionService : IConnectionService
    {
        private List<Connection> connections { get; set; }

        public ConnectionService()
        {
            connections = new List<Connection>();
        }

        public Connection CreateConnection(string serialNo)
        {
            RemoveExpiredConnections();

            var connection = new Connection(serialNo);
            connections.Add(connection);
            return connection;
        }

        public Connection? GetConnection(Guid connectionId)
        {
            RemoveExpiredConnections();

            return connections.FirstOrDefault(m => m.ConnectionID == connectionId);
        }

        public void RemoveConnection(Guid connectionId)
        {
            RemoveExpiredConnections();

            connections.RemoveAll(m => m.ConnectionID == connectionId);
        }

        private void RemoveExpiredConnections()
        {
            connections.RemoveAll(m => m.ExpireTime <= DateTime.UtcNow);
        }

        public class Connection
        {
            public Guid ConnectionID { get; private set; }
            public DateTime ExpireTime { get; private set; }
            public string SerialNo { get; private set; }

            public Connection(string serialNo)
            {
                ConnectionID = Guid.NewGuid();
                ExpireTime = DateTime.UtcNow.AddMinutes(2);
                SerialNo = serialNo;
            }
        }
    }
}
