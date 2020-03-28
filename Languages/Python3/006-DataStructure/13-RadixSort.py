#!/usr/local/bin/python3
import random, string

def radix_sort(array):
	output = [0 for i in range(256)]
	count = [0 for i in range(256)]
	ans = ['' for _ in array]

	for i in array:
		count[ord(i)] += 1
	for i in range(256):
		count[i] += count[i - 1]
	for i in range(len(array)):
		output[count[ord(array[i])] - 1] = array[i]
		count[ord(array[i])] -= 1
	for i in range(len(array)):
		ans[i] = output[i]
	return ans

def generate(length: int):
	list = []
	forSelect = string.ascii_letters + '0987654321'
	for i in range(length):
		_ = random.choice(forSelect)
		list.append(_)
	return list

if __name__ == '__main__':
	array = generate(10)
	print('Before:')
	for i in array: print(i, end = ', ')
	array = radix_sort(array)
	print('\nAfter:')
	for i in array: print(i, end = ', ')
	
