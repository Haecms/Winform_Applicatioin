using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Task
{


    /* Task : https://kukuta.tistory.com/363
       ThreadPool 의 기능을 보완 하기 위하여 사용되는 비동기 스레드 기능 . 
       1. 백그라운드 속성의 스레드 
       2. 기본적으로 스레드 풀을 사용 
       4. 결과 값을 리턴 받을 수 있음. (*)

       - using System.Threading.Tasks; 추가  

       Task 가 수행하는 메서드 시그니처 
       - 반환 값이 없고 인자가 없는 대리자 (Action)
       - 반환 값이 없고 Object 인자가 1개 존재 하는 대리자 (Action<object>)
       - 반환 결과가 존재 하고 인자 가 없는 대리자 (Func<[반환형식]>
       - 반환 결과가 존재 하고 인자가 1개 존재하는 대리자 (Func<object, [반환형식]>
    */



    //class MyClass
    //{
    //    static void Main(string[] args)
    //    {
    //        // 메인 프로세스 를 종료 시키기 위하여 ctr + F5 로 실행 한다. 
    //        new TaskTest_ContinueWith().RunTaskFunc2();
    //        Console.ReadLine();
    //    }
    //}


    #region < Task 가 Action 델리게이트 를 수행하는 예제 > 
    // Action 반환 형이 없는 델리게이트 메서드 시그니쳐(메서드 형식)

    class TaskTest_Action
    {
        // 인자 가 없는 함수 . 
        private void TaskMethod_1()
        {
            Console.WriteLine("인자가 없는 Task 메서드 입니다.");
        }

        // 인자 가 있는 함수 
        // (Thread 와 Task 가 실행하는 메서드의 인자는 Object 형식의 단일 인자만 가능하다)
        private void TaskMethod_2(object obj)
        {
            Console.WriteLine($"{obj} 인자를 가지는 Task 메서드 2 입니다.");
        }


        public void RunTask()
        {
            // 인자 와 반환결과 가 없는 메서드 의 Task 
            Task task_1 = new Task(TaskMethod_1);
            task_1.Start();
        }

        public void RunTask2()
        {
            // 인자를 가지고 반환값이 없는 메서드의  Task 와 Thread
            Task task_2 = new Task(TaskMethod_2, "오브젝트");
            task_2.Start();
            
            // Thread 와 용법이 약간 상이 하다. 
            Thread thread = new Thread(TaskMethod_2);
            thread.Start("오브젝트");
        }
    }
    #endregion  

    #region < Task 의 Wait > 
    // Task 를 종료 할때까지 Wait

    class TestTask_Wait
    {
        private void ShowCount()
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}  스레드 의 {i} 번째 표현");
                Thread.Sleep(500);
            }
        }

        public void RunWaitTask()
        {
            Task task = new Task(ShowCount);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Task 와 동시에 실행됩니다.");
            task.Start();
            task.Wait();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} : Task 를 모두 기다린 후 실행 됩니다.");

        }
    }
    #endregion  

    #region <Task 가 Func 대리자를 수행 비동기 프로세스의 결과 값을 반환 받음 ** >
    class Task_Func
    {
        // 인자 가 없는 int 반환 메서드  . 
        private int TaskMethod()
        {
            for (int i = 0; i <10; i ++)
            {
                Thread.Sleep(1000);
            }
            return 10;
        }

        // 인자 가 있는 string 반환 메서드 
        private string TaskMethod(object obj)
        {
            return $"{obj} 인자를 가지는 Task 메서드 2 입니다.";
        }


        // 인자 를 N 개 받는  List<int> 반환 메서드 (X)
        private List<int> TaskMethod(int iValue, double dValue2, bool bFlag)
        {
            return new List<int> { iValue, Convert.ToInt32(dValue2), Convert.ToInt32(bFlag) };
        }


        public void RunTask()
        {
            // 인자를 받지 않는 int 반환 메서드 Task 수행
            Func<int> func = TaskMethod;
            Task<int> task = new Task<int>(func);

            // => 
            //Task<int> task1 = new Task<int>(() => 10);

            task.Start();

            // Task 의 결과 를 받아와 표현
            // *** 결과를 받기 위하여 스레드가 대기함.
            Console.WriteLine(task.Result);
        }


        public void RunTask2()
        {
            // 인자(object) 를 받는 int 반환 메서드 Task 수행
            Func<object, string> func = TaskMethod;
            Task<string> task = new Task<string>(func, "OBJECT");
            // => 
            //Task<string> task = new Task<string>(objcet => objcet + "입니다" , "OBJCET");

            task.Start();

            // Task 의 결과 를 받아와 표현
            // *** 결과를 받기 위하여 스레드가 대기함.
            Console.WriteLine(task.Result);

            // Task<반환형> ([Func], [object]) 형태 고정 이므로 인자를 여러개 받는 메서드는 Task 로 등록 할 수 없다.
            //Func<int, double, bool, List<int>> func3 = TaskMethod;
        }
    }
    #endregion

    #region < 반환 을 하는 Task 제너릭 클래스 만들어 보기 > 
    // Task 기능과는 별개의 Generic 클래스 만들어 보기. 
    class TaskTest_GenericClass
    {

        #region < 인자를 받지 않는 결과 반환 Task >
        public void RunTask()
        {
            // 반환값을 가지는 Task
            _Task<int> task = new _Task<int>(() => 100);
            task.Start();
            Console.WriteLine(task.result.ToString());
        }




        class _Task<Result>
        {
            private Task<Result> _task;
            private Func<Result> _func;
            public Result result
            {
                get
                {
                    _task.Wait();
                    if (_task.IsCompleted)
                        return _task.Result;
                    else return default(Result);
                }
            }

            public _Task(Func<Result> func)
            {
                _func = func;
            }

            public void Start()
            {
                _task = new Task<Result>(_func);
                _task.Start();
            }
        }
        #endregion 


        #region < Object 인자를 받는 결과 반환 Task > 
        public void RunTask_Param()
        {
            _Task_Param<string> task2 = new _Task_Param<string>((init) =>
            {
                for (int i = 0; i < (int)init; i++)
                {
                    Console.Write(i + "...");
                    Thread.Sleep(500);
                }
                return $"{init} 문자열 반환";
            }, 10);
            task2.Start();

            Console.WriteLine(task2.result); // 결과 를 받을 때 까지 대기
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + "M ...");
                Thread.Sleep(200);
            }
            
            Console.ReadLine();
        }




        class _Task_Param<Result>
        {
            private Task<Result> _task;
            private Func<object, Result> _func;
            private object _obj;
            public Result result
            {
                get
                {
                    _task.Wait();
                    if (_task.IsCompleted)
                        return _task.Result;
                    else return default(Result);
                }
            }

            public _Task_Param(Func<object, Result> func, object obj)
            {
                _func = func;
                _obj  = obj; 
            }

            public void Start()
            {
                Func<Result> func = () => _func(_obj);
                _task = new Task<Result>(func);
                _task.Start();
            }
        }
        #endregion
    }
    #endregion

    #region < Task 객체생성 없이 바로 수행하는 Run Method > 
    // ** Task.Run() 메서드 는 Action,  또는 Func<[반환 데이터 형식]> 만 처리 한다. 



    class TaskTest_Run
    {
        #region < 반환 값이 없는 Task Run > 
        private void TaskMethod_1()
        {
            Console.WriteLine("인자를 가지지 않는 Task 메서드 1 입니다.");
        }

        private void TaskMethod_2(object obj)
        {
            Console.WriteLine($"{obj} 인자를 가지는 Task 메서드 2 입니다.");
        }

        public void RunTaskAction()
        {
            Action<object> actionMethod = TaskMethod_2;
            Action actionMethod2 = () => actionMethod("object_1");
            Task.Run(actionMethod2); 

            // => 다른 표현 1
            Task.Run(() => actionMethod("object_2"));  

            // ==> 다른 표현 2
            Action<object> actionMethod3 = (obj) => Console.WriteLine(obj.ToString());
            Task.Run( () => actionMethod3("object_3"));
            
        }
        #endregion
        

        #region < 반환 값을 가지는 메서드 의 Task Run >
        // 인자 가 없는 숫자 반환 메서드
        private int TaskMethod_3()
        {
            return 10;
        }

        // 인자 가 있는 문자 반환 메서드
        private string TaskMethod_4(object obj)
        {
            return $"{obj} 인자를 가지는 Task 메서드 2 입니다.";
        }

        public void RunTaskFunc()
        {
            /**************************************************************************************************/
            // 인자 없이 반환 값을 가지는 메서드 의 Task Run()
            Func<int> TaskFunc_3 = TaskMethod_3;
            Task<int> task = Task.Run(TaskFunc_3);
            Console.WriteLine(task.Result.ToString());


            //// => 다른표현 1
            //Func<int> TaskFunc_4 = () => 10;
            //Task<int> task2 = Task.Run(TaskFunc_3);
            //Console.WriteLine(task.Result.ToString());

            //// => 다른 표현 2
            //Console.WriteLine(Task.Run(TaskFunc_3).Result.ToString());

            //// => 다른 표현 3
            //Console.WriteLine((Task.Run(() => 10)).Result.ToString());
        }
        public void RunTaskFunc2()
        {
            ///**************************************************************************************************/
            // 인자를 가지고 반환값을 가지는 메서드의 Tsk Run() 
            Func<string> TaskFun4F = () => TaskMethod_4("Object"); 

            Task<string> task = Task<string>.Run(TaskFun4F);

            Console.WriteLine(task.Result.ToString()); 

            //// => 다른 표현 1
            //Func<object, string> TaskFunc_4 = TaskMethod_4;
            //Func<string> TaskFun4 = () => TaskFunc_4("Object");
            //Console.WriteLine(Task<string>.Run(TaskFun4F).Result.ToString());

            //// => 다른 표현 2
            //Func<object, string> TaskFunc_5 = (obj) => $"{obj}  인자를 가지는 Task 메서드 2 입니다. ";
            //Func<string> TaskFunc_4F = () => TaskFunc_4("object");
            //Console.WriteLine(Task<string>.Run(TaskFunc_4F).Result.ToString());

        }
        #endregion
    }

    #endregion
  
    #region < 연속된 작업의 실행 ContinueWith  >  
    class TaskTest_ContinueWith
    {
        // 결과 값을 반환 받을 수 있는 Task 의 경우 서브 스레드의 Result 의 결과 가 필요할 경우 프로세스의 흐름이 동기적으로 바뀌어
        // 서브 스레드의 결과에 따른 분기 실행을 할 수 없다. 

        public void RunTaskFunc()
        {
            Func<bool> TaskFun4F = () => 
            { 
                for (int i =0; i < 10; i++)
                {
                    Console.WriteLine($"{i} 초 경과");
                    Thread.Sleep(1000);
                }
                return true;
            };


            Task<bool> task = Task.Run(TaskFun4F);


            if (task.Result)
            {
                Console.WriteLine("서브 스레드 로직을 완료 하였습니다.");
            }

            // 메인 프로세스 
            Console.WriteLine("서브 스레드 가 종료 되기 전에 표현 되지 않습니다.");
        }

        // 메인 프로세스 는 별개 로 실행하고 서브 스레드의 결과에 따른 로직 처리 를 이어서 하고싶을 경우
        // ContinueWith() 메서드에 를 통하여 결과를 받아 실행 할 메서드 를 인자로 전달
        public void RunTaskFunc2()
        {
            Func<bool> TaskFun4F = () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{i} 초 경과");
                    Thread.Sleep(1000);
                }
                return true;
            };

            Task<bool> task = Task<bool>.Run(TaskFun4F);

            task.ContinueWith(f_task =>
            {
                if (f_task.Result)
                {
                    Console.WriteLine("서브 스레드 로직이 완료된 후 반환 결과가 True 이므로 표현 됩니다..");
                }
                else
                {
                    Console.WriteLine("서브 스레드 로직이 완료되었지만 분기에 의해 표현 되지 않습니다..");
                }

            });

            // 메인 프로세스 
            Console.WriteLine("서브 스레드 의 결과 도출 을 기다리지 않고실행합니다.");
        }


        public void RunTaskFunc3()
        { 
            Task<bool> task = Task<bool>.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{i} 초 경과");
                    Thread.Sleep(1000);
                }
                return true;
            });

            task.ContinueWith(TaskWithResultContinue);
            // 메인 프로세스 
            Console.WriteLine("서브 스레드 의 결과 도출 을 기다리지 않고실행합니다.");
        }

        public void TaskWithResultContinue(Task<bool> f_task)
        {
            if (f_task.Result)
            {
                Console.WriteLine("서브 스레드 로직이 완료된 후 반환 결과가 True 이므로 표현 됩니다..");
            }
            else
            {
                Console.WriteLine("서브 스레드 로직이 완료되었지만 분기에 의해 표현 되지 않습니다..");
            }
        } 

        #region < 교안에는 풀어내지 않은 내용 보충 > 

        // 시간이 오래 걸리는 작업 메서드 TaskMethod() 
        private int TaskMethod(object obj)
        {
            int count = (int)obj;
            int result = 0;
            Console.WriteLine("Start Task");
            for (int i = 0; i <= count; i++)
            {
                Thread.Sleep(1000);
                result += 1;
            }
            Console.WriteLine("Finish Task");

            return result;
        }

        private void _Result(int result)
        {
            Console.WriteLine($"결과를 출력 합니다. {result}");
        } 

        private void _Continuewith(Task<int> task)
        {
            Console.WriteLine($"결과를 출력 합니다. {task.Result}");
        }

        public void RunTaskContinutWith()
        {
            // 1. 시간이 오래 걸리는 작업 메서드 TaskMethod() 가 있을때 별도의 Task 를생성후 메인 스레드는 유지
            //Task<int>task2 = new Task<int>(TaskMethod, 10);

            Func<int> funcTask = () => TaskMethod(5);
            Task<int> task = Task.Run(funcTask);



            // 2. TaskMethod() 메서드의 결과 를 받아와서 처리해야 하는 로직이 있을때 
            //    결과 를 _Result() 메서드에 전달 하거나, Wait 를 사용하여 출력 할 수 있다. 
            //_Result(task.Result);
            //Console.WriteLine("Main Thread 는 Taskmesthod 가 종료 된후 _Result() 를 실행하고 진행합니다.");

            // 3. TaskMethod 의 결과를 받아 _Result 를 실행 시키키 위해 task.result 를 사용하면 
            //    TaskMethod 의 Task 내용이 종료 될때까지 메인 스레드 가 Blocking 된다. 
            //    메인 스레드를 Blocking 하지 않고 TaskMethod 의 결과로 _Result 의 내용을 수행 할 수 있도록 하려면. 
            //    메인 스레드 와 Task.Result 를 연속 실행 하기 위하여 ContinueWith 를 사용 할 수 있다. 


            task.ContinueWith(_Continuewith);

            //아래와 같이 풀어서 표현 할 수 있다.
            // => 
            //task.ContinueWith((task_result) => Console.WriteLine($"결과를 출력 합니다.{task_result.Result}"));

            // => 
            //Action<Task<int>> action = (task_result) => Console.WriteLine($"결과를 출력 합니다.{task_result.Result}");
            //task.ContinueWith(action);

            
            Console.WriteLine("Main Thread 는 선행 Task 를 기다리지 않고 진행합니다.");
            Console.ReadLine();

            // ContinueWith
            // TaskMethod 의 작업이 완료 되면 비동기 적으로 이어 실행 하는 연속  Task 작업을 예약한다. 
            // Task<int> 를 결과값을 가진 객체 task 를 인자 로 받는 메서드(_Continuewith) 를 연속으로 실행. 
        }

        public void DoTaskResult()
        {
            // 아래의 예상 결과 를 작성하여 보세요.

            Console.WriteLine("Start Main Process");
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Start Task");
                for (int i = 0; i <= 2; i++)
                {
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Finish Task");
            }
            );
            task.ContinueWith((t) => Console.WriteLine("End ContinueWith Process"));
            Console.WriteLine("End Main Process");
            Console.ReadLine();


            /*
                Start Main Process
                End Main Process
                Start Task
                Finish Task
                End ContinueWith Process
            */
        }

        #endregion
    }
    #endregion


































    #region <!--심화 필수 강의 내용에서 제외 --  무한 반복 등 수행 시간이 오래 걸리는 Task 를 ThreadPool (Background) 에 등록하지 않고 별도로 사용하기 > 
    class TestTask_WithoutThreadPool
    {
        private void ShowNowTime()
        {
            // 프로그램 종료 시 까지 반복적으로 시간을 표시 하는 구문.
            while (true)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Thread.Sleep(1000);
            }
        }

        public void RunShowTime()
        {
            // 블로킹 작업 등 시간이 오래 걸리는 Task 는 스레드 풀에 등록 하지 않고 별도로 사용한다. 
            Task task = new Task(ShowNowTime, TaskCreationOptions.LongRunning);
            task.Start();
        }
    }
    #endregion

    #region < 연속된 작업의 실행 TaskAwaiter  !-- 심화 (반드시 학습 할 내용은 아님) > 
    class TaskTest_Awaiter
    {
        // 시간이 오래 걸리는 작업 메서드 TaskMethod() 
        private int TaskMethod(object obj)
        {
            int count = (int)obj;
            int result = 0;
            Console.WriteLine("Start Task");
            for (int i = 0; i <= count; i++)
            {
                Thread.Sleep(1000);
                result += 1;
            }
            Console.WriteLine("Finish Task");

            return result;
        }


        private void AwaiterMethod(Task<int> task)
        {
            Console.WriteLine($"첫번째 결과를 출력 합니다. {task.Result}");
        }

        public void RunTaskAwaiter()
        {
            Task<int> task = Task.Run(() => TaskMethod(5));

            // Task 의 결과로 처리할 비동기 메서드 연결. 
            TaskAwaiter<int> awaiter = task.GetAwaiter();

            // 첫번째 연속 결과  
            awaiter.OnCompleted(() => AwaiterMethod(task));

            // 두번째 연속 결과  
            awaiter.OnCompleted(() => Console.WriteLine($"두번째 메서드 는 람다로 결과를 출력  합니다. : {awaiter.GetResult()}"));

            Console.WriteLine("Main Thread 는 선행 Task 를 기다리지 않고 진행합니다.");
            Console.ReadLine();
        }
    }
    #endregion



}
