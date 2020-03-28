#!/usr/local/bin/python3
import random

def select_sort(array):
	for i in range(len(array)):
		min_index = i
		for j in range(i + 1, len(array)):
			if array[min_index] > array[j]:
				min_index = j
		array[i], array[min_index] = array[min_index], array[i]

def generate(length: int):
	list = []
	for i in range(length):
		_ = random.randint(0, 100)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before:')
	for i in array: print(i)
	select_sort(array)
	print('\nAfter:')
	for i in array: print(i)

