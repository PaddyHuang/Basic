#!/usr/local/bin/python3

class SeqStack(object):
	def __init__(self):	# 构造函数
		print('Initiating list...')
		self.__top = -1			# 顺序栈栈顶指针
		self.__maxsize = 10		# 顺序栈最大长度
		self.__elements = [0] * self.__maxsize	# 顺序栈元素列表
		print('Initiated.')

	def __del__(self):	# 析构函数
		print('Del list')
		del self
	
	def __len__(self):	# 获取长度
		print('Stack size: ', end = '')
		return self.__top

	def isEmpty(self):		# 顺序栈判空
		return True if self.__top == -1 else False

	def isFull(self):		# 顺序栈判满
		return True if self.__top >= self.__maxsize else False
	
	def push(self, value: int):
		self.__elements[self.__top] = value
		self.__top += 1

	def peek(self):
		return self.__elements[self.__top - 1]

	def pop(self):
		value = self.__elements[self.__top - 1]
		self.__top -= 1
		return value

def main():
	seqStack = SeqStack()
	seqStack.push(10)
	seqStack.push(20)
	seqStack.push(30)
	while not seqStack.isEmpty():
		print('Pop: ', end = '')
		print(seqStack.pop())

if __name__ == '__main__':
	main()
