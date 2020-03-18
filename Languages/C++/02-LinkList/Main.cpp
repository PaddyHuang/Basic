// Main.cpp
// Author: Paddy Huang
// Date: 2020.03.09 20:29

#include "LinkList.hpp"
using namespace std;

// 测试函数
int main(void){
	LinkList<char> l;	// 声明一个单链表
    l.CreateLinkList(5);
    l.TraverseLinkList();
    cout << "list is empty? " << l.isEmpty() << endl;
    cout << "list is full? " << l.isFull() << endl;
    cout << "Length: " << l.GetLength() << endl;

    // cout << l.GetElemByElem(5)->data << endl;
    cout << l.GetElemByIndex(4)->data << endl;

    l.DeleteAtHead();
    l.TraverseLinkList();
	
    l.DeleteAll();
    l.TraverseLinkList();

    // 测试1万次插入删除
    // for (int i = 1; i < 10000; i++)
	// 	l.InsertLinkListAtRear(i);
	// for(int i = 1; i < 10000; i++){
	// 	l.InsertLinkList(50, 99);
	// 	l.DeleteElem(50);
	// }
    // cout << "Done" << endl;
	


	// int i;
	// cout << "1.创建一个单链表	2.遍历单链表		3.通过下标获取元素\n4.查找要查询的元素的下标5.通过下标插入元素	6.通过下标删除一个元素\n7.获取单链表的长度	8.删除所有元素		9.判断单链表是否为空\n10.判断单链表是否满	11.根据数据删除节点	12.在头部插入数据\n13.在头部删除数据	14.在单链表最后插入数据	0.退出" << endl;
	// do
	// {
	// 	cout << "请选择一个操作: " ;
	// 	cin >> i;
	// 	switch (i)
	// 	{
	// 	case 1:
	// 		int n;
	// 		cout << "请输入单链表的元素个数: ";
	// 		cin >> n;
	// 		l.CreateLinkList(n);
	// 		break;
	// 	case 2:
	// 		l.TraverseLinkList();
	// 		break;
	// 	case 3: {
	// 		int index1;
	// 		cout << "请输入将要获取元素的下标: ";
	// 		cin >> index1;
	// 		Node getElemByIndex = l.GetElemByIndex(index1);
	// 		cout << getElemByIndex.data << endl;
	// 		break;
	// 		}
	// 	case 4:
	// 		DataType data;
	// 		cout << "请输入将要查找元素的值: ";
	// 		cin >> data;
	// 		cout<<"该元素的下标为:"<<l.GetElemByElem(data)<<endl;
	// 		break;
	// 	case 5:
	// 		int index2;
	// 		DataType insertData;
	// 		cout << "请输入要插入的数据的位置: ";
	// 		cin >> index2;
	// 		cout << "请输入要插入的数据: ";
	// 		cin >> insertData;
	// 		l.InsertLinkList(index2, insertData);
	// 		break;
	// 	case 6:
	// 		int deleteIndex;
	// 		cout << "请输入要删除的数据的下标: ";
	// 		cin >> deleteIndex;
	// 		l.DeleteElem(deleteIndex);
	// 		break;
	// 	case 7:
	// 		cout<<l.GetLength()<<endl;
	// 		break;
	// 	case 8:
	// 		l.DeleteAll();
	// 		break;
	// 	case 9:
	// 		if (l.isEmpty() == 1) 
	// 			cout << "单链表为空" << endl;
	// 		else
	// 			cout << "单链表不为空" << endl;
	// 		break;
	// 	case 10:
	// 		if (l.isFull() == 1)
	// 			cout << "单链表满" << endl;
	// 		else
	// 			cout << "单链表不满" << endl;
	// 		break;
	// 	case 11:
	// 		DataType data1;
	// 		cout << "请输入要删除的数据: ";
	// 		cin >> data1;
	// 		l.DeleteElemByELem(data1);
	// 		break;
	// 	case 12:
	// 		DataType data2;
	// 		cout << "请输入要在头部插入的数据: ";
	// 		cin >> data2;
	// 		l.InsertLinkListAtHead(data2);
	// 		break;
	// 	case 13:
	// 		l.DeleteAtHead();
	// 		break;
	// 	case 14:
	// 		DataType data3;
	// 		cout << "请输入要在末尾插入的数据: ";
	// 		cin >> data3;
	// 		l.InsertLinkListAtRear(data3);
	// 		break;
	// 	default:
	// 		break;
	// 	}
	// } while(i != 0);

    return 0;
}
