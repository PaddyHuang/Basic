local newProductor
function productor()
	local i = 0
	while true do
		i = i + 1
		send(i)		-- send product to consumer
	end 
end

function consumer()
	while true do
		local i = receive() -- get product from productor
		print(i)
	end
end

function receive()
	local status, value = coroutine.resume(newProductor)
	return value
end

function send(x)
	coroutine.yield(x)	-- x is the value to be sent. After return, suspend
end


-- Startup
newProductor = coroutine.create(productor)
consumer()

