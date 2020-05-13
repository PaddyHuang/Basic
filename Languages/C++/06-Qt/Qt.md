# Note for Qt

> OS: macOS Mojave
>
> Environment: Xcode 11.3

## 1. Installation for Qt

### (1) Install Qt using homebrew

```shell
brew install qt		// for uninstall use: brew uninstall qt
```

and remember the position where qt is. We can use:

```shell
brew info qt
```

for me, that is /usr/local/Cellar/qt/5.14.2

### (2) Install Qt-creator

```shell
brew cask install qt-creator	// for uninstall use: brew cask uninstall qt-creator
```

qt is the base tool for qt-creator, but the latter cannot detect the former automatically. Thus, we need to configure qt-creator manually.

Step1: Preferences --> Kits --> Qt Versions --> Add: /usr/local/Cellar/qt/5.11.2/bin/qmake

Step2: Preferences --> Kits --> Kits, choose our desktop, choose compiler for clang(both c and c++) and choose Qt Version for the version we added previously.

Done.

## 2. Create 1st project

### (1) Click New --> Qt Widget Application --> name and choose somewhere to place it

These are ome detail configures:

- Build System: qmake

- Base class: Widget(without Generate form, which is a GUI method to manipulate UI. we will learn it later)

- Kits: Choose the one we added previously

- Version Control: Git

  Done. We could browse our project outline and then run it(A blank window).

  ```cpp
  // main.cpp
  #include "widget.h"
  
  #include <QApplication>
  
  // argc: argument counter	命令行变量的数量
  // *argv[]: atgument vector	命令行变量的数组
  int main(int argc, char *argv[])
  {
      int main(int argc, char *argv[])
  {
      // 应用程序对象。在Qt中，应用程序对象application，有且仅有一个
      QApplication a(argc, argv);
      // 窗口对象 继承自QWidget
      Widget w;
      // 窗口对象默认不会显示，必须调用show方法显示窗口
      w.show();
      // 让应用程序对象进入消息循环
      // 让代码阻塞到这行
      return a.exec();
  }
  ```
  
  ```shell
  # 01-First.pro 用于配置生成的makefile
  
  QT       += core gui	# Qt包含的模块
  
  greaterThan(QT_MAJOR_VERSION, 4): QT += widgets	# 当高于Qt4版本时，QT包含widget模块
  
  CONFIG += c++11		# 使用C++11标准
  
  # The following define makes your compiler emit warnings if you use
  # any Qt feature that has been marked deprecated (the exact warnings
  # depend on your compiler). Please consult the documentation of the
  # deprecated API in order to know how to port your code away from it.
  DEFINES += QT_DEPRECATED_WARNINGS
  
  # You can also make your code fail to compile if it uses deprecated APIs.
  # In order to do so, uncomment the following line.
  # You can also select to disable deprecated APIs only up to a certain version of Qt.
  #DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0
  
  SOURCES += \
      main.cpp \
      widget.cpp
  
  HEADERS += \
      widget.h
  
  # Default rules for deployment.
  qnx: target.path = /tmp/$${TARGET}/bin
  else: unix:!android: target.path = /opt/$${TARGET}/bin
  !isEmpty(target.path): INSTALLS += target
  
  ```
  
  ```cpp
  // widget.h
  #ifndef WIDGET_H
  #define WIDGET_H
  
  #include <QWidget>	// 包含头文件QWidget类
  
  class Widget : public QWidget		// Widget继承自QWidget
  {
      Q_OBJECT		// 宏，允许使用信号和槽的机制
  
  public:
      Widget(QWidget *parent = nullptr);	//有参构造函数，默认参数为构造空指针
      ~Widget();	// 析构函数
  };
  #endif // WIDGET_H
  
  ```
  
  ```cpp
  // widget.cpp
  #include "widget.h"
  
  Widget::Widget(QWidget *parent)
      : QWidget(parent)
  {
  }
  
  Widget::~Widget()
  {
  }
  ```
  
  > 命名规范：
  >
  > 1. 类名：首字母大写，单词和单词之间的首字母大写
  > 2. 函数名、变量名：首字母小写，单词和单词之间的首字母大写
  >
  > 快捷键：
  >
  > 1. 注释：command(ctrl) + /
  > 2. 运行：command(ctrl) + r
  > 3. 编译：command(ctrl) + b
  > 4. 字体缩放：command(ctrl) + 鼠标滚轮
  >
  > 5. 查找：command(ctrl) + f
  > 6. 整行移动：command(ctrl) + shift + up/down
  > 7. 帮助文档：F1
  > 8. 自动对齐：command(ctrl) + i
  > 9. 同名之间.h, .cpp切换：F4
  
  

## 3. QPushButton API

[References]: https://doc.qt.io/qt-5/qpushbutton.html

