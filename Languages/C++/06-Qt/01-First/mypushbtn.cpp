#include "mypushbtn.h"
#include <QDebug>

MyPushBtn::MyPushBtn(QWidget *parent) : QPushButton(parent)
{
    qDebug() << "My Push Btn Constructor calling";
}

MyPushBtn::~MyPushBtn()
{
    qDebug() << "My Push Btn Destructor calling";
}
