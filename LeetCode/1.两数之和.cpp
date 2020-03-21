/*
 * @lc app=leetcode.cn id=1 lang=cpp
 *
 * [1] 两数之和
 */

// @lc code=start
class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        // 1. 暴力法
        // for(int i = 0; i < nums.size(); i++)
        //     for(int j = i + 1; j < nums.size(); j++)
        //         if(target - nums[j] == nums[i])
        //             return vector<int>{i, j};
        
        // 2. 两遍哈希表
        // std::map<int, int> dict;
        // for(int i = 0; i < nums.size(); i++)
        //     dict.insert(std::pair<int, int>(nums[i], i));

        // for(int i = 0; i < nums.size(); i++){
        //     int complement = target - nums[i];
        //     std::map<int, int>::iterator iter = dict.find(complement);
        //     if(iter != dict.end() && iter->second != i)
        //         return vector<int>{i, iter->second};
        // }      

        // 3. 一遍哈希表
        std::map<int, int> dict;
        for (int i = 0; i < nums.size(); i++)
        {
            int complement = target - nums[i];
            std::map<int, int>::iterator iter = dict.find(complement);
            if(iter != dict.end())
                return vector<int>{iter->second, i};
            dict.insert(std::pair<int, int>(nums[i], i));
        }
        
        return vector<int>{0};
    }
};
// @lc code=end

