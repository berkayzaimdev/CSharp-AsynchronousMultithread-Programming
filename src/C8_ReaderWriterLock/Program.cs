// Çok sayıda thread'in bir kaynağa aynı anda erişmeye çalıştığı senaryolarda kullanılmaktadır.
// Okuma ve Yazma için iki farklı davranışa sahip olan bir senkronizasyon yöntemidir;
    // Okuma işlemini thread'lerin birbirleriyle çakışmadan eşzamanlı olarak yapmalarını sağlar
    // Yazma işlemini ise aynı anda tek thread'in yapmasını sağlar.

// Okuma işlemlerinin daha sık olduğu senaryolarda tercih edilebilir

internal class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            new Thread(Read).Start();
        }

        for (int i = 0; i < 2; i++)
        {
            new Thread(Write).Start();            
        }
    }
    
    static ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim(); 
    static int c = 0;

    static void Read()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                readerWriterLock.EnterReadLock();
                Console.WriteLine($"R: Thread {Thread.CurrentThread.ManagedThreadId} is reading : {c}");
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
            Thread.Sleep(1000);
        }
    }
    
    static void Write()
    {
        try
        {
            readerWriterLock.EnterReadLock();
            for (int i = 0; i < 10; i++) // kritik bölge olduğu için aynı anda sadece 1 thread aksiyondadır
            {
                Console.WriteLine($"W: Thread {Thread.CurrentThread.ManagedThreadId} is writing : {++c}");
                Thread.Sleep(200);
            }
        }
        finally
        {
            readerWriterLock.ExitReadLock();
        }
    }
}
