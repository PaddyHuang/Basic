#!/usr/local/bin/python3
# Description: 将 0001 题生成的 200 个激活码（或者优惠券）保存到 MySQL 关系型数据库中。
# Author: Paddy Huang
# Date: 2020-20 19:47

# 1. 导入数据库
import sqlite3

# 2. 打开数据库，创建数据库
connector = sqlite3.connect('Test.db')

# 3. 创建游标
cur = connector.cursor()


# 4. 执行SQL语句
# 4.1 创建表格
cur.execute('CREATE TABLE test(id INTEGER PRIMARY KEY, name TEXT, age INTEGER)')
# 4.1 新增数据
# 4.1.1 方法一
data = "5, 'Polin', 20"
cur.execute('insert into test values (%s)'%data)
# 4.1.2 方法二
cur.execute('insert into test values(?,?,?)', (6, 'Rophen', 19))
# 4.1.3 方法三
cur.executemany('insert into test values(?,?,?)', [(7, 'Haha', 10), (8, 'Hoho', 9)])

# 4.2 更新数据
# 4.2.1 方法一
cur.execute('update test set name=? where id=?',('nihao', 7))
# 4.2.2 方法二
cur.execute("update test set name='haha' where id=7")

# 4.3 删除数据
# 4.3.1 方法一
n = cur.execute('delete from test where id=?',(7,))
print(n)
# 4.3.2 方法二
n = cur.execute('delete from test where id=8')

# 4.4 查询数据并显示
# 4.4.1 全部显示
cur.execute('select * from test')
for item in cur:
	print(item)
# 或者
cur.execute('select * from test')
print(cur.fetchall())
# 4.4.2 显示一条
cur.execute('select * from test')
print(cur.fetchone())
# 4.4.3 显示多条
cur.execute('select * from test')
print(cur.fetchmany(3))

# 4.5 删除表格
# cur.execute('drop table test')

# 5 事务提交或回滚
# 5.1 提交
connector.commit()
# 5.2 回滚
connector.rollback()

# 6. 关闭
# 6.1 关闭游标（先）
cur.close()
# 6.2 关闭数据库
connector.close()

