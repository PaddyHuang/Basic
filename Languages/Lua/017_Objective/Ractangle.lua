-- [meta class]
Ractangle = {area = 0, length = 0, breadth = 0}

-- constructor new
function Ractangle:new(o, length, breadth)
	o = o or {}
	setmetatable(o, self)
	self.__index = self
	self.length = length or 0
	self.breadth = breadth or 0
	self.area = length * breadth
	return o
end

-- function
function Ractangle:printArea()
	print("Area of Rectangle: ", self.area)
end








