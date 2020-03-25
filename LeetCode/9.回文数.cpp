/*
 * @lc app=leetcode.cn id=9 lang=cpp
 *
 * [9] 回文数
 */

// @lc code=start
class Solution {
public:
    bool isPalindrome(int x) {
        // 特殊情况：
        // 1. x < 0: 不是回文数
        // 2. 末尾是0: 则首位也必须是0才能是回文数
        if(x < 0 || (x % 10 == 0 && x != 0))
            return false;

        // 方法一：vector<int>数组判断首尾 28ms, 11MB
        vector<int> array;
        while(x != 0){
            array.push_back(x % 10);
            x /= 10;
        }
        for(int i = 0, length = array.size(); i < length; i++)
            if(array[i] != array[length - i - 1])
                return false;
        return true;

        // 方法二: 反转一半数字 12ms, 7.3MB
        // int reverted = 0;
        // while(x > reverted){
        //     reverted = reverted * 10 + x % 10;
        //     x /= 10;
        // }
        // return x == reverted || x == reverted / 10;
    
        // 方法三: int转为string 16ms, 7.3MB
        // string source = to_string(x);
        // string reverted = source;
        // reverse(reverted.begin(), reverted.end());

        // return source == reverted;
    }
};
// @lc code=end

