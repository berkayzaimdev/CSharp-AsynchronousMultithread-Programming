#region Semaphore

// C Programlama'daki semafor yapısına çok benziyor

//List<int> numbers = new();
//Semaphore semaphore = new(2, 2); // (izin verilen thread sayısı, sayaç değeri)

//Thread thread1 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 0;
//    while (i<10)
//    {
//        Console.WriteLine($"Thread 1: {++i}");
//        numbers.Add(i);
//        Thread.Sleep(100);
//    }
//    semaphore.Release();
//});

//Thread thread2 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 10;
//    while (i < 20)
//    {
//        Console.WriteLine($"Thread 2: {++i}");
//        numbers.Add(i);
//        Thread.Sleep(1500);
//    }
//    semaphore.Release();
//});

//Thread thread3 = new(() =>
//{
//    semaphore.WaitOne();
//    int i = 20;
//    while (i < 30)
//    {
//        Console.WriteLine($"Thread 3: {++i}");
//        numbers.Add(i);
//        Thread.Sleep(2000);
//    }
//    semaphore.Release();
//});
//thread1.Start();
//thread1.Start();
//thread3.Start();

#endregion

#region SemaphoreSlim

// Daha hızlı çalışan ve düşük bellek tüketimine sahip bir araçtır.
// Semafordan daha yenidir fakat daha sınırlı bir çalışma sergiler
// Semaforun aksine asenkron davranış da sergileyebilir. WaitAsync metodunu kullanabiliriz bu noktada
// Basit, az yoğunluk gerketiven ama optimizasyonun önemli olduğu işlemlerde tercih edilebilir

List<int> numbers = new();
SemaphoreSlim semaphore = new(2, 2); // (izin verilen thread sayısı, sayaç değeri)

Thread thread1 = new(() =>
{
    semaphore.Wait();
    int i = 0;
    while (i < 10)
    {
        Console.WriteLine($"Thread 1: {++i}");
        numbers.Add(i);
        Thread.Sleep(100);
    }
    semaphore.Release();
});

Thread thread2 = new(() =>
{
    semaphore.Wait();
    int i = 10;
    while (i < 20)
    {
        Console.WriteLine($"Thread 2: {++i}");
        numbers.Add(i);
        Thread.Sleep(1500);
    }
    semaphore.Release();
});

Thread thread3 = new(() =>
{
    semaphore.Wait();
    int i = 20;
    while (i < 30)
    {
        Console.WriteLine($"Thread 3: {++i}");
        numbers.Add(i);
        Thread.Sleep(2000);
    }
    semaphore.Release();
});
thread3.Start();
thread1.Start();
thread2.Start();

#endregion