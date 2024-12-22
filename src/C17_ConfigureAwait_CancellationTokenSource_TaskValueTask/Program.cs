#region ConfigureAwait ⭐

// async Task<string> ReadFileAsync(string path)
// {
//     StreamReader streamReader = new StreamReader(path);
//
//     string content = await streamReader.ReadToEndAsync().ConfigureAwait(false); // asenkron işlemden sonra çalışacak olan kod, farklı bir context'te çalışabilir
//     string content2 = await streamReader.ReadToEndAsync().ConfigureAwait(true); // asenkron işlemden sonra çalışacak olan kod, aynı context'te çalışır
//     Console.WriteLine("end."); 
//     return content;
// }
//
// ReadFileAsync("...");

#endregion

#region CancellationTokenSource

// CancellationToken = başlamış bir asenkron işlemi iptal etmek için kullanılır (lamba)
// CancellationTokenSource = birden fazla CT barındırıyor olup, iptali tetiklemek için kullanılır (düğme)

// async Task DoWorkAsync(CancellationToken cancellationToken)
// {
//     for (int i = 0; i < 10; i++)
//     {
//         cancellationToken.ThrowIfCancellationRequested(); // iptal sinyali geldiyse hata fırlat
//         await Console.Out.WriteLineAsync($"{i}");
//         await Task.Delay(1000);
//     }
//
//     Console.WriteLine("Done");
// }
//
// CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
//
// Task.Run(async () =>
// {
//     await Task.Delay(3000);
//     await cancellationTokenSource.CancelAsync();
// });
//
// try
// {
//     await DoWorkAsync(cancellationTokenSource.Token);
// }
// catch (Exception e)
// {
//     Console.WriteLine(e);
//     throw;
// }
//
// await DoWorkAsync(cancellationTokenSource.Token);

#endregion

#region Task-ValueTask

/*
   Task
      * .NET asenkron programlamanın temel taşıdır ve genellikle uzun süren işlemleri veya I/O işlemlerini temsil etmektedir.
      * Bir class'tır ve bu doğrultuda heap'te saklanır ve GC tarafından yönetilir
      * Bundan dolayı kısa süren işlemler için bir heap tahsisi gerektirmesinden dolayı maliyetlidir.
 
   ValueTask
      * Kısa süreli veya düşük gecikme sürli işlemler için tasarlanmış bir struct'tır
      * Struct olması dolayısıyla stack'te saklanır ve daha az bellek tahsisi gerektirir.
*/

async ValueTask<int> Y()
{
   await Task.Delay(1000);
   return 10;
}

await Y();

#endregion