-- [1. Define a module]
module = {}
-- [2. Define a variable]
module.constant = "This is a constant"
-- [3. Define a function]
function module.func1()
	io.write("This is a public function!\n")
end

local function func2()
	print("This is a private function!\n")
end

function module.func3()
	func2()
end

return module








