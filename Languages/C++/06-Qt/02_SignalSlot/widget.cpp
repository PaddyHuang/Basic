#include "widget.h"
#include "ui_widget.h"
#include <QPushButton>
#include <QDebug>
// Teacher 教师类
// Student 学生类
// 下课后，老师会触发一个信号，饿了，学生响应信号，请客吃饭

Widget::Widget(QWidget *parent)
    : QWidget(parent)
    , ui(new Ui::Widget)
{
    ui->setupUi(this);

    // Create a  teacher
    this->teacher = new Teacher(this);
    // Create a student
    this->student = new Student(this);

//    // 老师饿了，学生请客
//    connect(this->teacher, &Teacher::hungry, this->student, &Student::treat);
//    // 调用下课函数
//    classIsOver();
    // 连接带参数的信号和槽
    // 函数指针 -> 函数地址
    void (Teacher::*teacherSignal)(QString) = &Teacher::hungry;
    void (Student::*studentSlot)(QString) = &Student::treat;
    connect(this->teacher, teacherSignal, this->student, studentSlot);
    classIsOver();

    // 点击一个下课的按钮，就下课
    QPushButton *btn = new QPushButton("下课", this);
    this->setFixedSize(400, 400);
    // 点击按钮触发下课
//    connect(btn, &QPushButton::clicked, this, &Widget::classIsOver);
    // 无参信号和槽连接
    void (Teacher::*teacherSignal2)(void) = &Teacher::hungry;
    void (Student::*studentSlot2)(void) = &Student::treat;
//    connect(this->teacher, teacherSignal2, this->student, studentSlot2);
    // 信号连接信号
    connect(btn, &QPushButton::clicked, this->teacher, teacherSignal2);
    //  断开信号
//    disconnect(this->teacher, teacherSignal2, this->student, studentSlot2);

    // 拓展
    // 1. 信号可以连接信号
    // 2. 一个信号可以连接多个槽函数
//    connect(btn, &QPushButton::clicked, this, &Widget::close);
    // 3. 多个信号，可以连接一个槽函数
    // 4. 信号和槽函数的参数必须一一对应
    // 5. 信号的参数个数可以多于槽函数的参数个数

    // Qt4版本以前的信号和槽连接方式
    // 利用Qt4信号槽，连接无参版本
    // Qt4版本底层SIGNAL("hungry"), SLOT("treat")，以字符串函数名查找对应函数
    connect(teacher, SIGNAL(hungry()), student, SLOT(treat()));
    // Qt4版本优点，参数直观；缺点：类型不做检测
    // Qt5以上，支持Qt4版本写法，反之不支持

    // Lambda Expression
//    QPushButton *btn2 = new QPushButton();
//    [btn](){
//        btn->setText("haha");
//        btn2->setText("aaaa");  // btn2看不到
//    }();

    // Lambda表达式按值传递时，传递进来的时该值的拷贝，默认该拷贝值为只读状态，要是想修改该拷贝值就得使用mutable关键字
    QPushButton *myBtn = new QPushButton(this);
    QPushButton *myBtn2 = new QPushButton(this);
    myBtn2->move(100, 100);
    int m = 10;
    connect(myBtn, &QPushButton::clicked, this, [m]()mutable {m = 100 + 10; qDebug() << m;});
    connect(myBtn2, &QPushButton::clicked, this, [=](){qDebug() << m;});
    qDebug() << m;

    // Lambda 的返回值
    int ret = []() ->int {return 100000;}();
    qDebug() << "ret = " << ret;

    // 利用lambda表达式实现点击按钮关闭窗口
    QPushButton *btnLambda = new QPushButton(this);
    btnLambda->setText("Close");
    btnLambda->move(200, 100);
    connect(btnLambda, &QPushButton::clicked, this, [=](){
        this->close();
    });

    // Exercise
    QWidget *w = new QWidget();
    QPushButton *openBtn = new QPushButton("打开", this);
    openBtn->move(300, 100);
    connect(openBtn, &QPushButton::clicked, w, &QWidget::show);
    QPushButton *closeBtn = new QPushButton("关闭", this);
    closeBtn->move(300, 200);
    connect(closeBtn, &QPushButton::clicked, w, &QWidget::close);

    QPushButton *multiBtn = new QPushButton("Multi", this);
    multiBtn->move(300, 300);
    bool toggle = true;
    connect(multiBtn, &QPushButton::clicked, w, [toggle, w, multiBtn]()mutable{
        if(toggle){
            w->show();
            multiBtn->setText("打开");
            toggle = false;
        }
        else{
            w->close();
            multiBtn->setText("关闭");
            toggle = true;
        }
    });

}

Widget::~Widget()
{
    delete ui;
}

void Widget::classIsOver(){
    // 下课函数，调用后，触发老师饿了的信号
//    emit teacher->hungry();
    emit teacher->hungry("宫保鸡丁");
}
