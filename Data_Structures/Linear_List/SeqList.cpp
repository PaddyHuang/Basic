#include <iostream>

#define InitSize 100		// define initSize of List
#define ElemType int

typedef struct{
	int *data;				// dynamically malloc list
	int MaxSize, length;
}SeqList;					// the type of list

// 1. Init list
void InitList(SeqList &list){
	list.data = new ElemType[InitSize];
	list.length = 0;
	list.MaxSize = InitSize;
}

// 2. Get length
int GetLength(SeqList list){
	return list.length;
}

// 3. Locate Element By Value
int LocateElem(SeqList list, ElemType value){
	for(int i = 0; i < list.length; i++)
		if(list.data[i] == value)
			return i;
	return -1;
}

// 4. Get Element By Index
int GetElem(SeqList list, int i){
	if(i < 0 || i > list.length)
		return -1;
	return list.data[i];
}

// 5. List Insert Element
bool ListInsert(SeqList &list, int i, ElemType value){
	if(i < 0 || i > list.length)
		return false;
	if(list.length > list.MaxSize)
		return false;
	
	for(int j = list.length; j > i; j--)
		list.data[j] = list.data[j - 1];
	list.data[i] = value;
	list.length++;
	return true;
}

// 6. Delete Element
bool DeleteELem(SeqList &list, int i, ElemType &value){
	if(i < 0 || i > list.length - 1)
		return false;
	if(list.length <= 0)
		return false;

	value = list.data[i];
	
	if(i == list.length -1){
		list.length--;
		return true;
	}
	else{
		for(int j = i; j < list.length; j++)
			list.data[j - 1] = list.data[j];
		list.length--;
		return true;
	}
}

// 7. Print List
void PrintList(SeqList list){
	if(list.length <= 0) std::cout << "Empty List." << std::endl;
	for(int i = 0; i < list.length; i++){
		std::cout << "------" << std::endl;
		std::cout << "|No." << i << "|" << list.data[i] << "|" << std::endl;
	}
	std::cout << "------" << std::endl;
}

// 8. Empty
bool Empty(SeqList list){
	if(list.length <= 0)
		return true;
	return false;
}

// 9. Destroy list
void Destroy(SeqList &list){
	free(list.data);
	list.data = NULL;
	list.length = 0;
}

/* Exercises */
/* 1. 从顺序表中删除具有最小值的元素（假设唯一），并由函数返回被删除元素的值。空出的位置由最后一个元素填补，若顺序表为空，则显示出错误信息并退出运行。*/
bool DeleteMin(SeqList &list, ElemType &x){
    if(list.length <= 0) return false;
    ElemType min = list.data[0];            // 设第0个元素为最小值
    int minIndex = 0;                       // 最小值的索引
    for(int i = 1; i < list.length; i++)    // 从第1个元素开始比较
        if(min > list.data[i]){
            min = list.data[i];             // 循环结束后，min中存着最小值
            minIndex = i;                   // i指向最小值元素
        }
    x = min;                                // 返回被删除的元素值
    list.data[minIndex] = list.data[list.length - 1];   // 将空出的位置用最后一个元素填补
    list.length--;                          // 表长减一
    return true;                            // 程序完成
}
/* 2. 设计一个高效算法，将顺序表中元素逆值，要求算法空间复杂度为O(1) */
bool ReverseList(SeqList &list){
    if(list.length <= 0) return false;
    for(int i = 0; i < list.length / 2; i++){
        ElemType temp = list.data[i];
        list.data[i] = list.data[list.length-i-1];
        list.data[list.length-i-1] = temp;
    }
    return true;
}
/* 3. 长度为$n$的顺序表，编写一个时间复杂度为$O(n)$，空间复杂度为$O(1)$的算法。该算法删除顺序表中所有值为$x$的数据元素。 */
bool DeleteAllSettingValue(SeqList &list, ElemType x){
    if(list.length <= 0) return false;
    int counter = 0;            // 计数器，记录不为x的元素个数
    for(int i = 0; i < list.length; i++)
        if(list.data[i] != x){
            list.data[counter] = list.data[i];
            counter++;
        }
    list.length = counter;
    return true;
}
/* 4. 从有序顺序表中删除其值在给定值$s$与$t$之间（要求$s<t$）的所有元素。如果$s$或$t$不合理或顺序表为空则报错并退出运行。 */
bool DeleteRange(SeqList &list, ElemType s, ElemType t){
    if(list.length <= 0 || s >= t) return false;
    int counter = 0;                      // 记录非给定范围内元素的个数
    for(int i = 0; i < list.length; i++)
        if(list.data[i] < s || list.data[i] > t)
            list.data[counter++] = list.data[i];
    list.length = counter;
    return true;
}
/* 6. 从有序顺序表中删除所有值重复的元素，使表中所有元素值均不同。 */
bool RemoveDuplicates(SeqList &list){
	if(list.length <= 0) return false;
	int i = 0;
	for(int j = 1; j < list.length; j++)
		if(list.data[i] != list.data[j])
			list.data[++i] = list.data[j];
	list.length = i + 1;
	return true;
}

