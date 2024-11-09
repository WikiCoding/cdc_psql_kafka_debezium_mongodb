namespace connect_kafka_mongodb_api.Infra;

public record Source(
    string version,
    string connector,
    string name,
    long ts_ms,
    string snapshot,
    string db,
    string sequence,
    long ts_us,
    long ts_ns,
    string schema,
    string table,
    int txId,
    long lsn,
    string xmin);