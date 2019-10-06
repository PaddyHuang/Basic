/*
Author: Paddy Huang
Date: 2019-10-07 07:04:24
Description: Find max value
*/
#include <iostream>

/*
Function: find the max value between two int
Para: int a, int b
Return: int max
*/
int maxValue(int a, int b){
	return a > b ? a : b;
}

int main(){
	std::cout << maxValue(10, 12) << std:: endl;
	std::cout <<maxValue(9, 20) << std::endl;
	return 0;
}

