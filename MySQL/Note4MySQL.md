# Note for MySQL

> MySQL: 关系型数据库

## 一、Operate MySQL in Terminal

## 1. Basic operation

#### (1). Login MySQL

```sql
mysql -u root -p 123456		-- 以root用户，密码123456登录
mysql -u root -p mysql		-- Connect database mysql with user: root, user will be prompted for a password
mysql -h database_host database_name	-- Connect database on other host
mysql -e "source filename.sql" database_name	-- Execute SQL statements in s script file
```

#### (2). Show all databases

```sql
mysql> show databases;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| performance_schema |
| sys                |
+--------------------+
4 rows in set (0.00 sec)
```

#### (3). Use a database

```sql
mysql> use mysql;
Reading table information for completion of table and column names
You can turn off this feature to get a quicker startup with -A

Database changed
```

#### (4). Show all tables in the database

```
mysql> show tables;
```

#### (5). Select statements

```sql
select * from user;
```

#### (6). Create database

```sql
mysql> create database test;
Query OK, 1 row affected (0.04 sec)

mysql> show databases;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| performance_schema |
| sys                |
| test               |
+--------------------+
5 rows in set (0.01 sec)

mysql> use test;
Database changed

mysql> show tables;
Empty set (0.00 sec)
```

#### (7). Create table and describe its structure

```sql
mysql> create table pet(
    -> name varchar(20),
    -> owner varchar(20),
    -> species varchar(20),
    -> sex char(1),
    -> birth date,
    -> death date);
Query OK, 0 rows affected (0.14 sec)

mysql> show tables;
+----------------+
| Tables_in_test |
+----------------+
| pet            |
+----------------+
1 row in set (0.00 sec)

mysql> describe pet;
+---------+-------------+------+-----+---------+-------+
| Field   | Type        | Null | Key | Default | Extra |
+---------+-------------+------+-----+---------+-------+
| name    | varchar(20) | YES  |     | NULL    |       |
| owner   | varchar(20) | YES  |     | NULL    |       |
| species | varchar(20) | YES  |     | NULL    |       |
| sex     | char(1)     | YES  |     | NULL    |       |
| birth   | date        | YES  |     | NULL    |       |
| death   | date        | YES  |     | NULL    |       |
+---------+-------------+------+-----+---------+-------+
6 rows in set (0.01 sec)
```

#### (8). Insert data

```sql
mysql> insert into pet
    -> values('Puffball', 'Diame', 'hamster', 'f', '1999-03-30', NULL);
Query OK, 1 row affected (0.02 sec)

mysql> select * from pet;
+----------+-------+---------+------+------------+-------+
| name     | owner | species | sex  | birth      | death |
+----------+-------+---------+------+------------+-------+
| Puffball | Diame | hamster | f    | 1999-03-30 | NULL  |
+----------+-------+---------+------+------------+-------+
1 row in set (0.00 sec)
```

#### (9). MySQL支持多种类型，大致可以分为三类：数值、日期/时间和字符串(字符)类型。

##### (9.1) 数值类型

|     Type     |                Size(bytes)                 |                        Range(signed)                         |                       Range(unsigned)                        |   Usage    |
| :----------: | :----------------------------------------: | :----------------------------------------------------------: | :----------------------------------------------------------: | :--------: |
|   tinyint    |                     1                      |                         (-128, 127)                          |                           (0, 255)                           |   小整数   |
|   smallint   |                     2                      |                       (-32768, 32767)                        |                          (0, 65535)                          |   大整数   |
|  mediumint   |                     3                      |                      (-2^23 - 1，2^23)                       |                        (0, 2^24 - 1)                         |   大整数   |
| int(integer) |                     4                      |                      (-2^31 - 1, 2^31)                       |                        (0, 2^32 - 1)                         |   大整数   |
|    bigint    |                     8                      |                      (-2^63 - 1, 2^63)                       |                         (0,2^64 - 1)                         |  极大整数  |
|    float     |                     4                      | (-3.402 823 466 E+38，-1.175 494 351 E-38)，0，(1.175 494 351 E-38，3.402 823 466 351 E+38) |         0，(1.175 494 351 E-38，3.402 823 466 E+38)          | 单精度浮点 |
|    double    |                     8                      | (-1.797 693 134 862 315 7 E+308，-2.225 073 858 507 201 4 E-308)，0，(2.225 073 858 507 201 4 E-308，1.797 693 134 862 315 7 E+308) | 0，(2.225 073 858 507 201 4 E-308，1.797 693 134 862 315 7 E+308) | 双精度浮点 |
|   decimal    | 对decimal(m, d), 若m>d, 则为m+2; 否则为d+2 |                          依赖于m和d                          |                          依赖于m和d                          |   小数值   |

