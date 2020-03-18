// Main.cpp
// Author: Paddy Huang
// Date: 2020.03.11 17:37

#include "CirQueue.hpp"

int main(void){
//    TestSeqQueue();
//    TestListQueue();
	CirQueue<int> queue;
	queue.Enqueue(5);
	queue.Enqueue(7);
	queue.Enqueue(9);

	cout << queue.Dequeue() << endl;
	cout << queue.Dequeue() << endl;
	cout << queue.Dequeue() << endl;
	cout << queue.Dequeue() << endl;


    return 0;
}
