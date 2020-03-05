// SeqList.cpp
// Author: Paddy Huang
// Date: 2020.03.04 21:23

#include <iostream>
using namespace std;

#define MAXSIZE 3
#define ERROR -1
#define DataType int
#define ElemType Node

class Node{
	public:
		DataType data;
};

class SeqList{
	public:
		SeqList();  // 初始化构造函数
        ~SeqList(); // 析构函数
        void CreateSeqList(int n);      // 创建一个顺序表
        void TraverseSeqList();         // 遍历顺序表
        bool isEmpty();                 // 判断顺序表是否为空
        bool isFull();                  // 判断顺序表是否满
        int GetLength();                // 获取顺序表长度
        int GetElemByElem(DataType data);   // 以值查值
        ElemType GetElemByIndex(int i);     // 以索引查值
        void InsertSeqList(int n, DataType data);   // 向顺序表中插入元素
        void InsertSeqListAtHead(DataType data);    // 向顺序表头部插入元素
        void InsertSeqListAtRear(DataType data);    // 向顺序表尾部插入元素
        void DeleteElem(int i);                 // 以索引删除值
        void DeleteElemByELem(DataType data);   // 以值删值
        void DeleteAll();                   // 删除所有元素
        void DeleteAtHead();                // 删除头部元素
	private:
		ElemType *element;
		int length;
};

SeqList::SeqList(){
	element = new ElemType[MAXSIZE];
	if(!element) exit(ERROR);
	length = 0;
}

SeqList::~SeqList(){
	delete element;
}

void SeqList::CreateSeqList(int n){
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

void SeqList::TraverseSeqList(){
	for(int i = 0; i < length; i++) cout << "第" << i + 1 << "个元素: " << element[i].data << endl;
}

bool SeqList::isEmpty(){
	if(length == 0) return true;
	return false;
}

bool SeqList::isFull(){
	if(length == MAXSIZE) return true;
	return false;
}

int SeqList::GetLength(){
	return length;
}

int SeqList::GetElemByElem(DataType data){
	int index = 0;
	while(index < length && element[index].data != data) index++;
	if(index >= 0 && index < length) return index + 1;
	return ERROR;
}

ElemType SeqList::GetElemByIndex(int index){
	if(index < 1 || index > length) cout << "查找的下标不存在！" << endl;
	return element[index - 1];
}

void SeqList::InsertSeqList(int n, DataType data){
	if(n < 1 || n > length + 1) cout << "输入的下标不合法" << endl;
	else if(length >= MAXSIZE) cout << "该表已满" << endl;
	else{
		for(int i = length; i >= n - 1; i--) element[i] = element[i - 1];
		element[n - 1].data = data;
		length++;
	}
}

void SeqList::InsertSeqListAtHead(DataType data){
	if(length >=  MAXSIZE) cout << "该表已满" << endl;
	else{
		for(int i = length; i >= 0; i--) element[i] = element[i - 1];
		element[0].data = data;
		length++;
	}
}    // 向顺序表头部插入元素

void SeqList::InsertSeqListAtRear(DataType data){
	if(length >=  MAXSIZE) cout << "该表已满" << endl;
	else{
		element[length].data = data;
		length++;
	}
}    // 向顺序表尾部插入元素

void SeqList::DeleteElem(int index){
	if(index < 1 || index > length) cout << "输入的下标不合法" << endl;
	else{
		for(int i = index; i < length; i++) element[i - 1] = element[i];
		length--;
	}
}                 // 以索引删除值

void SeqList::DeleteElemByELem(DataType data){
	int index = 0;
	while(index < length && element[index].data != data) index++;
	for(int i = index; i < length; i++) element[i- 1] = element[i];
	length--;
}   // 以值删值

void SeqList::DeleteAll(){
	for(int i = 0; i < length; i++) element[i].data = 0;
	length = 0;
}                   // 删除所有元素

void SeqList::DeleteAtHead(){
	for(int i = 1; i < length; i++) element[i - 1] = element[i];
	length--;
}                // 删除头部元素

// 测试函数
int main(void){
	SeqList l;	// 声明一个顺序表
	int i;
	cout << "1.创建一个顺序表	2.遍历顺序表		3.通过下标获取元素\n4.查找要查询的元素的下标5.通过下标插入元素	6.通过下标删除一个元素\n7.获取顺序表的长度	8.删除所有元素		9.判断顺序表是否为空\n10.判断顺序表是否满	11.根据数据删除节点	12.在头部插入数据\n13.在头部删除数据	14.在顺序表最后插入数据	0.退出" << endl;
	do
	{
		cout << "请选择一个操作: " ;
		cin >> i;
		switch (i)
		{
		case 1:
			int n;
			cout << "请输入顺序表的元素个数: ";
			cin >> n;
			l.CreateSeqList(n);
			break;
		case 2:
			l.TraverseSeqList();
			break;
		case 3: {
			int index1;
			cout << "请输入将要获取元素的下标: ";
			cin >> index1;
			ElemType getElemByIndex = l.GetElemByIndex(index1);
			cout << getElemByIndex.data << endl;
			break;
			}
		case 4:
			DataType data;
			cout << "请输入将要查找元素的值: ";
			cin >> data;
			cout<<"该元素的下标为:"<<l.GetElemByElem(data)<<endl;
			break;
		case 5:
			int index2;
			DataType insertData;
			cout << "请输入要插入的数据的位置: ";
			cin >> index2;
			cout << "请输入要插入的数据: ";
			cin >> insertData;
			l.InsertSeqList(index2, insertData);
			break;
		case 6:
			int deleteIndex;
			cout << "请输入要删除的数据的下标: ";
			cin >> deleteIndex;
			l.DeleteElem(deleteIndex);
			break;
		case 7:
			cout<<l.GetLength()<<endl;
			break;
		case 8:
			l.DeleteAll();
			break;
		case 9:
			if (l.isEmpty() == 1) 
				cout << "顺序表为空" << endl;
			else
				cout << "顺序表不为空" << endl;
			break;
		case 10:
			if (l.isFull() == 1)
				cout << "顺序表满" << endl;
			else
				cout << "顺序表不满" << endl;
			break;
		case 11:
			DataType data1;
			cout << "请输入要删除的数据: ";
			cin >> data1;
			l.DeleteElemByELem(data1);
			break;
		case 12:
			DataType data2;
			cout << "请输入要在头部插入的数据: ";
			cin >> data2;
			l.InsertSeqListAtHead(data2);
			break;
		case 13:
			l.DeleteAtHead();
			break;
		case 14:
			DataType data3;
			cout << "请输入要在末尾插入的数据: ";
			cin >> data3;
			l.InsertSeqListAtRear(data3);
			break;
		default:
			break;
		}
	} while(i != 0);

    return 0;
}

