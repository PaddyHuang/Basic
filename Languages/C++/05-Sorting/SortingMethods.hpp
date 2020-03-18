#ifndef SORTING_METHODS
#define SORTING_METHODS

#include <iostream>
#include <cstdlib>
#include <ctime>
#include <cstring>
using namespace std;

template<class T>
class SortingMethods{
	public:
		// 插入排序
		void InsertSort(T *array, int length);				// 直接插入排序
		void ShellSort(T *array, int length);				// 希尔排序
		// 交换排序
		void BubbleSort(T *array, int length);				// 冒泡排序
		void QuickSort(T *array, int left, int right);		// 快速排序
		// 选择排序
		void SelectionSort(T *array, int length);			// 简单选择排序
		void HeapSort(T *array, int length);				// 堆排序 大根堆
		// 归并排序
		void MergeSort(T *array, int length);				// 归并排序
		// 基数排序
		void RadixSort_LSD(T *array, int length);			// 低位优先排序
		void RadixSort_LSD_Reverse(T *array, int length);	// 高位到低位
		void RadixSort_MSD(T *array, int length);			// 高位优先排序
		void RadixSort_MSD_Reverse(T *array, int length);	// 低位到高位
	private:
		void swap(T &a, T &b){
			T temp = a;
			a = b;
			b = temp;
			return;
		}
		
		// 大根堆内部函数
		// 调整
		void adjustHeap(T *array, int index, int length){	// node为需要调整的结点下标，length为堆长度
			int child = 2 * index + 1;	// 左孩子，第一个结点下标为0
			while(child < length){
				// 右子树
				if(child + 1 < length && array[child] < array[child + 1]) child++;
				if(array[index] >= array[child]) break;
				swap(array[index], array[child]);
				index = child;
				child = 2 * index + 1;
			}
		}

		// 建堆
		void makeHeap(T *array, int length){
			for(int i = length / 2; i >= 0; i--)
				adjustHeap(array, i, length);
		}

		// 归并排序内部函数
		void mergeArray(T *array, int left, int mid, int right, T *temp){
			if(array == NULL) return;

			int i = left, j = mid + 1, k = 0;
			while(i <= mid && j <= right){
				if(array[i] < array[j]){
					temp[k++] = array[i++];
					continue;
				}
				temp[k++] = array[j++];
			}
			while(i <= mid) temp[k++] = array[i++];
			while(j <= right) temp[k++] = array[j++];

			mencpy(&array[left], temp, k * sizeof(T));
			return;
		}

		void mmergeSort(T *array, int left, int right, T *temp){
			if(left < right){
				int mid = (left + right) / 2;
				mmergeSort(array, left, mid, temp);
				mmergeSort(array, mid + 1, right, temp);
				mergeArray(array, left, mid, right, temp);
			}
		}

		// 基数排序内部函数
		int getMaxDigit(T *array, int length){
			if(array == NULL) return 0;
			if(length < 1) return 0;

			int max = array[0];
			for(int i = 1; i < length; i++)
				if(array[i] > max)
					max = array[i];
			int digit = 1;
			while(max / 10 != 0){
				max /= 10;
				++digit;
			}
			return digit;
		}

		int getReminder(T value, int digit){
			int div = 1;
			for(int i = 1; i < digit; i++)
				div *= 10;
			return value / div % 10;
		}
};

template<class T>
void SortingMethods<T>::InsertSort(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	for(int i = 1; i < length; i++){	// i 是次数
		for(int j = i; j > 0; j--){
			if(array[j] < array[j - 1])			// 从大到小排序，反过来就是从小到大
				swap(array[j], array[j - 1]);
			else break;
		}
	}
	return;
}

template<class T>
void SortingMethods<T>::ShellSort(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	for(int div = length / 2; div >= 1; div /= 2)
		for(int k = 0; k < div; k++)
			for(int i = div + k; i < length; i += div)
				for(int j = i; j > k; j -= div)
					if(array[j] < array[j - div]) swap(array[j], array[j - div]);
					else break;
	return;
}

