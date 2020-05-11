#include <iostream>
#include <thread>

void func1(){
  std::cout << "HaHa" << std::endl;
}

int main(void){
  std::thread t1(func1);
  t1.join();

  return 0;
}
