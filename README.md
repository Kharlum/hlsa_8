# Run #
```
docker-compose -f "docker-compose.yml" up -d --build  
```

```
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithoutIndex?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithIndexBTREE?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
```

## siege -c25 ##
(insert new user and get select)  
![C10](screens/c25_flushLogLevel0.jpg "without index and with innodb_flush_log_at_trx_commit = 0")  
socket: 537147848 select timed out: Connection timed out  
![C10](screens/c25_flushLogLevel0_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 0")  
![C10](screens/c25_flushLogLevel1.jpg "without index and with innodb_flush_log_at_trx_commit = 1")  
![C10](screens/c25_flushLogLevel1_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 1")  
![C10](screens/c25_flushLogLevel2.jpg "without index and with innodb_flush_log_at_trx_commit = 2")  
socket: 537146840 select timed out: Connection timed out  
![C10](screens/c25_flushLogLevel2_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 2")  

## siege -c50 ##
(insert new user and get select)  
![C10](screens/c50_flushLogLevel0.jpg "without index and with innodb_flush_log_at_trx_commit = 0")  
socket: 537154472 select timed out: Connection timed out  
![C10](screens/c50_flushLogLevel0_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 0")  
![C10](screens/c50_flushLogLevel1.jpg "without index and with innodb_flush_log_at_trx_commit = 1")  
socket: 537152456 select timed out: Connection timed out  
![C10](screens/c50_flushLogLevel1_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 1")  
socket: 537150592 select timed out: Connection timed out  
![C10](screens/c50_flushLogLevel2.jpg "without index and with innodb_flush_log_at_trx_commit = 2")  
socket: 537154760 select timed out: Connection timed out
![C10](screens/c50_flushLogLevel2_BTREE.jpg "without index BTREE and with innodb_flush_log_at_trx_commit = 2")  
