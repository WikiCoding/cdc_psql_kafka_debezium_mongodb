namespace connect_kafka_mongodb_api.Infra;

public record Field(
    string type,
    bool optional,
    string name,
    int version,
    string field
);
