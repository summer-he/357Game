using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeFiveSevenGame
{
    class Program
    {
        static List<int> _list = new List<int>() { 3, 5, 7 };
        static Random random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("按【回车键】开始...");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine($"初始值：{string.Join(",", _list)}");

            var index = 1;
            while (_list.Sum() > 0)
            {
                Console.WriteLine("");
                Console.WriteLine($"第{index}轮...");
                Console.WriteLine("玩家1开始...");
                UserOneTake();
                Console.WriteLine($"结果：{string.Join(",", _list)}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("玩家2开始");
                UserTwoTake();
                Console.WriteLine($"结果：{string.Join(",", _list)}");

                index++;
                Thread.Sleep(1500);
            }
        }

        public static void UserOneTake()
        {
            TakePoker("user1");
        }

        public static void UserTwoTake()
        {
            TakePoker("user2");
        }

        public static void TakePoker(string user)
        {
            //if (_list.Count < rowIndex)
            //    return;
            //if (_list[rowIndex] > takeNum)
            //    return;

            var rowIndex = 0;
            while (true)
            {
                rowIndex = random.Next(_list.Count);
                if (_list[rowIndex] != 0)
                {
                    //该行没有则重新随机
                    break;
                }
            }
            var takeNum = random.Next(_list[rowIndex] + 1);
            Console.WriteLine($"玩家{user}在{rowIndex + 1}行拿了{takeNum}根火柴{(takeNum == 0 ? "(0根属于任意根复合题目要求)" : "")}");

            _list[rowIndex] = _list[rowIndex] - takeNum;
            if (_list.Sum() == 0)
            {
                Console.WriteLine($"{user} lose");
                Console.ReadLine();
            }
        }
    }
}
