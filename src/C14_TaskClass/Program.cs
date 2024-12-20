#region Task Sınıfı Oluşturma

#region new Task();

// klasik task oluşturma metodudur. başlatılan task koşmaz, start metodunun çağrılmasını bekler

// Task newTask = new Task(() =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         Console.WriteLine(i);
//     }
// });

// newTask.Start(); // başlatılması gerekir

#endregion

#region Task.Run();

// en pratik ve yaygın kullanıma sahip olan Task tanımlama yöntemidir.
// ThreadPool'dan bir thread alınır, ardından bu koşmakta olan thread üzerinde çalışan bir Task nesnesi elde edilir.

// Task taskRun = Task.Run(() =>
// {
//     for (int i = 10; i < 20; i++)
//     {
//         Console.WriteLine(i);
//     }
// });

#endregion

#region Task.Factory.StartNew();

// Task.Run kullanımından daha esnek ve gelişmiş bir yapı sunar. Daha özelleştirilebilir bir yöntemdir.
// Bu kullanım ile, alt task'lar da çalışır

// Task startNew = Task.Factory.StartNew(() =>
// {
//     for (int i = 20; i < 30; i++)
//     {
//         Console.WriteLine(i);
//     }
// });

#endregion

#endregion

#region Task Sınıfı Metotları

#region Start

// Task task = Task.Run(() =>
// {
//     Console.WriteLine("Started");
// });
//
// task.Start(); // zaten koşmakta olan bir task'ı startlamak exception fırlatacaktır

#endregion

#region Wait

// Task task = new Task(() =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         Console.WriteLine(i);
//     }
// });
// task.Start();
// task.Wait(); // Task sonlanana kadar bekler
// Console.WriteLine("Merhaba");

#endregion

#region ContinueWith

// task tamamlanmasının hemen ardından kuyrukta çalışmak üzere bekleyen bir metot oluştur

// int i = 0;
//
// Task task = Task.Run(() =>
// {
//     for (; i < 10; i++)
//     {
//         Console.WriteLine(i);
//     }
// });
//
// task.ContinueWith((_task) =>
// {
//     for (; i < 20; i++)
//     {
//         Console.WriteLine(i);
//     }
// });
//
// Console.WriteLine("Merhaba");

#endregion

#region WaitAll 

// Parametre olarak verilen TÜM task'lerın bitmesini bekler

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 100; i++)
//     {
//         Console.WriteLine("Task 1 => "+ i);
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 200; i++)
//     {
//         Console.WriteLine("Task 2 => "+ i);
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 300; i++)
//     {
//         Console.WriteLine("Task 3 => "+ i);
//     }
// });
//
// Task.WaitAll(task1, task2, task3); // params alır. senkron bekler

#endregion

#region WaitAny

// Parametre olarak verilen herhangi bir task'ın bitmesini bekler

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 100; i++)
//     {
//         Console.WriteLine("Task 1 => "+ i);
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 200; i++)
//     {
//         Console.WriteLine("Task 2 => "+ i);
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 300; i++)
//     {
//         Console.WriteLine("Task 3 => "+ i);
//     }
// });
//
// Task.WaitAny(task1, task2, task3); // params alır. senkron bekler
//
// Console.WriteLine("Merhaba");

#endregion

#region WhenAll

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 100; i++)
//     {
//         Console.WriteLine("Task 1 => "+ i);
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 200; i++)
//     {
//         Console.WriteLine("Task 2 => "+ i);
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 300; i++)
//     {
//         Console.WriteLine("Task 3 => "+ i);
//     }
// });
//
// Task.WhenAll(task1, task2, task3); // bu sefer farklı bir yaklaşım var. Burada bloklama gibi bir mantık yok çünkü bu süreç de asenkron işlemekte
// // await kullanmak bu bekleyişi senkronize eder.
// // merhaba kelimesi sonda yazılmaz bir önceki metoda kıyasla
//
// Console.WriteLine("Merhaba");

#endregion

#region WhenAny

// verilen herhangi bir task sonlandığında geriye bir task döndürür

// Task task1 = Task.Run(() =>
// {
//     for (int i = 0; i < 100; i++)
//     {
//         Console.WriteLine("Task 1 => "+ i);
//     }
// });
//
// Task task2 = Task.Run(() =>
// {
//     for (int i = 0; i < 200; i++)
//     {
//         Console.WriteLine("Task 2 => "+ i);
//     }
// });
//
// Task task3 = Task.Run(() =>
// {
//     for (int i = 0; i < 300; i++)
//     {
//         Console.WriteLine("Task 3 => "+ i);
//     }
// });
//
// Task.WhenAny(task1, task2, task3); // senkron bir bekleme söz konusu değil. merhaba herhangi bir yerde yazabilir
//
// Console.WriteLine("Merhaba");

