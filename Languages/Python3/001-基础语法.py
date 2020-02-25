#!/usr/local/bin/python3

# Python3 source files are decoded on UTF-8 in default and all string are Unicode.

# Identifiers
# 	1. The firsr char must be letters or underline(_).
# 	2. The others must be letters, numbers or underline(_).
#	3. Case sensitive.

# Python3 Keywords
import keyword
print("keywords: ")
print(keyword.kwlist)

# Comments
# 1. Single lane: use #
'''
2. Multi lanes: use \'\'\' or \"\"\"
'''

# Indent

# Multiple line statements
total = 3 + \
		4 + \
		5
print(total)

# Waiting for input: use input("string")

# Display multiple line statements in one line: use ;
import sys; x = 'The Netherland'; sys.stdout.write(x + '\n')


# Number
# Python3 boasts 4 classes for number: int, bool, float, complex

# String
# 	1. '' and "" are equivalent.
#	2. ''' or """ could define a multiple string.
#	3. Python3 string is unchangeable.
#	4. char is not supported and string with length == 1 is a char.
#	5. Interception format of string: str[head:rear:step].
str='Runoob'

print(str)                 # 输出字符串
print(str[0:-1])           # 输出第一个到倒数第二个的所有字符
print(str[0])              # 输出字符串第一个字符
print(str[2:5])            # 输出从第三个开始到第五个的字符
print(str[2:])             # 输出从第三个开始后的所有字符
print(str * 2)             # 输出字符串两次
print(str + '你好')        # 连接字符串

print('------------------------------')

print('hello\nrunoob')      # 使用反斜杠(\)+n转义特殊字符
print(r'hello\nrunoob')     # 在字符串前面添加一个 r，表示原始字符串，不会发生转义


