//
//  SeqList.h
//  DataStructure
//
//  Created by Paddy Huang on 2020/2/1.
//  Copyright © 2020 Paddy Huang. All rights reserved.
//

#ifndef SeqList_h
#define SeqList_h

#include <stdio.h>
#include <stdlib.h>     // malloc 函数在此头文件中

#define bool int
#define true 1
#define false -1

#define ElemType int
#define InitSize 50

typedef struct {
    ElemType *data;
    int length, MaxSize;
}SeqList;

// 1. Init list
void InitSeqList(SeqList *list);
// 2. Get length
int GetLength(SeqList list);
// 3. Empty
int Empty(SeqList list);
// 4. Locate Element By Value and return index
int LocateElem(SeqList list, ElemType value);
// 5. Get Element By Index
ElemType GetElem(SeqList list, int index);
// 6. Insert Element by index
int InsertElem(SeqList *list, int index, ElemType value);
// 7. Delete Element by index
int DeleteElem(SeqList *list, int index, ElemType *value);
// 8. Print List
void PrintList(SeqList list);
// 9. Destroy list
void DestroyList(SeqList *list);

#endif /* SeqList_h */
