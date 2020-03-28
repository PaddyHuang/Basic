#!/usr/local/bin/python3
import random

def merge(array, left, mid, right):
	n1 = mid - left + 1
	n2 = right - mid
	# 创建临时数组
	L = [0] * n1
	R = [0] * n2
	# 拷贝数据到临时数组L[], R[]
	for i in range(0, n1):
		L[i] = array[left + i]
	for i in range(0, n2):
		R[i] = array[mid + 1 + i]
	# 归并数组到array[left..right]
	i = 0	# 初始化第一个子数组的索引
	j = 0	# 初始化第二个子数组的索引
	k = left	# 初始归并子数组索引

	while i < n1 and j < n2:
		if L[i] <= R[j]:
			array[k] = L[i]
			i += 1
		else:
			array[k] = R[j]
			j += 1
		k += 1
	# 拷贝L[]还剩余的元素
	while i < n1:
		array[k] = L[i]
		i += 1
		k += 1
	# 拷贝R[]还剩余的元素
	while j < n2:
		array[k] = R[j]
		j += 1
		k += 1

def merge_sort(array, left: int, right: int):
	if left < right:
		mid = (left + (right - 1)) // 2
		merge_sort(array, left, mid)
		merge_sort(array, mid + 1, right)
		merge(array, left, mid, right)

def generate(length: int):
	list = []
	for i in range(length):
		_  = random.randint(0, 100)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before:')
	for i in array: print(i, end = ', ')
	merge_sort(array, 0, len(array) - 1)
	print('\nAfter:')
	for i in array: print(i, end = ', ')

