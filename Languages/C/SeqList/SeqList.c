//
//  SeqList.c
//  DataStructure
//
//  Created by Paddy Huang on 2020/2/1.
//  Copyright © 2020 Paddy Huang. All rights reserved.
//

#include "SeqList.h"

// 1. Init list
void InitSeqList(SeqList *list){
    list = (SeqList*)malloc(sizeof(SeqList));
    list->data = (ElemType*)malloc(sizeof(ElemType) * InitSize);
    list->length = 0;
    list->MaxSize = InitSize;
    
    for(int i = 0; i < 10; i++) InsertElem(list, i, 123);
    
}

// 2. Get length
int GetLength(SeqList list){return list.length;}

// 3. Empty
bool Empty(SeqList list){return list.length == 0 ? true : false;}

// 4. Locate Element By Value and return index
int LocateElem(SeqList list, ElemType value){
    if(list.length <= 0) return -1;
    for(int i = 0; i < list.length; i++)
        if(list.data[i] == value)
            return i;
    return -1;
}

// 5. Get Element By Index
ElemType GetElem(SeqList list, int index){
    if(list.length <= 0) return -1;
    if(index < 0 || index > list.length) return -1;
    
    return list.data[index];
}

// 6. Insert Element by index
bool InsertElem(SeqList *list, int index, ElemType value){
    if(list->length <= 0) return false;
    if(index < 0 || index > list->length) return false;
    
    if(index == 0){ list->data[index] = value; return true; }
    
    for (int i = list->length; i > index; i--)  // Move elements backward.
        list->data[i] = list->data[i - 1];
    
    list->data[index] = value;                  // Assign
    list->length++;
    
    return true;
}

// 7. Delete Element by index
bool DeleteElem(SeqList *list, int index, ElemType *value){
    if(list->length <= 0) return false;
    if(index < 0 || index > list->length) return false;
    
    for(int i = index; i < list->length; i++)       // Cover elements
        list->data[i] = list->data[i + 1];
    
    list->length--;
    
    return true;
}

// 8. Print List
void PrintList(SeqList list){
    for(int i = 0; i < list.length; i++)
        printf("|No.%d| %d |\n", i, list.data[i]);
}

// 9. Destroy list
void DestroyList(SeqList *list){
    list->data = NULL;
    list->length = 0;
    free(list);
}


int main(void){
	SeqList list;
	InitSeqList(&list);

	for(int i = 0; i < 10; i++) InsertElem(&list, i, i);

	PrintList(list);

	return 0;
}
