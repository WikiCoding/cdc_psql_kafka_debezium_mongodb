namespace connect_kafka_mongodb_api.Infra;

public record DebeziumMessage(
    Schema schema,
    Payload payload
    );