#!/usr/local/bin/python3
import random

def bubble_sort(array):
	length = len(array)
	# 遍历所有数组元素
	for i in range(length):
		for j in range(length - i - 1):
			if array[j] > array[j + 1]:
				array[j], array[j + 1] = array[j + 1], array[j]	# 交换两个数

def generate(length: int) -> list:
	list = []
	for i in range(length):
		_ = random.randint(0, 100)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before:')
	for i in array: print(i, end = ', ')
	bubble_sort(array)
	print('\nAfter:')
	for i in array: print(i, end = ', ')
