/*
Author: Paddy Huang
Date: 2019-10-07 07:28:17
Description: Find min value
*/
#include <iostream>
using namespace std;

/*
Function: find the min value
Para: int a, int b
Return: int minValue
*/
int minValue(int a, int b){
	return a < b ? a : b;
}

int main(){
	cout << minValue(12, 1) << endl;
	return 0;
}
