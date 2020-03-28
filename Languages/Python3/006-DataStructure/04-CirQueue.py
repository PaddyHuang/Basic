#!/usr/local/bin/python3

class CirQueue(object):
	def __init__(self, size: int):
		self.front = self.rear = 0
		self.size = size
		self.elements = [0] * self.size
		print('Initiated.')

	def __del__(self):
		print('Destroy queue')

	# def __len__(self):

	def enqueue(self, value: int):
		if (self.rear + 1) % self.size == self.front:	# 判断队列是否已满
			print('Queue is full')
			return
		self.rear = (self.rear + 1) % self.size
		self.elements[self.rear] = value

	def dequeue(self):
		if self.front == self.rear:		# 判断队列是否为空
			print('Queue is empty')
			return
		self.front = (self.front + 1) % self.size	# 队首指针指向下一个单元，即出队（被删除）元素
		return self.elements[self.front]

	def getQueue(self):
		if self.front == self.rear:		# 判断队列是否为空
			print('Queue is empty')
			return
		return self.elements[(self.front + 1) % self.size]

	def isEmpty(self):
		return self.front == self.rear

def main():
	queue = CirQueue(5)
	print(queue.isEmpty())
	queue.enqueue(5)
	queue.enqueue(4)
	print(queue.getQueue())
	queue.dequeue()
	print(queue.getQueue())

if __name__ == '__main__':
	main()

