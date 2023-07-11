using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using UsersAPI.Domain.Interfaces.Messages;
using UsersAPI.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Producers
{
    public class UserMessageProducer : IUserMessageProducer
    {
        private readonly RabbitMQSettings rabbitmqSettings;

        public UserMessageProducer(IOptions<RabbitMQSettings> rabbitmqSettings)
        {
            this.rabbitmqSettings = rabbitmqSettings.Value;
        }

        public void Send(UserMessageVO userMessage)
        {
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(rabbitmqSettings?.Url) };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    //Criando a fila
                    model.QueueDeclare(
                            queue: rabbitmqSettings.Queue,
                            durable: true, //Mantem as mensagens na fila quando o consumer caia 
                            autoDelete: false, //Apaga a fila quando tiver vazia
                            exclusive: false, //Fila exclusiva para uma única aplicação 
                            arguments: null
                        );

                    //Gravando mensagem na fila
                    model.BasicPublish(
                            exchange: string.Empty,
                            routingKey: rabbitmqSettings.Queue,
                            body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userMessage))
                        );
                }
            }
        }
    }
}
