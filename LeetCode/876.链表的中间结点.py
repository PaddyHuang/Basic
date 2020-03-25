#
# @lc app=leetcode.cn id=876 lang=python3
#
# [876] 链表的中间结点
#

# @lc code=start
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def middleNode(self, head: ListNode) -> ListNode:
        if head == None: return None

        # 法一: 两次遍历 52ms, 13.6MB
        # length = 0
        # p = head
        # while p != None:
        #     length += 1
        #     p = p.next
        # p = head
        # for i in range(0, length // 2):
        #     if p != None:
        #         p = p.next
        # return p

        # 法二: 将单链表化为顺序表 52ms, 13.6MB
        # length = 0
        # array = []
        # p = head
        # while p != None:
        #     array.append(p)
        #     length += 1
        #     p = p.next
        # return array[length // 2]

        # 法三: 快慢指针 40ms, 13.6MB
        slow = fast = head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next
        return slow

# @lc code=end

