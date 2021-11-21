Run  
```
docker-compose -f "docker-compose.yml" up -d --build  
```

```
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithoutIndex?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithIndexBTREE?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
```

siege -c25  
(insert new user and get select)
![C10](screens/c25_flushLogLevel0.jpg)  
![C10](screens/c25_flushLogLevel0_BTREE.jpg)  
![C10](screens/c25_flushLogLevel1.jpg)  
![C10](screens/c25_flushLogLevel1_BTREE.jpg)  
![C10](screens/c25_flushLogLevel2.jpg)  
![C10](screens/c25_flushLogLevel2_BTREE.jpg)  

siege -c50  
(insert new user and get select)
![C10](screens/c50_flushLogLevel0.jpg)  
![C10](screens/c50_flushLogLevel0_BTREE.jpg)  
![C10](screens/c50_flushLogLevel1.jpg)  
![C10](screens/c50_flushLogLevel1_BTREE.jpg)  
![C10](screens/c50_flushLogLevel2.jpg)  
![C10](screens/c50_flushLogLevel2_BTREE.jpg)  

siege -c70  
(insert new user and get select)
![C10](screens/c70_flushLogLevel0.jpg)  
![C10](screens/c70_flushLogLevel0_BTREE.jpg)  
![C10](screens/c70_flushLogLevel1.jpg)  
![C10](screens/c70_flushLogLevel1_BTREE.jpg)  
![C10](screens/c70_flushLogLevel2.jpg)  
![C10](screens/c70_flushLogLevel2_BTREE.jpg)  
