#!/usr/local/bin/python3

a, b = 0, 1
while b < 10:	# 输出10以内的所有fibonacci数列
	# print(b)
	print(b, end = ', ')
	a, b = b, a + b

