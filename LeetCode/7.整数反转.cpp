/*
 * @lc app=leetcode.cn id=7 lang=cpp
 *
 * [7] 整数反转
 */

// @lc code=start
class Solution {
public:
    int reverse(int x) {
        int res = 0, temp;
        while(x != 0){
            temp = x % 10;
            x /= 10;
            // 32位int最大值__INT32_MAX__ + 1 即是 __INT_MIN__
            // __INT_MIN__ = (1 << 31) = 0x80000000
            // __INT_MAX__ = (1 << 31) - 1 = 0x7fffffff
            if(res < (__INT32_MAX__ + 1) / 10 || res > __INT32_MAX__ / 10)
                return 0;
            
            // 多开一个if会多占用资源
            // if(res < (__INT32_MAX__ + 1) / 10) return 0;
            // if(res > __INT32_MAX__ / 10) return 0;

            res = res * 10 + temp;
        }

        return res;
    }
};
// @lc code=end

