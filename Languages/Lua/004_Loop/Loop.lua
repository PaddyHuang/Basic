-- [while]
a = 10
while (a < 20)
	do
		print("a: ", a)
		a = a + 1
end

-- [for]
-- [Number]
for i = 10, 1, -1 do
	print(i)
end

-- [泛型]
days = {"Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"}
-- [i是数组索引，v是对应索引的数组元素值]
for i,v in ipairs(days) do
	print(v)
end

-- [repeat..until]
a = 10
repeat
	print("a: ", a)
	a = a + 1
until(a > 15)



