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

-- 查询练习
-- 1. 查询student表中的所有记录

-- 2. 查询student表中的所有记录的sname、ssex、class列

-- 3. 查询教师所有的单位，即不重复的department列

-- 4. 查询score表中成绩在60-80之间的所有记录

-- 5. 查询score表中成绩为75、76或78的记录

-- 6. 查询student表中‘95031’班或性别为‘f’的同学记录

-- 7. 以class降序查询student表的所有记录

-- 8. 以cno升序、degree降序查询score表的所有记录

-- 9. 查询‘95031’班的学生人数

-- 10. 查询score表中的最高分的学生学好和课程好（子查询或排序）
```



## 二、如何使用可视化工具操作数据库？





## 三、如何在编程语言中操作数据库？