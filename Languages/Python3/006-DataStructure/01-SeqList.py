#!/usr/local/bin/python3

class SeqList(object):
	#__nodes = []	# 顺序表元素列表
	#__length = 0	# 顺序表长度
	#__maxsize = 10	# 顺序表最大长度

	def __init__(self):	# 构造函数
		print('Initiating list...')
		self.__length = 0			# 顺序表长度
		self.__maxsize = 10000		# 顺序表最大长度
		self.__nodes = [0] * self.__maxsize	# 顺序表元素列表
		print('Initiated.')

	def __del__(self):	# 析构函数
		print('Del list')
		del self

	def __repr__(self):	# 打印、转换	
		#print(self.__nodes)
		if self.__length > 0:
			print('List start:')
			for index in range(0, self.__length):
				print('No.%d: %d' % (index + 1, self.__nodes[index]))
			return 'List ends.'
		else:
			return 'Empty list.'

	def __setitem__(self, index: int, value: int):	# 按索引赋值
		#print('setitem')
		if 0 <= index < self.__length:
			self.__nodes[index] = value
		else:
			print('Invalid index')
		return

	def __getitem__(self, index: int):	# 按索引取值
		return self.__nodes[index] if 0 <= index < self.__length else -1
	
	def __len__(self):	# 获取长度
		print('List length: ', end = '')
		return self.__length

	def isEmpty(self):		# 顺序表判空
		return True if self.__length <= 0 else False

	def isFull(self):		# 顺序表判满
		return True if self.__length >= self.__maxsize else False
	
	def insert(self, index: int, value: int):
		if index < 0 or index > self.__length:
			print('Invalid Index')
			return
		if self.__length > self.__maxsize:
			print('List is full')
			return

		for i in range(self.__length - 1, index - 1):
			self.__nodes[i + 1] = self.__nodes[i]

		self.__nodes[index] = value
		self.__length += 1

	def appendAtHead(self, value: int):
		if self.__length > self.__maxsize:
			print('List is full')
			return

		for i in range(self.__length - 1, 0 - 1):
			self.__nodes[i + 1] = self.__nodes[i]
		self.__nodes[0] = value
		self.__length += 1

	def append(self, value: int):
		if self.__length > self.__maxsize:
			print('List is full')
			return

		self.__nodes[self.__length] = value
		self.__length += 1

	def createSeqList(self, num: int):
		if num < 0:
			print('Invalid num')
			return
	
		for index in range(0, num):
			print('Please input No.%d element: ' % (index + 1), end = '')
			value = input()
			self.append(int(value))

		self.__length = num

	def removeAt(self, index: int):
		if index < 0 or index > self.__length:
			print('Invalid index')
			return
		for i in range(index, self.__length):
			self.__nodes[i - 1] = self.__nodes[i]
		self.__length -= 1

	def removeFor(self, value: int):
		index = 0
		while index < self.__length and self.__nodes[index] != value:
			index += 1
		for i in range(index, self.__length):
			self.__nodes[i] = self.__nodes[i + 1]
		self.__length -= 1

	def removeAll(self):
		for i in range(0, self.__length):
			self.__nodes[i] = 0
		self.__length = 0

	def removeAtHead(self):
		for i in range(1, self.__length):
			self.__nodes[i - 1] = self.__nodes[i]
		self.__length -= 1

def main():
	seqList = SeqList()
	for i in range(0, 10000 - 1):
		seqList.append(i)
	for i in range(0, 10000):
		seqList.insert(50, 99)
		seqList.removeAt(50)
		
	#print(seqList)
	#print(len(seqList))
	#print(seqList.isEmpty())
	#seqList.createSeqList(5)
	#print(seqList)
	#print(seqList)

if __name__ == '__main__':
	main()
