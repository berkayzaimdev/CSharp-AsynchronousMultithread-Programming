#region Senkron

// IEnumerable<int> GetNumbers()
// {
//     for (int i = 0; i < 10; i++)
//     {
//         Thread.Sleep(1000);
//         yield return i;
//     }
// }
//
// foreach (var i in GetNumbers())
// {
//     Console.WriteLine(i);
// }

#endregion

#region Asenkron

// Büyük veri parçalarını işleme,
// Büyük veri okuma-yazma süreçleri,
// Web API ve uzak sunucu gibi kaynaklardan veri tüketme gibi durumlarda elverişli interface'lerdir.

async IAsyncEnumerable<int> GetNumbersAsync()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}

await foreach (var i in GetNumbersAsync())
{
    Console.WriteLine(i);
}

#endregion