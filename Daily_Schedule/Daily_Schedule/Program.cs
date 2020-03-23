using System;
using System.Collections.Generic;
using System.IO;
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
    class Activity
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
        public Activity()
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
        public Activity(string task_name)
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
        public Activity(string task_name, int task_time_to_finish)
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
        public Activity(string task_name, int task_time_to_finish, Task_Impartance task_importance)
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
        public Activity(string task_name, int task_time_to_finish, Task_Impartance task_importance, Daily_Task_Status task_status)
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
                List<Activity> tasks = new List<Activity>();
                Console.Title = "Simple daily schedualer";
                string strFileName = "dataFile.txt";
                int choice;
                do
                {
                    choice = menu(tasks.Count, strFileName);
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
                            Activity tmp = new Activity();
                            tmp = Get_New_Task_Data();
                            tasks.Add(tmp); Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n\t=======================================");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            List_Activity(tmp, tasks.Count);
                            Console.ReadKey();
                            break;
                        case 2:
                            ///This case is for listing activities 
                            if (tasks.Count > 0)
                            {
                                int i = 0;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\n\t================================================");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                foreach (Activity a in tasks)
                                {
                                    i++;
                                    List_Activity(a, i);
                                }//foreach
                            }//if there is task to list
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\tThere is no activity in your schedule");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }//else
                            Console.ReadKey();
                            break;
                        case 3:
                            ///This case is for edittng an existing task
                            ///
                            if (tasks.Count == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\tThere is no activity in your schedule");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.ReadKey();
                            }//if task list is empty
                            else {
                                int indexToEdit;
                                indexToEdit = get_index_of_editting_cell();
                                if ((indexToEdit < 0) || (indexToEdit > tasks.Count))
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\n\tIndex is out of range, please try again");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.ReadKey();
                                }//if index out of range
                                else {
                                    Activity t = new Activity();
                                    t = tasks[indexToEdit-1];
                                    Console.Write("\n\t=======================================");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    List_Activity(t, indexToEdit);

                                    t=get_new_data_for_existing_Task(t);
                                    tasks[indexToEdit - 1] = t;
                                    Console.Write("\n\tOne record is editted....");
                                    Console.ReadKey();
                                }//else if index is in reach
                            }//else if list has got tasks
                            break;
                        case 4:
                            ///This case is for deletting an Item from tasks 
                            ///
                            ///

                            if (tasks.Count > 0)
                            {
                                int index;
                                index = get_RemovalTakID(0, tasks.Count - 1);
                                if (index != -1) {
                                    Activity act = new Activity();
                                    act = tasks[index];
                                    List_Activity(act, index);
                                    if (get_confirm_to_Delete())
                                    {
                                        tasks.RemoveAt(index);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.Write("\n\tOne task is removed....");                                        
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("\n\tpress any key to continue...");
                                    }//if it is ok to delete
                                }//if correct index is entered
                                
                            }//if there is task to list
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\tThere is no activity in your schedule");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }//else
                            Console.ReadKey();


                            break;
                        case 5:
                            ///This case is for clearing the whole task list
                            ///
                            if (tasks.Count > 0)
                            {
                                if (get_confirm_to_Delete()) {
                                    tasks.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("\n\tAll tasks are removed....");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.Write("\n\tpress any key to continue...");
                                }//if
                            }//if there is task to list
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\tThere is no activity in your schedule");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                
                            }//else
                            Console.ReadKey();
                            break;
                            ///This Case is for getting new file name
                            ///
                        case 6:
                            strFileName = get_file_Name(strFileName);
                            break;
                            ///This case is for writting data to file
                        case 7:
                            if (tasks.Count > 0)
                            {
                                Console.Write("\n\tWriting data to file started at===>{0}", DateTime.Now.ToLongTimeString());
                                Console.Beep(300, 200);
                                System.IO.File.Delete(strFileName);
                                 foreach (Activity item in tasks)
                                {
                                    write_data_to_file(item, strFileName);
                                }//foreach
                                Console.Beep(500, 200);
                                Console.Write("\n\tWriting data to file finished at {0}", DateTime.Now.ToLongTimeString());                                
                                
                            }//if there is task to list
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\tThere is no activity in your schedule");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }//else
                            Console.ReadKey();
                            break;
                        ///This Case is for reading data from data file
                        case 8:
                            tasks.Clear();
                            Read_data_from_file(ref tasks, strFileName);
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
                Console.Write("\n\tException no =1");
                Console.Write("\n\tThe exception has got the following error ");
                Console.Write("\n\t{0}", ex.Message);
                Console.ReadKey();
            }//catch
        }//Main
        static int menu(int numberOfTasks,string fileName)
        {
            int result = -1;
            char chrInput=' ';
            string strInput = "";
            Console.Clear();
            Console.Write("\n\tCurrent Data File=");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(fileName);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t==============================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\tNumber of current tasks={0}", numberOfTasks);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t==============================");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\t0)Exit");
            Console.Write("\n\t1)Enter new task");
            Console.Write("\n\t2)List Tasks");
            Console.Write("\n\t3)Edit Task");
            Console.Write("\n\t4)Delete Task");
            Console.Write("\n\t5)Remove All Tasks");
            Console.Write("\n\t6)Change Data File");
            Console.Write("\n\t7)Write Data to File");
            Console.Write("\n\t8)Read Data from File");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t=========================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\tEnter your choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
            strInput = Console.ReadLine();
            if (strInput.Length == 1) {
                chrInput = strInput[0];
                if (char.IsNumber(chrInput)) {
                    result = int.Parse(strInput);
                }//if
            }//if user has entered a choice            
            return result;
        }//menu
        //-----------------------------------------------------------------------------------
        static void List_Activity(Activity act, int index)
        {            
            Console.Write("\n\tTask Number:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(index);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\tTask Name:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.ActivityName);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\tTask Time to finish:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.ActivityTimeToFinish);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\tTask Importance:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.MyTask_Importance.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n\tTask Status=");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.MY_Task_Status.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t================================================");
            Console.ForegroundColor = ConsoleColor.Gray;
        }//List_Activity
        //-----------------------------------------------------------------------------------
        static Activity Get_New_Task_Data()
        {
            string strInput = "";
            Activity newactivity = new Activity();
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
        static int get_index_of_editting_cell() {
            int index=-1;
            try
            {
                Console.Write("\n\tEnter index of task to edit:");
                index = int.Parse(Console.ReadLine());                
            }//try
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAn exception has occured");
                Console.Write("\n\tException no =2");
                Console.Write("\n\tThe exception has got the following error ");
                Console.Write("\n\t{0}", ex.Message);
            }//catch
            return index;
        }//get_index_of_editting_cell
         //---------------------------------------------------------
         /// <summary>
         /// This method gets the current Task as parameter and asks for new data from user
         /// </summary>
         /// <param name="act"></param>
         /// <returns></returns>
        static Activity get_new_data_for_existing_Task(Activity act) {
            string strInput = "";
            Activity edittedActivity = new Activity();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t===================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n\t Editting Task ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\t===================");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write("\n\tTask Name:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.ActivityName);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" (Enter new name or press enter to accept current name) :");
            strInput = Console.ReadLine();
            if (strInput.Length == 0)
            {
                edittedActivity.ActivityName = act.ActivityName;
            }//Currrent name is confirmed
            else {
                edittedActivity.ActivityName = strInput;
            }//else if new name is entered

            Console.Write("\n\tTask Time to finish:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.ActivityTimeToFinish);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" (Enter new Time to finish or press enter to accept current Task Time to finish) :");
            strInput = Console.ReadLine();
            if (strInput.Length == 0)
            {
                edittedActivity.ActivityTimeToFinish = act.ActivityTimeToFinish;
            }//Currrent ActivityTimeToFinish is confirmed
            else
            {
                edittedActivity.ActivityTimeToFinish = int.Parse(strInput);
            }//else if new ActivityTimeToFinish is entered

            Console.Write("\n\tTask Importance:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.MyTask_Importance.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" (Enter newTask Importance or press enter to accept current Task Importance V,M,L) :");
            strInput = Console.ReadLine();
            if (strInput.Length == 0)
            {
                edittedActivity.MyTask_Importance = act.MyTask_Importance;
            }//Currrent MyTask_Importance is confirmed
            else
            {                
                char choice = char.Parse(strInput.ToLower());
                switch (choice)
                {
                    case 'l':
                        edittedActivity.MyTask_Importance = Task_Impartance.Less_Important;
                        break;
                    case 'm':
                        edittedActivity.MyTask_Importance = Task_Impartance.Medium;
                        break;
                    case 'v':
                        edittedActivity.MyTask_Importance = Task_Impartance.Very_Important;
                        break;
                    default:
                        edittedActivity.MyTask_Importance = Task_Impartance.Not_Set;
                        break;
                }//switch
                
            }//else if new MyTask_Importance is entered

            Console.Write("\n\tTask Status=");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(act.MY_Task_Status.ToString());
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" (Enter new Task Status or press enter to accept current Task Status W,I,F,S) :");
            strInput = Console.ReadLine();
            if (strInput.Length == 0)
            {
                edittedActivity.MY_Task_Status = act.MY_Task_Status;
            }//Currrent Task Status is confirmed
            else
            {
                char choice = char.Parse(strInput.ToLower());
                switch (choice)
                {
                    case 'w':
                        edittedActivity.MY_Task_Status = Daily_Task_Status.Waiting;
                        break;
                    case 's':
                        edittedActivity.MY_Task_Status = Daily_Task_Status.Started;
                        break;
                    case 'i':
                        edittedActivity.MY_Task_Status = Daily_Task_Status.Idle;
                        break;
                    case 'f':
                        edittedActivity.MY_Task_Status = Daily_Task_Status.Finished;
                        break;
                    default:
                        edittedActivity.MY_Task_Status = Daily_Task_Status.Waiting;
                        break;
                }//switch
            }//else if new MY_Task_Status is entered
            return edittedActivity;
        }//static Activity get_new_data_for_existing_Task
        /// <summary>
        /// Theget_RemovalTaskID gets min and max number if activities list indexes and asks user ti 
        /// enter an index to remove content
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>int index</returns>
        static int get_RemovalTakID(int min,int max) {
            int index = -1;
            try
            {
                bool repeat = true;                
                do
                {
                    Console.Write("\n\tEnter task ID to delete (please enter a number from {0} to {1} [-1 to exit]) :",min,max);
                    index = int.Parse(Console.ReadLine());
                    if ((index >= min) && (index <= max))
                    {
                        repeat = false;
                    }//if entery is correct 
                    else if (index == -1) {
                        repeat = false;
                    }//if exit code e\is entered
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n\tPlease try again with an index in the range");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                    }//else
                } while (repeat);
            }//try
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAn exception with thw following message has occured ");
                Console.Write("\n\t{0}",ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
            }//catch

            return index;
        }//Delete_Task
        static bool get_confirm_to_Delete() {
            bool confirm = false;
            bool repeat = true;
            do
            {
                Console.Write("\n\tAre you sure that you want to delete the task(s)? (y/n)");
                string strInput = Console.ReadLine().ToLower();
                char choice = char.Parse(strInput);
                if ((choice == 'y') || (choice == 'n'))
                {
                    if (choice == 'y')
                    {
                        confirm = true;
                    }//if yes
                    else if (choice == 'n') {
                        confirm = false;
                    }//else if no
                    repeat = false;
                }//if entery is correct 
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\tPlease try again and enter y or n ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                }//else
            } while (repeat);
            return confirm;
        }//get_Confirm
        //-------------------------------------------------------------
        static string get_file_Name(string current_file_name) {
            string new_file_name = "";
            Console.Write("\n\tEnter new file name (Default==>{0}) " +
                "[Enter to confirm current file]:",current_file_name);
            new_file_name = Console.ReadLine();
            if (new_file_name.Length == 0)
            {
                new_file_name = current_file_name;
            }//If current file name is confirmed
            else {

            }//else if new file name is entered
            return new_file_name;
        }//get_file_Name
        //--------------------- write_data_to_file ----------------------------
        static void write_data_to_file(Activity act,string fileName) {
            try
            {
                FileStream destFile = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                BinaryWriter writer = new BinaryWriter(destFile);
                writer.Write(act.ActivityName);
                writer.Write(act.ActivityTimeToFinish);
                int actimportance = -2;
                switch (act.MyTask_Importance)
                {
                    case Task_Impartance.Not_Set:
                        actimportance = -1;
                        break;
                    case Task_Impartance.Less_Important:
                        actimportance = 0;
                        break;
                    case Task_Impartance.Medium:
                        actimportance = 1;
                        break;
                    case Task_Impartance.Very_Important:
                        actimportance = 2;
                        break;
                    default:
                        break;
                }//switch
                writer.Write(actimportance);

                int actstatus=-1;
                switch (act.MY_Task_Status)
                {
                    case Daily_Task_Status.Waiting:
                        actstatus = 0;
                        break;
                    case Daily_Task_Status.Started:
                        actstatus = 1;
                        break;
                    case Daily_Task_Status.Idle:
                        actstatus = 2;
                        break;
                    case Daily_Task_Status.Finished:
                        actstatus = 3;
                        break;
                    default:
                        break;
                }//switch
                writer.Write(actstatus);
                writer.Close();
                destFile.Close();
            }//try
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAn exception with thw following message has occured ");
                Console.Write("\n\t{0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
            }//catch
        }//write_data_to_file
        //--------------------- Read_data_from_file ----------------------------
        static void Read_data_from_file(ref List<Activity> activities,string fileName)
        {
            try
            {
                FileStream sourceFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(sourceFile);
                //Activity act = new Activity();
                int actimportance = -2;
                int actstatus = -1;
                while (sourceFile.Position < sourceFile.Length) {
                    Activity act = new Activity();
                    act.ActivityName = reader.ReadString();
                    act.ActivityTimeToFinish = reader.ReadInt32();
                    actimportance = reader.ReadInt32();
                    switch (actimportance)
                    {
                        case -1:
                            act.MyTask_Importance=Task_Impartance.Not_Set;
                            break;
                        case 0:
                            act.MyTask_Importance = Task_Impartance.Less_Important;
                            break;
                        case 1:
                            act.MyTask_Importance = Task_Impartance.Medium;
                            break;
                        case 2:
                            act.MyTask_Importance = Task_Impartance.Very_Important;
                            break;
                        default:
                            break;
                    }//switch
                    actstatus = reader.ReadInt32();
                    switch (actstatus)
                    {
                        case 0:
                            act.MY_Task_Status = Daily_Task_Status.Waiting;
                            break;
                        case 1:
                            act.MY_Task_Status = Daily_Task_Status.Started;
                            break;
                        case 2:
                            act.MY_Task_Status = Daily_Task_Status.Idle;
                            break;
                        case 3:
                            act.MY_Task_Status = Daily_Task_Status.Finished;
                            break;
                        default:
                            break;
                    }//switch
                    activities.Add(act);
                }//while there is data

                
                reader.Close();
                sourceFile.Close();
            }//try
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\tAn exception with thw following message has occured ");
                Console.Write("\n\t{0}", ex.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadKey();
            }//catch
        }//write_data_to_file
        //---------------------------------------------------------------------
    }//Program

}//Daily_Schedule
