#
# @lc app=leetcode.cn id=7 lang=python3
#
# [7] 整数反转
#

# @lc code=start
class Solution:
    def reverse(self, x: int) -> int:
        # 1. 计算法
        # if -10 < x < 10: return x
        # res, temp = 0, abs(x)
        # overflow = (1 << 31) - 1 if x > 0 else 1 << 31
        # while temp != 0:
        #     res = res * 10 + temp % 10
        #     if res > overflow: return 0
        #     temp //= 10
        # return res if x > 0 else -res

        # 2. string法
        if -10 < x < 10: return x
        str_x = str(x)
        if str_x[0] != '-':
            str_x = str_x[::-1]
            x = int(str_x)
        else:
            str_x = str_x[:0:-1]
            x = int(str_x)
            x = -x
        return x if -2147483648 < x < 2147483647 else 0
# @lc code=end

