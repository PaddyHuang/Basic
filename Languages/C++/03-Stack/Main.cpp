// Main.cpp
// Author: Paddy Huang
// Date: 2020.03.11 17:37

#include "SeqStack.hpp"
#include <stack>    // STL中自带的栈
using namespace std;

void TestSeqStack(){
    int temp = 0;
    SeqStack<int> *seqStack = new SeqStack<int>();
    cout << "main: " << endl;
    // 将10， 20， 30 依次压入栈中
    seqStack->push(10);
    seqStack->push(20);
    seqStack->push(30);
    // 弹出栈顶元素并赋值给temp
    // temp = seqStack->pop();
    // cout << "Pop temp = " << temp << endl;
    // // 取出栈顶元素给temp
    // temp = seqStack->peek();
    // cout << "Peek temp = " << temp << endl;
    // seqStack->push(40);
    // 全部出栈
    while (!seqStack->isEmpty()){
        temp = seqStack->pop();
        cout << "Pop temp = " << temp << endl;
    }
}

void TestSTLStack(){
    int temp = 0;
    stack<int> stk; // 定义int类型的栈
    stk.push(10);
    stk.push(20);
    stk.push(30);
    stk.pop();      // 弹出栈顶元素
    cout << "temp = " << temp << endl;
    temp = stk.top();   // 取得栈顶元素
    stk.push(40);
    while(!stk.empty()){
        temp = stk.top();
        stk.pop();
        cout << "temp = " << temp << endl;
    }
}

int main(void){
    cout << "Test SeqStack: " << endl;
    TestSeqStack();
    // cout << "Test STL Stack: " << endl;
    // TestSTLStack();

    return 0;
}