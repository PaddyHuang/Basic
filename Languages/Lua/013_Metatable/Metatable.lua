-- [1. Defination]
-- setmetatable
-- Method 1
mytable = {}
mymetatable = {}
setmetatable(mytable, mymetatable)	-- set mytable as mymetatable

-- Method 2
mytable = setmetatable({},{})

-- getmetatable
getmetatable(mytable)

-- [2. __index]
mytable = setmetatable({key1 = "value1"}, {
	__index = function(mytable, key)
		if key == "key2" then
			return "metatablevalue"
		else
			return nil
		end
	end
})
print(mytable.key1, mytable.key2)

-- Simplified
mytable = setmetatable({key1 = "value1"}, {__index ={ key2 = "metatablevalue" }})
print(mytable.key1, mytable.key2)

-- [3. __newindex]
mytable = {}
mytable = setmetatable({key1 = "value1"}, {__newindex = mymetatable})

print(mytable.key1)

mytable.newkey = "newKey2"
print(mytable.newkeym, mymetatable.newkey)

mytable.key1 = "newKey1"
print(mytable.key1, mymetatable.key1)

-- use rawset to update table
mytable = setmetatable({key1 = "value1"}, {
	__newindex = function(mytable, key, value)
		rawset(mytable, key, "\""..value.."\"")
	end
})

mytable.key1 = "new value"
mytable.key2 = 4

print(mytable.key1, mytable.key2)

-- [4. __add(add two table)]
function table_maxn(t)
	local mn = 0
	for k, v in pairs(t) do
		if mn < k then
			mn = k
		end
	end
	return mn
end

-- add two table
mytable = setmetatable({1, 2, 3}, {
	__add = function(mytable, newtable)
		for i = 1, table_maxn(newtable) do
			table.insert(mytable, table_maxn(mytable) + 1, newtable[i])
		end
		return mytable
	end
})

secondtbale = {4, 5, 6}
mytable = mytable + secondtbale

for k, v in ipairs(mytable) do
	print(k, v)
end

-- [5. __call]
mytable = setmetatable({10}, {
	__call = function(mytable, newtable)
		sum = 0
		for i = 1, table_maxn(mytable) do
			sum = sum + mytable[i]
		end
		for i = 1, table_maxn(newtable) do
			sum = sum + newtable[i]
		end
		return sum
	end
})

newtable = {10, 20, 30}
print(mytable(newtable))

-- [6. __tostring]
mytable = setmetatable({10, 20, 30}, {
	__tostring = function(mytable)
		sum = 0
		for k, v in pairs(mytable) do
			sum = sum + v
		end
		return "Sum = "..sum
	end
})
print(mytable)

