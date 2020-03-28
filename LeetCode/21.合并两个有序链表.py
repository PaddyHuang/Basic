#
# @lc app=leetcode.cn id=21 lang=python3
#
# [21] 合并两个有序链表
#

# @lc code=start
# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, x):
#         self.val = x
#         self.next = None

class Solution:
    def mergeTwoLists(self, l1: ListNode, l2: ListNode) -> ListNode:
        list = ListNode(-1)
        head = list

        # 方法一:  迭代法 Time: O(m + n), Space: O(1) 58ms, 13.6MB
        while l1 != None and l2 != None:
            if l1.val < l2.val:
                head.next = l1
                l1 = l1.next
            else:
                head.next = l2
                l2 = l2.next
            head = head.next
        
        # while l1 != None:
        #     head.next = l1
        #     head = head.next
        #     l1 = l1.next
        # while l2 != None:
        #     head.next = l2
        #     head = head.next
        #     l2 = l2.next

        # 方法二:  迭代法 Time: O(m + n), Space: O(1) 6.7ms, 6.4MB
        head.next = l1 if l1 != None else l2

        return list.next
# @lc code=end

