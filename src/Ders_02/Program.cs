class Program
{
    private static void Main(string[] args)
    {
        // Thread thread1 = new(ThreadMethod);
        Thread thread2 = new((o) => 
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Worker Thread -> {i}");
            }
        });

        thread2.Start(); // thread koşmaya başlar

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Main Thread -> {i}");
        }
    }

    static void ThreadMethod()
    {
        // ...
    }
}