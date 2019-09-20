Shape = {area = 0}

-- [Basic Function]
function Shape:new(object, side)
	object = object or {}
	setmetatable(object, self)
	self.__index = self
	side = side or 0
	self.area =side * side
	return object
end

--
function Shape:printArea()
	print("Area: ", self.area)
end

-- [Construct Object]
myShape = Shape:new(nil, 10)
myShape:printArea()


