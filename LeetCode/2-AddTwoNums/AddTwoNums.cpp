/*
 * @Description: 给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
    如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
    您可以假设除了数字 0 之外，这两个数都不会以 0 开头。
    示例：
        输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
        输出：7 -> 0 -> 8
        原因：342 + 465 = 807
 * @Version: 1.0
 * @Autor: Paddy Huang
 * @Date: 2019-10-10 22:42:32
 * @LastEditors: Paddy Huang
 * @LastEditTime: 2019-10-10 23:06:21
 */
#include <iostream>
using namespace std;

// Definition for singly-linked list.
struct ListNode {
    int val;
    ListNode *next;
    ListNode(int x) : val(x), next(NULL) {}
 };
 
class Solution {
public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) {
        ListNode *list = new ListNode(0), *head = list;
        ListNode *p = l1, *q =l2;
        int carry = 0;
        
        while(p != NULL || q != NULL){
            int x = (p != NULL)? p->val : 0;
            int y = (q != NULL)? q->val : 0;
            int sum = carry + x + y;
            carry = sum / 10;
            
            head->next = new ListNode(sum % 10);
            head = head->next;

            if(p != NULL) p = p->next;
            if(q != NULL) q = q->next;
        }

        if(carry > 0) head->next = new ListNode(carry);

        return list->next;
    }
};

int main(){
    ListNode *l1 = new ListNode(0), *p = l1;
    ListNode *l2 = new ListNode(0), *q = l2;
    int maxSize = 9;
    for(int counter = 0; counter < maxSize - 5; counter++, p = p->next)
            p->next = new ListNode(counter + 1);
    for(int counter = maxSize; counter > 0; counter--, q = q->next)
            q->next = new ListNode(counter);
    for(p = l1->next; p != NULL; p = p->next)
            cout << p->val << " ";
    cout << endl;
    for(q = l2->next; q != NULL; q = q->next)
            cout << q->val << " ";
    cout << endl;

    Solution solution;
    ListNode* list = solution.addTwoNumbers(l1->next, l2->next);
    for(p = list; p != NULL; p = p->next)
            cout << p->val << " ";
    cout << endl;

    return 0;
}