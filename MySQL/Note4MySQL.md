# Note for MySQL

> MySQL: 关系型数据库

## 一、Operate MySQL in Terminal

### 1. Basic operation

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

联合主键：只要联合的主键值加起来不重复就可以

```sql
mysql> create table user2(
    -> id int,
    -> name varchar(20),
    -> password varchar(20),
    -> primary key(id, name)
    -> );
Query OK, 0 rows affected (0.11 sec)

mysql> insert into user2 values(1, 'zhangsan', '123');
mysql> insert into user2 values(2, 'zhangsan', '123');
mysql> insert into user2 values(1, 'lisi', '123');
mysql> insert into user2 values(NULL, 'zhangsan', '123');
```

#### (2). Auto-increment

```sql
mysql> create table user3(
    -> id int primary key auto_increment,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.14 sec)

mysql> insert into user3 (name) values('zhangsan');
Query OK, 1 row affected (0.02 sec)

mysql> select * from user3;
+----+----------+
| id | name     |
+----+----------+
|  1 | zhangsan |
+----+----------+
1 row in set (0.00 sec)

mysql> insert into user3 (name) values('zhangsan');
Query OK, 1 row affected (0.03 sec)

mysql> select * from user3;
+----+----------+
| id | name     |
+----+----------+
|  1 | zhangsan |
|  2 | zhangsan |
+----+----------+
2 rows in set (0.00 sec)
```

如果创建表的时候，忘记创建主键约束，怎么办？

```sql
mysql> create table user4(
    -> id int,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.08 sec)

mysql> desc user4;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.01 sec)

mysql> alter table user4 add primary key(id);
Query OK, 0 rows affected (0.13 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user4;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | NO   | PRI | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> alter table user4 drop primary key;
Query OK, 0 rows affected (0.21 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user4;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | NO   |     | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> alter table user4 modify id int primary key;
Query OK, 0 rows affected (0.12 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user4;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | NO   | PRI | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)
```

#### (3). Unique key

```sql
mysql> create table user5(
    -> id int, 
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.09 sec)

mysql> alter table user5 add unique(id);
Query OK, 0 rows affected (0.07 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user5;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  | UNI | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.01 sec)

mysql> insert into user5 values(1, 'zhangsan');
Query OK, 1 row affected (0.02 sec)

mysql> insert into user5 values(1, 'zhangsan');
ERROR 1062 (23000): Duplicate entry '1' for key 'user5.id'

mysql> insert into user5 values(1, 'lisi');
ERROR 1062 (23000): Duplicate entry '1' for key 'user5.id'

mysql> create table user6(
    -> id int,
    -> name varchar(20),
    -> unique(name)
    -> );
Query OK, 0 rows affected (0.11 sec)

mysql> create table user7(
    -> id int,
    -> name varchar(20) unique,
    -> );
Query OK, 0 rows affected (0.11 sec)

mysql> create table user8( id int, name varchar(20), unique(id, name));
Query OK, 0 rows affected (0.12 sec)

mysql> desc user8;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  | MUL | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.01 sec)

mysql> desc user7;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | YES  | UNI | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> alter table user7 drop index name;
Query OK, 0 rows affected (0.04 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user7;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> alter table user7 modify name varchar(20) unique;
Query OK, 0 rows affected (0.07 sec)
Records: 0  Duplicates: 0  Warnings: 0

mysql> desc user7;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | YES  | UNI | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)
```

> 总结：
>
> 1. 建表时就添加约束；
> 2. 添加可以使用alter...add...
> 3. 修改可以使用alter...modify...
> 4. 删除可以使用alter...drop...

#### (4). Not NULL：修饰的字段不能为空NULL

```sql
mysql> create table user9(
    -> id int, 
    -> name varchar(20) not null
    -> );
Query OK, 0 rows affected (0.09 sec)

mysql> desc user9;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | NO   |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> insert into user9 (id) values(1);
ERROR 1364 (HY000): Field 'name' doesn't have a default value

mysql> insert into user9 (name) values('lisi');
Query OK, 1 row affected (0.01 sec)

mysql> select * from user9;
+------+------+
| id   | name |
+------+------+
| NULL | lisi |
+------+------+
1 row in set (0.00 sec)
```

#### (5). Default：当插入字段值当时候，如果没有传值，就会使用默认值

```sql
mysql> create table user10(
    -> id int,
    -> name varchar(20),
    -> age int default 10
    -> );
Query OK, 0 rows affected (0.10 sec)

mysql> desc user10;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | YES  |     | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
| age   | int         | YES  |     | 10      |       |
+-------+-------------+------+-----+---------+-------+
3 rows in set (0.01 sec)

mysql> insert into user10 (id, name) values(1, 'zhangsan');
Query OK, 1 row affected (0.01 sec)

mysql> select * from user10;
+------+----------+------+
| id   | name     | age  |
+------+----------+------+
|    1 | zhangsan |   10 |
+------+----------+------+
1 row in set (0.00 sec)

mysql> insert into user10 values(1, 'lisi', 19);
Query OK, 1 row affected (0.02 sec)

mysql> select * from user10;
+------+----------+------+
| id   | name     | age  |
+------+----------+------+
|    1 | zhangsan |   10 |
|    1 | lisi     |   19 |
+------+----------+------+
2 rows in set (0.00 sec)
```

#### (6). Foreign key：设计到两个表（父表/子表 or 主表/副表）

```sql
mysql> create table classes(
    -> id int primary key,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.10 sec)

mysql> create table students(
    -> id int primary key,
    -> name varchar(20),
    -> class_id int,
    -> foreign key(class_id) references classes(id)
    -> );
Query OK, 0 rows affected (0.13 sec)

mysql> desc classes;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| id    | int         | NO   | PRI | NULL    |       |
| name  | varchar(20) | YES  |     | NULL    |       |
+-------+-------------+------+-----+---------+-------+
2 rows in set (0.00 sec)

mysql> desc students;
+----------+-------------+------+-----+---------+-------+
| Field    | Type        | Null | Key | Default | Extra |
+----------+-------------+------+-----+---------+-------+
| id       | int         | NO   | PRI | NULL    |       |
| name     | varchar(20) | YES  |     | NULL    |       |
| class_id | int         | YES  | MUL | NULL    |       |
+----------+-------------+------+-----+---------+-------+
3 rows in set (0.00 sec)

mysql> insert into classes values(1, 'One');
Query OK, 1 row affected (0.02 sec)

mysql> insert into classes values(2, 'Two');
Query OK, 1 row affected (0.02 sec)

mysql> insert into classes values(3, 'Three');
Query OK, 1 row affected (0.02 sec)

mysql> insert into classes values(4, 'Four');
Query OK, 1 row affected (0.01 sec)

mysql> select * from classes;
+----+-------+
| id | name  |
+----+-------+
|  1 | One   |
|  2 | Two   |
|  3 | Three |
|  4 | Four  |
+----+-------+
4 rows in set (0.00 sec)

mysql> insert into students values(1001, 'zhangsan', 1);
Query OK, 1 row affected (0.02 sec)

mysql> insert into students values(1002, 'zhangsan', 2);
Query OK, 1 row affected (0.03 sec)

mysql> insert into students values(1003, 'zhangsan', 3);
Query OK, 1 row affected (0.01 sec)

mysql> insert into students values(1004, 'zhangsan', 4);
Query OK, 1 row affected (0.01 sec)

mysql> insert into students values(1005, 'zhangsan', 5);
ERROR 1452 (23000): Cannot add or update a child row: a foreign key constraint fails (`test`.`students`, CONSTRAINT `students_ibfk_1` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`))

