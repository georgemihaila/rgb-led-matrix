using RabbitMQ.Client;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDMatrix.Core.Canvas.Drawing.Remote
{
    public abstract class RabbitMQConnectionBase
    {
        protected readonly string _hostName;
        protected readonly string _username;
        protected readonly string _password;
        protected readonly string _exchangeName;
        protected readonly ConnectionFactory _connectionFactory;
        protected readonly IConnection _connection;

        public RabbitMQConnectionBase(string hostName, string username, string password, string exchangeName)
        {
            _hostName = hostName;
            _username = username;
            _password = password;
            _exchangeName = exchangeName;

            _connectionFactory = new ConnectionFactory { HostName = _hostName, UserName = _username, Password = _password };
            _connection = _connectionFactory.CreateConnection();
        }
    }
}
