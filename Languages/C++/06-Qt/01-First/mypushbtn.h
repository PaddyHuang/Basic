#ifndef MYPUSHBTN_H
#define MYPUSHBTN_H

#include <QPushButton>

class MyPushBtn : public QPushButton
{
    Q_OBJECT
public:
    explicit MyPushBtn(QWidget *parent = nullptr);

//    MyPushBtn();
    ~MyPushBtn();

signals:

};

#endif // MYPUSHBTN_H
