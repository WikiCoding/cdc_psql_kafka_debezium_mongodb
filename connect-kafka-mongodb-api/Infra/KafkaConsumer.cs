using Confluent.Kafka;
using connect_kafka_mongodb_api.Repository;

namespace connect_kafka_mongodb_api.Infra;

public class KafkaConsumer : BackgroundService
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;
    private const string TOPIC = "commerce.public.Products";
    private readonly ILogger<KafkaConsumer> _logger;

    public KafkaConsumer(IConfiguration configuration, IServiceProvider serviceProvider, ILogger<KafkaConsumer> logger)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
        _logger = logger;
        
        _logger.LogWarning(_configuration["Kafka:BootstrapServers"]);
        
        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"],
            GroupId = "DbUpdatesConsumerGroup",
            AutoOffsetReset = AutoOffsetReset.Earliest,
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(TOPIC);

        while (!stoppingToken.IsCancellationRequested)
        {
            await ConsumeMessage(stoppingToken);

            await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
        }

        _consumer.Close();
    }
    
    private async Task ConsumeMessage(CancellationToken stoppingToken)
        {
            var consumeResult = _consumer.Consume(stoppingToken);

            if (consumeResult is null) { return; }

            var message = consumeResult.Message.Value;

            _logger.LogWarning("Received message {message}", message);

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                // dbContext.Add();
                // await dbContext.SaveChangesAsync(stoppingToken);
            }
        }
}