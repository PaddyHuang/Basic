function foo(a)
	print("foo output: ", a)
	return coroutine.yield(2 * a)
end

co = coroutine.create(
	function(a, b)
		print("first coroutine output: ", a, b)
		local r = foo(a + 1)

		print("second coroutine output: ", r)
		local r, s = coroutine.yield(a + b, a - b)

		print("third coroutine output: ", r, s)
		return b, "End Coroutine"
	end	
)

print("main", coroutine.resume(co, 1, 10))
print("----------------------------------")
print("main", coroutine.resume(co, "r"))
print("----------------------------------")
print("main", coroutine.resume(co, "x", "y"))
print("----------------------------------")
print("main", coroutine.resume(co, "x", "y"))
print("----------------------------------")


