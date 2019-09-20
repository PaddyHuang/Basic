-- [以下实例定义了函数 max()，参数为 num1, num2，用于比较两值的大小，并返回最大值]
function max(num1, num2)
	local result = 0
	if (num1 > num2) then
		result = num1
	else
		result = num2
	end

	return result
end

-- [Call]
print("Max: ", max(10,4))
print("Max: ", max(5,6))

-- [Lua 中我们可以将函数作为参数传递给函数，如下实例]
myPrint = function(param)
	print("这是打印函数 ##", param, " ##" )
end

function add(num1, num2, functionPrint)
	local result = num1 + num2
	functionPrint(result)
end

myPrint(10)
add(2, 5, myPrint)

-- [多返回值]
function maximum(a)
	local mi = 1	-- 最大u索引
	local m = a[mi]	-- 最大值
	for i,v in ipairs(a) do
		if v > v then
			mi = i
			m = v
		end
	end
	return m, mi
end

print(maximum({8, 10, 23, 12, 5}))

-- [可变参数]
-- [Lua 函数可以接受可变数目的参数，和 C 语言类似，在函数参数列表中使用三点 ... 表示函数有可变的参数。]
function addition(...)
	local s = 0
	for i, v in ipairs{...} do
		s = s + v
	end
	return s
end

print(add(3, 4, 5, 6, 7))

-- [我们也可以通过 select("#",...) 来获取可变参数的数量:]
function average(...)
	local result = 0
	local arg = {...}
	for i,v in ipairs(arg) do
		result = result + v
	end
	print("总共传入 " .. select("#", ...) .. "个数")

	return result/select("#", ...)
end

print("平均值为: ", average(10, 5, 3, 4, 5, 6 ))

-- [有时候我们可能需要几个固定参数加上可变参数，固定参数必须放在变长参数之前:]
function fwrite(fmt, ...)	--> 固定参数fmt
	return io.write(string.format(fmt, ...))
end

fwrite("runoob\n")	--> fmt = "runoob", 没有变长参数
fwrite("%d%d\n",1,2)	--> fmt = "%d%d",变长参数为1,2



