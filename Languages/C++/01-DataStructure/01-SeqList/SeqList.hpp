// SeqList.hpp
// Author: Paddy Huang
// Date: 2020.03.04 21:23

#ifndef SEQ_LIST_HXX
#define SEQ_LIST_HXX

#include <iostream>
using namespace std;

#define MAXSIZE 10000
#define ERROR -1
// #define DataType int

template<class T>
class Node{
	public:
		T data;
};

template<class T>
class SeqList{
	public:
		SeqList();  // 初始化构造函数
        ~SeqList(); // 析构函数
        void CreateSeqList(int n);      // 创建一个顺序表
        void TraverseSeqList();         // 遍历顺序表
        bool isEmpty();                 // 判断顺序表是否为空
        bool isFull();                  // 判断顺序表是否满
        int GetLength();                // 获取顺序表长度
        int GetElemByElem(T data);   // 以值查值
        Node<T> GetElemByIndex(int i);     // 以索引查值
        void InsertSeqList(int n, T data);   // 向顺序表中插入元素
        void InsertSeqListAtHead(T data);    // 向顺序表头部插入元素
        void InsertSeqListAtRear(T data);    // 向顺序表尾部插入元素
        void DeleteElem(int i);                 // 以索引删除值
        void DeleteElemByELem(T data);   // 以值删值
        void DeleteAll();                   // 删除所有元素
        void DeleteAtHead();                // 删除头部元素
	private:
		Node<T> *element;
		int length;
};

template<class T>
SeqList<T>::SeqList(){
	element = new Node<T>[MAXSIZE];
	if(!element) exit(ERROR);
	length = 0;
}

template<class T>
SeqList<T>::~SeqList(){
	delete element;
	element = NULL;
	length = 0;
}

template<class T>
void SeqList<T>::CreateSeqList(int n){
	if(n < 0){
		cout << "输入的结点数有误！" << endl;
		exit(ERROR);
	}
	for(int i = 0; i < n; i++){
		cout << "输入第" << i + 1 << "个元素: ";
		cin >> element[i].data;
	}
	length = n;
}

template<class T>
void SeqList<T>::TraverseSeqList(){
	for(int i = 0; i < length; i++) 
		cout << "第" << i + 1 << "个元素: " << element[i].data << endl;
}

template<class T>
bool SeqList<T>::isEmpty(){return length <= 0;}

template<class T>
bool SeqList<T>::isFull(){return length >= MAXSIZE;}

template<class T>
int SeqList<T>::GetLength(){return length;}

template<class T>
int SeqList<T>::GetElemByElem(T data){
	int index = 0;
	while(index < length && element[index].data != data) index++;
	if(index >= 0 && index < length) return index + 1;
	return ERROR;
}

template<class T>
Node<T> SeqList<T>::GetElemByIndex(int index){
	if(index < 1 || index > length) cout << "查找的下标不存在！" << endl;
	return element[index - 1];
}

template<class T>
void SeqList<T>::InsertSeqList(int n, T data){
	if(n < 1 || n > length + 1) cout << "输入的下标不合法" << endl;
	else if(length >= MAXSIZE) cout << "该表已满" << endl;
	else{
		for(int i = length; i >= n - 1; i--) element[i] = element[i - 1];
		element[n - 1].data = data;
		length++;
	}
}

template<class T>
void SeqList<T>::InsertSeqListAtHead(T data){
	if(length >=  MAXSIZE) cout << "该表已满" << endl;
	else{
		for(int i = length; i >= 0; i--) element[i] = element[i - 1];
		element[0].data = data;
		length++;
	}
}    // 向顺序表头部插入元素

template<class T>
void SeqList<T>::InsertSeqListAtRear(T data){
	if(length >=  MAXSIZE) cout << "该表已满" << endl;
	else{
		element[length].data = data;
		length++;
	}
}    // 向顺序表尾部插入元素

template<class T>
void SeqList<T>::DeleteElem(int index){
	if(index < 1 || index > length) cout << "输入的下标不合法" << endl;
	else{
		for(int i = index; i < length; i++) element[i - 1] = element[i];
		length--;
	}
}                 // 以索引删除值

template<class T>
void SeqList<T>::DeleteElemByELem(T data){
	int index = 0;
	while(index < length && element[index].data != data) index++;
	for(int i = index; i < length; i++) element[i- 1] = element[i];
	length--;
}   // 以值删值

template<class T>
void SeqList<T>::DeleteAll(){
	for(int i = 0; i < length; i++) element[i].data = 0;
	length = 0;
}                   // 删除所有元素

template<class T>
void SeqList<T>::DeleteAtHead(){
	for(int i = 1; i < length; i++) element[i - 1] = element[i];
	length--;
}                // 删除头部元素

#endif