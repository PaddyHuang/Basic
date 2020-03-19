#include "SortingMethods.hpp"

#define ARRAY_SIZE 100000				// 100k 
#define SIZE sizeof(A) / sizeof(int)

int main(void){
	int A[ARRAY_SIZE] = {0};
	SortingMethods<int> sorting;

	srand((unsigned)time(NULL));

	// cout << "Before: " << endl;
	for(int i = 0; i < SIZE; i++){
		A[i] = rand() % 100;		// 获取1～100之间的随机数
		// cout << A[i] << endl;
	}
	// cout << endl;

	// sorting.InsertSort(A, SIZE);			// 直接插入排序
	// sorting.ShellSort(A, SIZE);			// 希尔排序
	// sorting.BubbleSort(A, SIZE);			// 冒泡排序
	// sorting.QuickSort(A, 0, SIZE - 1);	// 快速排序
	// sorting.SelectionSort(A, SIZE);		// 选择排序
	// sorting.HeapSort(A, SIZE);			// 堆排序
	// sorting.MergeSort(A, SIZE);			// 归并排序
	// sorting.RadixSort_LSD(A, SIZE);		// 基数排序（低位到高位）
	// sorting.RadixSort_LSD_Reverse(A, SIZE);	// 基数排序（高位到低位）
	sorting.RadixSort_MSD(A, SIZE);			// 基数排序（高位到低位）
	// sorting.RadixSort_MSD_Reverse(A, SIZE);	// 基数排序（低位到高位）

	// cout << "After: " << endl;
	// for(int i = 0; i < SIZE; i++)
		// cout << A[i] << endl;
	// cout << endl;

	return 0;
}
