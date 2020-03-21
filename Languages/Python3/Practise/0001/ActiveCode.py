#!/usr/local/bin/python3
# Description: 做为 Apple Store App 独立开发者，你要搞限时促销，为你的应用生成激活码（或者优惠券），使用 Python 如何生成 200 个激活码（或者优惠券）？
# Author: Paddy Haung
# Date: 2020-20 19:35

import random, string

def generate(count, length):
	list, Re = [], ''
	forSelect = string.ascii_letters + '0123456789'	# string.ascii_letters 即所有大小写字母
	for i in range(count):
		for j in range(length):
			Re += random.choice(forSelect)		# 在所有字母即数字中任选20个组成一个激活码
		list.append(Re);
		Re = ''
	return list

if __name__ == '__main__':
	list = generate(200, 20)		# 生成200个长度为20个字符的激活码
	for i in range(len(list)):
		print(list[i])

