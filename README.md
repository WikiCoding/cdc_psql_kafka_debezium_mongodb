## Summary
Experiment with Kafka-Connect with PostgreSQL Connector Source and MongoDb Connector sink.
I'm using a raw confluentinc kafka connect image, so I'm added the plugins in the volumes section of the image.

## to configure the source and sink
1. make a POST request to http://localhost:8083/connectors with the next configuration bodies

## PostgreSQL configuration:
```json
{
  "name": "pg-source-connector",
  "config": {
    "connector.class": "io.debezium.connector.postgresql.PostgresConnector", 
    "database.hostname": "postgres", 
    "database.port": "5432", 
    "database.user": "postgres", 
    "database.password": "postgres", 
    "database.dbname" : "commerce", 
    "topic.prefix": "commerce", 
    "table.include.list": "public.products"
  }
}
```

## MongoDb configuration
```json
{
  "name": "mongodb-sink-connector",
  "config": {
    "connector.class": "com.mongodb.kafka.connect.MongoSinkConnector",
    "tasks.max": "1",
    "topics": "commerce.public.products",
    "connection.uri": "mongodb://mongouser:mongopass@mongodb:27017",
    "database": "commerce",
    "collection": "products",
    "key.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter": "org.apache.kafka.connect.json.JsonConverter",
    "value.converter.schemas.enable": "false",
    "writemodel.strategy": "com.mongodb.kafka.connect.sink.writemodel.strategy.ReplaceOneBusinessKeyStrategy",
    "document.id.strategy": "com.mongodb.kafka.connect.sink.processor.id.strategy.PartialValueStrategy",
    "document.id.strategy.partial.value.projection.list": "id",
    "document.id.strategy.partial.value.projection.type": "AllowList",

    "transforms": "extractPayload,extractAfter",
    "transforms.extractPayload.type": "org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.extractPayload.field": "payload",
    "transforms.extractAfter.type": "org.apache.kafka.connect.transforms.ExtractField$Value",
    "transforms.extractAfter.field": "after"
  }
}
```

## MongoDb cli cheat sheet
1. Connect:
```bash
mongosh "mongodb://mongouser:mongopass@mongodb:27017/commerce?authSource=admin"
````

2. see dbs:
```bash
show databases
```

3. see collections:
```bash
show collections
```

4. use a db:
```bash
use <db-name>
```

5. find records:
```bash
db.<collection>.find()
```