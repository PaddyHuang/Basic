#!//usr/local/bin/python3

# Multiple variables assignment
a = b = c = 1
print(a); print(b); print(c)

a , b, c = 1, 2, "Hello"
print(a); print(b); print(c)

# Standard Data Class
# 	1. Number	(Unchangeable)
#	2. String	(Unchangeable)
#	3. Tuple	(Unchangeable)
#	4. List		(Changeable)
#	5. Set		(Changeable)
#	6. Dictionary(Changeable)

# 1. Number: int, float, bool, complex
a, b, c, d = 10, 3.14, True, 4+3j
print(type(a), type(b), type(c), type(d))

# 2. String
str = 'Runoob'

print (str)          # 输出字符串
print (str[0:-1])    # 输出第一个到倒数第二个的所有字符
print (str[0])       # 输出字符串第一个字符
print (str[2:5])     # 输出从第三个开始到第五个的字符
print (str[2:])      # 输出从第三个开始的后的所有字符
print (str * 2)      # 输出字符串两次，也可以写成 print (2 * str)
print (str + "TEST") # 连接字符串

# 3. List
# List（列表） 是 Python 中使用最频繁的数据类型。
# 列表可以完成大多数集合类的数据结构实现。列表中元素的类型可以不相同，它支持数字，字符串甚至可以包含列表（所谓嵌套）。
# 列表是写在方括号 [] 之间、用逗号分隔开的元素列表。
# 和字符串一样，列表同样可以被索引和截取，列表被截取后返回一个包含所需元素的新列表。
# 列表截取的语法格式如下：var[head : rear] (0 is the first from head, -1 is the first from rear)

list = ['asd', 123, 3.232, 'qwe', 7+4j]
tinyList = [123, 'qwead']

print(list)
print(list[0])
print(list[1:3])
print(list[2:])
print(tinyList * 2)
print(list + tinyList)

# 4. Tuple
tuple = ('asd', 123, 3.232, 'qwe', 7+4j)
tinyTuple = (123, 'qwead')

print(tuple)
print(tuple[0])
print(tuple[1:3])
print(tuple[2:])
print(tinyTuple* 2)
print(tuple+ tinyTuple)

# 5. Set
# 集合（set）是由一个或数个形态各异的大小整体组成的，构成集合的事物或对象称作元素或是成员。
# 基本功能是进行成员关系测试和删除重复元素。
# 可以使用大括号 { } 或者 set() 函数创建集合，注意：创建一个空集合必须用 set() 而不是 { }，因为 { } 是用来创建一个空字典。
# 创建格式：param = {value01, value02, ...} or param = set(value)

students = {'Jack', 'Rose', 'Amy', 'Dicken', 'Tom', 'Mary'}
print(students)

if 'Rose' in students:
	print('Rose is student.')
else:
	print('Rose is not student')

# Set 可以进行集合运算
a = set('asdaf')
b = set('qeqfaas')
print(a)
print(a - b)
print(a | b)
print(a & b)
print(a ^ b)

# 6. Dictionary
# 字典（dictionary）是Python中另一个非常有用的内置数据类型。
# 列表是有序的对象集合，字典是无序的对象集合。两者之间的区别在于：字典当中的元素是通过键来存取的，而不是通过偏移存取。
# 字典是一种映射类型，字典用 { } 标识，它是一个无序的 键(key) : 值(value) 的集合。
# 键(key)必须使用不可变类型。
# 在同一个字典中，键(key)必须是唯一的。

dict = {}
dict['one'] = '02-hahaha'
dict[2] = '03-hohoho'

tinyDict = {'one': 'haha', 'tow': 'hoho', 'three': 'xixi'}

print(dict['one'])
print(dict[2])
print(tinyDict)
print(tinyDict.keys())
print(tinyDict.values())