template<class T>
void SortingMethods<T>::BubbleSort(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	for(int i = 0; i < length - 1; i++)			// i是循环次数
		for(int j = 0; j < length - 1 - i; j++)	// j是具体下标
			if(array[j] > array[j + 1])
				swap(array[j], array[j + 1]);
	return;
}

// 快速排序，随机选取哨兵放在最前面
template<class T>
void SortingMethods<T>::QuickSort(T *array, int left, int right){
	if(array == NULL) return;
	if(left >= right) return;

	srand((unsigned)time(NULL));	// 获取随机数
	int length = right - left;
	int index = rand() % (length + 1) + left;	// 获取随机下标
	swap(array[left], array[index]);	// 把最左边的元素作为哨兵
	
	int key = array[left], i = left, j = right;
	while(i < j){
		while(array[j] >= key && i < j) j--;
		if(i < j) array[i] = array[j];
		while(array[i] < key && i < j) i++;
		if(i < j) array[j] = array[i];
	}
	array[i] = key;		// 把哨兵赋值回去

	QuickSort(array, left, i - 1);		// 递归调用
	QuickSort(array, j + 1, right);
}

template<class T>
void SortingMethods<T>::SelectionSort(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	int min;
	for(int i = 0; i < length - 1; i++){
		min = i;
		for(int j = i + 1; j < length; j++)
			if(array[j] > array[min])
				min = j;
		swap(array[i], array[min]);
	}
	return;
}

template<class T>
void SortingMethods<T>::HeapSort(T *array, int length){
	makeHeap(array, length);
	for(int i = length - 1; i >= 0; i--){
		swap(array[i], array[0]);
		adjustHeap(array, 0, i);
	}
}

template<class T>
void SortingMethods<T>::MergeSort(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	T *temp = (T*)calloc(length, sizeof(T));
	mmergeSort(array, 0, length - 1, temp);

	mencpy(array, temp, sizeof(T) * length);

	free(temp);
	return;
}

template<class T>
void SortingMethods<T>::RadixSort_LSD(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	int digit = getMaxDigit(array, length);
	T count[10] = {0};
	T *temp = (T*)calloc(length, sizeof(T));

	for(int d = 1; d <= digit; d++){
		memset(count, 0, sizeof(count));
		for(int i = 0; i < length; i++)
			count[getReminder(array[i], d)]++;
		// 求右边界
		for(int i = 1; i < 10; i++)
			count[i] += count[i - 1];
		for(int i = length - 1; i >= 0; i--){
			int reminder = getReminder(array[i], d);
			int index = count[reminder];
			temp[index - 1] = array[i];
			count[reminder]--;
		}
		memcpy(array, temp, length * sizeof(T));
	}
	free(temp);
	return;
}

template<class T>
void SortingMethods<T>::RadixSort_LSD_Reverse(T *array, int length){
	if(array == NULL) return;
	if(length <= 1) return;

	int digit = getMaxDigit(array, length);
	T count[10] = {0};
	T *temp = (T*)calloc(length, sizeof(T));

	for(int d = 1; d <= digit; d++){
		memset(count, 0, sizeof(count));
		for(int i = 0; i < length; i++)
			count[getReminder(array[i], d)]++;
		// 求右边界
		for(int i = 8; i >= 0; i--)
			count[i] += count[i + 1];
		for(int i = length - 1; i >= 0; i--){
			int reminder = getReminder(array[i], d);
			int index = count[reminder];
			temp[index - 1] = array[i];
			count[reminder]--;
		}
		memcpy(array, temp, length * sizeof(T));
	}
	free(temp);
	return;
}

template<class T>
void SortingMethods<T>::RadixSort_MSD(T *array, int length){

}

template<class T>
void SortingMethods<T>::RadixSort_MSD_Reverse(T *array, int length){

}
#endif