mysql> delete from classes where id=4;
ERROR 1451 (23000): Cannot delete or update a parent row: a foreign key constraint fails (`test`.`students`, CONSTRAINT `students_ibfk_1` FOREIGN KEY (`class_id`) REFERENCES `classes` (`id`))
```

> 总结：
>
> 1. 主表classes中没有的数据值，在副表中，是不可以使用的。
> 2. 主表中的记录被副表引用，是不能被删除的

### 3. 数据库的三大设计范式

#### 3.1 第一范式(1NF)：数据表中的所有字段都是不可分割的原子值

```sql
mysql> create table students2(
    -> id int primary key,
    -> name varchar(20),
    -> address varchar(30)
    -> );
Query OK, 0 rows affected (0.06 sec)

mysql> insert into students2 values(1, 'zhangsan', 'Chian, SiChuan, ChengDu, Avenue 1st');
Query OK, 1 row affected (0.02 sec)

mysql> insert into students2 values(2, 'lisi', 'Chian, SiChuan, ChengDu, Avenue 2nd');
Query OK, 1 row affected (0.02 sec)

mysql> insert into students2 values(3, 'wangwu', 'Chian, SiChuan, ChengDu, Avenue 3rd');
Query OK, 1 row affected (0.01 sec)

mysql> select * from students2;
+----+----------+-------------------------------------+
| id | name     | address                             |
+----+----------+-------------------------------------+
|  1 | zhangsan | Chian, SiChuan, ChengDu, Avenue 1st |
|  2 | lisi     | Chian, SiChuan, ChengDu, Avenue 2nd |
|  3 | wangwu   | Chian, SiChuan, ChengDu, Avenue 3rd |
+----+----------+-------------------------------------+
3 rows in set (0.00 sec)
```

> 字段值还可以继续拆分的，就不满足第一范式

```sql
mysql> create table students3(
    -> id int primary key,
    -> name varchar(20),
    -> country varchar(30),
    -> province varchar(30),
    -> city varchar(30),
    -> details varchar(30)
    -> );
Query OK, 0 rows affected (0.06 sec)

mysql> insert into students3 values(1, 'zhangsan', 'Chian', 'SiChuan', 'ChengDu', 'Avenue 1st');
Query OK, 1 row affected (0.02 sec)

mysql> insert into students3 values(2, 'zhangsan', 'Chian', 'SiChuan', 'ChengDu', 'Avenue 2nd');
Query OK, 1 row affected (0.03 sec)

mysql> insert into students3 values(3, 'zhangsan', 'Chian', 'SiChuan', 'ChengDu', 'Avenue 3rd');
Query OK, 1 row affected (0.01 sec)

mysql> select * from students3;
+----+----------+---------+----------+---------+------------+
| id | name     | country | province | city    | details    |
+----+----------+---------+----------+---------+------------+
|  1 | zhangsan | Chian   | SiChuan  | ChengDu | Avenue 1st |
|  2 | zhangsan | Chian   | SiChuan  | ChengDu | Avenue 2nd |
|  3 | zhangsan | Chian   | SiChuan  | ChengDu | Avenue 3rd |
+----+----------+---------+----------+---------+------------+
3 rows in set (0.00 sec)
```

> 范式，设计得越详细，对于某些实际操作可能越好，但是不一定都是好处

#### 3.2 第二范式(2NF)：必须先满足第一范式，要求除主键外的每一列都必须完全依赖主键。

> 如果出现不完全依赖，只可能发生在联合主键的情况下

```sql
mysql> create table myOrder(		-- 订单表
    -> product_id int,
    -> customer_id int,
    -> product_name varchar(20),
    -> customer_name varchar(20),
    -> primary key(product_id, customer_id)
    -> );
Query OK, 0 rows affected (0.07 sec)
```

> 上表除主键外的其它字段，只依赖于主键的部分字段，不满足第二范式
>
> 解决方式：拆表

```sql
mysql> create table myOrder(
    -> order_id int primary key,
    -> product_id int,
    -> customer_id int
    -> );
Query OK, 0 rows affected (0.08 sec)

mysql> create table product(
    -> id int primary key,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.09 sec)

mysql> create table customer(
    -> id int primary key,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.11 sec)
```

> 分成三个表后，满足第二范式

#### 3.3 第三范式(3NF)：必须先满足第二范式，除了主键列的其它列之间不能有传递依赖关系

```sql
mysql> create table customer(
    -> id int primary key,
    -> name varchar(20),
    -> phone varchar(20)
    -> );
Query OK, 0 rows affected (0.11 sec)
```

### 4. 查询练习

#### 4.1 数据表准备

```sql
mysql> create database SelectTest;
Query OK, 1 row affected (0.02 sec)

mysql> use SelectTest;
Database changed

-- 学生表
mysql> create table student(
    -> sno varchar(20) primary key,
    -> sname varchar(20) not null,
    -> ssex varchar(10) not null,
    -> sbirthday datetime,
    -> class varchar(20)
    -> );
Query OK, 0 rows affected (0.12 sec)

mysql> desc student;
+-----------+-------------+------+-----+---------+-------+
| Field     | Type        | Null | Key | Default | Extra |
+-----------+-------------+------+-----+---------+-------+
| sno       | varchar(20) | NO   | PRI | NULL    |       |
| sname     | varchar(20) | NO   |     | NULL    |       |
| ssex      | varchar(10) | NO   |     | NULL    |       |
| sbirthday | datetime    | YES  |     | NULL    |       |
| class     | varchar(20) | YES  |     | NULL    |       |
+-----------+-------------+------+-----+---------+-------+
5 rows in set (0.00 sec)

-- 课程表
mysql> create table course(
    -> cno varchar(20) primary key,
    -> cname varchar(20) not null,
    -> tno varchar(20) not null, 
    -> foreign key(tno) references teacher(tno)
    -> );
Query OK, 0 rows affected (0.12 sec)

mysql> desc course;
+-------+-------------+------+-----+---------+-------+
| Field | Type        | Null | Key | Default | Extra |
+-------+-------------+------+-----+---------+-------+
| cno   | varchar(20) | NO   | PRI | NULL    |       |
| cname | varchar(20) | NO   |     | NULL    |       |
| tno   | varchar(20) | NO   | MUL | NULL    |       |
+-------+-------------+------+-----+---------+-------+
3 rows in set (0.00 sec)

-- 成绩表
mysql> create table score(
    -> sno varchar(20) not null,
    -> cno varchar(20) not null,
    -> degree decimal,
    -> foreign key(sno) references student(sno),
    -> foreign key(cno) references course(cno),
    -> primary key(sno, cno)
    -> );
Query OK, 0 rows affected (0.11 sec)
    
-- 教师表
mysql> create table teacher(
    -> tno varchar(20) primary key,
    -> tname varchar(20) not null,
    -> tsex varchar(10) not null,
    -> tbierthday datetime,
    -> prof varchar(20),
    -> department varchar(20) not null
    -> );
Query OK, 0 rows affected (0.09 sec)

mysql> desc teacher;
+------------+-------------+------+-----+---------+-------+
| Field      | Type        | Null | Key | Default | Extra |
+------------+-------------+------+-----+---------+-------+
| tno        | varchar(20) | NO   | PRI | NULL    |       |
| tname      | varchar(20) | NO   |     | NULL    |       |
| tsex       | varchar(10) | NO   |     | NULL    |       |
| tbierthday | datetime    | YES  |     | NULL    |       |
| prof       | varchar(20) | YES  |     | NULL    |       |
| department | varchar(20) | NO   |     | NULL    |       |
+------------+-------------+------+-----+---------+-------+
6 rows in set (0.00 sec)

