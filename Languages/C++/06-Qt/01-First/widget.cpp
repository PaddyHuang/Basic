#include "widget.h"
#include "mypushbtn.h"
#include <QPushButton>  // 控制按钮的头文件
#include <QDebug>

Widget::Widget(QWidget *parent)
    : QWidget(parent)
{
//     Create 1st button
    QPushButton *btn1 = new QPushButton();
//    btn->show();    // 以顶层的方式弹出窗口控件
//     让btn对象，依赖于Widget窗口中
    btn1->setParent(this);

//     显示文本
    btn1->setText("1st Btn");

//    Create 2nd Button
    QPushButton *btn2 = new QPushButton("2nd Btn", this);

//    移动btn2按钮
    btn2->move(100, 100);

//    重置窗口大小
    resize(600, 400);
//    设置固定窗口大小
    setFixedSize(600, 400);

//    设置窗口标题
    setWindowTitle("1st Window");

//    创建自定义按钮对象
    MyPushBtn *btn3 = new MyPushBtn;
    btn3->setText("My Push Btn");
    btn3->move(200, 0);
    btn3->setParent(this);

//    需求：点击按钮关闭窗口
//    connect(信号的发送者, 发送的具体信号(函数的地址), 信号的接收者, 信号的处理(槽))
    connect(btn3, &MyPushBtn::clicked, this, &Widget::close);
}

Widget::~Widget()
{
    qDebug() << "Widget Destructor calling";
}

