/*
 * @Description: 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
示例:
    给定 nums = [2, 7, 11, 15], target = 9
    因为 nums[0] + nums[1] = 2 + 7 = 9
    所以返回 [0, 1]
 * @Version: 1.0
 * @Autor: Paddy Huang
 * @Date: 2019-10-10 21:34:25
 * @LastEditors: Paddy Huang
 * @LastEditTime: 2019-10-10 22:39:29
 */
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        if(nums.empty()) return vector<int>{0};
        
        for(int i = 0; i < nums.size() - 1; i++)
            for(int j = i+ 1; j < nums.size(); j++)
                if(nums[i] + nums[j] == target)
                return vector<int>{i, j};
        
        return vector<int>{0};
    }
};

int main(){
    Solution solution;
    vector<int> test = {3,2,3,30,2,1,2,3,4,4,3,5,6,7,6,100,2,3,23,21};
    vector<int> res = solution.twoSum(test, 8);
    for(int i = 0; i < res.size(); i++)
        cout << res[i] << " ";
    return 0;
}
