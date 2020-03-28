#!/usr/local/bin/python3
import random

def shell_sort(array):
	length = len(array)
	gap = length // 2	# 分组间隔

	while gap > 0:
		for i in range(gap, length):
			temp = array[i]
			j = i
			while j >= gap and array[j - gap] > temp:
				array[j] = array[j - gap]
				j -= gap
			array[j] = temp
		gap = gap // 2

def generate(length):
	list = []
	for i in range(length):
		_ = random.randint(0, 100)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before:')
	for i in array: print(i, end = ', ')
	shell_sort(array)
	print('\nAfter:')
	for i in array: print(i, end = ', ')

