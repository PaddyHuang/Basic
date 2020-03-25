#
# @lc app=leetcode.cn id=9 lang=python3
#
# [9] 回文数
#

# @lc code=start
class Solution:
    def isPalindrome(self, x: int) -> bool:
        # 特殊情况：
        # 1. x < 0: 不是回文数
        # 2. 末尾是0: 则首位也必须是0才能是回文数
        if x < 0 or (x % 10 == 0 and x != 0):
            return False
        
        # 方法一: list数组判断首尾 108ms, 13.7MB
        # list = []
        # while x != 0:
        #     list.append(x % 10)
        #     x //= 10
        # length = len(list)
        # for i in range(0, length):
        #     if list[i] != list[length - i - 1]:
        #         return False
        # return True

        # 方法二: 反转一半数字 76ms, 13.6MB
        # reverted = 0
        # while x > reverted:
        #     reverted = reverted * 10 + x % 10
        #     x //= 10
        # return x == reverted or x == reverted // 10

        # 方法三: int转为string 84ms, 13.4MB
        l = list(str(x))
        left, right = 0, len(l) - 1
        while left <= right:
            if l[left] != l[right]:
                return False
            left += 1
            right -= 1
        return True

# @lc code=end

