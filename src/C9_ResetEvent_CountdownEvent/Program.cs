#region AutoResetEvent

// Bir thread'in belirli bir olayın gerçekleşmesini beklemesini sağlar.
// Olay gerçekleştiğinde otomatik olarak bekleyen thread'i yeniden işleme alır.

// Thread th1 = new(() =>
// {
//     Console.WriteLine("Thread 1");
//     autoResetEvent.Set(); // bekleyen thread e sinyal gönder. (hangi thread'e sinyal gönderileceğini işletim sistemi belirliyor)
//     // her seferinde set metodunu çağırmalıyız çünkü hangi thread'in çalışacağını bilemeyiz
// });
//
// Thread th2 = new(() =>
// {
//     autoResetEvent.WaitOne(); // bekle
//     Console.WriteLine("Thread 2");
// });
//
// Thread th3 = new(() =>
// {
//     autoResetEvent.WaitOne(); // bekle
//     Console.WriteLine("Thread 3");
// });
//
// th1.Start();
// th2.Start();
// th3.Start();


#endregion

#region ManualResetEvent

// Birden fazla thread'in belirli bir olayın gerçekleşmesini beklemesini sağlar.
// Manuel olarak sıfırlanabilir bir olay sinyali sağlar.

// var manualResetEvent = new ManualResetEventSlim(true); // sinyal verme konumu
// manualResetEvent = new ManualResetEventSlim(false); // sinyal bekleme konumu
//
// Thread th1 = new(() =>
// {
//     Console.WriteLine("Thread 1");
//     manualResetEvent.Set();
// });
//
// Thread th2 = new(() =>
// {
//     manualResetEvent.Wait(); // bekle
//     Console.WriteLine("Thread 2");
// });
//
// Thread th3 = new(() =>
// {
//     manualResetEvent.Wait(); // bekle
//     Console.WriteLine("Thread 3");
// });
//
// th1.Start();
// th2.Start();
// th3.Start();

#endregion

#region EventWaitHandle

// Manuel ya da Auto olarak davranış seçebildiğimiz resetevent sınıfı

// EventWaitHandle eventWaitHandle = new(true, EventResetMode.AutoReset);
//
// Thread th1 = new(() =>
// {
//     Console.WriteLine("Thread 1");
//     eventWaitHandle.Set(); 
// });
//
// Thread th2 = new(() =>
// {
//     eventWaitHandle.WaitOne();
//     Console.WriteLine("Thread 2");
// });
//
// Thread th3 = new(() =>
// {
//     eventWaitHandle.WaitOne();
//     Console.WriteLine("Thread 3");
// });
//
// th1.Start();
// th2.Start();
// th3.Start();

#endregion

#region CountdownEvent

// Belirli sayıda thread'in belirli bir olayın gerçekleşmesini beklemesini sağlar.

CountdownEvent countdownEvent = new(3); // int n => sinyal beklenen thread sayısı

Thread th1 = new(() =>
{
    Console.WriteLine("Thread 1");
    countdownEvent.Signal(); 
});

Thread th2 = new(() =>
{
    Console.WriteLine("Thread 2");
    countdownEvent.Signal();
});

Thread th3 = new(() =>
{
    Console.WriteLine("Thread 3");
    countdownEvent.Signal();
});

th1.Start();
th2.Start();
th3.Start();

countdownEvent.Wait(); // n thread'den sinyal gelene kadar bu satırda bekletilir
Console.WriteLine("Tüm thread'ler tamamlandı!");

#endregion