#region Thread sınıfı

//class Program
//{
//    private static void Main(string[] args)
//    {
//        // Thread thread1 = new(ThreadMethod);
//        Thread thread2 = new(() =>
//        {
//            for (int i = 0; i < 100; i++)
//            {
//                Console.WriteLine($"Worker Thread -> {i}");
//            }
//        });

//        thread2.Start(); // thread koşmaya başlar

//        for (int i = 0; i < 100; i++)
//        {
//            Console.WriteLine($"Main Thread -> {i}");
//        }
//    }

//    static void ThreadMethod()
//    {
//        // ...
//    }
//}

#endregion

#region Thread ID

//class Program
//{
//    private static void Main(string[] args)
//    {
//        WriteIdentifier();

//        Thread thread1 = new(() =>
//        {
//            WriteIdentifier("First");
//        });

//        thread1.Start();

//        Thread thread2 = new(() =>
//        {
//            WriteIdentifier("Second");
//        });

//        thread2.Start();
//    }

//    public static void WriteIdentifier(string name = "Main")
//    {
//        Console.WriteLine(string.Concat(name," Thread"));
//        Console.WriteLine(Environment.CurrentManagedThreadId);
//        Console.WriteLine(AppDomain.GetCurrentThreadId());
//        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
//    }
//}

#endregion

#region IsBackground

//class Program
//{
//    private static void Main(string[] args)
//    {
//        int i = 10;

//        Thread thread = new(() =>
//        {
//            while (i >= 0)
//            {
//                i--;
//                Thread.Sleep(200);
//            }
//            Console.WriteLine("Worker Thread görevini tamamladı");
//        });

//        thread.IsBackground = false;

//        thread.Start();
//        Console.WriteLine("Main thread görevini tamamladı!");
//    }
//}

#endregion

#region Thread State

//class Program
//{
//    private static void Main(string[] args)
//    {
//        int i = 10;

//        Thread thread = new(() =>
//        {
//            while (i >= 0)
//            {
//                i--;
//                Thread.Sleep(200);
//            }
//            Console.WriteLine("Worker Thread görevini tamamladı");
//        });

//        thread.Start();

//        ThreadState state = ThreadState.Running;

//        while(true)
//        {
//            if(state == ThreadState.Stopped)
//            {
//                break;
//            }

//            if(state != thread.ThreadState)
//            {
//                state = thread.ThreadState;
//                Console.WriteLine(thread.ThreadState);
//            }
//        }

//        Console.WriteLine("Main thread görevini tamamladı!");
//    }
//}

#endregion

#region Locking

//object lockingObj = new();

//int i = 1;

//Thread t1 = new(() =>
//{
//    lock (lockingObj)
//    {
//        while (i <= 10)
//        {
//            i++;
//            Console.WriteLine($"Thread 1 : {i}");
//        }
//    }
//});

//Thread t2 = new(() =>
//{
//    lock (lockingObj)
//    {
//        while (i > 0)
//        {
//            i--;
//            Console.WriteLine($"Thread 2 : {i}");
//        }
//    }
//});

//t1.Start();
//t2.Start();

#endregion

#region Join

//Thread t1 = new(() =>
//{
//    for(int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 1 -> {i}");
//    }
//});

//Thread t2 = new(() =>
//{
//    for(int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 1 -> {i}");
//    }
//});

//t1.Start();
//t1.Join(); // bu thread koşmasını bitirene dek, başka bir thread başlatma
//t2.Start();

#endregion

#region Thread İptal Etme I

//bool flag = false;

//Thread thread = new(() =>
//{
//    while (true)
//    {
//        if (flag) break;
//        Console.WriteLine("asdasdasd");
//    }

//    Console.WriteLine("Thread görevini tamamladı.");
//});

//thread.Start();
//// thread.Abort(); // kaynakların verimli bir şekilde temizlenememesinden ötürü deprecate edilmiştir
//Thread.Sleep(5);
//flag = true;

#endregion

#region Thread İptal Etme II

//Thread thread = new((cancellationToken) =>
//{
//    var cancellation = (CancellationTokenSource)cancellationToken;
//    while (true)
//    {
//        if (cancellation.IsCancellationRequested) break;
//        Console.WriteLine("asdasdasd");
//    }

//    Console.WriteLine("Thread görevini tamamladı.");
//});

//CancellationTokenSource cancellationToken = new();

//thread.Start(cancellationToken);
//Thread.Sleep(5);
//cancellationToken.Cancel();

#endregion

#region Interrupt

Thread thread = new(() =>
{
    try
    {
        Console.WriteLine("Thread beklemeye geçti!");
        Thread.Sleep(Timeout.Infinite);
    }

    catch (ThreadInterruptedException ex) // thread uyandırıldığı zaman bu hata fırlatıldığı için try-catch kullanımı önem taşıyor
    {
        Console.WriteLine("Thread uyandırıldı!");
    }
});

thread.Start();
thread.Interrupt(); // uyuyan thread'i uyandırır, yahut çalışma durumunu kesintiye uğratır

#endregion