using System.Collections.Concurrent;

#region ConcurrentBag<T>

// ConcurrentBag<int> numbers = new(); // asenkron süreçlerde, sırası önemli olmayan collection gereksinimi için kullanılır
//
// Task producer = Task.Run(async () =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         numbers.Add(i);
//         await Console.Out.WriteLineAsync($"P: {i.ToString()}");
//         await Task.Delay(500);
//     }
// });
//
// Task consumer = Task.Run(async () =>
// {
//     while (true)
//     {
//         if (numbers.TryTake(out int result)) // collection'da eleman var mı? varsa al
//         {
//             Console.WriteLine($"C: {result}");
//         }
//         else
//         {
//             await Task.Delay(500);
//         }
//     }
// });

// Task.WhenAny(producer, consumer);

#endregion

#region BlockingCollection<T>

// BlockingCollection<int> numbers = new(); // producer-consumer senaryosu için uygun olup, kapasite doluyken; bloklama, bekleme gibi fonksiyonları sağlar
//
// Task producer = Task.Run(async () =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         numbers.Add(i);
//         await Console.Out.WriteLineAsync($"P: {i.ToString()}");
//         await Task.Delay(500);
//     }
//     
//     numbers.CompleteAdding(); // döngü bittikten sonra artık eklemenin tamamlandığı sinyali verilir
// });
//
// Task consumer = Task.Run(async () =>
// {
//     while (true)
//     {
//         int result = numbers.Take(); // completeadding çağrıldıktan sonra artık bu metot hata fırlatacaktır
//         // take, eleman 0 ise hiçbir şey dönmez. bloklanma durumunda bekler
//         
//         Console.WriteLine($"C: {result}");
//     }
// });
//
// Task.WhenAll(producer, consumer);

#endregion

#region ConcurrentStack<T>

// ConcurrentStack<int> numbers = new(); // asenkron süreçler için tasarlanmış stack
//
// Task producer = Task.Run(async () =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         numbers.Push(i);
//         await Console.Out.WriteLineAsync($"P: {i.ToString()}");
//         await Task.Delay(500);
//     }
// });
//
// Task consumer = Task.Run(async () =>
// {
//     while (true)
//     {
//         if (numbers.TryPop(out int result))
//         {
//             Console.WriteLine($"C: {result}");
//         }
//         await Task.Delay(100);
//     }
// });
//
// Task.WhenAll(producer, consumer);

#endregion

#region ConcurrentQueue<T>

// ConcurrentQueue<int> numbers = new(); // asenkron süreçler için tasarlanmış queue
//
// Task producer = Task.Run(async () =>
// {
//     for (int i = 0; i < 10; i++)
//     {
//         numbers.Enqueue(i);
//         await Console.Out.WriteLineAsync($"P: {i.ToString()}");
//         await Task.Delay(500);
//     }
// });
//
// Task consumer = Task.Run(async () =>
// {
//     while (true)
//     {
//         if (numbers.TryDequeue(out int result))
//         {
//             Console.WriteLine($"C: {result}");
//         }
//         await Task.Delay(100);
//     }
// });
//
// await Task.WhenAll(producer, consumer);

#endregion

#region ConcurrentDictionary<TKey, TValue>

ConcurrentDictionary<int, int> numbers = new(); // asenkron süreçler için tasarlanmış dictionary

Task producer = Task.Run(async () =>
{
    for (int i = 0; i < 5; i++)
    {
        numbers[i] = i * i;
        await Console.Out.WriteLineAsync($"P: Dictionary[{i}] = {i*i}");
        await Task.Delay(500);
    }
});

Task consumer = Task.Run(async () =>
{
    await Task.Delay(3500);
    for (int i = 0; i < 5; i++)
    {
        if (numbers.TryGetValue(i, out int result))
        {
            await Console.Out.WriteLineAsync($"C: Dictionary[{i}] = {result}");
        }

        await Task.Delay(100);
    }
});

await Task.WhenAll(producer, consumer);

#endregion