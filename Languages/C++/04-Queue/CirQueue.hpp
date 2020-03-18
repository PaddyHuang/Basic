// CirQueue.hpp
// Author: Paddy Huang
// Date: 2020.03.11 17:37

// 循环队列
#ifndef CIR_QUEUE_HXX 
#define CIR_QUEUE_HXX

#include <iostream>
using namespace std;

template<class T, int size = 10>
class CirQueue{
    public:
        CirQueue();		// 构造函数，置空队列
        ~CirQueue();	// 析构函数

        void Enqueue(T value);	// 元素入队尾
        T Dequeue();			// 元素出队首

		T GetQueue();			// 获取队首元素，不删除
        bool isEmpty();			// 判空

    private:
		int front;              // 队首指针
        int rear;               // 队尾指针
		T elements[size];	    // 队列元素
};

template<class T, int size>
CirQueue<T, size>::CirQueue(){
	front = 0;
	rear = 0;
}

template<class T, int size>
CirQueue<T, size>::~CirQueue(){
	cout << "Destroy queue" << endl;
}

template<class T, int size>
void CirQueue<T, size>::Enqueue(T value){
	if((rear + 1) % size == front){		// 判断队列是否已满
		cout << "Queue is full" << endl;
		return;
	}
	rear = (rear + 1) % size;	// 队尾指针指向下一个单元
	elements[rear] = value;
}

template<class T, int size>
T CirQueue<T, size>::Dequeue(){
	if(isEmpty()){
		cout << "Queue is empty" << endl;
		exit(EXIT_FAILURE);
	}
	front = (front + 1) % size;	// 队首指针指向下一个单元，即出队（被删除）元素
	return elements[front];
}

template<class T, int size>
T CirQueue<T, size>::GetQueue(){
	if(isEmpty()){
		cout << "Queue is empty" << endl;
		return;
	}
	return elements[(front + 1) % size];
}

template<class T, int size>
bool CirQueue<T, size>::isEmpty(){
	return front == rear;
}

#endif
