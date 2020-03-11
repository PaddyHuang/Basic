#include <iostream>

void foo2(int a, int b){
	std::cout << a << " : " << b << std::endl;
}

//编译C++，一定要加extern "C"，注意C为大写，小写会无法识别
extern "C"{
	void cfoo2(int a, int b){ 
		foo2(a, b);
	}
}