// Main Function
int main(){
	// 1. Init list
	SeqList list;
	InitList(list);
	
	std::cout << "Initializing list, please enter value. (Type 999 to end this process.)" << std::endl;
	ElemType value = 0;		// Insert Value
	for(int i = 0; i < list.MaxSize; i++){
		if(value == 999) break;
		else{
			std::cin >> value;
			ListInsert(list, i, value);
			std::cout << "list[" << i << "]: " << value << std::endl;
		}
	}
	std::cout << std::endl << "Your initialized list:" << std::endl;
	PrintList(list);
	
	int option = 0;
	std::cout << "Welcome! This is a Sequence List. You can control the list with the following options:\n";
	do{
		std::cout << "1. Insert element\n" << "2. Locate element by index\n" << "3. Locate element by value\n" << "4. Delete element by index\n" << "5. Print list\n" << "6. Delete the min value.\n" << "7. Reverse List.\n" << "8. Delete All Setting Value.\n" << "9. Delete Range.\n" << "10. Remove Duplicates.\n" << "999. Destroy list and quit.\n" << "Choose an option: ";
		std::cin >> option;
		switch(option){
			case 1:{					// 1. Insert Element
				int insertIndex;
				std::cout << "Which position: ";
				std::cin >> insertIndex;
				
				ElemType insertValue;
				std::cout << "Value: ";
				std::cin >> insertValue;

				if(ListInsert(list, insertIndex, insertValue))
					std::cout << "Insert Done." << std::endl;
				else
					std::cout << "Error." << std::endl;
				break;
			}
			case 2:{					// 2. Locate Element By Index	
				int locateIndex;
				std::cout << "Which position:";
				std::cin >> locateIndex;
				std::cout << "No. " << locateIndex << ": " << GetElem(list, locateIndex) << std::endl;
				break;
			}
			case 3:{					// 3. Locate Element By Value
				ElemType locateElem;
				std::cout << "Value: ";
				std::cin >> locateElem;
				int locateIndex1 = LocateElem(list, locateElem);
				if(locateIndex1 > 0)
					std::cout << "No." << locateIndex1 << ": " << list.data[locateIndex1] << std::endl;
				else
					std::cout << "No this value." << std::endl;
				break;
			}
			case 4:{					// 4. Delete Element By Index
				int deleteIndex;
				std::cout << "Wich position: ";
				std::cin >> deleteIndex;

				ElemType deleteValue;
				if(DeleteELem(list, deleteIndex, deleteValue))
					std::cout << "No." << deleteIndex << ": " << deleteValue << ", delete done." << std::endl;
				else
					std::cout << "Error." << std::endl;
				break;
			}
			case 5:{					// 5. Print List
				PrintList(list);
				break;
			}
			case 6:{					// 6. Exercise 1. DeleteMin
				ElemType minValue;
				if(DeleteMin(list, minValue)){
					std::cout << "Delete min: " << minValue << ", Done." << std::endl;
					PrintList(list);
				}
				else
					std::cout << "Error." << std::endl;
				break;
			}
			case 7:{					// Exercise 7. Reverse List
				if(ReverseList(list))
					std::cout << "Reverse Done." << std::endl;
				else
					std::cout << "Error." << std::endl;
				PrintList(list);
				break;
			}
			case 8:{					// 8. Delete All Setting Value
				ElemType settingDeleteValue;
				std::cout << "Delete Value: ";
				std::cin >> settingDeleteValue;
				if(DeleteAllSettingValue(list, settingDeleteValue))
					std::cout << "Delete setting value, Done." << std::endl;
				else
					std::cout << "Error." << std::endl;
				break;
			}
			case 9:{
				ElemType s, t;
				std::cout << "Enter s: ";
				std::cin >> s;
				std::cout << "Enter t: ";
				std::cin >> t;

				if(DeleteRange(list, s, t))
					std::cout << "Delete Range: " << s << " ~ " << t << ": " << ", Done." << std::endl;
				else
					std::cout << "Error." << std::endl;	
				break;
			}
			case 10:{
				RemoveDuplicates(list);
				std::cout << "Remove Duplicates, Done." << std::endl;
				PrintList(list);
			}
			case 999:{					// 999. Destroy List and Quit
				Destroy(list);
				std::cout << "Destroy Done." << std::endl;
				break;
			}
			default:
				break;
		}
	}while(option != 999);

	return 0;
}


