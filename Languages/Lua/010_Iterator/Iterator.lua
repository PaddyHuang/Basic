-- [1.for iterator: key/value]
array = {"Lua", "Tutorial"}
for key,value in ipairs(array) do
	print(key, value)
end

-- [2.Stateless Iterator(typical: ipairs())]
function square(iteratorMaxCount, currentNumber)
	if currentNumber < iteratorMaxCount then
		currentNumber = currentNumber + 1
		return currentNumber, currentNumber * currentNumber
	end
end

for i, n in square,3 ,0 do
	print(i,n)
end

-- [3.Multi states iterator]
function elementIterator(collection)
	local index = 0
	local count = #collection
	-- clause
	return function()
		index = index + 1
		if index <= count then
			-- return the current element of Iterator
			return collection[index]
		end
	end
end

for element in elementIterator(array) do
	print(element)
end


