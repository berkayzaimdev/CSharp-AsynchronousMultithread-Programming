#region Interlocked Class

/*
int i = 0;

var prevalue = Interlocked.Exchange(ref i, 5); // (değişken, yeni değeri) => bir önceki değeri
Console.WriteLine(i);
Console.WriteLine(prevalue);

Interlocked.CompareExchange(ref i, 15, 0); // i'nin değeri, o anda 0 ise i=15 olur

Console.WriteLine(i);

Thread t1 = new Thread(() =>
{
    while (true)
    {
        Interlocked.Increment(ref i);
    }
});

Thread t2 = new Thread(() =>
{
    while (true)
    {
        Console.WriteLine(i);
    }
});

Thread t3 = new Thread(() =>
{
    while (true)
    {
        Interlocked.Decrement(ref i);
    }
});

t1.Start();
t2.Start();
t3.Start();
*/

#endregion

#region MemoryBarrier

var i = 0;

Thread t1 = new Thread(() =>
{
    while (true)
    {
        Interlocked.Increment(ref i);
        Thread.MemoryBarrier();
    }
});

Thread t2 = new Thread(() =>
{
    while (true)
    {
        Thread.MemoryBarrier();
        Console.WriteLine(i);
    }
});

t1.Start();
t2.Start();

#endregion