#!/usr/local/bin/python3
import random

def adjust(array, length: int, index: int):
	largest = index
	left = 2 * index + 1
	right = 2 * index + 2

	if left < length and array[index] < array[left]:
		largest = left
	if right < length and array[largest] < array[right]:
		largest = right
	if largest != index:
		array[index], array[largest] = array[largest], array[index]
		adjust(array, length, largest)

def heap_sort(array):
	length = len(array)
	# Build a max heap
	for i in range(length, -1, -1):
		adjust(array, length, i)
	# Exchange elements
	for i in range(length - 1, 0, -1):
		array[i], array[0] = array[0], array[i]	# exchange
		adjust(array, i, 0)

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
	heap_sort(array)
	print('\nAfter:')
	for i in array: print(i)

