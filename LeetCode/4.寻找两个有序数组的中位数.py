#
# @lc app=leetcode.cn id=4 lang=python3
#
# [4] 寻找两个有序数组的中位数
#

# @lc code=start
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        # 方法一：合并顺序表 + 快速排序 Time: O(log(m + n)), Space: O(m + n)
        # 52ms, 13.7MB
        list = []
        for i in range(0, len(nums1)):
            list.append(nums1[i])
        for i in range(0, len(nums2)):
            list.append(nums2[i])
        
        list.sort()
        length = len(list)

        if length % 2 != 0:
            return list[length // 2]
        else:
            return (list[length // 2] + list[length // 2 - 1] ) / 2

# @lc code=end

