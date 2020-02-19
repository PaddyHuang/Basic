//
//  RandomValue.c
//  DataStructure
//
//  Created by Paddy Huang on 2020/2/1.
//  Copyright © 2020 Paddy Huang. All rights reserved.
//

#include "RandomValue.h"

void InitSrand(void){
    srand(time(NULL));
}

// Get a random value from 0 to n,
int GetRandomBySecond(int n){
//    srand(time(NULL));
    return rand() % n;
}
