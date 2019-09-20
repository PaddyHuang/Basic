#include <iostream>

#define ElemType int
#define MaxSize 50
typedef struct{
	ElemType data[MaxSize];		// 存放栈中元素
	int top;					// 栈顶
} SeqStack;

// 1. Initialization
void InitStack(SeqStack &stack){
	//stack.data = new ElemType[MaxSize];
	stack.top = -1;
}

// 2. Empty
bool Empty(SeqStack stack){
	if(stack.top == -1)
		return true;
	return false;
}

// 3. In
bool Push(SeqStack &stack, ElemType value){
	if(stack.top == MaxSize - 1) return false;	// 栈满，报错
	stack.data[++stack.top] = value;			// 指针先加1，后入栈
	return true;
}

// 4. Out
bool Pop(SeqStack &stack, ElemType &value){
	if(stack.top == -1) return false;			// 栈空，报错
	value = stack.data[stack.top--];			// 先出栈，指针再减1
	return true;
}

// 5.读栈顶元素
bool GetTop(SeqStack &stack, ElemType &value){
	if(stack.top == -1) return false;			// 栈空，报错
	value = stack.data[stack.top];				// value记录栈顶元素
	return true;
}

// 6. 输出栈中所有元素
void PrintStack(SeqStack stack){
	for(int pointer = stack.top; pointer > -1; pointer--)
		std::cout << pointer << " : " << stack.data[pointer] << std::endl;
}

// 7. Destroy
void Destroy(SeqStack &stack){
	stack.top = -1;
	//free(stack.data);
}

int main(){
	SeqStack stack;
	InitStack(stack);

	std::cout << "Initializing stack, please enter value. (Type 999 to end this process.)" << std::endl;
	ElemType value = 0;		// Insert Value
	for(int i = 0; i < MaxSize; i++){
		if(value == 999) break;
		else{
			std::cin >> value;
			Push(stack, value);
			std::cout << "Stack[" << i << "]: " << value << std::endl;
		}
	}
	std::cout << std::endl << "Your initialized stack:" << std::endl;
	PrintStack(stack);
	
	int option = 0;
	std::cout << "Welcome! This is a Sequence Stack. You can control the list with the following options:\n";
	do{
		std::cout << "1. Push element\n" << "2. Pop element\n" << "3. Get top element\n" << "4. Print stack\n" << "999. Destroy stack and quit.\n" << "Choose an option: ";
		std::cin >> option;
		switch(option){
			case 1:{					// 1. Push
				ElemType pushValue;
				std::cout << "Value: ";
				std::cin >> pushValue;

				if(Push(stack, pushValue))
					std::cout << "Insert Done." << std::endl;
				else
					std::cout << "Error." << std::endl;
				break;
			}
			case 2:{					// 2. Pop
				ElemType popValue;
				if(Pop(stack, popValue))
					std::cout << "Pop: " << popValue << std::endl;				
				else
					std::cout << "Error!" << std::endl;
				
				break;
			}
			case 3:{					// 3. Get top 
				ElemType topValue;
				if(GetTop(stack, topValue))
					std::cout << "Top: " << topValue << std::endl;				
				else
					std::cout << "Error!" << std::endl;

				break;
			}
			case 4:{					// 5. Print List
				PrintStack(stack);
				break;
			}
			case 999:{					// 999. Destroy List and Quit
				Destroy(stack);
				std::cout << "Destroy Done." << std::endl;
				break;
			}
			default:
				break;
		}
	}while(option != 999);


	return 0;
}
