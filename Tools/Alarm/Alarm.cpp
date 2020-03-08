#include<iostream> 
#include<string> 
#include<ctime> 
using namespace std;
//时间类
class Time{
private:
    int hour;
    int minute;
    int second;
public:
    //设置时间
    void set(int h,int m,int s){
        hour = h;
        minute = m;
        second = s;
    }
    //时间走一秒,时分秒的变化情况
    void next(){
        if(second<59)
            second++;
        else if(minute<59){
            second=0;
            minute++;}
        else if(hour<23){
            minute=0;
            hour++;}
        else
            hour=0;
    }
    //得到时间
    int get(){
        return hour*10000+minute*100+second;
    }
};
//时钟类
class Clock{
private:
    Time now;
    Time ring_time;
public:
    //对表，设定初始时间
    void adjust_now(int h,int m,int s){
        now.set(h,m,s);
        cout<<"现在的时间是："<<h<<"时"<<m<<"分"<<s<<"秒"<<endl;
    }
    //设定闹铃时间
    void adjust_ring(int h,int m,int s){
        ring_time.set(h,m,s);
        cout<<"闹铃时间是："<<h<<"时"<<m<<"分"<<s<<"秒"<<endl;
    }
    //时间过一秒
    void tick(){
        long int old=time(0);
        while(time(0)==old);
        now.next();
    }
    //显示当前时间
    void showtime(){
        cout<<now.get()<<endl;
    }
    //时钟开始走时,等到了闹铃时间，开始响
    void run(){
        do{
            tick();
            showtime();
            if(now.get()>=ring_time.get())
                cout<<'\a';
        }while(1);
    }
};
 
int main(void){
 	int startHour, startMin, startSec, stopHour, stopMin, stopSec;
    Clock c;
	printf("Set start time(hour:min:second): ");
	scanf("%d:%d:%d", &startHour, &startMin, &startSec);

	printf("Set stop time(hour:min:second): ");
	scanf("%d:%d:%d", &stopHour, &stopMin, &stopSec);

    c.adjust_now(startHour, startMin, startSec);     //起始时间
    c.adjust_ring(stopHour, stopMin, stopSec);    //闹铃时间
 
    c.run();
}

extern "C"{
	void SetClock(int startHour, int startMin, int startSec, int stopHour, int stopMin, int stopSec){
		Clock clock;
		clock.adjust_now(startHour, startMin, startSec);
		clock.adjust_ring(stopHour, stopMin, stopSec);
		clock.run();
	}
}