-- Fill data
-- Student info
insert into student values('101', 'A', 'm', '1900-09-01', '96033');
insert into student values('102', 'K', 'm', '1902-10-01', '96031');
insert into student values('103', 'B', 'm', '1901-01-20', '96033');
insert into student values('104', 'C', 'm', '1901-05-04', '96033');
insert into student values('105', 'Y', 'f', '1900-02-03', '96031');
insert into student values('106', 'X', 'm', '1901-07-15', '96031');
insert into student values('107', 'Z', 'm', '1901-07-15', '96033');
insert into student values('108', 'H', 'f', '1901-07-15', '96031');
insert into student values('109', 'G', 'f', '1901-07-15', '96031');
-- Teacher info
insert into teacher values('093', 'AA', 'm', '1887-12-03', 'Prof', 'CS');
insert into teacher values('102', 'BB', 'm', '1898-10-01', 'Lecture', 'EE');
insert into teacher values('195', 'CC', 'f', '1892-02-20', 'Assistant', 'CS');
insert into teacher values('209', 'DD', 'f', '1898-08-03', 'Assistant', 'EE');
-- Course info
insert into course values('3-105', 'DataStructure', '102');
insert into course values('3-245', 'Network', '195');
insert into course values('6-295', 'Architecture', '093');
insert into course values('10-232', 'System', '209');
-- Score info
insert into score values('103', '3-105', '76');
insert into score values('101', '3-105', '98');
insert into score values('102', '3-245', '43');
insert into score values('104', '6-295', '74');
insert into score values('105', '3-105', '89');
insert into score values('105', '6-295', '56');
insert into score values('106', '10-232', '75');
insert into score values('108', '10-232', '23');
insert into score values('107', '3-105', '76');
insert into score values('109', '6-295', '62');
insert into score values('108', '6-295', '76');
insert into score values('107', '10-232', '71');
```

#### 4.2 查询练习

##### 1. 查询student表中的所有记录

```sql
mysql> select * from student;
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 101 | A     | m    | 1900-09-01 00:00:00 | 96033 |
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
9 rows in set (0.01 sec)
```

##### 2. 查询student表中所有记录的sname、ssex、class列

```sql
mysql> select sname, ssex, class from student;
+-------+------+-------+
| sname | ssex | class |
+-------+------+-------+
| A     | m    | 96033 |
| K     | m    | 96031 |
| B     | m    | 96033 |
| C     | m    | 96033 |
| Y     | f    | 96031 |
| X     | m    | 96031 |
| Z     | m    | 96033 |
| H     | f    | 96031 |
| G     | f    | 96031 |
+-------+------+-------+
9 rows in set (0.01 sec)
```

##### 3. 查询教师所有的单位，即不重复的department列

```sql
mysql> select distinct department from teacher;		-- distinct 去重
+------------+
| department |
+------------+
| CS         |
| EE         |
+------------+
2 rows in set (0.01 sec)
```

##### 4. 查询score表中成绩在60-80之间的所有记录(查询区间)

```sql
-- 法一：between...and...
mysql> select * from score where degree between 60 and 80;
-- 法二：直接用运算符比较
mysql> select * from score where degree > 60 and degree < 80;
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 103 | 3-105  |     76 |
| 104 | 6-295  |     74 |
| 106 | 10-232 |     75 |
| 107 | 10-232 |     71 |
| 107 | 3-105  |     76 |
| 108 | 6-295  |     76 |
| 109 | 6-295  |     62 |
+-----+--------+--------+
7 rows in set (0.00 sec)
```

##### 5. 查询score表中成绩为75、76或78的记录

```sql
-- 表示或关系
mysql> select * from score where degree in (75, 76, 78);
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 103 | 3-105  |     76 |
| 106 | 10-232 |     75 |
| 107 | 3-105  |     76 |
| 108 | 6-295  |     76 |
+-----+--------+--------+
4 rows in set (0.01 sec)
```

##### 6. 查询student表中‘95031’班或性别为‘f’的同学记录

```sql
-- or 表示或关系
mysql> select * from student where class = '95031' or ssex = 'f';
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
3 rows in set (0.01 sec)
```

##### 7. 以class降序查询student表的所有记录

```sql
-- 升序 asc(default)
mysql> select * from student order by class asc;
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
| 101 | A     | m    | 1900-09-01 00:00:00 | 96033 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
+-----+-------+------+---------------------+-------+
9 rows in set (0.00 sec)
-- 降序 desc
mysql> select * from student order by class desc;
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 101 | A     | m    | 1900-09-01 00:00:00 | 96033 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
9 rows in set (0.00 sec)
```

##### 8. 以cno升序、degree降序查询score表的所有记录

```sql
mysql> select * from score order by cno asc, degree desc;
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 106 | 10-232 |     75 |
| 107 | 10-232 |     71 |
| 108 | 10-232 |     23 |
| 101 | 3-105  |     98 |
| 105 | 3-105  |     89 |
| 103 | 3-105  |     76 |
| 107 | 3-105  |     76 |
| 102 | 3-245  |     43 |
| 108 | 6-295  |     76 |
| 104 | 6-295  |     74 |
| 109 | 6-295  |     62 |
| 105 | 6-295  |     56 |
+-----+--------+--------+
12 rows in set (0.00 sec)
```

##### 9. 查询‘96031’班的学生人数

```sql
mysql> select count(*) from student where class = '96031';
+----------+
| count(*) |
+----------+
|        5 |
+----------+
1 row in set (0.00 sec)
```

##### 10. 查询score表中的最高分的学生学好和课程好（子查询或排序）

```sql
mysql> select sno, cno from score where degree = (select max(degree) from score);
+-----+-------+
| sno | cno   |
+-----+-------+
| 101 | 3-105 |
+-----+-------+
1 row in set (0.00 sec)

-- Step 1. 找到最高分
select max(degree) from score;
-- Step 2. 找最高分的sno和cno
select sno, cno from score where degree = (select max(degree) from score);

-- 排序的做法
mysql> select sno, cno, degree from score order by degree;
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 108 | 10-232 |     23 |
| 102 | 3-245  |     43 |
| 105 | 6-295  |     56 |
| 109 | 6-295  |     62 |
| 107 | 10-232 |     71 |
| 104 | 6-295  |     74 |
| 106 | 10-232 |     75 |
| 103 | 3-105  |     76 |
| 107 | 3-105  |     76 |
| 108 | 6-295  |     76 |
| 105 | 3-105  |     89 |
| 101 | 3-105  |     98 |
+-----+--------+--------+
12 rows in set (0.00 sec)

mysql> select sno, cno, degree from score order by degree limit 0, 1;	-- 0：起点，1：查几条
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 108 | 10-232 |     23 |
+-----+--------+--------+
1 row in set (0.00 sec)

mysql> select sno, cno, degree from score order by degree desc limit 0, 1;
+-----+-------+--------+
| sno | cno   | degree |
+-----+-------+--------+
| 101 | 3-105 |     98 |
+-----+-------+--------+
1 row in set (0.00 sec)
```

##### 11. 查询每门课的平均成绩

```sql
-- avg()
mysql> select avg(degree) from score where cno = '3-105';
+-------------+
| avg(degree) |
+-------------+
|     84.7500 |
+-------------+
1 row in set (0.00 sec)
-- group by 分组
mysql> select cno, avg(degree) from score group by cno;
+--------+-------------+
| cno    | avg(degree) |
+--------+-------------+
| 10-232 |     56.3333 |
| 3-105  |     84.7500 |
| 3-245  |     43.0000 |
| 6-295  |     67.0000 |
+--------+-------------+
4 rows in set (0.00 sec)
```

##### 12. 查询score表中至少有2名学生选修的并以3开头的课程的平均分数

```sql
-- score表中至少有2名学生选修的并以3开头的课程
-- group by 后跟的条件要用having
-- like 模糊查询
mysql> select cno from score group by cno having count(cno) >= 2 and cno like '3%';
+-------+
| cno   |
+-------+
| 3-105 |
+-------+
1 row in set (0.00 sec)
-- score表中至少有2名学生选修的并以3开头的课程的平均分数
mysql> select cno, avg(degree), count(*) from score group by cno having count(cno) >= 2 and cno like '3%';
+-------+-------------+----------+
| cno   | avg(degree) | count(*) |
+-------+-------------+----------+
| 3-105 |     84.7500 |        4 |
+-------+-------------+----------+
1 row in set (0.00 sec)
```

##### 13. 查询分数大于70，小于90的sno列

```sql
-- 法一：
mysql> select sno, degree from score
    -> where degree > 70 and degree < 90;
