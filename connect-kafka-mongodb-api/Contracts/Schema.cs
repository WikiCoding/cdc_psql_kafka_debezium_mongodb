namespace connect_kafka_mongodb_api.Infra;

public record Schema(
    string type,
    List<Field> fields,
    bool optional,
    string name,
    int version
    );