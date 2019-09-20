-- [1.linear array(a dimensional array)]
array1 = {"Lua", "Tutorial"}
for i = 0, 2 do
	print(array1[i])
end

array2 = {}
for i = -2, 2 do
	array2[i] = i * 2
end

for i = -2, 2 do
	print(array2[i])
end

-- [2. multi dimensional array]
-- init array
array = {}
for i = 1, 3 do
	array[i] = {}	-- empty array
	for j = 1, 3 do
		array[i][j] = i * j
	end
end

-- visit array
for i = 1, 3 do
	for j = 1, 3 do
		print(array[i][j])
	end
end



