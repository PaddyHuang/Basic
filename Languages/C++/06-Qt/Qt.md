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

