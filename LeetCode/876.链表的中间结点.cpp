/*
 * @lc app=leetcode.cn id=876 lang=cpp
 *
 * [876] 链表的中间结点
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     ListNode *next;
 *     ListNode(int x) : val(x), next(NULL) {}
 * };
 */
class Solution {
public:
    ListNode* middleNode(ListNode* head) {
        if(head == NULL) return NULL;

        // 法一: 两次遍历 0ms, 8.3MB
        // int length = 0;
        // ListNode *p = head;
        // while(p != NULL){   // 求表长
        //     length++;
        //     p = p->next;
        // }
        // p = head;
        // for(int i = 0; i < length / 2; i++)
        //     if(p != NULL)
        //         p = p->next;
        // return p;

        // 法二: 将单链表化为顺序表 0ms, 8.2MB
        // int length = 0;
        // vector<ListNode*> array;
        // ListNode *p = head;
        // while(p != NULL){
        //     array.push_back(p);
        //     length++;
        //     p = p->next;
        // }
        // return array[length / 2];

        // 法三: 快慢指针 0ms, 7.9MB
        ListNode *slow = head;
        ListNode *fast = head;
        while(fast && fast->next){
            slow = slow->next;
            fast = fast->next->next;
        }
        return slow;

    }
};
// @lc code=end

