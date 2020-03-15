using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> tasks = new List<string>();
                Console.Title = "Simple daily schedualer";
                int choice;
                do
                {
                    choice = menu();
                } while (choice != 0);
            }//try
            catch (Exception)
            {
                                
            }//catch
        }//Main
        static int menu() {
            int result = -1;
            Console.Clear();
            Console.Write("\n\t0)Exit");
            Console.Write("\n\t1)Enter new task");
            Console.Write("\n\t2)List Tasks");
            Console.Write("\n\t3)Edit Task");
            Console.Write("\n\t4)Delete Task");
            Console.Write("\n\t5)Remove All Tasks");
            Console.Write("\n\t=========================");
            Console.Write("\n\tEnter your choice:");
            result = int.Parse(Console.ReadLine());


            return result;
        }//menu
    }//Program
}//Daily_Schedule
