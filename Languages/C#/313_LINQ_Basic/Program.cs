using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _313_LINQ_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化武林高手
            var masterList = new List<MartialArtsMaster>(){
                new MartialArtsMaster(){ Id = 1, Name = "黄蓉",    Age = 18, Menpai = "丐帮", Kongfu = "打狗棒法",  Level = 9  },
                new MartialArtsMaster(){ Id = 2, Name = "洪七公",  Age = 70, Menpai = "丐帮", Kongfu = "打狗棒法",  Level = 10 },
                new MartialArtsMaster(){ Id = 3, Name = "郭靖",    Age = 22, Menpai = "丐帮", Kongfu = "降龙十八掌",Level = 10 },
                new MartialArtsMaster(){ Id = 4, Name = "任我行",  Age = 50, Menpai = "明教", Kongfu = "葵花宝典",  Level = 1  },
                new MartialArtsMaster(){ Id = 5, Name = "东方不败",Age = 35, Menpai = "明教", Kongfu = "葵花宝典",  Level = 10 },
                new MartialArtsMaster(){ Id = 6, Name = "林平之",  Age = 23, Menpai = "华山", Kongfu = "葵花宝典",  Level = 7  },
                new MartialArtsMaster(){ Id = 7, Name = "岳不群",  Age = 50, Menpai = "华山", Kongfu = "葵花宝典",  Level = 8  },
                new MartialArtsMaster() { Id = 8, Name = "令狐冲", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 },
                new MartialArtsMaster() { Id = 9, Name = "梅超风", Age = 23, Menpai = "桃花岛", Kongfu = "九阴真经", Level = 8 },
                new MartialArtsMaster() { Id =10, Name = "黄药师", Age = 23, Menpai = "梅花岛", Kongfu = "弹指神通", Level = 10 },
                new MartialArtsMaster() { Id = 11, Name = "风清扬", Age = 23, Menpai = "华山", Kongfu = "独孤九剑", Level = 10 }
            };

            //初始化武学
            var kongfuList = new List<Kongfu>(){
                new Kongfu(){Id=1, Name="打狗棒法", Power=90},
                new Kongfu(){Id=2, Name="降龙十八掌", Power=95},
                new Kongfu(){Id=3, Name="葵花宝典", Power=100},
                new Kongfu() { Id=  4, Name = "独孤九剑", Power = 100 },
                new Kongfu() { Id = 5, Name = "九阴真经", Power = 100 },
                new Kongfu() { Id = 6, Name = "弹指神通", Power = 100 }
            };

            // 查询所有武学级别大于8的武林高手
            // 1. 传统查询方法
            var res1 = new List<MartialArtsMaster>();
            foreach (var item in masterList)
            {
                if (item.Level > 8)
                {
                    res1.Add(item);
                }
            }
            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // 2. 使用LINQ查询（LINQ表达式写法）
            var res2 = from m in masterList  // from 后面设置查询的集合
                      where m.Level > 8  && m.Menpai == "丐帮"    // where 后面设置查询的条件
                      select m.Name;              // select 表示m的结果返回 

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine();

            // 3. 使用LINQ查询（扩展方法的写法）
            var res3 =  masterList.Where(Test1);
            foreach (var item in res3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // 4. 使用LINQ查询（扩展方法的写法-Lambda表达式）
            var res4 = masterList.Where(m => m.Level > 8 && m.Menpai == "丐帮");
            foreach (var item in res4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // 5. LINQ联合查询
            // 取得所学功夫的杀伤力大于90的大侠
            var res5 = from m in masterList
                       from k in kongfuList
                       where m.Kongfu == k.Name && k.Power > 90
                       //select new { master = m, kongfu = k };
                       select m;

            foreach (var item in res5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();




            Console.ReadKey();
        }

        // 过滤方法
        static bool Test1(MartialArtsMaster master)
        {
            if (master.Level > 8 && master.Menpai == "丐帮")
            {
                return true;
            }
            return false;
        }
    }
}
