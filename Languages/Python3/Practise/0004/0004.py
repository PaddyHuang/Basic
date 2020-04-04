#!/usr/local/bin/python3

# Description: 任一个英文的纯文本文件，统计其中的单词出现的个数。
# Author: Paddy Huang
# Date: 2020-03-28 22:35

import re

def func(file_path):
	file = open(file_path, 'r').read()
	file = re.findall(r'[\w\-\_\'\.]+', file)
	print(len(file))

if __name__ == '__main__':
	file_path = 'English.txt'
	func(file_path)

