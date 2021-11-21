USE home4db;

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `id` int unsigned not null auto_increment,
  `firstname` varchar(255) not null,
  `datebirth` date not null,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT = 1 CHARACTER SET utf8;

LOAD DATA INFILE '/usr/share/mysql/sql/users.txt'
INTO TABLE `users`
FIELDS TERMINATED BY ','
LINES TERMINATED BY '\n'
IGNORE 1 ROWS
(firstname, dateBirth);

DROP TABLE IF EXISTS `users_with_btree`;

CREATE TABLE `users_with_btree` (
  `id` int unsigned not null auto_increment,
  `firstname` varchar(255) not null,
  `datebirth` date not null,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT = 1 CHARACTER SET utf8;

CREATE INDEX `datebirth_btree` ON `users_with_btree` (`datebirth`) USING BTREE;

INSERT INTO `users_with_btree` (`firstname`, `datebirth`)
SELECT firstname, datebirth FROM `users`;