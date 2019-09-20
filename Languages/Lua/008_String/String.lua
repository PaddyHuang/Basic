-- [string]
string1 = "Lua"
print("\"string1: \"", string1)
string2 = "runoob.com"
print("srting2: ", string2)
string3 = [["Lua Tutorial]]
print("string3: ", sting3)

-- [String Operation] 
-- [1.string.upper(argument)]
print("string.upper(string1): ", string.upper(string1))
-- [2.string.lower(argument)]
print("string.lower(string1): ", string.lower(string1))
-- [3.string.gsub(mainString, findString, replaceString, num)]
print("string.gsub(\"aaaa\", \"a\", \"z\", 3)", string.gsub("aaaa", "a", "z", 3))
-- [4.string.find(str, subSrt, [init,[end]])]
print("string.find(\"Hello Lua User\", \"Lua\", 1)", string.find("Hello Lua User", "Lua", 1))
-- [5.string.reverse(arg)]
print("string.reverse(\"Lua\")", string.reverse("Lua"))
-- [6.string.format(...)]
print("string.format(\"the calue is: %d\", 4)", string.format("the calue is: %d", 4))
-- [7.string.char(arg), string.byte(arg, int),default int is the first one.]
print("string.char(97, 98, 99, 100)", string.char(97, 98, 99, 100))
print("string.byte(\"ABCD\", 4)", string.byte("ABCD", 4))
print("string.byte(\"ABCD\")", string.byte("ABCD"))
-- [8.string.len(arg)]
print("string.len(\"abc\")", string.len("abc"))
-- [9.string.rep(string,n)]
print("string.rep(\"abcd\",2)", string.rep("abcd",2))
-- [10. .. concat two string]
print("www.runoob" .. "com")
-- [11.string.gmatch(str, pattern)]
for word in string.gmatch("Hello Lua User", "%a+") do print(word) end
-- [12.string.match(str, pattern, init)]
print("string.match(\"I have 2 questions for you.\", \"%d+ %a+\"): ", string.match("I have 2 questions for you.", "%d+ %a+"))
print("string.match(\"I have 2 questions for you.\", \"(%d+) (%a+)\"): ", string.match("I have 2 questions for you.", "(%d+) (%a+)"))



