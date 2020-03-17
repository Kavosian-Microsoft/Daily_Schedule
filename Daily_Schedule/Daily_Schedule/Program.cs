using System;
using System.Collections.Generic;

namespace Daily_Schedule
{

    /// <summary>
    /// This is a class to represent an activity
    /// Any activity has got a name, for any activity I have to store stimated time to 
    /// finish, it's importance and dependency. 
    /// For name I am going to use an string property, for time to finsih I am going
    /// to use an integer variable to hold the minutes required to fulfill the task. For 
    /// inportance of any task it is better to define an enumeration with three choices:
    ///     1)Very_Important
    ///     2)Medium
    ///     3)Less_Important
    /// for dependencies I have to use a list. I am going to add depencency in next comming 
    /// version :-) 981226 03.16.2020 20:33
    /// </summary>
    enum Task_Impartance
    {
        Not_Set = -1,
        Less_Important = 0,
        Medium = 1,
        Very_Important = 2
    }//Task_Importance
    enum Daily_Task_Status
    {
        Waiting = 0,
        Started = 1,
        Idle = 2,
        Finished = 3
    }//Task_Status
    class Actitvity
    {
        protected string _activityName;
        protected int _activityTimeToFinish;
        protected Task_Impartance _taskImportance;
        protected Daily_Task_Status _task_Status;
        public string ActivityName
        {
            get { return _activityName; }//get
            set { _activityName = value; }//set
        }//ActivityName
        public int ActivityTimeToFinish
        {
            get { return _activityTimeToFinish; }//get                
            set
            {
                if (value >= 0)
                {
                    _activityTimeToFinish = value;
                }//if value > 0 
            }//set
        }//ActivityTimeToFinish
        public Task_Impartance MyTask_Importance
        {
            get { return _taskImportance; }//get
            set { _taskImportance = value; }//set
        }//MyTask_Importance
        public Daily_Task_Status MY_Task_Status
        {
            get { return this._task_Status; }//get
            set { _task_Status = value; }//set
        }//MY_Task_Status
        /// <summary>
        /// This is the first constructor for activity class with no argument
        /// </summary>
        public Actitvity()
        {
            ActivityName = "";
            ActivityTimeToFinish = 0;
            MyTask_Importance = Task_Impartance.Not_Set;
            MY_Task_Status = Daily_Task_Status.Waiting;
        }//Activity
        /// <summary>
        /// This is the second constructor for activity class with one argument representing
        /// task name
        /// </summary>
        public Actitvity(string task_name)
        {
            ActivityName = task_name;
            ActivityTimeToFinish = 0;
            MyTask_Importance = Task_Impartance.Not_Set;
            MY_Task_Status = Daily_Task_Status.Waiting;
        }//Activity
        /// <summary>
        /// This is the second constructor for activity class with two arguments representing
        /// task name and time to finsih
        /// </summary>
        public Actitvity(string task_name, int task_time_to_finish)
        {
            ActivityName = task_name;
            ActivityTimeToFinish = task_time_to_finish;
            MyTask_Importance = Task_Impartance.Not_Set;
            MY_Task_Status = Daily_Task_Status.Waiting;
        }//Activity
        /// <summary>
        /// This is the second constructor for activity class with three arguments representing
        /// task name and time to finsih and task importance
        /// </summary>
        public Actitvity(string task_name, int task_time_to_finish, Task_Impartance task_importance)
        {
            ActivityName = task_name;
            ActivityTimeToFinish = task_time_to_finish;
            MyTask_Importance = task_importance;
            MY_Task_Status = Daily_Task_Status.Waiting;
        }//Activity
        /// <summary>
        /// This is the second constructor for activity class with four arguments representing
        /// task name and time to finsih and task importance and task status
        /// </summary>
        public Actitvity(string task_name, int task_time_to_finish, Task_Impartance task_importance, Daily_Task_Status task_status)
        {
            ActivityName = task_name;
            ActivityTimeToFinish = task_time_to_finish;
            MyTask_Importance = task_importance;
            MY_Task_Status = task_status;
        }//Activity
    }//Activity
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                //The following List stores every instance of an activity
                List<Actitvity> tasks = new List<Actitvity>();
                Console.Title = "Simple daily schedualer";
                int choice;
                do
                {
                    choice = menu();
                    switch (choice)
                    {
                        case 0:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\tPress any key to exit application...");
                            break;
                        case 1:
                            ///This case is for adding new task to this system
                            ///When  a new task is created, required data must be collected
                            ///
                            Actitvity tmp = new Actitvity();
                            tmp = Get_New_Task_Data();
                            tasks.Add(tmp);
                            Console.Write("\n\tThe following activity is added to list");
                            Console.Write("\n\tActivity Name:{0}", tmp.ActivityName);
                            Console.Write("\n\tEstimetated time to finish:{0}", tmp.ActivityTimeToFinish);
                            Console.Write("\n\tActivity importance:{0}", tmp.MyTask_Importance.ToString());
                            Console.Write("\n\tActivity status:{0}", tmp.MY_Task_Status.ToString());
                            Console.ReadKey();
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        default:
                            break;
                    }//switch

                } while (choice != 0);
                Console.ReadKey();
            }//try
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAn exception has occured");
                Console.Write("\n\tThe exception has got the following error ");
                Console.Write("\n\t{0}", ex.Message);
            }//catch
        }//Main
        static int menu()
        {
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
        //-----------------------------------------------------------------------------------
        static void List_Activity(Actitvity act) {
        }//List_Activity
        //-----------------------------------------------------------------------------------
        static Actitvity Get_New_Task_Data()
        {
            string strInput = "";
            Actitvity newactivity = new Actitvity();
            Console.Write("\n\tEnter Task Name:");
            strInput = Console.ReadLine();
            newactivity.ActivityName = strInput;
            Console.Write("\n\tEnter Estimetate time to finish the task:");
            strInput = Console.ReadLine();
            newactivity.ActivityTimeToFinish = int.Parse(strInput);
            Console.Write("\n\tEnter task importance (Less Important L,Medium M, Very Important V):");
            strInput = Console.ReadLine();
            char choice = char.Parse(strInput.ToLower());
            switch (choice)
            {
                case 'l':
                    newactivity.MyTask_Importance = Task_Impartance.Less_Important;
                    break;
                case 'm':
                    newactivity.MyTask_Importance = Task_Impartance.Medium;
                    break;
                case 'v':
                    newactivity.MyTask_Importance = Task_Impartance.Very_Important;
                    break;
                default:
                    newactivity.MyTask_Importance = Task_Impartance.Not_Set;
                    break;
            }//switch

            Console.Write("\n\tEnter task status (Waiting W, Started S, Idle I,Finished F):");
            strInput = Console.ReadLine();
            choice = char.Parse(strInput.ToLower());

            switch (choice)
            {
                case 'w':
                    newactivity.MY_Task_Status = Daily_Task_Status.Waiting;
                    break;
                case 's':
                    newactivity.MY_Task_Status = Daily_Task_Status.Started;
                    break;
                case 'i':
                    newactivity.MY_Task_Status = Daily_Task_Status.Idle;
                    break;
                case 'f':
                    newactivity.MY_Task_Status = Daily_Task_Status.Finished;
                    break;
                default:
                    newactivity.MY_Task_Status = Daily_Task_Status.Waiting;
                    break;
            }//switch
            return newactivity;
        }//Get_New_Task_Data
        
    }//Program
}//Daily_Schedule
