using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using UsersAPI.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Models;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Consumers
{
    public class UserMessageConsumer : BackgroundService
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly EmailMessageService? _emailMessageService;
        private readonly RabbitMQSettings? _rabbitMQSettings;

        private IConnection? _connection;
        private IModel? _model;

        public UserMessageConsumer(IServiceProvider? serviceProvider, EmailMessageService? emailMessageService, IOptions<RabbitMQSettings>? rabbitMQSettings)
        {
            _serviceProvider = serviceProvider;
            _emailMessageService = emailMessageService;
            _rabbitMQSettings = rabbitMQSettings.Value;

            var factory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings?.Url) };
            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(
                queue: _rabbitMQSettings?.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //objeto utilizado para ler e processar a fila
            var consumer = new EventingBasicConsumer(_model);

            //Criando o mecanismo para ler cada item da fila
            consumer.Received += async (sender, args) =>
            {
                //lendo e deserializando o conteudo do item obtido da fila
                var payload = Encoding.UTF8.GetString(args.Body.ToArray());
                var userMessageVO = JsonConvert.DeserializeObject<UserMessageVO>(payload);

                //processando o item
                using (var scope = _serviceProvider.CreateScope())
                {
                    var messageRequestModel = new MessageRequestModel
                    {
                        MailTo = userMessageVO.To,
                        Subject = userMessageVO.Subject,
                        Body = userMessageVO.Body,
                        IsBodyHtml = true
                    };

                    //enviando a mensagem para o email do usuário
                    await _emailMessageService?.SendMessage(messageRequestModel);

                    //removendo o item da fila
                    _model.BasicAck(args.DeliveryTag, false);
                }
            };

            //executando a leitura da fila..
            _model.BasicConsume(_rabbitMQSettings.Queue, false, consumer);
        }
    }
}