namespace connect_kafka_mongodb_api.Infra;

public record Payload(
    Before before, 
    After after,
    Source source,
    string transaction,
    string op,
    long ts_ms,
    long ts_us,
    long ts_ns
    );
