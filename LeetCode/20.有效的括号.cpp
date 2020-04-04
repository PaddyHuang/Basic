/*
 * @lc app=leetcode.cn id=20 lang=cpp
 *
 * [20] 有效的括号
 */

// @lc code=start
class Solution {
public:
    bool isValid(string s) {
        std::stack<char> stk;

        for(char& c : s)
            switch (c)
            {
            case '(':
            case '[':
            case '{': stk.push(c); break;
            case ')': if(stk.empty() || stk.top() != '(') return false; else stk.pop(); break;
            case ']': if(stk.empty() || stk.top() != '[') return false; else stk.pop(); break;
            case '}': if(stk.empty() || stk.top() != '{') return false; else stk.pop(); break;
            default: ;  // pass
            }
        return stk.empty();
    }
};
// @lc code=end