+-----+--------+
| sno | degree |
+-----+--------+
| 103 |     76 |
| 104 |     74 |
| 105 |     89 |
| 106 |     75 |
| 107 |     71 |
| 107 |     76 |
| 108 |     76 |
+-----+--------+
7 rows in set (0.00 sec)
-- 法二：
mysql> select sno, degree from score where degree between 70 and 90;
+-----+--------+
| sno | degree |
+-----+--------+
| 103 |     76 |
| 104 |     74 |
| 105 |     89 |
| 106 |     75 |
| 107 |     71 |
| 107 |     76 |
| 108 |     76 |
+-----+--------+
7 rows in set (0.01 sec)
```

##### 14. 查询所有学生的sname、cno和degree列

```sql
mysql> select student.sname, score.cno, score.degree from student, score where student.sno = score.sno;
+-------+--------+--------+
| sname | cno    | degree |
+-------+--------+--------+
| A     | 3-105  |     98 |
| K     | 3-245  |     43 |
| B     | 3-105  |     76 |
| C     | 6-295  |     74 |
| Y     | 3-105  |     89 |
| Y     | 6-295  |     56 |
| X     | 10-232 |     75 |
| Z     | 10-232 |     71 |
| Z     | 3-105  |     76 |
| H     | 10-232 |     23 |
| H     | 6-295  |     76 |
| G     | 6-295  |     62 |
+-------+--------+--------+
12 rows in set (0.00 sec)
```

##### 15. 查询所有学生的sno、cname、degree列

```sql
mysql> select score.sno, course.cname, score.degree from score, course where score.cno = course.cno;
+-----+---------------+--------+
| sno | cname         | degree |
+-----+---------------+--------+
| 106 | System        |     75 |
| 107 | System        |     71 |
| 108 | System        |     23 |
| 101 | DataStructure |     98 |
| 103 | DataStructure |     76 |
| 105 | DataStructure |     89 |
| 107 | DataStructure |     76 |
| 102 | Network       |     43 |
| 104 | Architecture  |     74 |
| 105 | Architecture  |     56 |
| 108 | Architecture  |     76 |
| 109 | Architecture  |     62 |
+-----+---------------+--------+
12 rows in set (0.00 sec)
```

##### 16. 查询所有学生的sname、cname、degree列

```sql
mysql> select student.sname, course.cname, score.degree from student, score, course where student.sno = score.sno and course.cno = score.cno;
+-------+---------------+--------+
| sname | cname         | degree |
+-------+---------------+--------+
| X     | System        |     75 |
| Z     | System        |     71 |
| H     | System        |     23 |
| A     | DataStructure |     98 |
| B     | DataStructure |     76 |
| Y     | DataStructure |     89 |
| Z     | DataStructure |     76 |
| K     | Network       |     43 |
| C     | Architecture  |     74 |
| Y     | Architecture  |     56 |
| H     | Architecture  |     76 |
| G     | Architecture  |     62 |
+-------+---------------+--------+
12 rows in set (0.00 sec)
```

##### 17. 查询‘96031’班学生每门课的平均分

```sql
-- 选出96031班的所有学生
mysql> select sno from student where class = '96031';
-- 选出96031班所有学生的信息
mysql> select * from score where sno in (select sno from student where class = '96031');
-- 查询‘96031’班学生每门课的平均分
mysql> select cno, avg(degree) from score where sno in (select sno from student where class = '96031') group by cno;
+--------+-------------+
| cno    | avg(degree) |
+--------+-------------+
| 3-245  |     43.0000 |
| 3-105  |     89.0000 |
| 6-295  |     64.6667 |
| 10-232 |     49.0000 |
+--------+-------------+
4 rows in set (0.00 sec)
```

##### 18. 查询选修“3-105”课程的成绩高于“103”号同学“3-105”成绩的所有同学的成绩

```sql
-- 选出“103”号同学“3-105”成绩
select degree from score where sno = '103';
-- 选出所有选修“3-105”的同学
select sno, degree from score where cno = '3-105';
-- 查询选修“3-105”课程的，并且成绩高于“103”号同学“3-105”成绩的，所有同学的成绩
mysql> select sno, degree from score where cno = '3-105' and degree > (select degree from score where sno = '103'); 
+-----+--------+
| sno | degree |
+-----+--------+
| 101 |     98 |
| 105 |     89 |
+-----+--------+
2 rows in set (0.00 sec)
```

##### 19. 查询成绩高于学号为“103”、课程号为“3-105”的成绩的所有记录

```sql
mysql> select * from score where degree > (select degree from score where sno = '103' and cno = '3-105');
+-----+-------+--------+
| sno | cno   | degree |
+-----+-------+--------+
| 101 | 3-105 |     98 |
| 105 | 3-105 |     89 |
+-----+-------+--------+
2 rows in set (0.00 sec)
```

##### 20. 查询和学号为‘108’、‘101‘的同学，同年出生的所有学生的sno、sname和sbirthday列

```sql
-- 选出学号为‘108’、‘101‘的同学的sbirthday
select year(sbirthday) from student where sno in ('108', '101');
-- 和学号为‘108’、‘101‘的同学，同年出生的所有学生的sno、sname和sbirthday列
mysql> select sno, sname, sbirthday from student where year(sbirthday) in (select year(sbirthday) from student where sno in ('108', '101'));
+-----+-------+---------------------+
| sno | sname | sbirthday           |
+-----+-------+---------------------+
| 101 | A     | 1900-09-01 00:00:00 |
| 103 | B     | 1901-01-20 00:00:00 |
| 104 | C     | 1901-05-04 00:00:00 |
| 105 | Y     | 1900-02-03 00:00:00 |
| 106 | X     | 1901-07-15 00:00:00 |
| 107 | Z     | 1901-07-15 00:00:00 |
| 108 | H     | 1901-07-15 00:00:00 |
| 109 | G     | 1901-07-15 00:00:00 |
+-----+-------+---------------------+
8 rows in set (0.02 sec)
```

##### 21. 查询AA教师任课的学生成绩

```sql
-- 先查出AA教师的教师编号
mysql> select tno from teacher where tname = 'AA';
+-----+
| tno |
+-----+
| 093 |
+-----+
1 row in set (0.00 sec)
-- 再查出查出AA教师任教的课程
mysql> select cno from course where tno in (select tno from teacher where tname = 'AA');
+-------+
| cno   |
+-------+
| 6-295 |
+-------+
1 row in set (0.01 sec)
-- 最后查出AA教师任课的学生成绩
mysql> select * from score where cno in (select cno from course where tno in (select tno from teacher where tname = 'AA'));
+-----+-------+--------+
| sno | cno   | degree |
+-----+-------+--------+
| 104 | 6-295 |     74 |
| 105 | 6-295 |     56 |
| 108 | 6-295 |     76 |
| 109 | 6-295 |     62 |
+-----+-------+--------+
4 rows in set (0.00 sec)
```

##### 22. 查询选修某课程的同学人数多于3人的教师姓名

```sql
-- 先查询选修每门课程的同学人数
mysql> select cno, count(sno) from score group by cno;
+--------+------------+
| cno    | count(sno) |
+--------+------------+
| 10-232 |          3 |
| 3-105  |          4 |
| 3-245  |          1 |
| 6-295  |          4 |
+--------+------------+
4 rows in set (0.01 sec)
-- 再查询选修人数多于3人的课程号
mysql> select cno from score group by cno having count(*) > 3;
+-------+
| cno   |
+-------+
| 3-105 |
| 6-295 |
+-------+
2 rows in set (0.00 sec)
-- 再查询这两门课任教的教师编号
mysql> select tno from course where cno in (select cno from score group by cno having count(*) > 3);
+-----+
| tno |
+-----+
| 093 |
| 102 |
+-----+
2 rows in set (0.00 sec)
-- 最后查教师姓名
mysql> select tname from teacher where tno in (select tno from course where cno in (select cno from score group by cno having count(*) > 3));
+-------+
| tname |
+-------+
| AA    |
| BB    |
+-------+
2 rows in set (0.00 sec)
```

##### 23. 查询96031和96033班全体学生的记录

```sql
mysql> select * from student where class in ('96031', '96033');
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 101 | A     | m    | 1900-09-01 00:00:00 | 96033 |
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
9 rows in set (0.00 sec)
```

##### 24. 查询存在有85分以上成绩的课程号

```sql
mysql> select cno, degree from score where degree > 85;
+-------+--------+
| cno   | degree |
+-------+--------+
| 3-105 |     98 |
| 3-105 |     89 |
+-------+--------+
2 rows in set (0.00 sec)
```

##### 25. 查询出CS系教师所教课程的成绩表

```sql
-- 先查出教CS的教师的教师编号
mysql> select tno from teacher where department = 'CS';
+-----+
| tno |
+-----+
| 093 |
| 195 |
+-----+
2 rows in set (0.00 sec)
-- 再查出这些教师所教的课程号
mysql> select cno from course where tno in (select tno from teacher where department = 'CS');
+-------+
| cno   |
+-------+
| 6-295 |
| 3-245 |
+-------+
2 rows in set (0.01 sec)
-- 最后查出score表中的degree
mysql> select cno, degree from score where cno in (select cno from course where tno in (select tno from teacher where department = 'CS'));
+-------+--------+
| cno   | degree |
+-------+--------+
| 6-295 |     74 |
| 6-295 |     56 |
| 6-295 |     76 |
| 6-295 |     62 |
| 3-245 |     43 |
+-------+--------+
5 rows in set (0.00 sec)
```

##### 26. 查询“CS”系和“EE”系不同职称的教师的tname和prof

> union：求并集

```sql
mysql> select * from teacher;
+-----+-------+------+---------------------+-----------+------------+
| tno | tname | tsex | tbierthday          | prof      | department |
+-----+-------+------+---------------------+-----------+------------+
| 093 | AA    | m    | 1887-12-03 00:00:00 | Prof      | CS         |
| 102 | BB    | m    | 1898-10-01 00:00:00 | Lecture   | EE         |
| 195 | CC    | f    | 1892-02-20 00:00:00 | Assistant | CS         |
| 209 | DD    | f    | 1898-08-03 00:00:00 | Assistant | EE         |
+-----+-------+------+---------------------+-----------+------------+
4 rows in set (0.00 sec)
-- 查询CS系有的职称
mysql> select prof from teacher where department = 'CS';
+-----------+
| prof      |
+-----------+
| Prof      |
| Assistant |
+-----------+
2 rows in set (0.00 sec)
-- 查询EE系有的职称
mysql> select prof from teacher where department = 'EE';
+-----------+
| prof      |
+-----------+
| Lecture   |
| Assistant |
+-----------+
2 rows in set (0.00 sec)
-- 查询CS有而EE没有的职称
mysql> select prof from teacher where department = 'CS' and prof not in (select prof from teacher where department = 'EE');
+------+
| prof |
+------+
| Prof |
+------+
1 row in set (0.01 sec)
-- 查询EE有而CS没有的职称
mysql> select prof from teacher where department = 'EE' and prof not in (select prof from teacher where department = 'CS');
+---------+
| prof    |
+---------+
| Lecture |
+---------+
1 row in set (0.01 sec)
-- union
mysql> select prof from teacher where department = 'CS' and prof not in (select prof from teacher where department = 'EE')
    -> union
    -> select prof from teacher where department = 'EE' and prof not in (select prof from teacher where department = 'CS');
