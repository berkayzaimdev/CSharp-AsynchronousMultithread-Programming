#region TaskFactory

#region ContinueWhenAny

// task'lar'dan herhangi biri tamamlandığında verilen metodu çalıştıran bir task oluşturur.

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task1: {i}");
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task2: {i}");
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task3: {i}");
//     }
// });
//
// TaskFactory taskFactory = new();
//
// taskFactory.ContinueWhenAny([task1, task2, task3], (tasks) =>
// {
//     Console.WriteLine("...");
// });
//
// Console.WriteLine("merhaba");
//
// Task.WaitAll(task1,task2,task3);

#endregion

#region ContinueWhenAll

// tüm task'lar tamamlandığında verilen metodu çalıştıran bir task oluşturur.

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task1: {i}");
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task2: {i}");
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 3; i++)
//     {
//         Console.WriteLine($"Task3: {i}");
//     }
// });
//
// TaskFactory taskFactory = new();
//
// taskFactory.ContinueWhenAll([task1, task2, task3], (tasks) =>
// {
//     Console.WriteLine("...");
// });
//
// Console.WriteLine("merhaba");
//
// Task.WaitAll(task1,task2,task3);

#endregion

#endregion

#region TaskScheduler

// Task instance'ların hangi Thread'te ya da işlemcide çalışacağını belirler.
// Task yöneticisi de diyebiliriz.
// Birden fazla thread arasında veya işlemcide iş yükünü organize etmek için kullanılır.
// Varsayılan olarak Task'ları .NET Thread Pool üzerinde çalıştırır

// var customTaskScheduler = new CustomTaskScheduler();
//
// Task.Factory.StartNew(() =>
// {
//     Console.WriteLine("Merhaba");
// }, CancellationToken.None, TaskCreationOptions.None, customTaskScheduler);
//
// class CustomTaskScheduler : TaskScheduler
// {
//     protected override IEnumerable<Task>? GetScheduledTasks() => null;
//
//     protected override void QueueTask(Task task) => ThreadPool.QueueUserWorkItem(_ =>
//     {
//         TryExecuteTask(task);
//     });
//
//     protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued) => true;
// }

#endregion

#region TaskCompletionSource

// task'ların dönüş tipi aksiyonunu manuel olarak yönetebilmemizi sağlayan sınıf

Task<int> Operation(ResultType resultType)
{
    TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
    
    switch (resultType)
    {
        case ResultType.Result:
            tcs.SetResult(42);
            break;
        case ResultType.Exception:
            tcs.SetException(new Exception("Hata!"));
            break;
        case ResultType.Cancelled:
            tcs.SetCanceled();
            break;
    }
    
    return tcs.Task;
}

Task<int> Operation2(ResultType resultType)
{
    TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
    
    switch (resultType)
    {
        case ResultType.Result:
            return Task.FromResult(42);
        case ResultType.Exception:
            return Task.FromException<int>(new Exception("Hata!"));
        case ResultType.Cancelled:
            return Task.FromCanceled<int>(new CancellationToken());
    }
    
    return tcs.Task;
}

Console.WriteLine(await Operation(ResultType.Result));
Console.WriteLine(Operation(ResultType.Cancelled).Status);
// Console.WriteLine(await Operation(ResultType.Exception));

Console.WriteLine(await Operation2(ResultType.Result));
Console.WriteLine(await Operation2(ResultType.Cancelled));
Console.WriteLine(await Operation2(ResultType.Exception));


enum ResultType
{
    Result,
    Exception,
    Cancelled
}

#endregion