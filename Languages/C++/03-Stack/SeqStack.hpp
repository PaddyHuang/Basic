// SeqStack.hpp
// Author: Paddy Huang
// Date: 2020.03.11 17:37

// 数组实现的栈，能存储任意类型的数据
// 元素从0开始
#ifndef SEQ_STACK_HXX
#define SEQ_STACK_HXX

#include <iostream>
using namespace std;

#define MAXSIZE 10

// 模版类
template<class T>
class SeqStack{
    public:
        SeqStack();
        ~SeqStack();
        void push(T t); // 向栈中添加一个元素
        T peek();       // 从栈顶取出一个元素
        T pop();        // 弹出栈顶元素
        int size();     // 返回栈大小
        bool isEmpty(); // 判空
    private:
        T *element;     // 元素
        int top;      // 栈顶指针
};

// 构造函数
template<class T>
SeqStack<T>::SeqStack(){
    element = new T[MAXSIZE];
    if(!element)
        cout << "Stack malloc error!" << endl;
    top = -1;
}

// 析构函数
template<class T>
SeqStack<T>::~SeqStack(){
    if(element){
        delete[] element;
        element = NULL;
        top = -1;
    }
}

// Push
template<class T>
void SeqStack<T>::push(T t){
    element[top++] = t;
}

// Peek
template<class T>
T SeqStack<T>::peek(){
    return element[top - 1];
}

// Pop
template<class T>
T SeqStack<T>::pop(){
    T value = element[top - 1];
    top--;
    return value;
}

// Size
template<class T>
int SeqStack<T>::size(){
    return top;
}

// isEmpty
template<class T>
bool SeqStack<T>::isEmpty(){
    return top == -1;
}

#endif
