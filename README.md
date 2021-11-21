Run  
```
docker-compose -f "docker-compose.yml" up -d --build  
```

```
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithoutIndex?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
siege -c10 -t60S http://127.0.0.1:8082/mysqltest/GetWithIndexBTREE?datebirth={FORMAT: yyyy-MM-dd}&flushLogLevel={VALUE: innodb_flush_log_at_trx_commit}  
```

siege -c25  
![C10](screens/c10.jpg)  

siege -c25  
![C10](screens/c25.jpg)  

siege -c50  
![C10](screens/c50.jpg)  
