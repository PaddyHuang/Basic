/*
 * @lc app=leetcode.cn id=21 lang=cpp
 *
 * [21] 合并两个有序链表
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
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2) {
        // if(l1 == NULL || l2 == NULL) return NULL;
        
        ListNode *list = new ListNode(-1);
        ListNode *head = list;   

        // 方法一:  迭代法 Time: O(m + n), Space: O(1) 9.3ms, 6.6MB
        while(l1 != NULL && l2 != NULL){
            // head->next = new ListNode(0);
            if(l1->val < l2->val){
                head->next = l1;
                l1 = l1->next;
            }
            else{
                head->next = l2;
                l2 = l2->next;
            }
            head = head->next;
        }
        // while(l1 != NULL){
        //     // head->next = new ListNode(0);
        //     head->next = l1;
        //     head = head->next;
        //     l1 = l1->next;
        // }
        // while(l2 != NULL){
        //     // head->next = new ListNode(0);
        //     head->next = l2;
        //     head = head->next;
        //     l2 = l2->next;
        // }
        // 方法二:  迭代法 Time: O(m + n), Space: O(1) 6.7ms, 6.4MB
        head->next = l1 != NULL ? l1 : l2;

        return list->next;
    }
};
// @lc code=end

