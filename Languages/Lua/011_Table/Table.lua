-- [1. Simple Table]
mytable = {}
print("type of mytable: ", type(mytable))

mytable[1] = "Lua"
mytable["wow"] = "Before Altering"
print("the element of index 1 in mytable is: ", mytable[1])
print("the element of index wow in mytable is: ", mytable["wow"])

-- [alternatetable and mytable point at the same table]
alternatetable = mytable
print("alternatetable[1]: ", alternatetable[1])
print("alternatetable[\"wow\"]", alternatetable["wow"])

alternatetable["wow"] = "After Altering"

print("alternatetable[\"wow\"]: ", alternatetable["wow"])
-- release variable
alternatetable = nil
print("alternatetable: ", alternatetable)

-- mytable is still able to be visited
print("mytable[\"wow\"]", mytable["wow"])

mytable = nil
print("mytable: ", mytable)

-- [1. Table concat]
fruits = {"banana", "orange", "apple"}
-- return the string after concatting tables
print("Concatted string: ", table.concat(fruits))
-- assign concat character
print("Concatted string: ", table.concat(fruits, ", "))
-- assign index to concat table
print("Concatted string: ", table.concat(fruits, ", ", 2, 3))

-- [2. Table insert]
table.insert(fruits, "mango")
print("the element of index 4 is: ", fruits[4])
-- insert at index 2
table.insert(fruits, 2, "grapes")
print("the element of index 2 is: ", fruits[2])

print("the last element is: ", fruits[5])
-- remove th last element
table.remove(fruits)
print("the last element after removing: ", fruits[5])

-- [3. Table sort]
fruits = {"banana", "orange", "apple", "grapes"}
print("Before sorting")
for k,v in ipairs(fruits) do
	print(k, v)
end

table.sort(fruits)
print("After sorting")
for k,v in ipairs(fruits) do
	print(k, v)
end

-- [4. Table maxn]
function table_maxn(t)
	local mn = nil
	for k,v in ipairs(t) do
		if(mn == nil) then
			mn = v
		end
		if mn < v then
			mn = v
		end
	end
	return mn
end

tb1 = {[1] = 2, [2] = 6, [3] = 34, [26] = 5}
print("max in tb1: ", table_maxn(tb1))
print("length of tb1: ", #tb1)

-- [5. Table length]
function table_length(t)
	local length = 0
	for k, v in pairs(s) do
		length = length + 1
	end
	return length
end



