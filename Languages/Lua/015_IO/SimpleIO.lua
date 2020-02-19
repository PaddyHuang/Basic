-- [1. read only]
file = io.open("test.lua", "r")

io.input(file)
-- output the first col
print(io.read())
-- close opened file
io.close(file)

-- [2. add]
file = io.open("test.lua", "a")

io.output(file)
-- add words at the last col
io.write("-- test.lua ÎÄÄ©×¢ÊÍ")

io.close(file)



