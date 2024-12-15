#region ThreadPool

// ThreadPool.SetMaxThreads(4, 4); // sadece parametre olarak verebiliyoruz pratikte bu şekilde uygulanması garanti değil
// // yönlendirme niteliğinde parametre söylüyoruz. nihai kararı Thread Pool vermekte
// // ikinci parametre ise I/O işlemlerinde optimizasyon sağlar. n sayıda thread , I/O işlemi tamamlanana kadar bloke olmaz n tane işlem ardışık çalışır
// ThreadPool.SetMinThreads(2, 2);
//
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 1");
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 2");
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 3");
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 4");
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 5");
// ThreadPool.QueueUserWorkItem(WorkerMethod, "Task 6");
//
// Console.Read();
//
// void WorkerMethod(object state)
// {
//     string jobName = state as string;
//
//     Console.WriteLine($"{jobName} işi başladı");
//     Thread.Sleep(new Random().Next(1000, 3000));
//     Console.WriteLine($"{jobName} işi tamamlandı");
// }

#endregion

#region WaitHandles
//
// // Bir signaling yaklaşımıdır.
// // Auto/Manual ResetEvent yapıları birer wait handles yapılardır diyebiliriz.
//
// AutoResetEvent autoResetEvent = new AutoResetEvent(false);
//
// RegisteredWaitHandle registeredWaitHandle =
//     ThreadPool.RegisterWaitForSingleObject(
//         autoResetEvent,
//         WorkerMethod, // hedef metot
//         "Task 1 wait handle", // metot için parametre
//         -1, // zaman aşımı süresi. -1 verildiği takdirde sinyal gelene kadar beklenir. t zaman verildiği takdirde zaman tamamlanınca thread otomatik olarak çalışır
//         true); // thread 1'den fazla kez çalıştırılsın mı?
//
// RegisteredWaitHandle registeredWaitHandle2 =
//     ThreadPool.RegisterWaitForSingleObject(
//         autoResetEvent,
//         WorkerMethod,
//         "Task 2 wait handle",
//         1500, // sinyal gelmezse 1,5 sn sonra aktifleşir
//         true);
//
// Thread.Sleep(2000);
//
// autoResetEvent.Set();
//
// registeredWaitHandle.Unregister(autoResetEvent); // sistem kaynaklarını serbest bırakıyoruz
//
// Console.Read();
//
// void WorkerMethod(object state, bool timedOut)
// {
//     string jobName = (string)state;
//
//     Console.WriteLine($"{jobName} işi başladı");
//     Thread.Sleep(new Random().Next(1000, 3000));
//     Console.WriteLine($"{jobName} işi tamamlandı");
// }

#endregion  

#region WaitAll

// Hepsinden sinyal gelince aktifleşir

// AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
// AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
// ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
// ManualResetEvent manualResetEvent2 = new ManualResetEvent(false);
//
// WaitHandle.WaitAll
// (
// [autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2]
// );
//
// autoResetEvent1.Set();
// autoResetEvent2.Set();
// manualResetEvent1.Set();
// manualResetEvent2.Set();
//
// Console.WriteLine("Hello world!");
// Console.Read();

#endregion  

#region WaitAny

// Herhangi birinden sinyal gelince aktifleşir

// AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
// AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);
// ManualResetEvent manualResetEvent1 = new ManualResetEvent(false);
// ManualResetEvent manualResetEvent2 = new ManualResetEvent(false);
//
// WaitHandle.WaitAny
// (
// [autoResetEvent1, autoResetEvent2, manualResetEvent1, manualResetEvent2]
// );
//
// autoResetEvent1.Set();
// autoResetEvent2.Set();
// manualResetEvent1.Set();
// manualResetEvent2.Set();
//
// Console.WriteLine("Hello world!");
// Console.Read();

#endregion

#region SignalAndWait

// Önce ilk parametreye signal verilir ardından bu signal sayesinde ikinci parametreden signal beklenir.

AutoResetEvent autoResetEvent1 = new AutoResetEvent(false);
AutoResetEvent autoResetEvent2 = new AutoResetEvent(false);

WaitHandle.SignalAndWait
(
    autoResetEvent1, autoResetEvent2
);

autoResetEvent1.Set();
autoResetEvent2.Set();

Console.WriteLine("Hello world!");
Console.Read();

#endregion    