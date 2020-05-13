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