+---------+
| prof    |
+---------+
| Prof    |
| Lecture |
+---------+
2 rows in set (0.00 sec)
```

##### 27. 查询选修编号为"3-105"课程且成绩*至少*高于选修编号为'3-245'课程的同学的cno，sno和degree，并且按照degree从高到地次序排序

```sql
-- 先查询选修‘3-105’课程的同学
select * from score where cno = '3-105';
-- 再查选修‘3-245’课程的同学的成绩
select degree from score where cno = '3-245';
-- 最后查询选修编号为"3-105"课程且成绩至少高于选修编号为'3-245'课程的同学的cno，sno和degree，并且按照degree从高到地次序排序
mysql> select cno, sno, degree from score where cno = '3-105' and degree > any(select degree from score where cno = '3-245') order by degree desc;
+-------+-----+--------+
| cno   | sno | degree |
+-------+-----+--------+
| 3-105 | 101 |     98 |
| 3-105 | 105 |     89 |
| 3-105 | 103 |     76 |
| 3-105 | 107 |     76 |
+-------+-----+--------+
4 rows in set (0.00 sec)
```

##### 28. 查询选修编号为"3-105"且成绩高于选修编号为"3-245"课程的同学cno，sno和degree

> all：表示所有

```sql
mysql> select cno, sno, degree from score where cno = '3-105' and degree > all(select degree from score where cno = '3-245');
+-------+-----+--------+
| cno   | sno | degree |
+-------+-----+--------+
| 3-105 | 101 |     98 |
| 3-105 | 103 |     76 |
| 3-105 | 105 |     89 |
| 3-105 | 107 |     76 |
+-------+-----+--------+
4 rows in set (0.01 sec)
```

##### 29. 查询所有教师和同学的 name ,sex, birthday

```sql
-- 查出教师姓名
select tname as name, tsex, tbirthday from teacher;
-- 查出学生姓名
select sname as name, ssex, sbirthday form student;
-- 并集
mysql> select tname as name, tsex as sex, tbierthday as birthday from teacher
    -> union
    -> select sname, ssex, sbirthday from student;		-- 第二排会以第一排为准
+------+-----+---------------------+
| name | sex | birthday            |
+------+-----+---------------------+
| AA   | m   | 1887-12-03 00:00:00 |
| BB   | m   | 1898-10-01 00:00:00 |
| CC   | f   | 1892-02-20 00:00:00 |
| DD   | f   | 1898-08-03 00:00:00 |
| A    | m   | 1900-09-01 00:00:00 |
| K    | m   | 1902-10-01 00:00:00 |
| B    | m   | 1901-01-20 00:00:00 |
| C    | m   | 1901-05-04 00:00:00 |
| Y    | f   | 1900-02-03 00:00:00 |
| X    | m   | 1901-07-15 00:00:00 |
| Z    | m   | 1901-07-15 00:00:00 |
| H    | f   | 1901-07-15 00:00:00 |
| G    | f   | 1901-07-15 00:00:00 |
+------+-----+---------------------+
13 rows in set (0.01 sec)
```

##### 30.查询所有'女'教师和'女'学生的name,sex,birthday

```sql
-- 查询所有女教师的name，sex和birthday
mysql> select tname, tsex, tbierthday from teacher where tsex = 'f';
+-------+------+---------------------+
| tname | tsex | tbierthday          |
+-------+------+---------------------+
| CC    | f    | 1892-02-20 00:00:00 |
| DD    | f    | 1898-08-03 00:00:00 |
+-------+------+---------------------+
2 rows in set (0.01 sec)
-- 查询所有女学生的name，sex和birthday
mysql> select sname, ssex, sbirthday from student where ssex = 'f';
+-------+------+---------------------+
| sname | ssex | sbirthday           |
+-------+------+---------------------+
| Y     | f    | 1900-02-03 00:00:00 |
| H     | f    | 1901-07-15 00:00:00 |
| G     | f    | 1901-07-15 00:00:00 |
+-------+------+---------------------+
3 rows in set (0.01 sec)
-- 查询所有'女'教师和'女'学生的name,sex,birthday
mysql> select tname as name, tsex as sex, tbierthday as birthday from teacher where tsex = 'f'
    -> union
    -> select sname, ssex, sbirthday from student where ssex = 'f';
