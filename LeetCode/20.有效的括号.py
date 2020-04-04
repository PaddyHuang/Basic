#
# @lc app=leetcode.cn id=20 lang=python3
#
# [20] 有效的括号
#

# @lc code=start
class Solution:
    def isValid(self, s: str) -> bool:
        # 1. 栈
        # stack, dict = [], {')' : '(', ']' : '[', '}' : '{'}
        # for item in s:
        #     if item in dict.keys():
        #         if not (stack and stack.pop() == dict[item]):
        #             return False
        #     else:
        #         stack.append(item)
        # return not stack

        # 2. 匹配
        stack = []
        for item in s:
            if item == '(': stack.append(item)
            elif item == '[': stack.append(item)
            elif item == '{': stack.append(item)
            elif item == ')':
                if (len(stack) == 0 or stack[len(stack) - 1] != '('):
                    return False
                else: stack.pop()
            elif item == ']':
                if (len(stack) == 0 or stack[len(stack) - 1] != '['):
                    return False
                else: stack.pop()
            elif item == '}':
                if (len(stack) == 0 or stack[len(stack) - 1] != '{'):
                    return False
                else: stack.pop()
        return len(stack) == 0
# @lc code=end

