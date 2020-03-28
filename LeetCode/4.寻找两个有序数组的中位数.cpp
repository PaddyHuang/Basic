/*
 * @lc app=leetcode.cn id=4 lang=cpp
 *
 * [4] 寻找两个有序数组的中位数
 */

// @lc code=start
class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        // 方法一：合并顺序表 + 快速排序 Time: O(log(m + n)), Space: O(m + n)
        // 53.3ms, 8.2MB
        vector<int> array;
        for(int i = 0; i < nums1.size(); i++) array.push_back(nums1[i]);
        for(int i = 0; i < nums2.size(); i++) array.push_back(nums2[i]);

        int size = array.size();
        // for(int i = 0; i < size; i++) cout << array[i] << endl;
        QuickSort(array, 0, size - 1);
        // for(int i = 0; i < size; i++) cout << array[i] << endl;
        // cout << array[size / 2] << endl;
        // cout << array[size / 2 - 1] << endl;

        // if(size <= 1) return array[0];
        if(size % 2 != 0) return array[size / 2];
        else return (array[size / 2] + array[size / 2 - 1]) / 2.0;
    }
private:
    void swap(int &a, int &b){
        int temp = a;
        a = b;
        b = temp;
        return;
    }

    void QuickSort(vector<int>& array, int left, int right){
        if(left >= right) return;

        srand((unsigned)time(NULL));    // 获取随机数
        int length = right - left;
        int index = rand() % (length + 1) + left;   // 获取随机下标
        swap(array[left], array[index]);    // 把最左边的元素作为哨兵

        int key = array[left], i = left, j = right;
        while(i < j){
            while(array[j] >= key && i < j) j--;
            if(i < j) array[i] = array[j];
            while(array[i] < key && i < j) i++;
            if(i < j) array[j] = array[i];
        }
        array[i] = key;     // 把哨兵赋值回去

        QuickSort(array, left, i - 1);      // 递归调用
        QuickSort(array, j + 1, right);
    }
};
// @lc code=end

