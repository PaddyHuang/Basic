// SeqList.cpp
// Author: Paddy Huang
// Date: 2020.03.04 21:23

#include <iostream>
using namespace std;

#define MAXSIZE 3
#define Node ElemType
#define Error -1
typedef int DataType;

// 创建一个结点类
class Node{
	public:
		DataType data;
};

// 创建一个顺序表类
class SeqList{
	public:
		SeqList();	// 初始化构造函数
		~SeqList(); // 析构函数
		void CreateSeqList(int n);		// 创建一个顺序表
		void TraverseSeqList();			// 遍历顺序表
		bool isEmpty();					// 判断顺序表是否为空
		bool isFull();					// 判断顺序表是否满
		int GetLength();				// 获取顺序表长度
		int GetElemByElem(DataType data);	// 以值查值
		ElemType GetElemByIndex(int i);		// 以索引查值
		void InsertSeqList(int n, DataType data);	// 向顺序表中插入元素
		void InsertSeqListAtHead(DataType data);	// 向顺序表头部插入元素
		void InsertSeqListAtRear(DataType data);	// 向顺序表尾部插入元素
		void DeleteElem(int i);					// 以索引删除值
		void DeleteElemByELem(DataType data);	// 以值删值
		void DeleteAll();					// 删除所有元素
		void DeleteAtHead();				// 删除头部元素
	private:
		Node *elem;	// 顺序表的基地值
		int length;	// 顺序表长度
};

// 初始化顺序表
SeqList::SeqList(){
	elem = new ElemType[MAXSIZE];	// 开辟空间
	if(!elem) exit(Error);		// 当溢出时报警
	length = 0;
}

// 销毁顺序表
SeqList::~SeqList(){
	delete elem;		// 删除基地值指针
}

// 创建一个顺序表
void SeqList::CreateSeqList(int n){
	if(n < 0){
		cout << "输入的结点数有误！" << endl;
		exit(EXIT_FAILURE);
	}
	for(int i = 0; i < n; i++){		// 循环插入元素
		cout << "请输入第" << i + 1 << "个结点元素：" ;
		cin >> elem[i].data;
	}
	length = n;		// 更改顺序表长度
}

// 遍历顺序表
void SeqList::TraverseSeqList(){
	for(int i = 0; i < length; i++)		// 循环打印出顺序表元素
		cout << "第" << i + 1 << "个元素是：" << elem[i].data << endl;
}

// 以索引查值
ElemType SeqList::GetElemByIndex(int i){
	if(i < 1 || i > length)
		cout << "查找的下标不存在" << endl;
	return elem[i - 1];		// 返回指定下标元素
}

// 判断顺序表是否为空
bool SeqList::isEmpty(){
	if(length == 0)	return true;
	return false;
}

bool SeqList::isFull(){
	if(length == MAXSIZE) return true;
	return false;
}

// 获取顺序表长度
int SeqList::GetLength(){
	return length;
}

// 以值查值
int SeqList::GetElemByElem(DataType data){
	for(int i = 0; i < length; i++)			// 从头到尾遍历
		if(elem && elem[i].data == data)			// 若找到匹配项，返回结点下标
			return i + 1;
	return Error;
}

// 插入一个数据
void SeqList::InsertSeqList(int i, DataType data){
	if(i < 1 || i > length + 1)	cout << "输入的下标不合法！" << endl;
	else if(length > MAXSIZE) cout << "顺序表已达最大长度！" << endl;	// 顺序表满时，无法插入新元素
	else {
		for(int j = length - 1; j >= i - 1; j--) elem[j + 1] = elem[j];	// 循环后移元素
		elem[i - 1].data = data;		// 插入元素
		length++;				// 表长+1
	}
}

// 在头部插入元素
void SeqList::InsertSeqListAtHead(DataType data){
	for(int i = length - 1; i >= 0; i--) elem[i + 1] = elem[i];	// 循环后移全部元素
	elem[0].data = data;	// 在头部插入元素
	length++;		// 长度+1
}

// 在尾部插入元素
void SeqList::InsertSeqListAtRear(DataType data){
	if(length > MAXSIZE) cout << "顺序表已满" << endl;	// 当顺序表满时，不能插入新元素
	else{
		elem[length].data = data;	// 在表尾插入新元素
		length++;
	}
}

// 以索引删除值
void SeqList::DeleteElem(int i){
	if(i < 1 || i > length) cout << "输入的下标不合法！" << endl;
	else{
		for(int j = i; j <= length - 1; j++) elem[j - 1] = elem[j];	// 循环前移元素
		length--;	// 表长-1
	}
}

// 以值删值
void SeqList::DeleteElemByELem(DataType data){
	int index = 0;
	while(index < length && elem[index].data != data) index++;	// 找出待删元素的下标
	for(int i = index; index <= length - 1; i++) elem[i] = elem[i + 1];	// 循环前移覆盖删除元素
	length--;	// 表长-1
}

// 删除所有元素
void SeqList::DeleteAll(){
	for(int i = 0; i < length; i++) elem[i].data = 0;
	length = 0;
}

// 删除头部元素
void SeqList::DeleteAtHead(){
	for(int i = 1; i <= length - 1; i++) elem[i - 1] = elem[i];	// 循环前移覆盖删除元素
	length--;	// 表长-1
}

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


