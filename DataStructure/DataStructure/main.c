//
//  main.c
//  DataStructure
//
//  Created by Paddy Huang on 2020/1/31.
//  Copyright © 2020 Paddy Huang. All rights reserved.
//

#include <stdio.h>
#include "SeqList.h"


int main(int argc, const char * argv[]) {
    // insert code here...
    printf("Hello, World!\n");

    SeqList list;
    InitSeqList(&list);
    
//    InsertElem(&list, 0, 123);
    
    
    PrintList(&list);
    
    return 0;
}
