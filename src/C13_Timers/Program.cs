#region Multi-Threaded Timers
// Single-Threaded Timer yapısına göre daha güçlü, hassas ve esnektirler.
// Periyodik görevleri otomatik olarak gerçekleştirmeye yarar

// Thread Pool'dan istifade ederler. Her yeni timer tanımlamasında timer'ın kullanması için thread pool'dan bir thread alınır.
// Hassasiyetleri 10 ile 20 ms aralığındadır. bu değer işletim sistemine bağlıdır.

#region System.Threading.Timer

// Timer timer = new(state =>
// {
//     Console.WriteLine(state);
// }, "Tick!", 1000, 100); // ctor = (callback func, callback object, gerisayım, periyot)
//
// timer.Change(500, 1500); // geri sayım ve periyotu değiştirmeye yarar
//   
// Timer timer2 = new(state =>
// {
//     Console.WriteLine(state);
// }, "Tick!", 1000, Timeout.Infinite); // sadece bir kez çalışması için infinite veriyoruz

#endregion

#region System.Timers.Timer

System.Timers.Timer timer = new();

timer.Elapsed += (sender, e) =>
{
    Console.WriteLine(DateTime.UtcNow);
};

timer.Interval = 1000;

timer.Start();

Thread.Sleep(5000);

timer.Stop();

#endregion

#endregion

#region Single-Threaded Timers

// Sadece kendi ortamlarında (WPF, Forms) çalışacak şekilde tasarlanmıştır.
// Tek bir thread tarafından kullanılırlar
// Yetmediği durumlarda multi-threaded timer yapısı kullanmak gerekebilir

#endregion