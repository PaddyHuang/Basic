/*------Description------
Author: Paddy Huang
Date: 2019-10-06 22:03:57
Description: 九九乘法表
*/
#include <iostream>

int main(){
	for(int i = 1; i < 10; i++){
		for(int j = 1; j <= i; j++)
			std::cout << i << "X" << j << "=" << i*j << " ";
		std::cout << std::endl;
	}
	return 0;
}
