#!/usr/local/bin/python3
import random

def insert_sort(array):
	for i in range(1, len(array)):
		key = array[i]
		j = i - 1
		while j >= 0 and key < array[j]:
			array[j + 1] = array[j]
			j -= 1
		array[j + 1] = key

def generate(length):
	list = []
	for i in range(length):
		_ = random.randint(0, 100)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before: ')
	for i in array: print(i)
	print()
	insert_sort(array)
	for i in array: print(i)

