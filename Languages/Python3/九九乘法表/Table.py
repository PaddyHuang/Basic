#!/usr/local/bin/python3
'''
Author: Paddy Huang
Date: 2019-10-06 22:28:45
Description: 九九乘法表
'''
for i in range(1,10):
	for j in range(1, i+1):
		print("%dX%d=%d" %(i, j, i*j), end = " ")
	print()