+------+-----+---------------------+
| name | sex | birthday            |
+------+-----+---------------------+
| CC   | f   | 1892-02-20 00:00:00 |
| DD   | f   | 1898-08-03 00:00:00 |
| Y    | f   | 1900-02-03 00:00:00 |
| H    | f   | 1901-07-15 00:00:00 |
| G    | f   | 1901-07-15 00:00:00 |
+------+-----+---------------------+
5 rows in set (0.00 sec)
```

##### 31.查询成绩比该课程平均成绩低的同学的成绩表

> 复制表数据做条件查询

```sql
-- 查询每门课程的平均成绩
select cno, avg(degree) from score group by cno;
-- 查询成绩比该课程平均成绩低的同学的成绩表
mysql> select * from score a where a.degree < (select avg(b.degree) from score b where a.cno = b.cno);
+-----+--------+--------+
| sno | cno    | degree |
+-----+--------+--------+
| 103 | 3-105  |     76 |
| 105 | 6-295  |     56 |
| 107 | 3-105  |     76 |
| 108 | 10-232 |     23 |
| 109 | 6-295  |     62 |
+-----+--------+--------+
5 rows in set (0.03 sec)
```

##### 32.查询所有任课教师的tname和department(要在分数表中可以查得到)

```sql
mysql> select tname, department from teacher where tno in (select tno from course);
+-------+------------+
| tname | department |
+-------+------------+
| AA    | CS         |
| BB    | EE         |
| CC    | CS         |
| DD    | EE         |
+-------+------------+
4 rows in set (0.01 sec)
```

##### 33.查出至少有2名男生的班号

```sql
mysql> select class from student where ssex = 'm' group by class having count(*) > 1;
+-------+
| class |
+-------+
| 96033 |
| 96031 |
+-------+
2 rows in set (0.01 sec)
```

##### 34.查询student 表中不姓"A"的同学的记录

```sql
mysql> select * from student where sname not like 'A%';
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
8 rows in set (0.00 sec)
```

##### 35. 查询student中每个学生的姓名和年龄

```sql
-- 年龄 = 当前时间 - 出生年份
mysql> select year(now());
+-------------+
| year(now()) |
+-------------+
|        2020 |
+-------------+
1 row in set (0.00 sec)
-- 
mysql> select year(sbirthday) from student;
+-----------------+
| year(sbirthday) |
+-----------------+
|            1900 |
|            1902 |
|            1901 |
|            1901 |
|            1900 |
|            1901 |
|            1901 |
|            1901 |
|            1901 |
+-----------------+
9 rows in set (0.01 sec)
-- 查询student中每个学生的姓名和年龄
mysql> select sname, (year(now()) - year(sbirthday)) as age from student;
+-------+------+
| sname | age  |
+-------+------+
| A     |  120 |
| K     |  118 |
| B     |  119 |
| C     |  119 |
| Y     |  120 |
| X     |  119 |
| Z     |  119 |
| H     |  119 |
| G     |  119 |
+-------+------+
9 rows in set (0.00 sec)
```

##### 36. 查询student中最大和最小的sbirthday的值

```sql
mysql> select max(sbirthday) as Youngest, min(sbirthday) as Eldest from student;
+---------------------+---------------------+
| Youngest            | Eldest              |
+---------------------+---------------------+
| 1902-10-01 00:00:00 | 1900-02-03 00:00:00 |
+---------------------+---------------------+
1 row in set (0.00 sec)
```

##### 37. 以班级号和年龄从大到小的顺序查询student表中的全部记录

```sql
mysql> select * from student order by class desc, (now() - sbirthday) desc;
+-----+-------+------+---------------------+-------+
| sno | sname | ssex | sbirthday           | class |
+-----+-------+------+---------------------+-------+
| 101 | A     | m    | 1900-09-01 00:00:00 | 96033 |
| 103 | B     | m    | 1901-01-20 00:00:00 | 96033 |
| 104 | C     | m    | 1901-05-04 00:00:00 | 96033 |
| 107 | Z     | m    | 1901-07-15 00:00:00 | 96033 |
| 105 | Y     | f    | 1900-02-03 00:00:00 | 96031 |
| 106 | X     | m    | 1901-07-15 00:00:00 | 96031 |
| 108 | H     | f    | 1901-07-15 00:00:00 | 96031 |
| 109 | G     | f    | 1901-07-15 00:00:00 | 96031 |
| 102 | K     | m    | 1902-10-01 00:00:00 | 96031 |
+-----+-------+------+---------------------+-------+
9 rows in set (0.00 sec)
```

##### 38.查询"男"教师及其所上的课

```sql
-- 查询出男教师
select tno from teacher where tsex = 'm';
-- 查询"男"教师 及其所上的课
mysql> select cno from course where tno in (select tno from teacher where tsex = 'm');
+-------+
| cno   |
+-------+
| 6-295 |
| 3-105 |
+-------+
2 rows in set (0.01 sec)
```

##### 39.查询最高分同学的sno, cno和degree

```sql
-- 查出最高分的同学
select max(degree) from score;
-- 查询最高分同学的sno, cno和degree
mysql> select sno, cno , degree from score where degree in (select max(degree) from score);
+-----+-------+--------+
| sno | cno   | degree |
+-----+-------+--------+
| 101 | 3-105 |     98 |
+-----+-------+--------+
1 row in set (0.00 sec)
```

##### 40. 查询和"C"同性别的所有同学的sname

```sql
-- 查询出“C”的性别
mysql> select ssex from student where sname  = 'C';
+------+
| ssex |
+------+
| m    |
+------+
1 row in set (0.00 sec)
-- 查询和"C"同性别的所有同学的sname
mysql> select sname, ssex from student where ssex = (select ssex from student where sname  = 'C');
+-------+------+
| sname | ssex |
+-------+------+
| A     | m    |
| K     | m    |
| B     | m    |
| C     | m    |
| X     | m    |
| Z     | m    |
+-------+------+
6 rows in set (0.00 sec)
```

##### 41.查询和"C"同性别并且同班的所有同学的sname

```sql
-- 查询出“C”的性别
mysql> select ssex from student where sname  = 'C';
+------+
| ssex |
+------+
| m    |
+------+
1 row in set (0.00 sec)
-- 查询和"C"同班的所有同学的sname
mysql> select sname, ssex, class from student where 
    -> ssex = (select ssex from student where sname  = 'C')
    -> and
    -> class = (select class from student where sname  = 'C');
+-------+------+-------+
| sname | ssex | class |
+-------+------+-------+
| A     | m    | 96033 |
| B     | m    | 96033 |
| C     | m    | 96033 |
| Z     | m    | 96033 |
+-------+------+-------+
4 rows in set (0.01 sec)
```

##### 42. 查询所有选修'DataStructure'课程的'男'同学的成绩表

```sql
-- 选出'DataStructure'课程的课程号
mysql> select cno from course where cname = 'DataStructure';
+-------+
| cno   |
+-------+
| 3-105 |
+-------+
1 row in set (0.00 sec)
-- 选出男同学的学号
mysql> select sno from student where ssex = 'm';
+-----+
| sno |
+-----+
| 101 |
| 102 |
| 103 |
| 104 |
| 106 |
| 107 |
+-----+
6 rows in set (0.00 sec)
-- 查询所有选修'DataStructure'课程的'男'同学的成绩表
mysql> select * from score where
    -> cno in (select cno from course where cname = 'DataStructure')
    -> and 
    -> sno in (select sno from student where ssex = 'm');
