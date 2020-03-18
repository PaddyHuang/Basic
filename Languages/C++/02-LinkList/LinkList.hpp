// Linkist.hpp
// Author: Paddy Huang
// Date: 2020.03.09 20:29

// 单链表
// 对表内从0开始，对表外从1开始
#ifndef LINK_LIST_HXX
#define LINK_LIST_HXX

#include <iostream>
#include <stdlib.h>
using namespace std;

#define MAXSIZE 10000
#define ERROR -1

template<class T>
class Node{
	public:
		T data;
        Node<T> *next;
};

template<class T>
class LinkList{
	public:
		LinkList();  // 初始化构造函数
        ~LinkList(); // 析构函数
        void CreateLinkList(int n);      // 创建一个单链表
        void TraverseLinkList();         // 遍历单链表
        bool isEmpty();                 // 判断单链表是否为空
        bool isFull();                  // 判断单链表是否满
        int GetLength();                // 获取单链表长度
        Node<T>* GetElemByElem(T data);   // 以值查值
        Node<T>* GetElemByIndex(int index);     // 以索引查值
        void InsertLinkList(int index, T data);   // 向单链表中插入元素
        void InsertLinkListAtHead(T data);    // 向单链表头部插入元素
        void InsertLinkListAtRear(T data);    // 向单链表尾部插入元素
        void DeleteElem(int index);                 // 以索引删除值
        void DeleteElemByElem(T data);   // 以值删值
        void DeleteAll();                   // 删除所有元素
        void DeleteAtHead();                // 删除头部元素
	private:
		Node<T> *head;
		int length;
};

template<class T>
LinkList<T>::LinkList(){
	head = new Node<T>();
    head->next = NULL;
	length = 0;
}

template<class T>
LinkList<T>::~LinkList(){
	head->next = NULL;
    delete head;
}

template<class T>
void LinkList<T>::CreateLinkList(int n){
	if(n < 0 || n > MAXSIZE){
		cout << "输入的结点数有误！" << endl;
		exit(ERROR);
	}
	for(int i = 0; i < n; i++){
		cout << "输入第" << i + 1 << "个元素: ";
		Node<T> *node = (Node<T>*)malloc(sizeof(Node<T>));
        cin >> node->data;
        node->next = head->next;
        head->next = node;
	}
	length = n;
}

template<class T>
void LinkList<T>::TraverseLinkList(){
	if(length == 0) {cout << "Empty list." << endl; return;}
    Node<T> *p = head->next;
    for(int i = 0; p != NULL; p = p->next, i++)
        cout << "第" << i + 1 << "个元素: " << p->data << endl;
}

template<class T>
bool LinkList<T>::isEmpty(){return length <= 0;}

template<class T>
bool LinkList<T>::isFull(){return length >= MAXSIZE;}

template<class T>
int LinkList<T>::GetLength(){return length;}

template<class T>
Node<T>* LinkList<T>::GetElemByElem(T data){
	for(Node<T> *p = head->next; p != NULL; p = p->next)
        if(p->data == data)
            return p;
    return NULL;
}

template<class T>
Node<T>* LinkList<T>::GetElemByIndex(int index){
	if(index < 1 || index > length) {cout << "查找的下标不存在！" << endl; return NULL;}
	Node<T> *p = head;
    for(int i = 1; i <= index; p = p->next, i++);
    
    if(p) return p;
    return NULL;
}

template<class T>
void LinkList<T>::InsertLinkList(int index, T data){
	if(index < 1 || index > length) {cout << "输入的下标不合法" << endl; return;}
	if(length >= MAXSIZE) {cout << "该表已满" << endl; return;}

	Node<T> *pre = GetElemByIndex(index);
    Node<T> *node = (Node<T>*)malloc(sizeof(Node<T>));
    node->data = data;
    node->next = pre->next;
    pre->next = node;

	length++;
}

template<class T>
void LinkList<T>::InsertLinkListAtHead(T data){     // 向单链表头部插入元素
	if(length >=  MAXSIZE) {cout << "该表已满" << endl; return;}
	
    Node<T> *node = (Node<T>*)malloc(sizeof(Node<T>));
    node->data = data;
    node->next = head->next;
    head->next = node;

	length++;
}

template<class T>
void LinkList<T>::InsertLinkListAtRear(T data){     // 向单链表尾部插入元素
	if(length >=  MAXSIZE) {cout << "该表已满" << endl; return;}

	Node<T> *pre = length == 0 ? head : GetElemByIndex(length);
    Node<T> *node = (Node<T>*)malloc(sizeof(Node<T>));
    node->data = data;
    node->next = pre->next;
    pre->next = node;

	length++;
}    

template<class T>
void LinkList<T>::DeleteElem(int index){       // 以索引删除值
	if(index < 1 || index > length) {cout << "输入的下标不合法" << endl; return;}

	Node<T> *pre = GetElemByIndex(index - 1);
    Node<T> *p = pre->next;    // Current node to be deleted
    pre->next = p->next;

	length--;
}

template<class T>
void LinkList<T>::DeleteElemByElem(T data){     // 以值删值
	int index = 1;
    Node<T> *p = head->next;
	while(p && p->data != data) {p = p->next; index++;}
	if(p == NULL) {return;}
    Node<T> *pre = GetElemByIndex(index - 1);          // 获取前驱结点
    pre->next = p->next;
    
	length--;
}   

template<class T>
void LinkList<T>::DeleteAll(){     // 删除所有元素
	head->next = NULL;
	length = 0;
}              

template<class T>
void LinkList<T>::DeleteAtHead(){  // 删除头部元素
    head->next = head->next->next;
	length--;
}

#endif