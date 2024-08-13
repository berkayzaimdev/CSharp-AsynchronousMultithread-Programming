#region Spinning

//bool threadCondition = true;

//Thread t1 = new(() =>
//{
//    while(true)
//    {
//        if (!threadCondition)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 1 : {i}");
//            }

//            threadCondition = false;
//            break;
//        }
//    }
//});

//Thread t2 = new(() =>
//{
//    while (true)
//    {
//        if (threadCondition)
//        {
//            for (int i = 10; i > 0; i--)
//            {
//                Console.WriteLine($"Thread 2 : {i}");
//            }

//            threadCondition = false;
//            break;
//        }
//    }
//});

//t1.Start();
//t2.Start();

#endregion

#region Monitor.Enter ve Monitor.Exit

// bu metotlar, lock keyword'ün çözülmüş halidir. lock keyword'ü arkaplanda bu tarz bir davranış sergiler. hata durumunda ise kendisi unlock eder

//object locking = new();
//int i = 0;

//Thread t1 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 0; i < 10; i++)
//        {
//            Console.WriteLine($"Thread 1 : {i}");
//        }
//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});

//Thread t2 = new(() =>
//{
//    try
//    {
//        Monitor.Enter(locking);
//        for (i = 10; i > 0; i--)
//        {
//            Console.WriteLine($"Thread 2 : {i}");
//        }
//    }
//    finally
//    {
//        Monitor.Exit(locking);
//    }
//});

//t1.Start();
//t2.Start();

#endregion

#region lockTaken parametresi

// bu özelliği genellikle birden fazla thread ile çalışırken kullanıyoruz.
// bir thread'in kilidi aldığını ve diğerlerinin kilidi alamadığını kontrol etmek için kullanmayı tercih ediyoruz.
// bu sayede diğer thread'ler yalnızca kilidi beklemek yerine başka işlemler yapabilir

//object locking = new();
//int i = 0;

//Thread t1 = new(() =>
//{
//    bool lockTaken = false;
//    Monitor.Enter(locking, ref lockTaken);
//    try
//    {
//        if(lockTaken)
//        {
//            for (i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 1 : {i}");
//                Thread.Sleep(100);
//            }
//        }
//    }
//    finally
//    {
//        if(lockTaken)
//        {
//            Monitor.Exit(locking);
//        }
//    }
//});

//Thread t2 = new(() =>
//{
//    bool lockTaken = false;
//    Monitor.Enter(locking, ref lockTaken);
//    try
//    {
//        if (lockTaken)
//        {
//            for (i = 10; i > 0; i--)
//            {
//                Console.WriteLine($"Thread 2 : {i}");
//            }
//        }
//    }
//    finally
//    {
//        if (lockTaken)
//        {
//            Monitor.Exit(locking);
//        }
//    }
//});

//t1.Start();
//t2.Start();

#endregion

#region Monitor.TryEnter

//object locking = new();
//int i = 0;

//Thread t1 = new(() =>
//{

//    var result = Monitor.TryEnter(locking, 3); // belirlenen milisaniye içerisinde lock başarılı ise

//    if (result)
//    {
//        try
//        {

//            for (i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 1 : {i}");
//                Thread.Sleep(100);
//            }
//        }

//        finally
//        {
//            Monitor.Exit(locking);
//        }
//    }

//});

//Thread t2 = new(() =>
//{

//    var result = Monitor.TryEnter(locking, 3); // belirlenen milisaniye zarfında lock başarılı ise

//    if (result)
//    {
//        try
//        {
//            for (i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"Thread 2 : {i}");
//                Thread.Sleep(100);
//            }
//        }

//        finally
//        {
//            Monitor.Exit(locking);
//        }
//    }

//});

//t1.Start();
//t2.Start();

#endregion

#region Mutex sınıfı

// C programlamadaki mutex'ten çok farkı yok

//Mutex mutex = new();

//Thread t1 = new(() =>
//{
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 1 : {i}");
//        Thread.Sleep(100);
//    }
//    mutex.ReleaseMutex();
//});

//Thread t2 = new(() =>
//{
//    mutex.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Thread 2 : {i}");
//        Thread.Sleep(100);
//    }
//    mutex.ReleaseMutex();
//});

//t1.Start();
//t2.Start();

#endregion

#region Mutex ile Single Instance Application

//program, tek bir string sayesinde yalnızca bir instance üzerinden çalışabilmektedir.

//internal class Program
//{
//    static Mutex _mutex = null;
//    static string programName = "example project";

//    private static void Main(string[] args)
//    {
//        Mutex.TryOpenExisting(programName, out _mutex);
//        if (_mutex == null)
//        {
//            _mutex = new(true, programName);
//            Console.WriteLine("Processing...");
//            Console.Read();
//        }

//        else
//        {
//            _mutex.Close();
//            return;
//        }
//    }
//}

#endregion

#region Lock class

// Lock lockingObj = new(); // .NET 9 ile gelecektir.

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