#!/usr/local/bin/python3

class Node(object):
    def __init__(self, data):
        self.data = data
        self.next = None

class LinkList(object):
	def __init__(self, node = Node(0)):	# 构造函数, 头结点默认为None
		print('Initiating list...')
		self.__length = 0			# 单链表长度
		self.__maxsize = 10000		# 单链表最大长度
		self.__head = node	# 单链表头结点
		print('Initiated.')

	def __del__(self):	# 析构函数
		print('Del list')
		del self

	def __repr__(self):	# 打印、转换	
		#print(self.__nodes)
		if self.__length > 0:
			print('List start:')
			index = 1 
			p = self.__head.next
			while p != None:
				print('No.%d: %d' % (index, p.data))
				p = p.next
				index += 1
			return 'List ends.'
		else:
			return 'Empty list.'

	def __setitem__(self, index: int, value: int):	# 按索引赋值
		if self.__length == 0:
			print('Empty list')
			return

		#print('setitem')
		if 0 <= index <= self.__length:
			i = 1
			p = self.__head.next
			while p != None and i < index:  # 找出该结点
				p = p.next
				i += 1
			p.data = value
		else:
			print('Invalid index')
		return

	def __getitem__(self, index: int):	# 按索引取值
		if self.__length == 0:
			print('Empty list')
			return

		i = 1
		p = self.__head.next
		while p != None and i < index:
			p = p.next
			i += 1
		return p.data if p != None else -1
	
	def __len__(self):	# 获取长度
		print('List length: ', end = '')
		return self.__length

	def isEmpty(self):		# 单链表判空
		return True if self.__length <= 0 else False

	def isFull(self):		# 单链表判满
		return True if self.__length >= self.__maxsize else False
	
	def insert(self, index: int, value: int):
		if index < 1 or index > self.__length:
			print('Invalid Index')
			return
		if self.__length > self.__maxsize:
			print('List is full')
			return
		i = 0		# 找出前驱结点
		p = self.__head.next
		while p != None and i < index - 1:
			p = p.next
			i += 1

		node = Node(value)
		node.next = p.next
		p.next = node
		self.__length += 1

	def appendAtHead(self, value: int):
		if self.__length > self.__maxsize:
			print('List is full')
			return

		node = Node(value)
		node.next = self.__head.next
		self.__head.next = node
		self.__length += 1

	def append(self, value: int):
		if self.__length > self.__maxsize:
			print('List is full')
			return
		i = 0		# 找出前驱结点
		p = self.__head
		while p != None and i < self.__length:
			p = p.next
			i += 1

		node = Node(value)
		node.next = p.next
		p.next = node
		self.__length += 1

	def createSeqList(self, num: int):
		if num < 0:
			print('Invalid num')
			return
	
		for index in range(0, num):
			print('Please input No.%d element: ' % (index + 1), end = '')
			value = input()
			self.append(int(value))

	def removeAt(self, index: int):
		if index < 0 or index > self.__length:
			print('Invalid index')
			return
		i = 0
		p = self.__head
		while p != None and i < index - 1:      # 找到前驱结点
			p = p.next
			i += 1
		p.next = p.next.next

		self.__length -= 1

	def removeFor(self, value: int):
		index = 0
		p = self.__head
		while p != None and p.data != value:    # 找到该结点
			p = p.next
			index += 1
		if p == None:
			print('No this node')
			return
		
		i = 0
		p = self.__head
		while p != None and i < index - 1:      # 找到前驱结点
			p = p.next
			i += 1
		p.next = p.next.next

		self.__length -= 1

	def removeAll(self):
		self.__head.next = None
		self.__length = 0

	def removeAtHead(self):
		self.__head.next = self.__head.next.next
		self.__length -= 1

def main():
	linkList = LinkList()
	#linkList.createSeqList(5)
	#linkList.removeAt(2)
	#linkList.removeFor(3)
	#linkList.removeFor(3)
	#linkList.append(100)
	#linkList.appendAtHead(200)
	#print(len(linkList))
	#linkList.insert(2, 300)
	#linkList[2] = 2000
	#print(linkList[2])
	#linkList.append(400)
	#print(linkList)
	#linkList.removeAtHead()
	#linkList.removeAll()
	#print(linkList)

	for i in range(0, 10000 - 1):
		linkList.append(i)
	for i in range(0, 10000):
		linkList.insert(50, 99)
		linkList.removeAt(50)

if __name__ == "__main__":
	main()
    
