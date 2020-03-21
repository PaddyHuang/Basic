#!/usr/local/bin/python3
# Description: 将 0001 题生成的 200 个激活码（或者优惠券）保存到 MySQL 关系型数据库中。
# Author: Paddy Huang
# Date: 2020-20 19:47

import sqlite3, ActiveCode

def saveToSQLite3(codes):
	connector = sqlite3.connect('Database.db')
	cur = connector.cursor()
	cur.execute('CREATE TABLE IF NOT EXISTS ActiveCodes(No INTEGER PRIMARY KEY, Code TEXT)')
	for i in range(0, len(codes)):
		code = codes[i]
		cur.execute('insert into ActiveCodes values(?,?)', (i, code))

	cur.execute('select * from ActiveCodes')
	for item in cur:
		print(item)

	# connector.commit()

	cur.close()
	connector.close()

if __name__ == '__main__':
	list = ActiveCode.generate(200, 20)		# 生成200个长度为20个字符的激活码
	saveToSQLite3(list)
	#for i in range(len(list)):
		#print(list[i])


