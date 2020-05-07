// Main.cpp
// Author: Paddy Huang
// Date: 2020.03.04 21:23

#include "SeqList.hpp"
using namespace std;

// Test Methods
int main(void){
	SeqList<char> list;	// Declare a sequense list
  // Test 10k insert & delete
//	for (auto i = 0; i < 10000 - 1; i++)
//		list.InsertSeqListAtRear('a');
//	for(auto i = 0; i < 10000; i++){
//		list.InsertSeqList(50, 's');
//		list.DeleteElem(50);
//	}

  int i;
	cout << "1. Create a list \t\t 2. Traverse list \t\t 3. Check element by index \n"
      << "4. Check index by element \t 5. Insert element by index \t 6. Delete element by index \n"
      << "7. Get list length \t\t 8. Delete all element \t\t 9. List is empty? \n"
      << "10. List is full? \t\t 11. Delete element by value \t 12. Insert element at head \n"
      << "13. Delete element at head \t 14. Insert element at rear \t 0. Exit" << endl;
	// do
	// {
	// 	cout << "请选择一个操作: " ;
	// 	cin >> i;
	// 	switch (i)
	// 	{
	// 	case 1:
	// 		int n;
	// 		cout << "请输入顺序表的元素个数: ";
	// 		cin >> n;
	// 		l.CreateSeqList(n);
	// 		break;
	// 	case 2:
	// 		l.TraverseSeqList();
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
	// 		l.InsertSeqList(index2, insertData);
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
	// 			cout << "顺序表为空" << endl;
	// 		else
	// 			cout << "顺序表不为空" << endl;
	// 		break;
	// 	case 10:
	// 		if (l.isFull() == 1)
	// 			cout << "顺序表满" << endl;
	// 		else
	// 			cout << "顺序表不满" << endl;
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
	// 		l.InsertSeqListAtHead(data2);
	// 		break;
	// 	case 13:
	// 		l.DeleteAtHead();
	// 		break;
	// 	case 14:
	// 		DataType data3;
	// 		cout << "请输入要在末尾插入的数据: ";
	// 		cin >> data3;
	// 		l.InsertSeqListAtRear(data3);
	// 		break;
	// 	default:
	// 		break;
	// 	}
	// } while(i != 0);

    return 0;
}
