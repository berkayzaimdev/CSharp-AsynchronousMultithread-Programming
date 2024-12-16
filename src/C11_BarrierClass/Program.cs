// Bu araç ile bir grup thread'in belirli bir zamanda eşzamanlı olarak buluşması sağlanır.
// oyun mantığı ile checkpoint e kadar tek tek oyuncuların gelmesi, ardından yeni bölümün başlaması

Barrier barrier = new Barrier(3, _ => Console.WriteLine("all of the threads passed the checkpoint"));

Thread t1 = new Thread(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Thread 1.1 - {i}");
    }

    barrier.SignalAndWait();

    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Thread 1.2 - {i}");
    }
});

Thread t2 = new Thread(() =>
{
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($"Thread 2.1 - {i}");
    }

    barrier.SignalAndWait();

    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine($"Thread 2.2 - {i}");
    }
});

Thread t3 = new Thread(() =>
{
    for (int i = 0; i < 4; i++)
    {
        Console.WriteLine($"Thread 3.1 - {i}");
    }

    barrier.SignalAndWait();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Thread 3.2 - {i}");
    }
});

t1.Start();
t2.Start();
t3.Start();