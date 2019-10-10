-- [Author: Paddy Huang]
-- [Date: 2019-10-07 06:24:17]
-- [Description: 九九乘法表]

for i = 1, 9 do
	local res = ""
	for j = 1, i do
		res = res .. string.format("%dX%d=%d ", i, j, i*j)
	end
	print(res)
end

