#!/usr/local/bin/python3
import random

def swap(a, b):
	t = a
	a = b
	b = t

def quick_sort(array, left: int, right: int):
	if array == None:
		return
	if left >= right:
		return
	length = right - left
	index = random.randint(0, length) + left	# 使用随机元素作为哨兵
#	swap(array[left], array[index])					# 将第一个元素作为哨兵
	array[left], array[index] = array[index], array[left]	# 闭包交换

	key, i, j = array[left], left, right
	while(i < j):
		while array[j] >= key and i < j: j -= 1
		if i < j: array[i] = array[j]
		while array[i] < key and i < j: i += 1
		if i < j: array[j] = array[i]
	array[i] = key
	
	quick_sort(array, left, i - 1)
	quick_sort(array, i + 1, right)

def generate(length: int) -> list:
	list = []
	for i in range(length):
		list.append(random.randint(1, 100))
	return list

if __name__ == '__main__':
	array = generate(10)
	for i in array: print(i)
	print()
	quick_sort(array, 0, len(array) - 1)
	for i in array: print(i)