+-----+-------+--------+
| sno | cno   | degree |
+-----+-------+--------+
| 101 | 3-105 |     98 |
| 103 | 3-105 |     76 |
| 107 | 3-105 |     76 |
+-----+-------+--------+
3 rows in set (0.02 sec)
```

##### 43. 假设使用了以下命令建立了一个grade表，查询所有同学的sno , cno和grade列

```sql
CREATE TABLE grade(
    low INT(3),
    upp INT(3),
    grade CHAR(1)
);
INSERT INTO grade VALUES(90,100,'A');
INSERT INTO grade VALUES(80,89,'B');
INSERT INTO grade VALUES(70,79,'c');
INSERT INTO grade VALUES(60,69,'D');
INSERT INTO grade VALUES(0,59,'E');
```

```sql
-- 查询所有同学的sno , cno和grade列
mysql> select sno, cno, grade from score, grade where degree between low and upp;
+-----+--------+-------+
| sno | cno    | grade |
+-----+--------+-------+
| 101 | 3-105  | A     |
| 102 | 3-245  | E     |
| 103 | 3-105  | c     |
| 104 | 6-295  | c     |
| 105 | 3-105  | B     |
| 105 | 6-295  | E     |
| 106 | 10-232 | c     |
| 107 | 10-232 | c     |
| 107 | 3-105  | c     |
| 108 | 10-232 | E     |
| 108 | 6-295  | c     |
| 109 | 6-295  | D     |
+-----+--------+-------+
12 rows in set (0.00 sec)
```

### 5. SQL的四种查询方式

```sql
-- 例：创建两个表
mysql> create database JoinTest;
Query OK, 1 row affected (0.04 sec)

mysql> use JoinTest;
Database changed

mysql> use JoinTest;
Database changed
mysql> create table person(
    -> id int,
    -> name varchar(20),
    -> cardId int
    -> );
Query OK, 0 rows affected (0.12 sec)

mysql> create table card(
    -> id int,
    -> name varchar(20)
    -> );
Query OK, 0 rows affected (0.11 sec)

mysql> delete from card where id in (3, 4, 5, 1);
Query OK, 4 rows affected (0.01 sec)

mysql> select * from card;
Empty set (0.00 sec)

mysql> insert into card values(1, 'Food Card');
Query OK, 1 row affected (0.01 sec)

mysql> insert into card values(2, 'ICBC Card');
Query OK, 1 row affected (0.02 sec)

mysql> insert into card values(3, 'POST Card');
Query OK, 1 row affected (0.01 sec)

mysql> insert into card values(4, 'CCB Card');
Query OK, 1 row affected (0.02 sec)

mysql> insert into card values(5, 'CMB Card');
Query OK, 1 row affected (0.01 sec)

mysql> select * from card;
+------+-----------+
| id   | name      |
+------+-----------+
|    1 | Food Card |
|    2 | ICBC Card |
|    3 | POST Card |
|    4 | CCB Card  |
|    5 | CMB Card  |
+------+-----------+
5 rows in set (0.00 sec)

mysql> insert into person values(1, 'zhangsan', 1);
Query OK, 1 row affected (0.02 sec)

mysql> insert into person values(2, 'lisi', 4);
Query OK, 1 row affected (0.02 sec)

mysql> insert into person values(3, 'wangwu', 5);
Query OK, 1 row affected (0.02 sec)

mysql> select * from person;
+------+----------+--------+
| id   | name     | cardId |
+------+----------+--------+
|    1 | zhangsan |      1 |
|    2 | lisi     |      4 |
|    3 | wangwu   |      5 |
+------+----------+--------+
3 rows in set (0.00 sec)
-- 并没有创建外键
```

#### 5.1 内连接：inner join / join

在两张表中，通过某个相关联的字段，查询出相关记录数据

```sql
 mysql> select * from person (inner) join card on person.cardId = card.id;
+------+----------+--------+------+-----------+
| id   | name     | cardId | id   | name      |
+------+----------+--------+------+-----------+
|    1 | zhangsan |      1 |    1 | Food Card |
|    2 | lisi     |      4 |    4 | CCB Card  |
|    3 | wangwu   |      5 |    5 | CMB Card  |
+------+----------+--------+------+-----------+
3 rows in set (0.01 sec)
```

#### 5.2 外连接：

##### 5.2.1 左连接：left join / left outer join

左外连接，会把左表的所有数据取出，而右表中的数据，如果有与左表中的相等的，就取出，否则置空。

```sql
mysql> select * from person left (outer) join card on person.cardId = card.id;
+------+----------+--------+------+-----------+
| id   | name     | cardId | id   | name      |
+------+----------+--------+------+-----------+
|    1 | zhangsan |      1 |    1 | Food Card |
|    2 | lisi     |      4 |    4 | CCB Card  |
|    3 | wangwu   |      5 |    5 | CMB Card  |
+------+----------+--------+------+-----------+
3 rows in set (0.01 sec)
```

##### 5.2.2 右连接：right join / right outer join

右外连接，会把右表的所有数据取出，而左表中的数据，如果有与右表中的相等的，就取出，否则置空。

```sql
mysql> select * from person right (outer) join card on person.cardId = card.id;
+------+----------+--------+------+-----------+
| id   | name     | cardId | id   | name      |
+------+----------+--------+------+-----------+
|    1 | zhangsan |      1 |    1 | Food Card |
| NULL | NULL     |   NULL |    2 | ICBC Card |
| NULL | NULL     |   NULL |    3 | POST Card |
|    2 | lisi     |      4 |    4 | CCB Card  |
|    3 | wangwu   |      5 |    5 | CMB Card  |
+------+----------+--------+------+-----------+
5 rows in set (0.00 sec)
```

##### 5.2.3 完全外连接：full join / full outer join

```sql
mysql> select * from person left join card on person.cardId = card.id
    -> union
    -> select * from person right join card on person.cardId = card.id;
+------+----------+--------+------+-----------+
| id   | name     | cardId | id   | name      |
+------+----------+--------+------+-----------+
|    1 | zhangsan |      1 |    1 | Food Card |
|    2 | lisi     |      4 |    4 | CCB Card  |
|    3 | wangwu   |      5 |    5 | CMB Card  |
| NULL | NULL     |   NULL |    2 | ICBC Card |
| NULL | NULL     |   NULL |    3 | POST Card |
+------+----------+--------+------+-----------+
5 rows in set (0.01 sec)
```

### 6. 事务

#### 6.1 事务是MySQL中最小的不可分割的工作单元。事务能保证一个业务的完整性。

例如：

```sql
-- a --withdraw-> 100
update bank set money = money - 100 where name = 'a';
-- b <-sotre-- 100
update bank set money = money + 100 where name = 'b';
```

在实际的程序中，如果只有一条语句执行成功，另一条语句没有执行成功，就会出现数据前后不一致。

多条sql语句，可能会有同时成功的要求，要么就同时失败。

#### 6.2 MySQL中如何控制事务？

##### 6.2.1 MySQL中默认开启事务（自动提交）

```sql
mysql> select @@autocommit;
+--------------+
| @@autocommit |
+--------------+
|            1 |
+--------------+
1 row in set (0.01 sec)
```

默认开启自动提交的作用是什么？

当我们去执行一个sql语句时，效果就会立即体现出来，且不能回滚。

```sql
mysql> create database bank;
Query OK, 1 row affected (0.08 sec)

mysql> create table bank(
    -> id int primary key,
    -> name varchar(20),
    -> money int
    -> );
Query OK, 0 rows affected (0.13 sec)

