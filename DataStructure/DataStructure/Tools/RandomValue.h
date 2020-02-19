//
//  RandomValue.h
//  DataStructure
//
//  Created by Paddy Huang on 2020/2/1.
//  Copyright © 2020 Paddy Huang. All rights reserved.
//

#ifndef RandomValue_h
#define RandomValue_h

#include <stdio.h>
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */

void InitSrand(void);
// Get a random value from 0 to n,
int GetRandomBySecond(int n);

#endif /* RandomValue_h */
