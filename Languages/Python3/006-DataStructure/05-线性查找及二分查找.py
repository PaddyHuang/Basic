#!/usr/local/bin/python3
import random, string

# 线性查找
def search(array, value) -> int:
	if array == None:
		return -1

	for i in range(len(array)):
		if array[i] == value:
			return i
	return -1

# 二分查找
def binary_search(array, value) -> int:
	if array == None:
		return -1

	left, right, mid = 0, len(array) - 1, 0
	while(left < right):
		mid = (left + right) // 2
		if array[mid] < value:
			left = mid + 1
		else:
			right = mid - 1
	return left if left >= right else -1

def generate(length):	# 生成随机字符数组
	list, re = [], ''
	forSelect = string.ascii_letters + '0123456789'
	for i in range(length):
		re = random.choice(forSelect)
		list.append(re)
		re = ''
	return list

if __name__ == '__main__':
	array = generate(200000)		# 生成20个随机字符
	# for i in array: print(i)
	# value= input('Input a value to search: ')
	value = 'a'
	index = search(array, value)
#	index = binary_search(array, value)
	if value != '':
		if index == -1:
			print('Target: %c is not in this array' % value)
		else:
			print('Value %c index: %d' % (value, index))