##### (9.2) 日期和时间类型

|   Type    | Size(bytes) |                            Range                             |       Format        |          Usage           |
| :-------: | :---------: | :----------------------------------------------------------: | :-----------------: | :----------------------: |
|   date    |      3      |                    1000-01-01/9999-12-31                     |     YYYY-MM-DD      |          日期值          |
|   time    |      3      |                   '-838:59:59'/'838:59:59'                   |      HH:MM:SS       |     时间值或持续时间     |
|   year    |      1      |                          1901/2155                           |        YYYY         |          年份值          |
| datetime  |      8      |           1000-01-01 00:00:00/9999-12-31 23:59:59            | YYYY-MM-DD HH:MM:SS |     混合日期和时间值     |
| timestamp |      4      | 1970-01-01 00:00:00/2038 结束时间是第 **2147483647** 秒，北京时间 **2038-1-19 11:14:07**，格林尼治时间 2038年1月19日 凌晨 03:14:07 |   YYYYMMDD HHMMSS   | 混合日期和时间值，时间戳 |

##### (9.3) 字符串类型

|    Type    |   Size(bytes)   | Usage                         |
| :--------: | :-------------: | ----------------------------- |
|    char    |      0-255      | 定长字符串                    |
|  varchar   |     0-65535     | 变长字符串                    |
|  tinyblob  |      0-255      | 不超过255个字符的二进制字符串 |
|  tinytext  |      0-255      | 短文本字符串                  |
|    blob    |     0-65535     | 二进制形式的长文本数据        |
|    text    |     0-65535     | 长文本数据                    |
| mediumblob |  0-16 777 215   | 二进制形式的中等长度文本数据  |
| mediumtext |  0-16 777 215   | 中等长度文本数据              |
|  longblob  | 0-4 294 967 295 | 二进制形式的极大文本数据      |
|  longtext  | 0-4 294 967 295 | 极大文本数据                  |

##### (10). Delete data

```sql
mysql> delete from pet where name = 'Fluffy';
Query OK, 1 row affected (0.02 sec)
```

##### (11). Update data

```sql
mysql> update pet set owner='Rophen' where name='Chirpy';
Query OK, 1 row affected (0.03 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> select * from pet;
+----------+--------+---------+------+------------+------------+
| name     | owner  | species | sex  | birth      | death      |
+----------+--------+---------+------+------------+------------+
| Puffball | Diame  | hamster | f    | 1999-03-30 | NULL       |
| Claws    | Gwen   | cat     | m    | 1994-04-03 | NULL       |
| Buffy    | Harold | dog     | f    | 1989-05-13 | NULL       |
| Fang     | Benny  | dog     | m    | 1990-08-27 | NULL       |
| Bowser   | Diane  | dog     | m    | 1979-08-31 | 1995-07-29 |
| Chirpy   | Rophen | bird    | f    | 1998-09-11 | NULL       |
| Whistle  | Gwen   | bird    | NULL | 1997-12-09 | NULL       |
| Slim     | Benny  | snake   | m    | 1996-04-29 | NULL       |
| Puffball | Diane  | hamster | f    | 1999-03-30 | NULL       |
+----------+--------+---------+------+------------+------------+
9 rows in set (0.01 sec)
```

> 数据记录常见操作：
>
> 1. 增 insert
> 2. 删 delete
> 3. 改 update
> 4. 查 select

### 2. Constraints Key

#### (1). Primary key: 能够唯一确定一张表中的一条记录，即通过给某字段添加约束，使得该字段不重复且不为空

```sql
mysql> create table user(
    -> id int primary key,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.23 sec)

mysql> describe user;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | NO   | PRI | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.04 sec)

mysql> insert into user values(1, 'zhangsan');
Query OK, 1 row affected (0.03 sec)

mysql> insert into user values(1, 'zhangsan');
ERROR 1062 (23000): Duplicate entry '1' for key 'user.PRIMARY'

mysql> insert into user values(2, 'zhangsan');
Query OK, 1 row affected (0.03 sec)

mysql> select * from user;
+----+----------+
| id | name     |
+----+----------+
|  1 | zhangsan |
|  2 | zhangsan |
+----+----------+
2 rows in set (0.00 sec)

mysql> insert into user values(NULL, 'zhangsan');
ERROR 1048 (23000): Column 'id' cannot be null
```



#### (2). Auto-increment

#### (3). Foreign key

#### (4). Unique key

#### (5). Not NULL

#### (6). Default

## 二、如何使用可视化工具操作数据库？





## 三、如何在编程语言中操作数据库？