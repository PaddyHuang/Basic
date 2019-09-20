file =io.open("test.lua", "r")
print(file:read())
file:close()

file = io.open("test.lua", "a")

file:write("-- test")
file:close()



