-- [1. Shape]
Shape = {area = 0}

function Shape:new(o, side)
	o = o or {}
	setmetatable(o, self)
	self.__index = self
	side = side or 0
	self.area =side * side
	return o
end

function Shape:printArea()
	print("Area: ", self.area)
end

-- [2. myShape]
myShape = Shape:new(nil, 10)
myShape:printArea()

-- [3. Square]
Square = Shape:new()

-- override Constructor new
function Square:new(o, side)
	o = o or Shape:new(o, side)
	setmetatable(o, self)
	self.__index = self
	return o
end

-- override Function printArea()
function Square:printArea()
	print("Area of Square: ", self.area)
end

-- [4. mySquare]
mySquare = Square:new(nil, 10)
mySquare:printArea()


-- [5. Ractangle] 
Ractangle = Shape:new()

-- override Constructor new
function Ractangle:new(o, length, breadth)
	o = o or Shape:new(o)
	setmetatable(o, self)
	self.__index = self
	self.area = length * breadth
	return o
end

-- override Function printArea()
function Ractangle:printArea()
	print("Area of Ractangle: ", self.area)
end

myRactangle = Ractangle:new(nil, 10, 20)
myRactangle:printArea()