```cpp
#include "widget.h"
#include <QPushButton>  // 控制按钮的头文件

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
}

Widget::~Widget()
{
    qDebug() << "Widget Destructor calling";
}
```

## 4. 对象树(对象模型)

> 总结：
>
> 1. 当创建的对象在堆区时，如果指定的父亲是QObject派生类或者QObject子类的派生类，可以不用管理释放的操作，会将对象放入对象树中；
> 2. 一定程度上简化了内容回收机制。

## 5. Qt窗口坐标系：原点在左上角，x轴以右为正，y轴以下为正

## 6. 信号和槽机制

```
连接方式：
connect(信号的发送者, 发送的具体信号, 信号的接收者, 信号的处理(槽函数slot))
需求：点击按钮关闭窗口
connect(btn3, &MyPushBtn::clicked, this, &Widget::close);
```

> 信号槽点优点：松散耦合，信号发送端和接受端，本身是没有关系的，通过connect连接，将两者结合。

### 6.1 自定义信号

> 总结：
>
> 1. 返回void；
> 2. 需要声明，不需要实现；
> 3. 可以有参数，可以重载。

### 6.2 自定义槽函数

> 总结：
>
> 1. 返回void；
> 2. 需要声明，也需要实现；
> 3. 可以有参数，可以重载；
> 4. 可以写到public slots下或全局函数。

### 6.3 触发自定义信号

> emit触发自定义信号

### 6.4 案例：下课后，老师触发饿了，学生响应信号，请客吃饭

> 当自定义信号和槽出现重载：
>
> 1. 需要利用函数指针，明确指向函数地址；
> 2. void (Teacher::*teacherSignal)(QString) = &Teacher:hungry;
> 3. QString( .toUtf8 ) -> QByteArray( .data() ) -> char *；
> 4. 信号可以连接信号；
> 5. 使用disconnect断开信号连接.

```cpp
// Student.h
#ifndef STUDENT_H
#define STUDENT_H

#include <QObject>

class Student : public QObject
{
    Q_OBJECT
public:
    explicit Student(QObject *parent = nullptr);

signals:

public slots:
    // 早期Qt版本，必须要写到public slots，高级版本可以写到public或全局下
    // 返回值void，需要声明，也需要实现
    // 可以有参数，可以重载
    void treat();
		void treat(QString food);
};

#endif // STUDENT_H
```

```cpp
// Student.cpp
#include "student.h"
#include <QDebug>

Student::Student(QObject *parent) : QObject(parent)
{

}

void Student::treat(){
    qDebug() << "Treat teacher";
}
void Student::treat(QString food){
    // QString -> char *
    // 先转成QByteArray( .toUtf8() ) 再转char * ( .data() )
    qDebug() << "Treat teacher. The " << food.toUtf8().data() << " will be nice.";
}
```

```cpp
// Teacher.h
#ifndef TEACHER_H
#define TEACHER_H

#include <QObject>

class Teacher : public QObject
{
    Q_OBJECT
public:
    explicit Teacher(QObject *parent = nullptr);

signals:
    // 自定义信号，写到signals下
    // 返回值是void，只需要声明，不需要实现
    // 可以有参数，可以重载
    void hungry();
	  void hungry(QString food);
};

#endif // TEACHER_H
```

```cpp
// Teacher.cpp
#include "teacher.h"

Teacher::Teacher(QObject *parent) : QObject(parent)
{

}
```

```cpp
// Widget.h
#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include "teacher.h"
#include "student.h"

QT_BEGIN_NAMESPACE
namespace Ui { class Widget; }
QT_END_NAMESPACE

class Widget : public QWidget
{
    Q_OBJECT

public:
    Widget(QWidget *parent = nullptr);
    ~Widget();

private:
    Ui::Widget *ui;

    Teacher * teacher;
    Student * student;

    void classIsOver();
};
#endif // WIDGET_H
```

```cpp
// Widget.cpp
#include "widget.h"
#include "ui_widget.h"

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
    connect(this->teacher, teacherSignal2, this->student, studentSlot2);
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
```

## 7. Lambda表达式(C++11)

定义并创建匿名的函数对象

```cpp
    // QPushButton *btn2 = new QPushButton();
    [btn](){
        btn->setText("haha");
        btn2->setText("aaaa");  // btn2看不到
    }();

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
```

> 总结：
>
> 1. []：标识符，匿名函数；
> 2. =：值传递，常用；
> 3. &：引用传递；
> 4. ()：参数；
> 5. {}：函数体；
> 6. mutable：修饰值传递变量，可以修改拷贝的数据，改变不了本体；
> 7. 返回值：[]() ->int {}

```cpp
[=](){};		// Lambda 表达式最常用形式
```

```cpp
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
```