#endregion

#region Delay ⭐

// Task syncDelay = Task.Run(() =>
// {
//     Console.WriteLine($"Sync Task: {DateTime.Now.ToString("hh:mm:ss")}");
//     
//     Task.Delay(-1); // sonsuz bekler fakat senkron bir şekilde bekler.
//     // bu senkron bekleyiş, kodsal anlamda sonraki kodları bloklamaz
//     
//     Console.WriteLine($"Sync Task: {DateTime.Now.ToString("hh:mm:ss")}");
// });
//
// syncDelay.Wait();
//
// Console.WriteLine("--------------");
//
// Task asyncDelay = Task.Run(async () =>
// {
//     Console.WriteLine($"Async Task: {DateTime.Now.ToString("hh:mm:ss")}");
//     
//     await Task.Delay(3000);
//     // fakat asenkron kullanım ile kod düzeyinde bir bloke sağlanır ve sonraki kodlara süre boyunca gidilemez.
//     
//     Console.WriteLine($"Async Task: {DateTime.Now.ToString("hh:mm:ss")}");
// });
//
// asyncDelay.Wait();

#endregion

#region FromCancelled

// Task task = Task.Run(() =>
// {
//     return Task.FromCanceled(new()); // başarısız bir task döndürür
// });

#endregion

#region FromException

// Task task = Task.Run(() =>
// {
//     return Task.FromException(new NullReferenceException("test")); // hata ile sonuçlanmış bir task döndürür
// });

#endregion

#region FromResult ⭐

// bir nesneyi task nesnesinde temsil etmek istiyorsak 
//
// Task<int> integerTask1 = Task.Run(() =>
// {
//     return 37;
// });
//
// Console.WriteLine(integerTask1.Result);
//
// Task<int> integerTask2 = Task.FromResult(5);
//
// Console.WriteLine(integerTask2.Result);

// task1 === task2

#endregion

#region Yield ⭐

// bir task'ı geçici olarak bekletmeyi ve diğer thread'lere vermeyi sağlar.
// task'ı asenkrona çevirir
// bu kısım biraz havada kaldı daha sonra bakılacak

// async Task X()
// {
//     await Task.Yield();
// };

#endregion

#region GetAwaiter

// Task<int> task1 = Task<int>.Run(() =>
// {
//     return 3;
// });
//
// Console.WriteLine(task1.Result); // .Result kullanımı bu asenkron parçacağı senkron hale getirerek bitmesini bekler. 
//
// Console.WriteLine("-----------");
//
//
//
// Task<int> task2 = Task<int>.Run(() =>
// {
//     return 3;
// });
//
// Console.WriteLine(task2.GetAwaiter().GetResult()); 
// daha elverişli, daha az maliyetli ve daha izlenebilir bir yaklaşım sunar.
// geriye bir task döndürür

#endregion

#endregion

#region Task Sınıfı Property'leri

#region CompletedTask

// Task X()
// {
//     //....
//     return Task.CompletedTask; //başarılı task
// }

#endregion

#region CurrentId

// Console.WriteLine(Task.CurrentId); //mainthread'in current id'si yoktur.
//
// Task task = Task.Run(() =>
// {
//     Console.WriteLine(Task.CurrentId); // o anda yürütülen Task'ın ID'si
// });

#endregion

#region Factory

// startnew de kullanırız

#endregion

#region IsCompleted

// task tamamlandı mı?

#endregion

#region IsCanceled

// task iptal edildi mi?

#endregion

#region AsyncState

// var mytask = Task.Factory.StartNew((i) =>
// {
//     var _i = (int)i;
//
//     for (int j = 0; j < _i; j++)
//     {
//         Console.WriteLine("Merhaba");
//     }
// }, 10);
//
// var state = mytask.AsyncState; // task'ın durumu (ikinci property)

#endregion

#region IsCompletedSuccessfully

// task başarılı olarak tamamlandı mı? (başarısız tasklar sayılmaz)

#endregion

#region Id

// Task'a ait ID'yi döndürür

#endregion

#region IsFaulted

// Task hata ile sonuçlandı mı?

#endregion

#region Status

Task task = Task.Run(async () =>
{
    for (int i = 0; i < 3; i++)
    {
        await Task.Delay(500);
    }
});

var status = task.Status;
var status2 = TaskStatus.WaitingForActivation;

while (true)
{
    if (status != status2)
    {
        Console.WriteLine(status);
        break;
    }
}

#endregion

#endregion