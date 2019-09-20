using System;

namespace _Exercise_Struct
{
    struct Student
    {
        private string name;
        private string number;
        private string class_number;
        private string score_DataStructure;

        public bool SetName(string name){
            if(name == null)
                return false;
            else
            {
                this.name = name;
                return true;
            }
        }

        public bool SetNumber(string number)
        {
            if (number == null)
                return false;
            else
            {
                this.number = number;
                return true;
            }
        }

        public bool SetClass_Number(string class_number)
        {
            if (class_number == null)
                return false;
            else
            {
                this.class_number = class_number;
                return true;
            }
        }

        public bool SetScore(string score)
        {
            if (score == null)
                return false;
            else
            {
                this.score_DataStructure = score;
                return true;
            }
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetNumber()
        {
            return this.number;
        }

        public string GetClass_Number()
        {
            return this.class_number;
        }

        public string GetScore_DataStructre()
        {
            return this.score_DataStructure;
        }

        override public string ToString()
        {
            return "Name: " + this.GetName() + "\nNumber: " + this.GetNumber() + "\nClass Number: " + this.GetClass_Number() + "\nData Structure: " + this.GetScore_DataStructre();
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 定义一个结构体(有学号、姓名、班级和数据结构成绩四个字段)，声明该结构体变量，用赋值语句赋值后输出
            Student student = new Student();
            student.SetName("Polin");
            student.SetNumber("2014131609");
            student.SetClass_Number("146");
            student.SetScore("96");
            student.ToString();
            Console.WriteLine(student.ToString());
        }
    }
}