mysql> insert into bank values(1, 'a', 1000);
Query OK, 1 row affected (0.03 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
+----+------+-------+
1 row in set (0.00 sec)

mysql> rollback;
Query OK, 0 rows affected (0.00 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
+----+------+-------+
1 row in set (0.00 sec)
```

设置默认提交为false：

##### 6.2.2 手动提交（commit）数据，再撤销，不可行（数据持久性）

```sql
set autocommit = 0；
mysql> set autocommit = 0;
Query OK, 0 rows affected (0.01 sec)

mysql> select @@autocommit;
+--------------+
| @@autocommit |
+--------------+
|            0 |
+--------------+
1 row in set (0.00 sec)

mysql> insert into bank values(2, 'b', 1000);
Query OK, 1 row affected (0.01 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
|  2 | b    |  1000 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
|  2 | b    |  1000 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> rollback;
Query OK, 0 rows affected (0.01 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
+----+------+-------+
1 row in set (0.00 sec)

mysql> insert into bank values(2, 'b', 1000);
Query OK, 1 row affected (0.00 sec)

mysql> commit;
Query OK, 0 rows affected (0.02 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
|  2 | b    |  1000 |
+----+------+-------+
2 rows in set (0.01 sec)

mysql> rollback;
Query OK, 0 rows affected (0.00 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
|  2 | b    |  1000 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> update bank set money = money - 100 where name = 'a';
Query OK, 1 row affected (0.01 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> update bank set money = money + 100 where name = 'b';
Query OK, 1 row affected (0.00 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> rollback;
Query OK, 0 rows affected (0.01 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |  1000 |
|  2 | b    |  1000 |
+----+------+-------+
2 rows in set (0.01 sec)
```

事务给我们提供了一个返回的机会

```sql
mysql> select @@autocommit;
+--------------+
| @@autocommit |
+--------------+
|            0 |
+--------------+
1 row in set (0.00 sec)

mysql> set autocommit = 1;
Query OK, 0 rows affected (0.01 sec)

mysql> select @@autocommit;
+--------------+
| @@autocommit |
+--------------+
|            1 |
+--------------+
1 row in set (0.00 sec)
```

##### 6.2.3 手动开启一个事务 begin/start transaction

```sql
mysql> update bank set money = money - 100 where name = 'a';
Query OK, 1 row affected (0.03 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> update bank set money = money + 100 where name = 'b';
Query OK, 1 row affected (0.02 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.00 sec)

-- 事务没有被撤销
mysql> rollback;
Query OK, 0 rows affected (0.00 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.00 sec)

-- 手动开启事务
mysql> begin;		-- 或 start transaction
Query OK, 0 rows affected (0.01 sec)

mysql> update bank set money = money - 100 where name = 'a';
Query OK, 1 row affected (0.00 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> update bank set money = money + 100 where name = 'b';
Query OK, 1 row affected (0.00 sec)
Rows matched: 1  Changed: 1  Warnings: 0

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   800 |
|  2 | b    |  1200 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> rollback;
Query OK, 0 rows affected (0.01 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.00 sec)

mysql> commit;
Query OK, 0 rows affected (0.01 sec)
```

事务开启后，一旦提交，就不能回滚。

#### 6.3 事务的四大特征(ACID)

##### 6.3.1 A：原子性——事务是最小单位，不可再分割；

##### 6.3.2 C：一致性——事务要求，在同一事务中的sql语句，必须保证同时成功或同时失败；

##### 6.3.3 I：隔离性——事务A和B之间具有隔离性；

1. read uncommitted; 读未提交的：

2. read committed;     读已提交的

3. repeatable read;     可重复读的（MySQL默认隔离级别）

4. serializable             串行化：事务操作串行。当一个表被一个事务操作时，另一个事务不能对其进行写操作，被阻塞，排队等待，直到前一个事务commit。等待超时也得重新执行。

   > 性能：read uncommitted > read committed > repeatable read > serializable
   >
   > 隔离级别越高，性能越差。

如何查询数据库隔离级别：

```sql
-- mysql 8.0+
select @@global.transaction_isolation;	-- 系统级别
select @@transaction_isolation;					-- 会话级别

mysql> select @@global.transaction_isolation;
+--------------------------------+
| @@global.transaction_isolation |
+--------------------------------+
| REPEATABLE-READ                |
+--------------------------------+
1 row in set (0.01 sec)

-- mysql 5.x
select @@global.tx_isolation;		-- 系统级别
select @@tx_isolation;					-- 会话级别
```

如何修改数据库隔离级别:

例：

```sql
mysql> set session transaction isolation level read uncommitted;	-- 当前会话
mysql> set global transaction isolation level read uncommitted;	-- 当前系统
Query OK, 0 rows affected (0.00 sec)

mysql> select @@transaction_isolation;
+-------------------------+
| @@transaction_isolation |
+-------------------------+
| READ-UNCOMMITTED        |
+-------------------------+
1 row in set (0.00 sec)

mysql> start transaction;
Query OK, 0 rows affected (0.01 sec)
-- a在b处买800块钱的鞋子
mysql> update bank set money = money - 800 where name = 'a';
Query OK, 1 row affected (0.01 sec)
Rows matched: 1  Changed: 1  Warnings: 0
-- b收到800块钱
mysql> update bank set money = money + 800 where name = 'b';
Query OK, 1 row affected (0.01 sec)
Rows matched: 1  Changed: 1  Warnings: 0
-- b去查帐
mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   100 |
|  2 | b    |  1900 |
+----+------+-------+
2 rows in set (0.01 sec)
-- 发货
-- 晚上请女朋友吃好吃的
-- 1900

-- a -> rollback;
mysql> rollback;
Query OK, 0 rows affected (0.02 sec)
-- b吃完饭结账，发现钱不够
mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.01 sec)
-- 如果两个不同地方都在进行操作。如果事务a开启后，它的数据可以被别的事务读取到。
-- 这样就会出现“脏读”：一个事务读取到另一个事务没有提交的数据。
-- 实际开发中不允许脏读的出现。
```

```sql
-- 修改隔离级别
mysql> set session transaction isolation level read committed;
Query OK, 0 rows affected (0.00 sec)

mysql> select @@transaction_isolation;
+-------------------------+
| @@transaction_isolation |
+-------------------------+
| READ-COMMITTED          |
+-------------------------+
1 row in set (0.00 sec)

-- 小张：银行会计
mysql> start transaction;
Query OK, 0 rows affected (0.00 sec)

mysql> select * from bank;
+----+------+-------+
| id | name | money |
+----+------+-------+
|  1 | a    |   900 |
|  2 | b    |  1100 |
+----+------+-------+
2 rows in set (0.00 sec)
-- 小张上厕所

-- 小明
mysql> start transaction;
Query OK, 0 rows affected (0.00 sec)

mysql> insert into bank values(3, 'c', 100);
Query OK, 1 row affected (0.00 sec)

mysql> commit;
Query OK, 0 rows affected (0.02 sec)

-- 小张回来
mysql> select avg(money) from bank;
+------------+
| avg(money) |
+------------+
|   700.0000 |
+------------+
1 row in set (0.01 sec)
-- money平均值改变了
-- 虽然我能读到另一个事务提交的数据，但还是会出现问题：读取同一个表的数据出现前后不一致。
-- 不可重复读现象：read committed
```

```sql
-- 修改隔离级别
mysql> set session transaction isolation level repeatable read;
Query OK, 0 rows affected (0.00 sec)

mysql> select @@transaction_isolation;
+-------------------------+
| @@transaction_isolation |
+-------------------------+
| REPEATABLE-READ         |
+-------------------------+
1 row in set (0.00 sec)
-- 幻读：事务a和b同时操作一张表，事务a提交的数据，不能被事务b读到
```

```sql
-- 修改隔离级别
mysql> set session transaction isolation level serializable;
Query OK, 0 rows affected (0.00 sec)

mysql> select @@transaction_isolation;
+-------------------------+
| @@transaction_isolation |
+-------------------------+
| SERIALIZABLE            |
+-------------------------+
1 row in set (0.00 sec)
```



##### 6.3.4 D：持久性——事务一旦结束，就不可以回滚。





## 二、如何使用可视化工具操作数据库？





## 三、如何在编程语言中操作数据库？