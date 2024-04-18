# 1) Create Kafka Server (docker-compose.yml file)
docker-compose up -d --build

# 2) Create Topic
docker exec -it d5951a6a35d8 /opt/kafka/bin/kafka-topics.sh --create --zookeeper zookeeper:2181 --replication-factor 1 --partitions 1 --topic testtopic3

# OPTIONAL: Produce-Consume in terminal

### Produce Message
docker exec -it d5951a6a35d8 /opt/kafka/bin/kafka-console-producer.sh --broker-list localhost:9092 --topic testtopic3

### Consume Message
docker exec -it d5951a6a35d8 /opt/kafka/bin/kafka-console-consumer.sh --bootstrap-server localhost:9092 --topic testtopic3 --from-beginning

# 3) Stop Kafka
docker-compose down