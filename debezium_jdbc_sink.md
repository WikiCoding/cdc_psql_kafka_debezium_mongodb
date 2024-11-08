POST to http://localhost:8083/connectors

Body (just works with sql db's, so check this configuration in Debezium website):
```json
{
  "name": "mongo-sink-connector",
  "config": {
    "connector.class": "io.debezium.connector.jdbc.JdbcSinkConnector",
    "tasks.max": "1",
    "topics": "commerce.public.Products",
    "connection.url": "jdbc:mongo://mongodb:27017/commerce",
    "connection.username": "mongouser",
    "connection.password": "mongopass",
    "auto.create": "true",
    "insert.mode": "upsert",
    "primary.key.mode": "record_key",
    "primary.key.fields": "productId",
    "key.converter": "org.apache.kafka.connect.storage.StringConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter.schemas.enable": "false",
    "writemodel.strategy": "com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneDefaultStrategy"
  }
}
```

docker-compose debezium kafka-connect sink service:
```yaml
connector:
    image: quay.io/debezium/connect
    ports:
      - "8083:8083"
    environment:
      GROUP_ID: 1
      CONFIG_STORAGE_TOPIC: _connect_configs
      OFFSET_STORAGE_TOPIC: _connect_offsets
      STATUS_STORAGE_TOPIC: _connect_status
      BOOTSTRAP_SERVERS: kafka:9092
      CONNECT_CONFIG_STORAGE_REPLICATION_FACTOR: 1
      CONNECT_OFFSET_STORAGE_REPLICATION_FACTOR: 1
      CONNECT_STATUS_STORAGE_REPLICATION_FACTOR: 1
    depends_on:
      - zookeeper
      - kafka
```

To see what connectors are available:
GET to http://localhost:8083/connector-plugins